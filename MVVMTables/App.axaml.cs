using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MVVMAvalonia.Models;
using MVVMAvalonia.ViewModels;
using MVVMAvalonia.Views;

namespace MVVMAvalonia
{
    public partial class App : Application
    {
        private UsersModel usersModel;

        public App()
        {
            usersModel = new UsersModel();
        }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(usersModel),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}