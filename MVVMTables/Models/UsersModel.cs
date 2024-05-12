using MVVMAvalonia.Models.Users;
using MVVMAvalonia.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;

namespace MVVMAvalonia.Models
{
    public class UsersModel
    {
        private ObservableCollection<User> users = new ObservableCollection<User>();
        public ObservableCollection<User> Users 
        {
            get => users;
        }
        public UsersModel()
        {
            Request request = new Request();
            string response = "";

            try
            {
                response = request.SendRequest("https://jsonplaceholder.typicode.com/users");

                List<User> users = new List<User>();
                JsonCollectionConverterConverter<User> converter = new JsonCollectionConverterConverter<User>();

                users = converter.Convert(response);
                foreach (User user in users)
                {
                    Users.Add(user);
                }
            }
            catch (HttpRequestException e)
            {

            }
        }
    }
}
