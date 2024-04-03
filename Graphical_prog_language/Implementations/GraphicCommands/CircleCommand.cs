using Graphical_prog_language;
using Graphical_prog_language.Interface;

namespace Graphical_prog_language.Implementations.GraphicCommands
{
    /// <summary>
    /// Represents a command to draw a circle on the canvas.
    /// </summary>
    public class CircleCommand : IGraphicsCommand
    {
        /// <inheritdoc/>
        public void Execute(Graphics graphics, string[] argument, ICanvas canvas)
        {
            // Get current position, drawing pen, and command text box from the canvas
            Point currentPosition = canvas.CurrentPosition;
            Pen drawingPen = canvas.DrawingPen;
            TextBox commandTextBox = canvas.CommandTextBox;

            // Check if a valid radius is provided as an argument
            if (argument.Length == 1 && int.TryParse(argument[0], out int radius))
            {
                // Calculate coordinates for the bounding rectangle of the circle
                int x = currentPosition.X - radius;
                int y = currentPosition.Y - radius;

                // Draw or fill the circle based on canvas settings
                if (canvas.IsFilling)
                {
                    // Fill the circle
                    SolidBrush brush = new SolidBrush(canvas.FillColor);
                    graphics.FillEllipse(brush, x, y, 2 * radius, 2 * radius);
                }
                else
                {
                    // Draw the circle
                    graphics.DrawEllipse(drawingPen, x, y, 2 * radius, 2 * radius);
                }

             
            }
            else
            {
                // Show error message for invalid arguments
                MessageBox.Show("Invalid arguments for 'circle' command. Kindly provide a valid radius.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}