using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using MsBox.Avalonia;
using MsBox.Avalonia.Dto;
using MsBox.Avalonia.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
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

    public Bitmap SeeCurrentImageResult 
    {
        get => _SeeCurrentImageResult; 
        set { _SeeCurrentImageResult = value; OnPropertyChanged(nameof(SeeCurrentImageResult)); }
    }

    public Bitmap _SeeCurrentImageResult { get; set; }

    private List<string> formats = [".png", ".jpg", ".jpeg", ".bmp", ".ico", ".gif"];

    public ICommand OpenCommand { get; }
    public ICommand ImageCommand { get; }

    public MainViewModel() 
    {
        OpenCommand = new DeligateCommand(OpenFolder);
        ImageCommand = new DeligateCommand(OpenImage);

        GetLogicDrives();
    }

    private bool _ImageVisibility = false;

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

    public void OpenImage(object parameter)
    {
        if (parameter is FileViewModel fileViewModel)
        {
            SeeCurrentImageResult = new Bitmap(fileViewModel.FullName);
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
            var box = MessageBoxManager.GetMessageBoxCustom(
            new MessageBoxCustomParams
            {
                ButtonDefinitions = new List<ButtonDefinition>
                {
                    new ButtonDefinition { Name = "Ok", },
                },
                ContentTitle = "Error",
                ContentMessage = "Access error!",
                Icon = MsBox.Avalonia.Enums.Icon.Error,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                CanResize = false,
                MaxWidth = 400,
                MaxHeight = 200,
                ShowInCenter = true,
                Topmost = false,
            });

            box.ShowAsync();
            GoBack();
        }

        try
        {
            foreach (var fileInfo in dirInfo.GetFiles())
            {
                foreach (var format in formats)
                {
                    if (_ImageVisibility)
                    {
                        FileDirectory.Add(new FileViewModel(fileInfo));
                        break;
                    }
                    else if (fileInfo.Name.EndsWith(format))
                    {
                        FileDirectory.Add(new FileViewModel(fileInfo));
                        break;
                    }
                }
            }
        }
        catch { }
    }

    public void ImageVisibility(object parameter)
    {
        _ImageVisibility = !_ImageVisibility;
        ReloadEntity();
    }

    private void ReloadEntity()
    {
        MoveInFolders(FilePath);
    }
}
