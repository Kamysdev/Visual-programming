namespace UsersTables.ViewModels;

public partial class MainViewModel
{
    public class User
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
        public string? Name { get; set; }
        public string? NickName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }
        public string? City { get; set; }
        public string? CompanyName { get; set; }
    }
}
