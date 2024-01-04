using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.ViewViewModels.Main.ControlsContents.SwitchContents
{
    public class SwitchViewModel : BaseViewModel
    {
        public string SwitchTitle { get; } = TitleSwitch.SwitchTitle;

        public SwitchViewModel()
        {
            Title = "Switch";
        }
    }
}
