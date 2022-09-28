using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Layout;
using System.Collections.Generic;
using MathNotationTool.ViewModels;

namespace MathNotationTool.Views
{
    public partial class CalculatorView : UserControl
    {
        public CalculatorView()
        {
            InitializeComponent();
            DataContext = new CalculatorViewModel();
            CalculatorStack = this.Find<StackPanel>("CalculatorStack");

            List<string> numpad = new() {
                "sin cos tan inv",
                "\u221A \u03C0 CE \u00F7",
                "7 8 9 \u0078",
                "4 5 6 -",
                "1 2 3 +",
                "+/- 0 . ="
            };

            foreach (var rowStr in numpad) {

                StackPanel row = new() {
                    Margin = new(0, 5, 0, 0),
                    Orientation = Orientation.Horizontal
                };
                foreach (var columnStr in rowStr.Split(' ')) {

                    Button btn = new() {
                        Content = columnStr,
                        FontFamily = new("Consolas"),
                        FontWeight = FontWeight.Medium,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        Height = 40,
                        Width = 75,
                        Focusable = false,
                        Margin = new(5, 0, 0, 0)
                    };

                    if (int.TryParse(columnStr, out int _) == true) {
                        btn.Opacity = 0.6;
                    }
                    else if (string.IsNullOrEmpty(columnStr)) {
                        btn.Opacity = 0.0;
                    }

                    row.Children.Add(btn);
                }

                CalculatorStack?.Children.Add(row);
            }
        }
    }
}
