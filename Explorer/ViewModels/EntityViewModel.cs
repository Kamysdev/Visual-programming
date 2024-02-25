namespace Explorer.ViewModels;

public abstract class EntityViewModel : BaseViewModel
{
    public string? Name { get; }

    protected EntityViewModel(string name)
    {
        Name = name;
    }
}