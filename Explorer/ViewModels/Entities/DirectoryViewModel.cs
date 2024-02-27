using System.IO;

namespace Explorer.ViewModels;

public sealed class DirectoryViewModel : EntityViewModel
{
    public DirectoryViewModel(string name) : base(name)
    {
        IsFolder = true;
        FullName = name;
    }
    
    public DirectoryViewModel(DirectoryInfo name) : base(name.Name)
    {
        IsFolder = true;
        FullName = name.FullName;
    }
}
