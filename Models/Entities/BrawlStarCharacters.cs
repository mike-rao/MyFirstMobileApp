using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.Models.Entities
{
    public class BrawlStarCharacters
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        //[MaxLength(250), Unique]
        public string Name { get; set; }
        public string Rarity { get; set; }
        public int Owned { get; set; } = 0;
    }
}
