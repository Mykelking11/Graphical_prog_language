using Graphical_prog_language.Interface;

namespace Graphical_prog_language.Implementations.BasicCommands
{
    /// <summary>
    /// Represents a command to reset canvas settings.
    /// </summary>
    public class ResetCommand : IBasicCommand
    {
        public void Execute(Canvas canvas, string[] argument)
        {
            // Get command text box from the canvas
            TextBox commandTextBox = canvas.CommandTextBox;

            // Reset canvas properties
            canvas.CurrentPosition = new Point(400, 150);
            canvas.DrawingPen = new Pen(Color.Red);
            canvas.FillColor = Color.Black;

            
        }
    }
}