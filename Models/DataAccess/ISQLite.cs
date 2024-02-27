using MyFirstMobileApp.Models.Entities;
using SQLite;

namespace MyFirstMobileApp.Models.DataAccess
{
    public interface ISQLite2
    {       
        //SQLiteConnection InitializeDatabase();

        List<BrawlStarCharacters> GetBrawlStarCharacters();

        bool SaveBrawlStarCharacters(BrawlStarCharacters brawlStarCharacters);

        bool UpdateBrawlStarCharacters(BrawlStarCharacters brawlStarCharacters);

        void DeleteBrawlStarCharacters(int Id);
    }
}
