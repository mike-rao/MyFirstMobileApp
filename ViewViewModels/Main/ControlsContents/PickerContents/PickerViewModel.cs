using MyFirstMobileApp.Models;
using MyFirstMobileApp.Models.Entities;
using MyFirstMobileApp.ViewModels;
using MyFirstMobileApp.ViewViewModels.Main.ControlsContents.PickerContents.PickerVM;
using MyFirstMobileApp.ViewViewModels.Main.ControlsContents.PickerContents.PickerXAML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFirstMobileApp.ViewViewModels.Main.ControlsContents.PickerContents
{
    public class PickerViewModel : BaseViewModel
    {
        public ImageSource PickerXAMLButton { get; set; } = Buttons.ButtonPickerRed;
        public ImageSource PickerVMButton { get; set; } = Buttons.ButtonPickerBlue;
        public ICommand OnXAMLClicked { get; set; }
        public ICommand OnVMClicked { get; set; }


        public PickerViewModel()
        {
            Title = TitlePicker.PickerTitle;

            OnXAMLClicked = new Command(OnXAMLClickedAsync);
            OnVMClicked = new Command(OnVMClickedAsync);

        }

        private async void OnXAMLClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new PickerXAMLView());
        }
        private async void OnVMClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new PickerVMView());
        }
    }
}
