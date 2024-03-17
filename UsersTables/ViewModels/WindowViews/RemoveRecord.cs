using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersTables.ViewModels;

public partial class MainViewModel
{
    public int removableID { get; set; }

    public void ShowRemovableWindow()
    {
        RemoveUserWindow = new RemoveUser();
        RemoveUserWindow.DataContext = this;
        RemoveUserWindow?.Show();
    }

    public void RemoveRecord()
    {
        for (int i = 0; i < UsersList.Count; i++)
        {
            if (UsersList[i].ID == removableID)
            {
                UsersList.RemoveAt(i);
                break;
            }
        }
        removableID = 0;
        RemoveUserWindow?.Close();
    }

    public void CloseRemoveUserWindow()
    {
        removableID = 0;
        RemoveUserWindow?.Close();
    }
}
