using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewModels;
using MyFirstMobileApp.ViewViewModels.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.ViewViewModels.Main.ControlsContents.SliderContents
{
    public class SliderViewModel : BaseViewModel
    {
        public string SliderTitle { get; } = TitleSlider.SliderTitle;

        public SliderViewModel()
        {
            Title = "Slider Control";
        }
    }
}