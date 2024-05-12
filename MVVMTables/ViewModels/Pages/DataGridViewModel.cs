using MVVMAvalonia.Models;

namespace MVVMAvalonia.ViewModels.Pages
{
    public class DataGridViewModel : BasePageViewModel
    {
        public override string GetName()
        {
            return "DataGridViewModel";
        }

        public DataGridViewModel(UsersModel usersModel) : base(usersModel)
        {
        }
    }
}
