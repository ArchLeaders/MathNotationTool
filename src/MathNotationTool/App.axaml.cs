global using ReactiveUI;
global using static MathNotationTool.App;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using MathNotationTool.ViewModels;
using MathNotationTool.Views;

namespace MathNotationTool
{
    public partial class App : Application
    {
        public static AppWindow View { get; private set; } = null!;
        public static AppViewModel ViewModel { get; private set; } = null!;

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {

                // Create desktop instance
                View = new();
                desktop.MainWindow = View;

                // Create data context
                ViewModel = new();
                View.DataContext = ViewModel;
            }
            else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform) {
                singleViewPlatform.MainView = new AppView {
                    DataContext = new AppViewModel()
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}