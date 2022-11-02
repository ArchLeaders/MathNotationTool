using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Layout;
using System.Collections.Generic;
using MathNotationTool.ViewModels;
using Avalonia.Controls.Primitives;
using System.Reflection;

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
                "!√ π CE ←",
                "!sin !cos !tan ÷",
                "7 8 9 x",
                "4 5 6 -",
                "1 2 3 +",
                "!(/) 0 . ="
            };

            foreach (var rowStr in numpad) {

                StackPanel row = new() {
                    Margin = new(0, 5, 0, 0),
                    Orientation = Orientation.Horizontal
                };
                foreach (var columnStr in rowStr.Split(' ')) {

                    MethodInfo click = DataContext.GetType().GetMethod($"Function_{columnStr.Replace("=", "Equals").Replace("←", "Backspace")}") ?? DataContext.GetType().GetMethod($"Function_Generic")!;
                    Button btn;

                    if (columnStr.StartsWith('!')) {

                        var columnText = columnStr.Remove(0, 1);
                        click = DataContext.GetType().GetMethod($"Function_Boolean")!;
                        btn = new ToggleButton() {
                            Content = columnText,
                            FontFamily = new("Consolas"),
                            FontWeight = FontWeight.Medium,
                            FontSize = 16,
                            VerticalContentAlignment = VerticalAlignment.Center,
                            HorizontalContentAlignment = HorizontalAlignment.Center,
                            Height = 40,
                            Width = 75,
                            Focusable = false,
                            Margin = new(5, 0, 0, 0),
                        };

                        btn.Command = ReactiveCommand.Create(() => click.Invoke(DataContext, new object[] { $"{columnText}|{((ToggleButton)btn).IsChecked}" }));
                    }
                    else {
                        btn = new() {
                            Content = columnStr,
                            FontFamily = new("Consolas"),
                            FontWeight = FontWeight.Medium,
                            FontSize = 16,
                            VerticalContentAlignment = VerticalAlignment.Center,
                            HorizontalContentAlignment = HorizontalAlignment.Center,
                            Height = 40,
                            Width = 75,
                            Focusable = false,
                            Margin = new(5, 0, 0, 0),
                            Command = ReactiveCommand.Create(() => click.Invoke(DataContext, new object[] { $"{columnStr}|null" }))
                        };
                    }

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
