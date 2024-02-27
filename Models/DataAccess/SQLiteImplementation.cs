using MyFirstMobileApp.Models.Entities;
using SQLite;

namespace MyFirstMobileApp.Models.DataAccess
{
    public class SQLiteImplementation
    {
        //SQLiteAsyncConnection: Is a class provided by SQLite-net to facilitate asynchronous database operations.
        //con: This is a variable name chosen to represent the SQLite database connection.
        SQLiteAsyncConnection con;

        public SQLiteImplementation()
        {
            //Initialize and sets up the database. The method is async, as a result
            //we ignore any return value by using the discard symbole "_" which tells
            //the compiler that the result of the method is intentionally being ignored.
            //This can be useful when you have a method that returns a value,
            //but you don't need that value for the current operation.
            _ = InitializeDatabase();
        }

        //Method to get a connection to SQLite database with table creation
        private async Task InitializeDatabase()
        {
            if (con == null)
            {
                //Set the database file name
                string fileName = DbaseNames.BrawlStarCharactersDB;

                //Get the path to the personal folder on the device
                string documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

                //Combine the document path and file name to get the complete path
                string path = Path.Combine(documentPath, fileName);

                //Check if the directory exists, create it if it doesn't
                if (!File.Exists(path))
                {
                    //Create the directory if it doesn't exist
                    Directory.CreateDirectory(documentPath);
                }

                //Initialize SQLite connection
                con = new SQLiteAsyncConnection(path);

                //Create 'Vacation' table if it does not exist
                await con.CreateTableAsync<BrawlStarCharacters>();
            }
        }

        //Method to retrieve all vacations from the 'Vacation' table
        public async Task<List<BrawlStarCharacters>> GetBrawlStarCharacters()
        {
            //Use the returned connection from InitializeDatabase
            await InitializeDatabase();

            //SQL query to select all rows from 'Vacation' table
            string sql = "SELECT * FROM BrawlStarCharacters";

            //Execute the query and retrieve a list of vacations
            List<BrawlStarCharacters> brawlStarCharacters = await con.QueryAsync<BrawlStarCharacters>(sql);

            return brawlStarCharacters;
        }

        //Method to save a new vacation record
        public async Task<string> SaveBrawlStarCharacters(BrawlStarCharacters brawlStarCharacters)
        {
            string result = string.Empty;

            try
            {
                await InitializeDatabase();

                //Check if a record with the same Country and City already exists
                var existingVacation = await con.Table<BrawlStarCharacters>()
                      .Where(b => b.Name == brawlStarCharacters.Name && b.Rarity == brawlStarCharacters.Rarity)
                      .FirstOrDefaultAsync();

                if (existingVacation == null)
                {
                    //Insert the vacation record into the 'Vacation' table
                    await con.InsertAsync(brawlStarCharacters);
                }
                else
                {
                    //Record with the same Country and City already exists
                    string msg = brawlStarCharacters.Name + " and " + brawlStarCharacters.Rarity + " already exists.";
                    //await Application.Current.MainPage.DisplayAlert("Message", msg, "Ok");

                    result = msg;
                }
            }
            catch (Exception ex)
            {
                result = "ERROR: " + ex.Message;
            }

            return result;
        }

        //Method to update an existing vacation record
        public async Task<bool> UpdateBrawlStarCharacters(BrawlStarCharacters brawlStarCharacters)
        {
            bool res = false;

            try
            {
                //Use the returned connection from InitializeDatabase
                await InitializeDatabase();

                //$ is short-hand for String.Format, used with string 
                //interpolations (e.g. {0}).  Used in C# 6.0
                //SQL query to update vacation details based on the provided Id
                string sql = $"UPDATE BrawlStarCharacters " +
                                  $"SET Name = '{brawlStarCharacters.Name}', " +
                                  $"Rarity = '{brawlStarCharacters.Rarity}', " +
                                  $"Owned = '{brawlStarCharacters.Owned}' " +
                                  $"WHERE Id = {brawlStarCharacters.Id}";

                //Execute the update query
                await con.QueryAsync<BrawlStarCharacters>(sql);
                res = true;
            }
            catch (Exception ex)
            {
                // Handle exceptions
            }

            return res;
        }

        //Method to delete a vacation record based on the provided Id
        public async Task<bool> DeleteBrawlStarCharacters(int Id)
        {
            bool res = false;

            try
            {
                //Use the returned connection from InitializeDatabase
                await InitializeDatabase();

                /*****************************************************************************
                 * A SQL query is not the correct usage for deleting records based on their primary key. 
                 * For deleting a record by its primary key, DeleteAsync expects the actual object or 
                 * the primary key value, not an SQL query.
                 ******************************************************************************/
                var brawlStarCharactersToDelete = await con.Table<BrawlStarCharacters>().FirstOrDefaultAsync(b => b.Id == Id);

                if (brawlStarCharactersToDelete != null)
                {
                    //Delete the retrieved vacation
                    await con.DeleteAsync(brawlStarCharactersToDelete);
                    res = true;
                }
            }
            catch (Exception ex)
            {
                //Handle exceptions
                res = false;
            }

            return res;
        }
    }
}
