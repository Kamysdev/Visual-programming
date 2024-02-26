using System.IO;

namespace Explorer.ViewModels;

public sealed class DirectoryViewModel : EntityViewModel
{
    public DirectoryViewModel(string name) : base(name)
    {
        FullName = name;
    }
    
    public DirectoryViewModel(DirectoryInfo name) : base(name.Name)
    {
        FullName = name.FullName;
    }
}
