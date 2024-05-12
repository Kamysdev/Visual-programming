using MVVMAvalonia.Models;
using MVVMAvalonia.ViewModels.Pages;
using ReactiveUI;
using System.Collections.ObjectModel;

namespace MVVMAvalonia.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private UsersModel usersModel;

        private object content;
        private ObservableCollection<BasePageViewModel> viewModelCollection =
            new ObservableCollection<BasePageViewModel>();

        public MainWindowViewModel(UsersModel usersModel)
        {
            viewModelCollection.Add(new DataGridViewModel(usersModel));
            viewModelCollection.Add(new DataTreeViewModel(usersModel));

            Content = viewModelCollection[0];
            this.usersModel = usersModel;
        }

        public object Content
        {
            get => content;
            set
            {
                this.RaiseAndSetIfChanged(ref content, value);
            }
        }

        public ObservableCollection<BasePageViewModel> ViewModelCollection
        {
            get => viewModelCollection;
            set
            {
                this.RaiseAndSetIfChanged(ref viewModelCollection, value);
            }
        }
    }
}
