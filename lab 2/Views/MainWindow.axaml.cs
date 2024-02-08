using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace lab_2.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public void ClickKhaki(object sender, RoutedEventArgs args)
    {
        squarePan.Background = new SolidColorBrush(Colors.Khaki);
    }

    public void ClickRed(object sender, RoutedEventArgs args)
    {
        squarePan.Background = new SolidColorBrush(Colors.Red);
    }
    
    public void ClickMediumVioletRed(object sender, RoutedEventArgs args)
    {
        squarePan.Background = new SolidColorBrush(Colors.MediumVioletRed);
    }
    
    public void ClickBisque(object sender, RoutedEventArgs args)
    {
        squarePan.Background = new SolidColorBrush(Colors.Bisque);
    }
    
    public void ClickLemonChiffon(object sender, RoutedEventArgs args)
    {
        squarePan.Background = new SolidColorBrush(Colors.LemonChiffon);
    }
    
    public void ClickPowderBlue(object sender, RoutedEventArgs args)
    {
        squarePan.Background = new SolidColorBrush(Colors.PowderBlue);
    }
    
    void ClickMintCream(object sender, RoutedEventArgs args)
    {
        squarePan.Background = new SolidColorBrush(Colors.MintCream);
    }
    
    void ClickMaroon(object sender, RoutedEventArgs args)
    {
        squarePan.Background = new SolidColorBrush(Colors.Maroon);
    }
    
    void ClickRosyBrown(object sender, RoutedEventArgs args)
    {
        squarePan.Background = new SolidColorBrush(Colors.RosyBrown);
    }
    
    void ClickLightPink(object sender, RoutedEventArgs args)
    {
        squarePan.Background = new SolidColorBrush(Colors.LightPink);
    }
}
