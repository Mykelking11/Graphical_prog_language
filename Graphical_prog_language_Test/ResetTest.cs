using Graphical_prog_language.Implementations.BasicCommands;
using Graphical_prog_language;
using System.Drawing;

namespace Graphical_prog_language_Tests
{
    [TestFixture]
    public class ResetTest
    {
        [Test]

        public void Execute_ResetsCanvasProperties()
        {
            // Arrange
            ResetCommand resetCommand = new ResetCommand();
            Canvas canvas = new Canvas();

            // Act
            resetCommand.Execute(canvas, new string[] { });

            // Assert
            Assert.AreEqual(new Point(400, 150), canvas.CurrentPosition);
            Assert.AreEqual(Color.Red, canvas.DrawingPen.Color);
            Assert.AreEqual(Color.Black, canvas.FillColor);

        }
    }
}