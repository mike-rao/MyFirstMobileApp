using MyFirstMobileApp.Models;
using MyFirstMobileApp.Models.Entities;
using MyFirstMobileApp.ViewModels;
using MyFirstMobileApp.ViewViewModels.Main.ControlsContents.PickerContents.PickerResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFirstMobileApp.ViewViewModels.Main.ControlsContents.PickerContents.PickerXAML
{
    public class PickerXAMLViewModel : BaseViewModel
    {
        public ImageSource SubmitButton { get; set; } = Buttons.ButtonSubmit;
        public ICommand OnSubmitClicked { get; }

        private string _selectedCharacter = string.Empty;

        public PickerXAMLViewModel()
        {
            Title = TitlePicker.PickerXAMLTitle;

            OnSubmitClicked = new Command(OnSubmitClickedAsync);
        }

        public string SelectedCharacter
        {
            get
            {
                return _selectedCharacter;
            }

            set
            {
                if (_selectedCharacter != value)
                {
                    SetProperty(ref _selectedCharacter, value);
                }

            }
        }

        private async void OnSubmitClickedAsync(Object obj)
        {

            List<EntityCollectionWImages> chars = EntityCollectionWImages.GetSampleTroopData();

            var result = chars.FirstOrDefault(x => x.TroopName.Equals(_selectedCharacter));

            await Application.Current.MainPage.Navigation.PushAsync(new PickerResultsView(result.TroopName, result.TroopImage));

            if (String.IsNullOrEmpty(_selectedCharacter))
            {
                await Application.Current.MainPage.DisplayAlert(TitlePicker.PickerXAMLTitle, "A selection must be made!", "OK");
                return;
            }
        }
    }
}
