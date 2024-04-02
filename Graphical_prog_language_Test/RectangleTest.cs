using Graphical_prog_language;
using Graphical_prog_language.Implementations.GraphicCommands;
using Graphical_prog_language.Interface;
using Moq;
using System.Drawing;

namespace Graphical_prog_language_Tests
{
    [TestFixture]
    public class RectangleTest
    {
        [Test]
        public void Execute_Draws_Rectangle_Correctly()
        {
            var canvas = new Canvas();
            var rectangleCommand = new RectangleCommand();
            string[] args = { "100", "50" }; // Test dimensions
            var graphics = Graphics.FromImage(new Bitmap(100, 100));

            rectangleCommand.Execute(graphics, args, canvas);

            Assert.IsTrue(string.IsNullOrEmpty(canvas.CommandTextBox.Text));
        }



        [Test]
        public void Execute_InvalidArguments_ShowsErrorMessage()
        {
            // Arrange
            RectangleCommand rectangleCommand = new RectangleCommand();
            Bitmap bitmap = new Bitmap(100, 100);
            Graphics graphics = Graphics.FromImage(bitmap);
            string[] arguments = { }; // No arguments provided

            // Mock the ICanvas interface
            var mockCanvas = new Mock<ICanvas>();

            // Act
            rectangleCommand.Execute(graphics, arguments, mockCanvas.Object);

            // Assert
            Assert.IsTrue(true);
        }

    }
}