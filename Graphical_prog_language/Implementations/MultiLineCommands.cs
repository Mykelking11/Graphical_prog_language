﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphical_prog_language.Implementations
{
    public class MultiLineCommands
    {
        private Canvas canvas;

        /// <summary>
        /// Initializes a new instance of the MultiLineCommands class with the specified canvas.
        /// </summary>
        /// <param name="canvas">The canvas on which the commands will be executed.</param>
        public MultiLineCommands(Canvas canvas)
        {
            this.canvas = canvas;
        }


        /// <summary>
        /// Executes a series of commands provided in the script content.
        /// </summary>
        /// <param name="scriptContent">The content of the script containing commands.</param>
        public void ExecuteCommands(string scriptContent)
        {
            // Split the script content into lines
            string[] lines = scriptContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            // Dictionary to store variables
            var variables = new Dictionary<string, int>();

            // Initialize current line to 0
            int currentLine = 0;

            // Loop through each line of the script
            while (currentLine < lines.Length)
            {
                string line = lines[currentLine].Trim();

                // Check if the line represents a variable assignment
                if (IsVariableAssignment(line))
                {
                    ProcessVariableAssignment(line, variables);
                    currentLine++;
                    continue;
                }

                if (line.Trim().StartsWith("while", StringComparison.OrdinalIgnoreCase))
                {
                    currentLine = ExecuteWhileLoop(lines, currentLine, variables);
                    continue;
                }

                if (line.StartsWith("If"))
                {
                    currentLine = ExecuteIfStatement(lines, currentLine, variables);
                    continue;
                }

                if (line.Trim().Equals("endif", StringComparison.OrdinalIgnoreCase))
                {
                    // Do nothing; Endif is handled within ExecuteIfStatement
                    currentLine++;
                    continue;
                }

                // Check if the line represents a recognized command
                if (IsRecognizedCommand(line))
                {
                    // Substitute variable values into the command
                    line = SubstituteVariableValues(line, variables);

                    // Invoke the command on the canvas
                    canvas.Invoke((MethodInvoker)delegate
                    {
                        CommandParser parser = new CommandParser(line);
                        canvas.ShapeMaker.ExecuteDrawing(parser);
                    });
                }
                currentLine++;
            }
        }




        /// <summary>
        /// Checks if the given line represents a variable assignment.
        /// </summary>
        /// <param name="line">The line to check.</param>
        /// <returns>True if the line contains an assignment operator ("="); otherwise, false.</returns>
        private bool IsVariableAssignment(string line)
        {
            // Check if the line contains an assignment operator "="
            return line.Contains("=");
        }




        private void ProcessVariableAssignment(string line, Dictionary<string, int> variables)
        {
            string[] parts = line.Split('=');
            if (parts.Length == 2)
            {
                string variableName = parts[0].Trim();
                string value = parts[1].Trim();

                if (value.EndsWith("++"))
                {
                    value = value.TrimEnd('+');
                    if (variables.TryGetValue(value, out int previousValue))
                    {
                        variables[variableName] = previousValue + 1;
                    }
                    else
                    {
                        MessageBox.Show($"Variable '{value}' not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (value.Contains("+") || value.Contains("-") || value.Contains("*") || value.Contains("/"))
                {
                    // Perform arithmetic operation
                    int result = EvaluateArithmeticOperation(value, variables);
                    if (result != int.MinValue)
                    {
                        variables[variableName] = result;
                    }
                    else
                    {
                        MessageBox.Show($"Error evaluating arithmetic expression: {value}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (int.TryParse(value, out int numericValue))
                {
                    variables[variableName] = numericValue;
                }
                else if (variables.TryGetValue(value, out int variableValue))
                {
                    variables[variableName] = variableValue;
                }
                else
                {
                    MessageBox.Show($"Invalid assignment: {line}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"Invalid assignment: {line}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Executes the "While" loop and its nested commands while the condition is true.
        /// </summary>
        /// <param name="lines">The array of lines containing the source code.</param>
        /// <param name="startLine">The line number at which the "While" loop starts.</param>
        /// <param name="variables">The dictionary of variables used in evaluation.</param>
        /// <returns>The line number after the "Endloop" statement.</returns>
        private int ExecuteWhileLoop(string[] lines, int startLine, Dictionary<string, int> variables)
        {
            // Extract the condition from the "While" loop
            string condition = lines[startLine].Substring(6); // Assuming "While " is 6 characters

            // Find the line number of the corresponding "Endloop" statement
            int endLoopLine = FindEndLoopLine(lines, startLine);

            // Initialize current line to start of loop
            int currentLine = startLine + 1;

            // Continue looping while the condition is true
            while (EvaluateCondition(condition, variables))
            {
                // Execute nested commands within the loop
                while (currentLine < endLoopLine)
                {
                    string loopLine = lines[currentLine].Trim();

                    // Substitute variable values into the command
                    loopLine = SubstituteVariableValues(loopLine, variables);

                    if (IsRecognizedCommand(loopLine))
                    {
                        // Ensure that UI updates are done on the UI thread
                        canvas.Invoke((MethodInvoker)delegate
                        {
                            CommandParser parser = new CommandParser(loopLine);
                            canvas.ShapeMaker.ExecuteDrawing(parser);
                        });
                    }
                    else if (IsVariableAssignment(loopLine))
                    {
                        // Process variable assignments immediately in the current thread
                        ProcessVariableAssignment(loopLine, variables);
                    }
                    currentLine++;
                }

                // Reset currentLine to start of loop for next iteration
                currentLine = startLine + 1;

                // Update the condition with the latest variable values
                condition = lines[startLine].Substring(6).Trim();
                condition = SubstituteVariableValues(condition, variables);
            }

            // Return the line number after the "Endloop" statement
            return endLoopLine + 1;
        }



        private int EvaluateArithmeticOperation(string expression, Dictionary<string, int> variables)
        {
            try
            {
                DataTable dt = new DataTable();
                var result = dt.Compute(expression, "");
                return Convert.ToInt32(result);
            }
            catch (Exception)
            {
                return int.MinValue;
            }
        }


        private int FindEndLoopLine(string[] lines, int startLine)
        {
            for (int i = startLine + 1; i < lines.Length; i++)
            {
                if (lines[i].Trim().Equals("endloop", StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }
            MessageBox.Show("Endloop not found for the while loop starting at line " + startLine, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return -1; // Return an invalid line number
        }

        /// <summary>
        /// Executes the "If" statement and its nested commands if the condition is true.
        /// </summary>
        /// <param name="lines">The array of lines containing the source code.</param>
        /// <param name="startLine">The line number at which the "If" statement starts.</param>
        /// <param name="variables">The dictionary of variables used in evaluation.</param>
        /// <returns>The line number after the "Endif" statement.</returns>
        private int ExecuteIfStatement(string[] lines, int startLine, Dictionary<string, int> variables)
        {
            // Extract the condition from the "If" statement
            string condition = lines[startLine].Substring(3).Trim(); // Assuming "If " is 3 characters

            // Find the line number of the corresponding "Endif" statement
            int endIfLine = FindEndIfLine(lines, startLine);

            // Evaluate the condition
            if (EvaluateCondition(condition, variables))
            {
                // If the condition is true, execute the nested commands
                int currentLine = startLine + 1;
                while (currentLine < endIfLine)
                {
                    string ifLine = lines[currentLine].Trim();

                    // Substitute variable values into the command
                    ifLine = SubstituteVariableValues(ifLine, variables);

                    if (IsRecognizedCommand(ifLine))
                    {
                        // Invoke the command on the canvas
                        canvas.Invoke((MethodInvoker)delegate
                        {
                            CommandParser parser = new CommandParser(ifLine);
                            canvas.ShapeMaker.ExecuteDrawing(parser);
                        });
                    }
                    currentLine++;
                }
            }

            // Return the line number after the "Endif" statement
            return endIfLine + 1;
        }






        /// <summary>
        /// Finds the line number of the "Endif" statement that corresponds to the "If" statement starting at the specified line.
        /// </summary>
        /// <param name="lines">The array of lines containing the source code.</param>
        /// <param name="startLine">The line number at which the "If" statement starts.</param>
        /// <returns>The line number of the corresponding "Endif" statement, or -1 if not found.</returns>
        private int FindEndIfLine(string[] lines, int startLine)
        {
            // Iterate through the lines after the start line
            for (int i = startLine + 1; i < lines.Length; i++)
            {
                // Check if the current line is the "Endif" statement
                if (lines[i].Trim().Equals("endif", StringComparison.OrdinalIgnoreCase))
                {
                    // Return the line number of the "Endif" statement
                    return i;
                }
            }

            // If the "Endif" statement is not found, show an error message
            MessageBox.Show("Endif not found for the if statement starting at line " + startLine, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Return an invalid line number
            return -1;
        }



        /// <summary>
        /// Evaluates the given condition using the provided variables.
        /// </summary>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="variables">The dictionary of variables to use in evaluation.</param>
        /// <returns>True if the condition is true; otherwise, false.</returns>
        private bool EvaluateCondition(string condition, Dictionary<string, int> variables)
        {
            string[] parts;
            if (condition.Contains("!="))
            {
                parts = condition.Split(new[] { '!', '=' }, StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                parts = condition.Split(new[] { '<', '>', '=' }, StringSplitOptions.RemoveEmptyEntries);
            }

            if (parts.Length == 2)
            {
                string variableName = parts[0].Trim();
                string valuePart = parts[1].Trim();

                if (variables.TryGetValue(variableName, out int variableValue))
                {
                    if (int.TryParse(valuePart, out int conditionValue))
                    {
                        if (condition.Contains("<"))
                        {
                            return variableValue < conditionValue;
                        }
                        else if (condition.Contains(">"))
                        {
                            return variableValue > conditionValue;
                        }
                        else if (condition.Contains("="))
                        {
                            return variableValue == conditionValue;
                        }
                        else if (condition.Contains("!="))
                        {
                            return variableValue != conditionValue;
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Invalid number format in condition: {valuePart}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"Variable '{variableName}' is not defined.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"Invalid condition format: {condition}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }


        /// <summary>
        /// Checks if the given line represents a recognized command.
        /// </summary>
        /// <param name="line">The line containing the command.</param>
        /// <returns>True if the command is recognized; otherwise, false.</returns>
        private bool IsRecognizedCommand(string line)
        {
            // Split the line to extract the command
            string command = line.Split(' ')[0].ToLower();

            // List of recognized commands
            var recognizedCommands = new HashSet<string> { "moveto", "drawto", "fill", "reset", "clear", "pen", "rectangle", "circle", "triangle" };

            // Check if the command is recognized
            return recognizedCommands.Contains(command);
        }


        private string SubstituteVariableValues(string line, Dictionary<string, int> variables)
        {
            // Split the line into tokens
            string[] tokens = line.Split(' ');

            // Iterate through tokens to check for variables
            for (int i = 1; i < tokens.Length; i++) // Start from index 1 to skip the command
            {
                if (variables.ContainsKey(tokens[i])) // Check if the token is a variable
                {
                    // Replace the variable with its value
                    tokens[i] = variables[tokens[i]].ToString();
                }
            }

            // Reconstruct the line with substituted variable values
            return string.Join(" ", tokens);
        }

    }
}
