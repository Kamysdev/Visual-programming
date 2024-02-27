namespace Explorer.ViewModels;

public abstract class EntityViewModel : BaseViewModel
{
    public string? Name { get; }

    public bool IsFolder;

    public string FullName { get; set; }

    protected EntityViewModel(string name)
    {
        IsFolder = true;
        Name = name;
    }
}