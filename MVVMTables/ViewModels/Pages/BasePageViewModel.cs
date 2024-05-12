using MVVMAvalonia.Models;
using MVVMAvalonia.Models.Users;
using ReactiveUI;
using System.Collections.ObjectModel;

namespace MVVMAvalonia.ViewModels.Pages
{
    public abstract class BasePageViewModel : ViewModelBase
    {
        protected UsersModel usersModel;
        public string Header => GetName();
        public abstract string GetName();
        protected BasePageViewModel(UsersModel users)
        {
            this.usersModel = users;
            this.users = new ObservableCollection<User>();
            this.users = users.Users;
        }

        private ObservableCollection<User> users;
        public ObservableCollection<User> Users
        {
            get => users;
            set
            {
                this.RaiseAndSetIfChanged(ref users, value);
            }
        }
    }
}
