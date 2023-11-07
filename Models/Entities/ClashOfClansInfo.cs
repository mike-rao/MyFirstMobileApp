using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.Models.Entities
{

    public class ClashOfClansInfo
    {
        public string TroopType { get; set; } = string.Empty;
        public ImageSource TroopImage { get; set; } = null;
        public string TroopName { get; set; } = string.Empty;

        public ClashOfClansInfo()
        {
            //Constructor
        }

        public ClashOfClansInfo(string troopType, ImageSource troopImage, string troopName)
        {
            TroopType = troopType;
            TroopImage = troopImage;
            TroopName = troopName;
        }

        public static List<ClashOfClansInfo> GetSampleTroopData()
        {
            var troops =  new List<ClashOfClansInfo>
            {
                new ClashOfClansInfo("Ground", ImageSource.FromFile("Images/COC/hogrider.jpg"), "Hog Rider"),
                new ClashOfClansInfo("Air", ImageSource.FromFile("Images/COC/dragon.jpg"), "Dragon"),
                new ClashOfClansInfo("Hero", ImageSource.FromFile("Images/COC/archerqueen.jpg"), "Archer Queen"),
                new ClashOfClansInfo("Air", ImageSource.FromFile("Images/COC/balloon.jpg"), "Balloon"),
                new ClashOfClansInfo("Ground", ImageSource.FromFile("Images/COC/goblin.jpg"), "Goblin")
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
