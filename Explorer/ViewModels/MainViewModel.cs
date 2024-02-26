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
    public string FilePath {  get; set; }

    public ObservableCollection<EntityViewModel> FileDirectory { get; set; } = new ObservableCollection<EntityViewModel>();

    public EntityViewModel SelectedFile { get; set; }

    public ICommand openCommand { get; }

    public MainViewModel() 
    {
        openCommand = new DeligateCommand(OpenFolder);

        foreach (var logicalDrive in Directory.GetLogicalDrives())
        {
            FileDirectory.Add(new DirectoryViewModel(logicalDrive));
        }
    }
    
    private void OpenFolder(object? obj)
    {
        if (obj is DirectoryViewModel directoryViewModel) 
        {
            FilePath = directoryViewModel.Name;

            FileDirectory.Clear();
            var dirInfo = new DirectoryInfo(FilePath);

            foreach (var directory in dirInfo.GetDirectories())
            {
                FileDirectory.Add(new DirectoryViewModel(directory));
            }

            foreach (var fileInfo in dirInfo.GetFiles())
            {
                FileDirectory.Add(new FileViewModel(fileInfo));
            }
        }
    }

}
