﻿using System.IO;

namespace Explorer.ViewModels;

public sealed class FileViewModel : EntityViewModel
{
    public FileViewModel(string name) : base(name)
    {
        IsFolder = false;
    }

    public FileViewModel(FileInfo fileInfo) : base(fileInfo.Name)
    {
        IsFolder = false;
        FullName = fileInfo.FullName;
    }

    
}
