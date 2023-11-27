using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.Models.Entities
{

    public class EntityCollectionWImages
    {
        public string TroopType { get; set; } = string.Empty;
        public ImageSource TroopImage { get; set; } = null;
        public string TroopName { get; set; } = string.Empty;

        public EntityCollectionWImages()
        {
            //Constructor
        }

        public EntityCollectionWImages(string troopType, ImageSource troopImage, string troopName)
        {
            TroopType = troopType;
            TroopImage = troopImage;
            TroopName = troopName;
        }

        public static List<EntityCollectionWImages> GetSampleTroopData()
        {
            var troops =  new List<EntityCollectionWImages>
            {
                new EntityCollectionWImages("Ground", ImageSource.FromFile("Images/COC/hogrider.jpg"), "Hog Rider"),
                new EntityCollectionWImages("Air", ImageSource.FromFile("Images/COC/dragon.jpg"), "Dragon"),
                new EntityCollectionWImages("Hero", ImageSource.FromFile("Images/COC/archerqueen.jpg"), "Archer Queen"),
                new EntityCollectionWImages("Air", ImageSource.FromFile("Images/COC/balloon.jpg"), "Balloon"),
                new EntityCollectionWImages("Ground", ImageSource.FromFile("Images/COC/goblin.jpg"), "Goblin")
            };

            return troops;
        }

        public static List<string> GetTroopNames()
        {
            var sampleData = GetSampleTroopData();

            return sampleData.Select(info => info.TroopName).ToList();
        }
    }
}
