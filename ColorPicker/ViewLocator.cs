using Avalonia.Controls;
using Avalonia.Controls.Templates;
using ColorPicker.ViewModels;
using System;

namespace ColorPicker
{
    public class ViewLocator : IDataTemplate
    {
        public Control? Build(object? data)
        {
            if (data is null)
                return null;

            var name = data.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
            var type = Type.GetType(name);

            if (type != null)
            {
                var control = (Control)Activator.CreateInstance(type)!;
                control.DataContext = data;
                return control;
            }

            return new TextBlock { Text = "Not Found: " + name };
        }

        private static readonly IDataTemplate _dataTemplate = new ViewLocator();

        public static Control? GetView(object? viewModel)
        {
            if (viewModel == null)
                return null;

            return _dataTemplate.Build(viewModel);
        }

        public bool Match(object? data)
        {
            return data is ViewModelBase;
        }
    }

    public static class ViewModelLocator
    {
        private static MainWindowViewModel _viewModel;

        public static MainWindowViewModel MainWindowViewModelInstance
        {
            get
            {
                if (_viewModel == null)
                {
                    _viewModel = new MainWindowViewModel();
                }
                return _viewModel;
            }
        }
    }
}
