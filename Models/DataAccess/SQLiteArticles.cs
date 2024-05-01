using MyFirstMobileApp.Models.Entities;
using SQLite;
using System.Diagnostics;

namespace MyFirstMobileApp.Models.DataAccess
{
    public class SQLiteArticles
    {

        SQLiteAsyncConnection con;

        public SQLiteArticles()
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
                string fileName = DbaseNames.ArticleDB;

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

                //Create 'Article' table if it does not exist
                await con.CreateTableAsync<Article>();
            }
        }

        //Method to retrieve all articles from the 'Article' table
        public async Task<List<Article>> GetArticle()
        {
            //Use the returned connection from InitializeDatabase
            await InitializeDatabase();

            //SQL query to select all rows from '
            //
            //
            //' table
            string sql = "SELECT * FROM Article";

            //Execute the query and retrieve a list of articles
            List<Article> articles = await con.QueryAsync<Article>(sql);

            Debug.WriteLine("Fetched:" + articles.Count);

            return articles;
        }

        //Method to save a new articlef record
        public async Task<string> SaveArticle(Article article)
        {
            string result = string.Empty;

            try
            {
                await InitializeDatabase();

                //Check if a record with the same Country and City already exists
                var existingArticle = await con.Table<Article>()
                      .Where(m => m.Title == article.Title && m.Author == article.Author)
                      .FirstOrDefaultAsync();

                if (existingArticle == null)
                {
                    //Insert the article record into the '
                    //
                    //
                    //' table
                    await con.InsertAsync(article);
                    Debug.WriteLine("Inserted:" + article.ToString());
                }
                else
                {
                    //Record with the same Country and City already exists
                    string msg = article.Title + " and " + article.Author + " already exists.";
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

        //Method to update an existing article record
        public async Task<bool> UpdateArticle(Article article)
        {
            bool res = false;

            try
            {
                //Use the returned connection from InitializeDatabase
                await InitializeDatabase();

                //$ is short-hand for String.Format, used with string 
                //interpolations (e.g. {0}).  Used in C# 6.0
                //SQL query to update article details based on the provided Id
                string sql = $"UPDATE Article " +
                                  $"SET Title = '{article.Title}', " +
                                  $"Author = '{article.Author}', " +
                                  $"Link = '{article.Link}' " +
                                  $"WHERE Id = {article.Id}";

                //Execute the update query
                await con.QueryAsync<Article>(sql);
                res = true;
            }
            catch (Exception ex)
            {
                // Handle exceptions
            }

            return res;
        }

        //Method to delete a article record based on the provided Id
        public async Task<bool> DeleteArticle(int Id)
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
                var articleToDelete = await con.Table<Article>().FirstOrDefaultAsync(v => v.Id == Id);

                if (articleToDelete != null)
                {
                    //Delete the retrieved article
                    await con.DeleteAsync(articleToDelete);
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
