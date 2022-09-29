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

        private bool isMaximized = false;
        public bool IsMaximized {
            get => isMaximized;
            set => this.RaiseAndSetIfChanged(ref isMaximized, value);
        }

        public void ChangeTheme(string _)
        {
            Theme.Mode = Theme.Mode == FluentThemeMode.Dark ? FluentThemeMode.Light : FluentThemeMode.Dark;
            File.WriteAllText(ThemeFile, Theme.Mode.ToString());
        }
        public void ChangeState(string _) => View.WindowState = View.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        public void Minimize(string _) => View.WindowState = WindowState.Minimized;
        public void Close() => Environment.Exit(1);
    }
}
