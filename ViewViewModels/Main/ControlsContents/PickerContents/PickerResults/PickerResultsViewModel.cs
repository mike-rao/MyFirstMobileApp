using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.ViewViewModels.Main.ControlsContents.PickerContents.PickerResults
{
    public class PickerResultsViewModel : BaseViewModel
    {
        public ImageSource ImageSrc { get; set; }
        public string PickerSelection { get; set; }

        public PickerResultsViewModel (string value, ImageSource image)
        {
            Title = TitlePicker.PickerResultsTitle;
            PickerSelection = value;
            ImageSrc = image;
        }

    }
}