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

namespace MyFirstMobileApp.ViewViewModels.Main.CollectionsContents.CollectionWImagesContents
{
    public class CollectionWImagesViewModel : BaseViewModel
    {
        //Observable collection bound to the View
        public ObservableCollection<EntityCollectionWImages> TroopsCollection { get; }

        //Private fields
        private List<EntityCollectionWImages> _troops;

        //Constructor
        public CollectionWImagesViewModel()
        {
            Title = TitleCollectionWImages.CollectionsWImagesTitle;

            //Instantiate Observable TroopsCollection
            TroopsCollection = new ObservableCollection<EntityCollectionWImages>();
            _troops = EntityCollectionWImages.GetSampleTroopData();
            this.LoadTroops();
        }

        //Load
        //
        //s into the Observable collection
        private void LoadTroops()
        {
            try
            {
                TroopsCollection.Clear();
                foreach (var t in _troops)
                {
                    TroopsCollection.Add(t);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
