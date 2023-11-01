using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.Models.Entities
{
    public class SupercellGames
    {
        public string NameofGame { get; set; }

        public SupercellGames()
        {
            //Constructor
        }

        public SupercellGames(string name)
        {
            NameofGame = name;
        }

        public static List<SupercellGames> GetGames()
        {
            return new List<SupercellGames>
            {
                new SupercellGames("Clash of Clans"),
                new SupercellGames("Clash Royale"),
                new SupercellGames("Brawl Stars"),
                new SupercellGames("Hay Day"),
                new SupercellGames("Boom Beach")
            };
        }
    }
}
