using MyFirstMobileApp.Models;
using MyFirstMobileApp.Models.Entities;
using MyFirstMobileApp.ViewModels;
using MyFirstMobileApp.ViewViewModels.Main.CollectionsContents.AddEdit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFirstMobileApp.ViewViewModels.Main.CollectionsContents.CollectionWButtonsContents
{
    public class CollectionWButtonsViewModel : BaseViewModel
    {
        public ObservableCollection<EntityCollectionPage> SupercellGamesCollection { get; set; }

        public CollectionWButtonsViewModel()
        {
            //Set the title for this view
            Title = TitleCollectionWButtons.CollectionsWButtonsTitle;

            //Create a new ObservableCollection to store articles
            SupercellGamesCollection = new ObservableCollection<EntityCollectionPage>();

            //Load articles from the data source
            LoadGames();
        }

        //Method to load articles from a data source
        private void LoadGames()
        {
            IsBusy = true;

            try
            {
                //Clear the existing collection
                SupercellGamesCollection.Clear();

                //Get a list of Marvel articles and add them to the collection
                var supercellGames = EntityCollectionPage.GetGames();
                foreach (var game in supercellGames)
                {
                    SupercellGamesCollection.Add(game);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

#pragma warning disable CA1416 // Validate platform compatibility
        //Command to add a new article
        public ICommand AddCommand => new Command(async () =>
        {
            //Navigate to the AddCollectionView when the "Add" button is clicked

            await Application.Current.MainPage.Navigation.PushAsync(new AddCollectionView());

            //****************************************************************************************
            // A messaging event is a way for different parts of your app to communicate.
            // It's like a message sent from one part to another to share data or trigger actions.
            // MessagingCenter helps subscribe to and send these events.
            // In this code, when you add a article in AddCollectionView, it sends an "Add
            //
            //
            //
            //
            //
            // s" event.
            // UpdateableCollectionWButtonsViewModel listens for this event and updates the article list.
            //****************************************************************************************
            //Subscribe to the "Add
            //
            //
            //
            //
            //s" messaging event to receive updated data from AddCollectionView            
            MessagingCenter.Subscribe<EntityCollectionPage>(this, "AddGames", async (data) =>
            {
                //Add the new article data to the collection
                SupercellGamesCollection.Add(data);

                //Unsubscribe from the messaging event
                MessagingCenter.Unsubscribe<EntityCollectionPage>(this, "AddGames");
            });
        });

        //Command to update a article
        public ICommand UpdateCommand => new Command<EntityCollectionPage>(async game =>
        {
            //Get the index of the selected article in the collection
            var index = SupercellGamesCollection.IndexOf(game);

            //Navigate to the EditCollectionView to edit the selected article when the Update Button is Clicked
            await Application.Current.MainPage.Navigation.PushAsync(new EditCollectionView(game));

            //****************************************************************************************
            // A messaging event is a way for different parts of your app to communicate.
            // It's like a message sent from one part to another to share data or trigger actions.
            // MessagingCenter helps subscribe to and send these events.
            // In this code, when you update a article in EditCollectionView, it sends an "Update
            //
            //
            //
            //
            //
            // s" event.
            // UpdateableCollectionWButtonsViewModel listens for this event and updates the article list.
            //****************************************************************************************
            //Subscribe to the "Update
            //
            //
            //s" messaging event to receive updated data from EditCollectionView            
            MessagingCenter.Subscribe<EntityCollectionPage>(this, "UpdateGames", updatedGame =>
            {
                //Update the article in the collection with the edited data
                SupercellGamesCollection[index] = updatedGame;
            });
        });

        //Command to delete a article
        public ICommand DeleteCommand => new Command<EntityCollectionPage>(game =>
        {
            //Remove the selected article from the collection
            SupercellGamesCollection.Remove(game);
        });
#pragma warning restore CA1416 // Validate platform compatibility

    }
}
