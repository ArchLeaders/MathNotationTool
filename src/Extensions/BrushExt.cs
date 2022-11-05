using Avalonia.Media;
using System;

namespace MathNotationTool.Extensions
{
    public static class BrushExt
    {
        public static Brush ToBrush(this string color) => new SolidColorBrush(Convert.ToUInt32(color, 16));
        public static Brush ToBrush(this uint color) => new SolidColorBrush(color);
    }
}
