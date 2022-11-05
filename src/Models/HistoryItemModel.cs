﻿using AngouriMath;
using Avalonia;
using Avalonia.Controls;
using MathNotationTool.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathNotationTool.Models
{
    public class HistoryItemModel : ReactiveObject
    {
        private string name = null!;
        public string Name {
            get => name;
            set => this.RaiseAndSetIfChanged(ref name, value);
        }

        private string evaluatedStr = null!;
        public string EvaluatedStr {
            get => evaluatedStr;
            set => this.RaiseAndSetIfChanged(ref evaluatedStr, value);
        }

        private decimal value = 0.0M;
        public decimal Value {
            get => value;
            set => this.RaiseAndSetIfChanged(ref this.value, value);
        }

        private string srcEquationStr = null!;
        public string SrcEquationStr {
            get => srcEquationStr;
            set => this.RaiseAndSetIfChanged(ref srcEquationStr, value);
        }

        private Entity srcEquation = null!;
        public Entity SrcEquation {
            get => srcEquation;
            set => this.RaiseAndSetIfChanged(ref srcEquation, value);
        }

        public async void Copy() => await(Application.Current?.Clipboard?.SetTextAsync(SrcEquationStr) ?? Task.CompletedTask);
        public async void CopyId() => await(Application.Current?.Clipboard?.SetTextAsync(Name) ?? Task.CompletedTask);
        public async void CopySolution() => await(Application.Current?.Clipboard?.SetTextAsync($"{Value:0.00}") ?? Task.CompletedTask);
        public void Remove() => ViewModel.Calculator.ViewModel.History.Remove(this);
        public void Clear() => ViewModel.Calculator.ViewModel.History.Clear();

        public HistoryItemModel(string equationStr)
        {
            string eq = equationStr.GetSafe();
            Name = $"{ViewModel.Calculator.ViewModel.History.Count + 1}";
            SrcEquation = eq;
            SrcEquationStr = eq;
            Value = (decimal)SrcEquation.EvalNumerical();
            EvaluatedStr = $"{equationStr} = {value:0.00}";
        }

        public HistoryItemModel(string name, string equationStr, decimal value)
        {
            Name = name;
            SrcEquation = equationStr.GetSafe();
            SrcEquationStr = equationStr.GetSafe();
            Value = value;
            EvaluatedStr = $"{equationStr} = {value:0.00}";
        }
    }
}
