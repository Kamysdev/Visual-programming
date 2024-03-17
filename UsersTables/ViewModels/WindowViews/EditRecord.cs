using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersTables.ViewModels;

public partial class MainViewModel 
{
    public void ShowEditWindow()
    {
        EditUserWindow = new EditUser();
        EditUserWindow.DataContext = this;
        EditUserWindow?.Show();
    }

    public void EditRecord()
    {
        for (int i = 0; i < UsersList.Count; i++)
        {
            if (UsersList[i].ID == removableID) 
            {
                UsersList[i] = new User(UsersList[i].ID, addName, addNickName, addEmail, addPhone, addWebsite, addCity, addCompanyName);
                break;
            }
        }
        CloseEditWindow();
    }

    public void CloseEditWindow()
    {
        addName = null;
        addNickName = null;
        addEmail = null;
        addPhone = null;
        addWebsite = null;
        addCity = null;
        addCompanyName = null;
        EditUserWindow?.Close();
    }
}

