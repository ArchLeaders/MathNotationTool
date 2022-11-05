using Avalonia.Controls;
using Avalonia.Themes.Fluent;
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
        private string version = "Math Notation Tool - v0.0.4-alpha"; // Use compile time keys for version?
        public string Version {
            get => version;
            set => this.RaiseAndSetIfChanged(ref version, value);
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
        public void ChangeState(string _) => View.WindowState = View.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        public void Minimize(string _) => View.WindowState = WindowState.Minimized;
        public void Close() => Environment.Exit(1);
    }
}
