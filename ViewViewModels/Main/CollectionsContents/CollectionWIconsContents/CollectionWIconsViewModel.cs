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

namespace MyFirstMobileApp.ViewViewModels.Main.CollectionsContents.CollectionWIconsContents
{
    public class CollectionWIconsViewModel : BaseViewModel
    {
        public ObservableCollection<EntityCollectionPage> SupercellGamesCollection { get; set; }

        public CollectionWIconsViewModel()
        {
            //Set the title for this view
            Title = TitleCollectionWIcons.CollectionsWIconsTitle;

            //Create a new ObservableCollection to store movies
            SupercellGamesCollection = new ObservableCollection<EntityCollectionPage>();

            //Load movies from the data source
            LoadGames();
        }

        //Method to load movies from a data source
        private void LoadGames()
        {
            IsBusy = true;

            try
            {
                //Clear the existing collection
                SupercellGamesCollection.Clear();

                //Get a list of Marvel movies and add them to the collection
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
        //Command to add a new movie
        public ICommand AddCommand => new Command(async () =>
        {
            //Navigate to the AddCollectionView when the "Add" button is clicked

            await Application.Current.MainPage.Navigation.PushAsync(new AddCollectionView());

            //****************************************************************************************
            // A messaging event is a way for different parts of your app to communicate.
            // It's like a message sent from one part to another to share data or trigger actions.
            // MessagingCenter helps subscribe to and send these events.
            // In this code, when you add a movie in AddCollectionView, it sends an "AddMovies" event.
            // UpdateableCollectionWButtonsViewModel listens for this event and updates the movie list.
            //****************************************************************************************
            //Subscribe to the "AddMovies" messaging event to receive updated data from AddCollectionView            
            MessagingCenter.Subscribe<EntityCollectionPage>(this, "AddGames", async (data) =>
            {
                //Add the new movie data to the collection
                SupercellGamesCollection.Add(data);

                //Unsubscribe from the messaging event
                MessagingCenter.Unsubscribe<EntityCollectionPage>(this, "AddGames");
            });
        });

        //Command to update a movie
        public ICommand UpdateCommand => new Command<EntityCollectionPage>(async game =>
        {
            //Get the index of the selected movie in the collection
            var index = SupercellGamesCollection.IndexOf(game);

            //Navigate to the EditCollectionView to edit the selected movie when the Update Button is Clicked
            await Application.Current.MainPage.Navigation.PushAsync(new EditCollectionView(game));

            //****************************************************************************************
            // A messaging event is a way for different parts of your app to communicate.
            // It's like a message sent from one part to another to share data or trigger actions.
            // MessagingCenter helps subscribe to and send these events.
            // In this code, when you update a movie in EditCollectionView, it sends an "UpdateMovies" event.
            // UpdateableCollectionWButtonsViewModel listens for this event and updates the movie list.
            //****************************************************************************************
            //Subscribe to the "UpdateMovies" messaging event to receive updated data from EditCollectionView            
            MessagingCenter.Subscribe<EntityCollectionPage>(this, "UpdateGames", updatedGame =>
            {
                //Update the movie in the collection with the edited data
                SupercellGamesCollection[index] = updatedGame;
            });
        });

        //Command to delete a movie
        public ICommand DeleteCommand => new Command<EntityCollectionPage>(game =>
        {
            //Remove the selected movie from the collection
            SupercellGamesCollection.Remove(game);
        });
#pragma warning restore CA1416 // Validate platform compatibility

    }
}
