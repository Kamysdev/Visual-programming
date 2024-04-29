using Lab7_v2_Pt2.Modules;

namespace Lab7_v2_Pt2.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel() 
        { 
            windowEventFactory = new WindowEventFactory();

        }

        private WindowEventFactory windowEventFactory { get; set; }

        public void CreateNewWindow()
        {

        }
    }
}
