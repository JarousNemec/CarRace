namespace CarRace.Utils;

public static class GraphicsUtils
{
    public static Color[,] GetBitmapAsColor(Bitmap bitmap)
    {
        var width = bitmap.Width;
        var height = bitmap.Height;
        var pixels = new Color[width, height];
        for (var y = 0; y < height; y++)
        for (var x = 0; x < width; x++)
            pixels[x, y] = bitmap.GetPixel(x, y);
        return pixels;
    }

    public static bool IsSameColor(Color color1, Color color2)
    {
        return color1.A == color2.A && color1.R == color2.R && color1.G == color2.G && color1.B == color2.B;
    }
}