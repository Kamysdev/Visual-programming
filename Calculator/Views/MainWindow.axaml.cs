using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace Calculator.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.SystemDecorations = SystemDecorations.None;
        this.ExtendClientAreaToDecorationsHint = true;
        this.ExtendClientAreaTitleBarHeightHint = 30;
    }
}
