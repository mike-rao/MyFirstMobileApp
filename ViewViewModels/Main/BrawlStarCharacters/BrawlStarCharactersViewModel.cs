using Microsoft.Maui.Devices.Sensors;
using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.ViewViewModels.Main.BrawlStarCharacters
{
    public class BrawlStarCharactersViewModel : BaseViewModel
    {
        private readonly SQLiteImplementation _sqliteService = new SQLiteImplementation();

        //Collection to hold vac
        //ation data for the UI
        private ObservableCollection<BrawlStarCharacters> _brawlStarCharactersCollection;

        //Property to expose the BrawlStarCharacters collection to the UI
        public ObservableCollection<BrawlStarCharacters> BrawlStarCharactersCollection
        {
            get { return _brawlStarCharactersCollection; }
            set
            {
                _brawlStarCharactersCollection = value;
                OnPropertyChanged();
                //Debug.WriteLine($"BrawlStarCharactersCollection Count: {_BrawlStarCharactersCollection?.Count}");
            }
        }

        //Constructor to initialize the ViewModel
        public BrawlStarCharactersViewModel()
        {
            Title = TitleBrawlStarCharacters.BrawlStarCharactersTitle;

            //Initialize the BrawlStarCharacters collection
            BrawlStarCharactersCollection = new ObservableCollection<BrawlStarCharacters>();

            //Trigger an asynchronous refresh of the BrawlStarCharacters list data
            Task.Run(async () => await RefreshBrawlStarCharactersListData());

            _ = RefreshBrawlStarCharactersListData();
        }

        public async Task RefreshBrawlStarCharactersListData()
        {
            // Retrieve BrawlStarCharacters data from the SQLite database
            var BrawlStarCharacters = await _sqliteService.GetBrawlStarCharacters();

            // Update the ViewModel's BrawlStarCharacters collection with the new data
            BrawlStarCharactersCollection = new ObservableCollection<BrawlStarCharacters>(BrawlStarCharacters);
        }

        //Command to navigate to the BrawlStarCharactersMgmtView and handle Adds
        public Command AddCommand
        {
            get
            {
                return new Command<BrawlStarCharacters>((BrawlStarCharacters BrawlStarCharacters) =>
                {
                    //Unsubscribe from events - precautionary step to ensure that there are no existing subscriptions for the specified events
                    MessagingCenter.Unsubscribe<BrawlStarCharacters>(this, "AddBrawlStarCharacters");

                    //Navigate to the BrawlStarCharactersAddView, passing a BrawlStarCharacters if available
                    Application.Current.MainPage.Navigation.PushAsync(new BrawlStarCharactersMgmtView(BrawlStarCharacters));

                    //Subscribe to a MessagingCenter event for refreshing data when a new BrawlStarCharacters is added
                    MessagingCenter.Subscribe<BrawlStarCharacters>(this, "AddBrawlStarCharacters", async (data) =>
                    {
                        //Refresh the BrawlStarCharacters list data asynchronously
                        await RefreshBrawlStarCharactersListData();
                        //Unsubscribe from the MessagingCenter event after refreshing data
                        MessagingCenter.Unsubscribe<BrawlStarCharacters>(this, "AddBrawlStarCharacters");
                    });
                });
            }
        }

        //Command to navigate to the BrawlStarCharactersMgmtView and handle Updates
        public Command UpdateCommand
        {
            get
            {
                return new Command<BrawlStarCharacters>((BrawlStarCharacters BrawlStarCharacters) =>
                {
                    //Unsubscribe from events - precautionary step to ensure that there are no existing subscriptions for the specified events
                    MessagingCenter.Unsubscribe<BrawlStarCharacters>(this, "UpdateBrawlStarCharacters");

                    //Navigate to the BrawlStarCharactersAddView, passing a BrawlStarCharacters if available
                    Application.Current.MainPage.Navigation.PushAsync(new BrawlStarCharactersMgmtView(BrawlStarCharacters));

                    //Subscribe to a MessagingCenter event for refreshing data when a new BrawlStarCharacters is updated
                    MessagingCenter.Subscribe<BrawlStarCharacters>(this, "UpdateBrawlStarCharacters", async (data) =>
                    {
                        // Refresh the BrawlStarCharacters list data asynchronously
                        await RefreshBrawlStarCharactersListData();
                        // Unsubscribe from the MessagingCenter event after refreshing data
                        MessagingCenter.Unsubscribe<BrawlStarCharacters>(this, "UpdateBrawlStarCharacters");
                    });
                });
            }
        }

        //Command to delete a BrawlStarCharacters and update the collection
        public Command<BrawlStarCharacters> DeleteCommand
        {
            get
            {
                return new Command<BrawlStarCharacters>((BrawlStarCharacters BrawlStarCharacters) =>
                {
                    //Delete the BrawlStarCharacters from the SQLite database
                    _ = _sqliteService.DeleteBrawlStarCharacters(BrawlStarCharacters.Id);

                    //Remove the BrawlStarCharacters from the ViewModel's collection
                    BrawlStarCharactersCollection.Remove(BrawlStarCharacters);
                });
            }
        }
    }
}


/*
                     //Subscribe to a MessagingCenter event for refreshing data when a new BrawlStarCharacters is added
                    //MessagingCenter.Subscribe<BrawlStarCharactersAddViewModel, BrawlStarCharacters>(this, "AddBrawlStarCharacters", async (sender, addedBrawlStarCharacters) =>
                    MessagingCenter.Subscribe<BrawlStarCharacters>(this, "AddBrawlStarCharacters", async (data) =>
                    {
                        //Refresh the BrawlStarCharacters list data asynchronously
                        await RefreshBrawlStarCharactersListData();

                        //Unsubscribe from the MessagingCenter event after refreshing data
                        MessagingCenter.Unsubscribe<BrawlStarCharacters>(this, "AddBrawlStarCharacters");
                        //MessagingCenter.Unsubscribe<BrawlStarCharactersAddViewModel, BrawlStarCharacters>(this, "AddBrawlStarCharacters");
                    });
*/
