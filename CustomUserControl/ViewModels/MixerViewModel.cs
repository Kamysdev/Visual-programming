using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomUserControl.ViewModels
{
    public class MixerViewModel : ViewModelBase
    {
        public bool State;
        public string ConSize = "*";

        public int MinSliderValue;
        public int MaxSliderValue;

        public MixerViewModel() 
        {
            State = true;
            MinSliderValue = 0;
            MaxSliderValue = 100;
        }

        
    }
}
