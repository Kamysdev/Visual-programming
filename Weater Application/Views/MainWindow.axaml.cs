using Avalonia.Controls;

namespace Weater_Application.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        this.SystemDecorations = SystemDecorations.None;
        this.ExtendClientAreaToDecorationsHint = true;
        this.ExtendClientAreaTitleBarHeightHint = 30;
        InitializeComponent();
    }
}
