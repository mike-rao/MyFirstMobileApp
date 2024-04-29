using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MyFirstMobileApp.Models.Entities
{
    public class Article
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        //[MaxLength(250), Unique]
        public string Title { get; set; }
        public string Link { get; set; }
        public string Author { get; set; }
        
    }
}
