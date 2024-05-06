using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
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

                viewModel.UpdateData(a);
            }
        }
    }
}