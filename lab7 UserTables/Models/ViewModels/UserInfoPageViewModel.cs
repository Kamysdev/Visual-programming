using CommunityToolkit.Mvvm.ComponentModel;
using lab7.Models.UserModels;
using lab7.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace lab7.Models.ViewModels
{
    internal partial class UserInfoPageViewModel : ObservableObject
    {
        public class MyObservable
        {
            public static IObservable<NotifyCollectionChangedEventArgs> Create(ObservableCollection<Users> collection)
            {
                return Observable.FromEvent<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(
                    handler => (sender, args) => handler(args),
                    handler => collection.CollectionChanged += handler,
                    handler => collection.CollectionChanged -= handler);
            }
        }
        private readonly UserApiService _userApiService;

        public UserInfoPageViewModel()
        {
            _userApiService = new UserApiService();
            User = new ObservableCollection<Users>();
            MyObservable.Create(User)
                       .Subscribe(args => LogCollectionChanges(args));
            FetchUserInformation();
        }

        private void LogCollectionChanges(NotifyCollectionChangedEventArgs args)
        {
            if (args.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Users item in args.NewItems)
                {
                    string logMessage = $"Added: {item.Name} - {item.Id}";
                    LogToFile(logMessage);
                }
            }
            else if (args.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (Users item in args.OldItems)
                {
                    string logMessage = $"Removed: {item.Name} - {item.Id}";
                    LogToFile(logMessage);
                }
            }
        }

        private void LogToFile(string message)
        {
            string logFilePath = @"C:\Users\Kamys\Desktop\test.txt";
            System.IO.File.AppendAllText(logFilePath, message + Environment.NewLine);
        }

        public class Users
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }

            public Users(int id, string name, string username, string email, string phone)
            {
                Id = id;
                Name = name;
                UserName = username;
                Email = email;
                Phone = phone;
            }
        }

        public ObservableCollection<Users> User
        {
            get => _user;
            set { _user = value; OnPropertyChanged(nameof(User)); }
        }

        public ObservableCollection<Users> _user { get; set; }


        [ObservableProperty]
        private int tmpId = 11;

        [ObservableProperty]
        private string tmpName;

        [ObservableProperty]
        private string tmpUsername;

        [ObservableProperty]
        private string tmpEmail;

        [ObservableProperty]
        private string tmpPhone;

        [ObservableProperty]
        private int tmpIdEdit;

        [ObservableProperty]
        private string tmpNameEdit;

        [ObservableProperty]
        private string tmpUsernameEdit;

        [ObservableProperty]
        private string tmpEmailEdit;

        [ObservableProperty]
        private string tmpPhoneEdit;

        [ObservableProperty]
        private int tmpIdRemove;

        private async Task FetchUserInformation()
        {
            var userApiResponse = await _userApiService.GetUserInformation();
            if (userApiResponse != null)
            {
                for (int i = 0; i < 10; i++)
                {
                    User.Add(new Users(userApiResponse[i].Id, userApiResponse[i].Name, userApiResponse[i].Username, userApiResponse[i].Email, userApiResponse[i].Phone));
                }
            }
        }

        public void AddUser()
        {
            User.Add(new Users(TmpId, TmpName, TmpUsername, TmpEmail, TmpPhone));
            TmpId++;
        }

        public void RemoveUser()
        {
            for (int i = 0; i < User.Count; i++)
            {
                if (User[i].Id == TmpIdRemove)
                {
                    User.Remove(User[i]);
                    TmpIdRemove = 0;
                }
            }
        }

        public void EditUser()
        {
            for (int i = 0; i < User.Count; i++)
            {
                if (User[i].Id == TmpIdEdit)
                {
                    User.Remove(User[i]);
                    User.Add(new Users(TmpIdEdit, TmpNameEdit, TmpUsernameEdit, TmpEmailEdit, TmpPhoneEdit));
                    TmpIdEdit = 0;
                    TmpNameEdit = null;
                    TmpUsernameEdit = null;
                    TmpEmailEdit = null;
                    TmpPhoneEdit = null;
                }
            }
        }

        public class ObservableCollectionFactory
        {
            public IObservable<ICollectionChange> CreateObservableCollection(ObservableCollection<Users> collection)
            {
                return collection.ToObservable().Select(x => new CollectionChange(collection, x));
            }
        }

        public class CollectionChange : ICollectionChange
        {
            private readonly ObservableCollection<Users> _collection;
            private readonly Users _item;

            public CollectionChange(ObservableCollection<Users> collection, Users item)
            {
                _collection = collection;
                _item = item;
            }

            public Users Item => _item;

            public ObservableCollection<Users> Collection => _collection;
        }

        public interface ICollectionChange
        {
            Users Item { get; }
            ObservableCollection<Users> Collection { get; }
        }

        public class LoggingObserver : IObserver<ICollectionChange>
        {
            private readonly string _logFilePath;

            public LoggingObserver(string logFilePath)
            {
                _logFilePath = logFilePath;
            }

            public void OnNext(ICollectionChange value)
            {
                string logMessage = $"{value.Item} - {value.Collection}";
                System.IO.File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
            }

            public void OnCompleted()
            {
                // Здесь вы можете логировать информацию о завершении подписки
            }

            public void OnError(Exception error)
            {
                // Здесь вы можете логировать информацию об ошибке
            }
        }

    }
}
