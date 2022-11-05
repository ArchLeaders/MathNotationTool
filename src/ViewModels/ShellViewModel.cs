#pragma warning disable CA1822 // Mark members as static

using Avalonia.Controls;
using Avalonia.Themes.Fluent;
using AvaloniaGenerics.Dialogs;
using Material.Icons;
using MathNotationTool.Extensions;
using MathNotationTool.Views;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathNotationTool.ViewModels
{
    public class ShellViewModel : ReactiveObject
    {
        private AppView content = null!;
        public AppView Content {
            get => content;
            set => this.RaiseAndSetIfChanged(ref content, value);
        }

        private string? project;
        public string? Project {
            get => project;
            set => this.RaiseAndSetIfChanged(ref project, value);
        }

        //
        // Window stuff

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

        public async void Execute()
        {
            try {
                object result = await CSharpScript.EvaluateAsync(View.Editor.Text, RosylnDefaults);
                await MessageBox.Show(result.ToString() ?? "No Results", "Results");
            }
            catch (Exception ex) {
                await MessageBox.Show(ex.Message, "Error", formatting: Formatting.Markdown, icon: MaterialIconKind.ErrorOutline);
            }
        }

        public async void CreateProject()
        {
            var result = await MessageBox.Show("Any unsaved changes will be lost?\n\nAre you sure you wish to continue?", "Warning", MessageBoxButtons.YesNoCancel, Formatting.Markdown);
            if (result == MessageBoxResult.Yes) {
                ViewModel.Calculator.ViewModel.History.Clear();
                View.Editor.Text = "//\n// Math Notation Tool - (c) Arch Leaders\n\n";
            }
        }

        public async void SaveProject()
        {
            Project ??= await BrowserDialog.SaveFile.ShowDialog();
            if (Project != null) {

                using FileStream fs = File.Create(Project);
                using BinaryWriter writer = new(fs);

                // Make room for the header
                writer.Write("MNTP".AsSpan());

                // Write history count
                var history = ViewModel.Calculator.ViewModel.History;
                writer.Write((uint)history.Count);

                foreach (var item in history) {
                    writer.Write(item.Id);
                    writer.Write(item.SrcEquationStr);
                    writer.Write(item.Value);
                }

                writer.Write(View.Editor.Text);

                writer.Flush();
                writer.Dispose();
            }
        }

        public async void OpenProject()
        {
            try {
                var result = await BrowserDialog.File.ShowDialog();
                if (result != null) {

                    Project = result;

                    using FileStream fs = File.OpenRead(Project);
                    using BinaryReader reader = new(fs);

                    // Check file header
                    if (new string(reader.ReadChars(4)) != "MNTP") {
                        throw new InvalidDataException($"Invalid project header in '{result}', please choose a valid project file.");
                    }

                    // Read history items
                    ViewModel.Calculator.ViewModel.History.Clear();
                    uint count = reader.ReadUInt32();
                    for (int i = 0; i < count; i++) {
                        int id = reader.ReadInt32();
                        string eq = reader.ReadString();
                        decimal value = reader.ReadDecimal();

                        ViewModel.Calculator.ViewModel.History.Add(new(id, eq, value));
                        if (id > ViewModel.Calculator.ViewModel.LastId) {
                            ViewModel.Calculator.ViewModel.LastId = id;
                        }
                    }

                    // Read editor text
                    View.Editor.Text = reader.ReadString();
                }
            }
            catch (Exception ex) {
                await MessageBox.Show($"Could not open project file *'{Project}'*\n{ex.Message}", "Error", formatting: Formatting.Markdown, icon: MaterialIconKind.ErrorOutline);
            }
        }

        public void ChangeTheme()
        {
            Theme.Mode = Theme.Mode == FluentThemeMode.Dark ? FluentThemeMode.Light : FluentThemeMode.Dark;
            File.WriteAllText(ThemeFile, Theme.Mode.ToString());
        }
        public void ChangeState() => Shell.WindowState = Shell.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        public void Minimize() => Shell.WindowState = WindowState.Minimized;
        public void Close() => Environment.Exit(1);

        public ShellViewModel(AppView content)
        {
            Content = content;
        }
    }
}
