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
        private List<SupercellGames> _supercellgames;

        //Observable collection bound to the View
        public ObservableCollection<SupercellGames> SupercellGamesCollection { get; }

        //Constructor
        public CollectionPageViewModel() 
        {
            Title = TitleCollection.CollectionTitle;

            SupercellGamesCollection = new ObservableCollection<SupercellGames>();

            _supercellgames = SupercellGames.GetGames();
            this.LoadGames();
        }

        //Load movies into the Observable collection
        private void LoadGames()
        {
            try
            {
                SupercellGamesCollection.Clear();

                foreach (var p in _supercellgames)
                {
                    SupercellGamesCollection.Add(new SupercellGames { NameofGame = p.NameofGame });
                }
            }
            catch (Exception ex) 
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
