namespace Explorer.ViewModels;

public abstract class EntityViewModel : BaseViewModel
{
    public string? Name { get; }

    public string FullName { get; set; }

    protected EntityViewModel(string name)
    {
        Name = name;
    }
}