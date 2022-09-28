using Avalonia.Controls;
using System;

namespace MathNotationTool.ViewModels
{
    public class AppViewModel : ReactiveObject
    {
        private bool isMaximized = false;
        public bool IsMaximized {
            get => isMaximized;
            set => this.RaiseAndSetIfChanged(ref isMaximized, value);
        }

        public void ChangeState(string _) => View.WindowState = View.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        public void Minimize(string _) => View.WindowState = WindowState.Minimized;
        public void Close() => Environment.Exit(1);
    }
}
