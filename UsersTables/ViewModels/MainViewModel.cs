using System.Threading.Tasks;
using System;
using UsersTables.ViewModels.Services;
using System.Collections.ObjectModel;
using ReactiveUI;
using System.Reactive.Linq;
using System.IO;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.VisualTree;

namespace UsersTables.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly UserApiService _userApiService;

    public ObservableCollection<User> UsersList { get; set; } = new ObservableCollection<User>();
    private ObservableCollectionFactory factory = new ObservableCollectionFactory();

    AddUser AddUserWindow;
    RemoveUser RemoveUserWindow;
    EditUser EditUserWindow;

    public MainViewModel()
    {
        _userApiService = new UserApiService();

        IObservable<ICollectionChange> observable = factory.CreateObservableCollection(UsersList);
        LoggingObserver logsObserver = new LoggingObserver("C:\\Users\\Kamys\\source\\repos\\Kamysdev\\Visual programming\\1.txt");
        observable.Subscribe(logsObserver);


        FetchUserInformation();
    }

    private async Task FetchUserInformation()
    {
        var userApiResponse = await _userApiService.GetUserInformation();
        if (userApiResponse != null)
        {
            for (int i = 0; i < 10; i++)
            {
                UsersList.Add(new User(userApiResponse[i].id,
                    userApiResponse[i].name,
                    userApiResponse[i].username,
                    userApiResponse[i].email,
                    userApiResponse[i].phone,
                    userApiResponse[i].website,
                    userApiResponse[i].address.city,
                    userApiResponse[i].company.name));
            }
        }
    }

    public class ObservableCollectionFactory
    {
        public IObservable<ICollectionChange> CreateObservableCollection(ObservableCollection<User> collection)
        {
            return collection.ToObservable().Select(x => new CollectionChange(collection, x));
        }
    }

    public class CollectionChange : ICollectionChange
    {
        private readonly ObservableCollection<User> _collection;
        private readonly User _item;

        public CollectionChange(ObservableCollection<User> collection, User item)
        {
            _collection = collection;
            _item = item;
        }

        public User Item => _item;

        public ObservableCollection<User> Collection => _collection;
    }

    public interface ICollectionChange
    {
        User Item { get; }
        ObservableCollection<User> Collection { get; }
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
            string logMessage = $"{value.Collection}";
            value.Collection.CollectionChanged += (s, e) =>
            {
                if (e.NewItems != null)
                {
                    User user = e.NewItems.Cast<User>().FirstOrDefault();
                    if (user != null)
                    {
                        user.PropertyChanged += (s1, e1) =>
                        {
                            System.IO.File.AppendAllText(_logFilePath, $"{e1.PropertyName} changed" + Environment.NewLine);
                        };
                    }
                }
                else if (e.OldItems != null)
                {
                    User user = e.OldItems.Cast<User>().FirstOrDefault();
                    if (user != null)
                    {
                        user.PropertyChanged += (s1, e1) =>
                        {
                            System.IO.File.AppendAllText(_logFilePath, $"{e1.PropertyName} changed" + Environment.NewLine);
                        };
                    }
                }
            };
            System.IO.File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
        }

        public void OnCompleted()
        {
            
        }

        public void OnError(Exception error)
        {
            
        }
    }
}
