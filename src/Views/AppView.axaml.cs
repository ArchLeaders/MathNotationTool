using Avalonia.Controls;
using AvaloniaEdit.TextMate;
using AvaloniaEdit;
using Avalonia.Themes.Fluent;
using System;
using System.Diagnostics;
using TextMateSharp.Grammars;

namespace MathNotationTool.Views
{
    public partial class AppView : UserControl
    {
        public AppView()
        {
            InitializeComponent();

            App.Theme.ObservableForProperty(x => x.Mode).Subscribe(x => InitTextEditor(x.Value));
            InitTextEditor(App.Theme.Mode);

            Editor.Text = new(
                "//\n" +
                "// Math Notation Here!\n\n" +
                "// Normal math functions\n" +
                "var value = 15 + 45 * 34;\n\n" +
                "// Reference an equation in the history panel\n" +
                "var reference = Query(1);\n\n" +
                "// Return the final solution\n" +
                "return value + reference;"
            );
        }

        public void InitTextEditor(FluentThemeMode theme)
        {
            RegistryOptions registryOptions = theme == FluentThemeMode.Dark ? new(ThemeName.DarkPlus) : new(ThemeName.LightPlus);
            TextMate.Installation textMateInstallation = Editor.InstallTextMate(registryOptions);
            Language csharpLanguage = registryOptions.GetLanguageByExtension(".cs");
            textMateInstallation.SetGrammar(registryOptions.GetScopeByLanguageId(csharpLanguage.Id));
        }
    }
}
