using Avalonia;
using Avalonia.Controls;
using MathNotationTool.ViewModels;

namespace MathNotationTool.Views
{
    public partial class AppWindow : Window
    {
        public AppWindow()
        {
            InitializeComponent();
        }

        // Fix Win32 clipping issues
        protected override void HandleWindowStateChanged(WindowState state)
        {
            if (state == WindowState.Maximized) {
                Padding = new Thickness(5);
                ExtendClientAreaTitleBarHeightHint = 44;
                (DataContext as AppViewModel)!.IsMaximized = true;
            }
            else {
                Padding = new Thickness(8);
                ExtendClientAreaTitleBarHeightHint = 30;
                (DataContext as AppViewModel)!.IsMaximized = false;
            }

            base.HandleWindowStateChanged(state);
        }
    }
}
