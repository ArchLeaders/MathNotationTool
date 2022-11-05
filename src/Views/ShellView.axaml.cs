using Avalonia;
using Avalonia.Controls;
using MathNotationTool.ViewModels;

namespace MathNotationTool.Views
{
    public partial class ShellView : Window
    {
        public ShellView()
        {
            InitializeComponent();
        }

        // Fix Win32 clipping issues
        protected override void HandleWindowStateChanged(WindowState state)
        {
            if (state == WindowState.Maximized) {
                Padding = new Thickness(5);
                ExtendClientAreaTitleBarHeightHint = 104;
                ShellContext.IsMaximized = true;
            }
            else {
                Padding = new Thickness(8);
                ExtendClientAreaTitleBarHeightHint = 90;
                ShellContext.IsMaximized = false;
            }

            base.HandleWindowStateChanged(state);
        }
    }
}
