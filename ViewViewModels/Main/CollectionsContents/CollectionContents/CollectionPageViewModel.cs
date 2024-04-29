using MyFirstMobileApp.Models;
using MyFirstMobileApp.Models.Entities;
using MyFirstMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.ViewViewModels.Main.CollectionsContents.CollectionContents
{
    public class CollectionPageViewModel : BaseViewModel
    {
        //Private fields
        private List<EntityCollectionPage> _supercellgames;

        //Observable collection bound to the View
        public ObservableCollection<EntityCollectionPage> SupercellGamesCollection { get; }

        //Constructor
        public CollectionPageViewModel() 
        {
            Title = TitleCollection.CollectionTitle;

            //Instantiate Observable TroopsCollection
            SupercellGamesCollection = new ObservableCollection<EntityCollectionPage>();

            _supercellgames = EntityCollectionPage.GetGames();
            this.LoadGames();
        }

        //Load
        //s into the Observable collection
        private void LoadGames()
        {
            try
            {
                SupercellGamesCollection.Clear();
                foreach (var s in _supercellgames)
                {
                    SupercellGamesCollection.Add(new EntityCollectionPage { NameofGame = s.NameofGame});
                }
            }
            catch (Exception ex) 
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
