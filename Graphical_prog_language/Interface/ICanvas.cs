namespace Graphical_prog_language.Interface
{
    public interface ICanvas
    {
        Point CurrentPosition { get; set; }
        TextBox CommandTextBox { get; }
        PictureBox PictureBox { get; }
        Pen DrawingPen { get; set; }
        Color FillColor { get; set; }
        bool IsFilling { get; set; }

    }
}