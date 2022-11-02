using Avalonia.Controls;
using AvaloniaEdit.TextMate;
using AvaloniaEdit;
using AvaloniaEdit.TextMate.Grammars;
using Avalonia.Themes.Fluent;
using System;
using System.Diagnostics;

namespace MathNotationTool.Views
{
    public partial class AppView : UserControl
    {
        public AppView()
        {
            InitializeComponent();

            App.Theme.ObservableForProperty(x => x.Mode).Subscribe(x => InitTextEditor(x.Value));
            InitTextEditor(App.Theme.Mode);
        }

        public void InitTextEditor(FluentThemeMode theme)
        {
            RegistryOptions registryOptions = theme == FluentThemeMode.Dark ? new(ThemeName.DarkPlus) : new(ThemeName.LightPlus);
            TextMate.Installation textMateInstallation = editor.InstallTextMate(registryOptions);
            Language csharpLanguage = registryOptions.GetLanguageByExtension(".c");
            textMateInstallation.SetGrammar(registryOptions.GetScopeByLanguageId(csharpLanguage.Id));
        }
    }
}
