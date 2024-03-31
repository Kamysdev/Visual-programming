namespace UsersTables.ViewModels;
using System.ComponentModel;

public partial class MainViewModel
{
    public class User : INotifyPropertyChanged
    {
        public User()
        {
        }

        public User(int iD, string? name, string? nickName, string? email, string? phone, string? website, string? city, string? companyName)
        {
            ID = iD;
            Name = name;
            NickName = nickName;
            Email = email;
            Phone = phone;
            Website = website;
            City = city;
            CompanyName = companyName;
        }

        public int ID { get; set; }
        public string? Name 
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
                }
            }
        }
        private string? _name { get; set; }

        public string? NickName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }
        public string? City { get; set; }
        public string? CompanyName { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
