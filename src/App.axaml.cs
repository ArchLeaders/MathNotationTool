global using ReactiveUI;
global using static MathNotationTool.App;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MathNotationTool.ViewModels;
using MathNotationTool.Views;
using Avalonia.Themes.Fluent;
using System;
using System.IO;

namespace MathNotationTool
{
    public partial class App : Application
    {
        internal static readonly string ThemeFile = $"{Environment.GetEnvironmentVariable("LOCALAPPDATA")}\\MathNotationTool.theme";

        public static AppWindow View { get; private set; } = null!;
        public static AppViewModel ViewModel { get; private set; } = null!;
        public static FluentTheme Theme { get; set; } = new(new Uri("avares://BotwAvaloniaTemplate/Styles"));

        public override void Initialize() => AvaloniaXamlLoader.Load(this);

        public override void OnFrameworkInitializationCompleted()
        {
            if (!File.Exists(ThemeFile)) {
                File.WriteAllText(ThemeFile, "Dark");
            }

            Theme.Mode = File.ReadAllText(ThemeFile) == "Dark" ? FluentThemeMode.Dark : FluentThemeMode.Light;
            Current!.Styles[0] = Theme;

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {

                // Create desktop instance
                View = new();
                desktop.MainWindow = View;

                // Create data context
                ViewModel = new();
                View.DataContext = ViewModel;
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
