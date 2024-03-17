using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersTables.ViewModels;

public partial class MainViewModel
{
    public string? addName { get; set; }
    public string? addNickName { get; set; }
    public string? addEmail { get; set; }
    public string? addPhone { get; set; }
    public string? addWebsite { get; set; }
    public string? addCity { get; set; }
    public string? addCompanyName { get; set; }


    public void ShowAdditionalWindow()
    {
        AddUserWindow = new AddUser();
        AddUserWindow.DataContext = this;
        AddUserWindow.Show();
    }

    public void AddRecord()
    {
        UsersList.Add(new User(UsersList.Count + 1,
            addName,
            addNickName,
            addEmail,
            addPhone,
            addWebsite,
            addCity,
            addCompanyName));

        CloseAddUserWindow();
    }

    public void CloseAddUserWindow()
    {
        addName = null;
        addNickName = null;
        addEmail = null;
        addPhone = null;
        addWebsite = null;
        addCity = null;
        addCompanyName = null;
        AddUserWindow.Close();
    }
}
