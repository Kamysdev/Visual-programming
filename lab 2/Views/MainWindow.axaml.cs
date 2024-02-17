using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using ReactiveUI;

namespace lab_2.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public void ClickButton(object sender, RoutedEventArgs args)
    {
        if(sender is Button button && squarePan != null)
        {
            squarePan.Background = button.Background;
        }
    }
    
    public void ClickEvent(object sender, RoutedEventArgs args)
    {
        squarePan.Background = buttonKhaki.Background;
    }
}