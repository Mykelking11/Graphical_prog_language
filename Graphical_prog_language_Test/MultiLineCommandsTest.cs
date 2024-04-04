using NUnit.Framework;
using Graphical_prog_language.Implementations;
using Moq;
using System.Drawing;
using System.Windows.Forms;
using Graphical_prog_language;

namespace Graphical_prog_language_Tests
{
    [TestFixture]
    public class MultiLineCommandsTests
    {
        private Canvas canvas;
        private MultiLineCommands multiLineCommands;

        [SetUp]
        public void SetUp()
        {
            canvas = new Canvas();
            multiLineCommands = new MultiLineCommands(canvas);
        }

        [Test]
        public void ExecuteCommands_ValidScriptContent_DrawsShapes()
        {
            // Arrange
            string scriptContent = "circle 10\nrectangle 20 30";

            // Mock the canvas ShapeMaker
            var mockShapeMaker = new Mock<ShapeMaker>();
            canvas.ShapeMaker = mockShapeMaker.Object;

            // Act
            multiLineCommands.ExecuteCommands(scriptContent);

            // Assert
            mockShapeMaker.Verify(sm => sm.ExecuteDrawing(It.IsAny<CommandParser>()), Times.Exactly(2));
        }

        [Test]
        public void ExecuteCommands_InvalidScriptContent_NoShapesDrawn()
        {
            // Arrange
            string invalidScriptContent = "invalidCommand";

            // Mock the canvas ShapeMaker
            var mockShapeMaker = new Mock<ShapeMaker>();
            canvas.ShapeMaker = mockShapeMaker.Object;

            // Act
            multiLineCommands.ExecuteCommands(invalidScriptContent);

            // Assert
            mockShapeMaker.Verify(sm => sm.ExecuteDrawing(It.IsAny<CommandParser>()), Times.Never());
        }

    }
}