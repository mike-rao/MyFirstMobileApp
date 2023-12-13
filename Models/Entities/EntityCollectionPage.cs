using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.Models.Entities
{
    public class EntityCollectionPage
    {
        public string NameofGame { get; set; }

        //Image Buttons
        public ImageSource EditButton { get; } = Buttons.ButtonEdit;
        public ImageSource DeleteButton { get; } = Buttons.ButtonDelete;

        public EntityCollectionPage()
        {
            //Constructor
        }

        public EntityCollectionPage(string name)
        {
            NameofGame = name;
        }

        public static List<EntityCollectionPage> GetGames()
        {
            return new List<EntityCollectionPage>
            {
                new EntityCollectionPage("Clash of Clans"),
                new EntityCollectionPage("Clash Royale"),
                new EntityCollectionPage("Brawl Stars"),
                new EntityCollectionPage("Hay Day"),
                new EntityCollectionPage("Boom Beach"),
                new EntityCollectionPage("Clash Mini"),
                new EntityCollectionPage("Clash Heroes")
            };
        }
    }
}
