using System.Windows.Media;

public class MyColor {
    public Color Color { get; set; }
    public string Name { get; set; }

    public override string ToString() {
        return Name ?? $"R:{Color.R} G:{Color.G} B:{Color.B}";
    }
}
