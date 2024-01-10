using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewModels;
using MyFirstMobileApp.ViewViewModels.Main.ControlsContents.DatePickerContents;
using MyFirstMobileApp.ViewViewModels.Main.ControlsContents.EntryContents;
using MyFirstMobileApp.ViewViewModels.Main.ControlsContents.PickerContents;
using MyFirstMobileApp.ViewViewModels.Main.ControlsContents.SliderContents;
using MyFirstMobileApp.ViewViewModels.Main.ControlsContents.StepperContents;
using MyFirstMobileApp.ViewViewModels.Main.ControlsContents.SwitchContents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFirstMobileApp.ViewViewModels.Main.ControlsContents
{
    public class ControlsViewModel : BaseViewModel
    {
        //Pull button text from Model
        public String SliderButton { get; set; } = TitleControls.SliderButtonName;
        public String StepperButton { get; set; } = TitleControls.StepperButtonName;
        public String SwitchButton { get; set; } = TitleControls.SwitchButtonName;
        public String EntryButton { get; set; } = TitleControls.EntryButtonName;
        public String PickerButton { get; set; } = TitleControls.PickerButtonName;
        public String DateAndTimePickerButton { get; set; } = TitleControls.DateAndTimePickerButtonName;

        //Button Commands
        public ICommand OnSliderClicked { get; set; }
        public ICommand OnStepperClicked { get; set; }
        public ICommand OnSwitchClicked { get; set; }
        public ICommand OnEntryClicked { get; set; }
        public ICommand OnPickerClicked { get; set; }
        public ICommand OnDateAndTimePickerClicked { get; set; }

        public ControlsViewModel()
        {
            Title = TitleMain.ControlsButtonName;

            //Set Commands
            OnSliderClicked = new Command(OnSliderClickedAsync);
            OnStepperClicked = new Command(OnStepperClickedAsync);
            OnSwitchClicked = new Command(OnSwitchClickedAsync);
            OnEntryClicked = new Command(OnEntryClickedAsync);
            OnPickerClicked = new Command(OnPickerClickedAsync);
            OnDateAndTimePickerClicked = new Command(OnDateAndTimePickerClickedAsync);
        }

        //Navigation between pages
        private async void OnSliderClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new SliderView());
        }
        private async void OnStepperClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new StepperView());
        }
        private async void OnSwitchClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new SwitchView());
        }
        private async void OnEntryClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new EntryView());
        }
        private async void OnPickerClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new PickerView());
        }
        private async void OnDateAndTimePickerClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new DatePickerView());
        }
    }
}
