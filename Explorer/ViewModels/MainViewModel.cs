using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Explorer.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public ObservableCollection<EntityViewModel> FileDirectory { get; set; } = new ObservableCollection<EntityViewModel>();

    public ICommand dClick { get; }

    public MainViewModel() 
    {
        dClick = new DeligateCommand(OpenFolder);

        foreach (var logicalDrive in Directory.GetLogicalDrives())
        {
            FileDirectory.Add(new DirectoryViewModel(logicalDrive));
        }
    }
    
    
    private void OpenFolder(object? obj)
    {

    }

}
