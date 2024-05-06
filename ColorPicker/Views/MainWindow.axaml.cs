using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using ColorPicker.ColorCore;
using ColorPicker.ViewModels;
using System.Windows.Input;

namespace ColorPicker.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void w_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
        {
            if (sender is Visual visualSender)
            {
                MainWindowViewModel viewModel = ViewModelLocator.MainWindowViewModelInstance;
                var a = e.GetPosition(visualSender);

                w_ChangePColor(viewModel.UpdateRGBA(a));
            }
        }

        public void w_ChangePColor(CoreColorsRGBA color)
        {
            Palet.Background = new SolidColorBrush(Color.FromArgb(255, (byte)color.R, (byte)color.G, (byte)color.B));
        }
    }
}