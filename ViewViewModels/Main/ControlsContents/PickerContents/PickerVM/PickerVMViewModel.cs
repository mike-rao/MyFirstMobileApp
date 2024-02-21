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

namespace MyFirstMobileApp.ViewViewModels.Main.ControlsContents.PickerContents.PickerVM
{
    public class PickerVMViewModel : BaseViewModel
    {
        public ImageSource SubmitButton { get; set; } = "ImageButtons/buttonsubmit.png";

        //Property to bind the Picker Item Source
        public List<string> CharacterList { get; set; }
        List<EntityCollectionWImages> _troops;
        string _selectedCharacter = string.Empty;

        public ICommand OnSubmitClicked { get; }

        public PickerVMViewModel()
        {
            //Set Title
            Title = TitlePicker.PickerVMTitle;

            //Get Characters from ActorCharacterInfo Class to Populate Picker
            this.GetCharacterList();

            //Set Submit Button Command
            OnSubmitClicked = new Command(OnSubmitClickedAsync);
        }

        private void GetCharacterList()
        {
            var allCharacterInfo = EntityCollectionWImages.GetSampleTroopData();

            //Filter and map the character names from the list of ActorCharacterInfo objects
            CharacterList = allCharacterInfo.Select(info => info.TroopName).ToList();
            _troops = allCharacterInfo;
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

        private async void OnSubmitClickedAsync(object obj)
        {
            //Verify user made a selection
            if (string.IsNullOrEmpty(_selectedCharacter))
            {
                await Application.Current.MainPage.DisplayAlert(TitlePicker.PickerVMTitle, "A selection must be made!", "OK");
                return;
            }

            //Get selection
            var selectedCharacterName = _selectedCharacter;

            //Find the ActorCharacterInfo based on the selected character name
            var selectedCharacterInfo = _troops.FirstOrDefault(info => info.TroopName == selectedCharacterName);

            if (selectedCharacterInfo != null)
            {
                //Combining actor's name and character's name into a single string for display
                string name = $"{selectedCharacterInfo.TroopName} \nTroop Type: {selectedCharacterInfo.TroopType}";

                //Use selected CharacterInfo.ActorImage for the actor's image
                await Application.Current.MainPage.Navigation.PushAsync(new PickerResultsView(name, selectedCharacterInfo.TroopImage));
            }
        }
    }
}
