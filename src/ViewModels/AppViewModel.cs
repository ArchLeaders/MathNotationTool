using Avalonia.Controls;
using Avalonia.Themes.Fluent;
using AvaloniaGenerics.Dialogs;
using MathNotationTool.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathNotationTool.ViewModels
{
    public class AppViewModel : ReactiveObject
    {
        private CalculatorView calculator = new();
        public CalculatorView Calculator {
            get => calculator;
            set => this.RaiseAndSetIfChanged(ref calculator, value);
        }

        // 
        // Context Menu

        public void SelectAll() => View.Editor.SelectAll();

        public void Copy() => View.Editor.Copy();

        public void Cut() => View.Editor.Cut();

        public void Paste() => View.Editor.Paste();

        public async void Export()
        {
            var result = await BrowserDialog.SaveFile.ShowDialog();
            if (result != null) {
                File.WriteAllText(result, View.Editor.Text);
            }
        }
    }
}
