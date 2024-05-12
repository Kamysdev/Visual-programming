using MVVMAvalonia.Models;
using System.Collections.ObjectModel;
using MVVMAvalonia.Models.PagesModels;

namespace MVVMAvalonia.ViewModels.Pages
{
    public class DataTreeViewModel : BasePageViewModel
    {
        public override string GetName()
        {
            return "DataTreeViewModel";
        }

        public ObservableCollection<Node> Nodes { get; }
        public DataTreeViewModel(UsersModel usersModel) : base(usersModel)
        {
            Nodes = new ObservableCollection<Node>();

            foreach (var user in usersModel.Users)
            {
                Nodes.Add(new Node("ID: " + (user.Id.ToString()), new ObservableCollection<Node>
                {
                    new Node("Username: " + user.Username), new Node("Name: " + user.Name),
                    new Node("Email: " + user.Email), new Node("Phone: " + user.Phone),
                    new Node("Website: " + user.Website), new Node("Address: ",new ObservableCollection<Node>
                    {
                        new Node("City: " + user.Address.City), new Node("Street: " + user.Address.Street),
                        new Node("Suite: " + user.Address.Suite), new Node("Code: " + user.Address.Zipcode),
                        new Node("Geo: ", new ObservableCollection<Node>
                        {
                            new Node("Lat: " + user.Address.Geo.Lat), new Node("Lon: " + user.Address.Geo.Lng)
                        })
                    })
                }));
            }
        }
    }
}
