using ReactiveUI;
using System;

namespace CustomUserControl.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private object content;

        public object Content
        {
            get => content;
            set
            {
                this.RaiseAndSetIfChanged(ref content, value);
            }
        }

        public MainWindowViewModel()
        {
            Content = new MixerViewModel();
        }

        private void Window_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
        {
            Content = new MixerMinizedViewModel();
        }
    }
}
