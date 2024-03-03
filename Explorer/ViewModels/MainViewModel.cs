using Avalonia.Controls;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;

namespace Explorer.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    public string FilePath { get; set; }

    public string LastFilePath { get; set; }

    public ObservableCollection<EntityViewModel> FileDirectory 
    {
        get;
        set;
    } = [];

    public EntityViewModel? SelectedFile { get; set; }

    public ICommand OpenCommand { get; }

    public MainViewModel() 
    {
        OpenCommand = new DeligateCommand(OpenFolder);

        GetLogicDrives();
    }

    public void GoBack()
    {
        if (LastFilePath == null || LastFilePath.Length == 0)
        {
            return;
        }
        else if (LastFilePath != null)
        {
            MoveInFolders(LastFilePath);
            FilePath = LastFilePath;
        }
    }

    public void GoUp()
    {
        LastFilePath = FilePath;

        if (FilePath == null || FilePath.Length == 0)
        {
            return;
        }

        if (FilePath[^1] == '\\')
        {
            FilePath = FilePath.Remove(FilePath.Length - 1);
            for (int i = FilePath.Length - 1; i >= 0; i--)
            {
                if (Convert.ToString(FilePath[i]) == "\\")
                {
                    break;
                }
                FilePath = FilePath.Remove(i);
            }
        }

        for (int i = FilePath.Length - 1; i >= 0; i--)
        {
            if (Convert.ToString(FilePath[i]) == "\\")
            {
                break;
            }
            FilePath = FilePath.Remove(i);
        }

        if (FilePath.Length == 0)
        {
            FileDirectory.Clear();

            GetLogicDrives();
            return;
        }

        MoveInFolders(FilePath);
        return;
    }

    private void GetLogicDrives()
    {
        foreach (var logicalDrive in Directory.GetLogicalDrives())
        {
            FileDirectory.Add(new DirectoryViewModel(logicalDrive));
        }
    }

    private void OpenFolder(object parameter)
    {
        if (parameter is DirectoryViewModel directoryViewModel) 
        {
            LastFilePath = FilePath;
            FilePath = directoryViewModel.FullName;

            MoveInFolders(FilePath);
        }
    }

    private void MoveInFolders(string movablePath)
    {
        FileDirectory.Clear();
        var dirInfo = new DirectoryInfo(movablePath);

        try
        {
            foreach (var directory in dirInfo.GetDirectories())
            {
                FileDirectory.Add(new DirectoryViewModel(directory));
            }
        }
        catch
        {

        }
        
        try
        {
            foreach (var fileInfo in dirInfo.GetFiles())
            {
                FileDirectory.Add(new FileViewModel(fileInfo));
            }
        }
        catch
        {

        }
    }

    private void ReloadEntity()
    {
        MoveInFolders(FilePath);
    }
}
