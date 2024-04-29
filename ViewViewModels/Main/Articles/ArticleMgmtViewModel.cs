using MyFirstMobileApp.Models;
using MyFirstMobileApp.Models.DataAccess;
using MyFirstMobileApp.Models.Entities;
using MyFirstMobileApp.ViewModels;

namespace MyFirstMobileApp.ViewViewModels.Articles
{
    public class ArticleMgmtViewModel : BaseViewModel
    {
        //Properties to bind to the UI
        public List<Article> ArticleCollection { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Link { get; set; }
        public int Id { get; set; }

        //Text for the button based on whether it's an update or save operation
        public string ButtonText { get; set; }

        //Create an instance of the SQLiteImplementation class to handle SQLite database operations,
        //and assign it to the private readonly field _sqliteService for use throughout the class.
        //readonly variable ensures it can only be assigned a value at the time of declaration or in the constructor
        private readonly SQLiteArticles _sqliteService = new SQLiteArticles();

        //Constructor to initialize the ViewModel with existing Article details if provided
        public ArticleMgmtViewModel(Article Article)
        {
            //Initialize the collection
            ArticleCollection = new List<Article>();

            if (Article != null)
            {
                Title = TitleArticles.TitleUpdateArticle;
                //If Article exists, populate ViewModel properties

                ArticleCollection.Add(Article);
                Id = Article.Id;
                Title = Article.Title;
                Author = Article.Author;
                Link = Article.Link;

                ButtonText = "Update";
            }
            else
            {
                Title = TitleArticles.TitleAddArticle;

                //If no Article provided, initialize a new one and set button text to "Save"
                ArticleCollection = new List<Article>();

                ButtonText = "Save";
            }
        }

        //Command for saving or updating Article details
        public Command<Article> PerformSave
        {
            get
            {
                return new Command<Article>(async (Article Article) =>
                {
                    try
                    {
                        //Check for required data before save or update
                        if (string.IsNullOrEmpty(Title) || string.IsNullOrEmpty(Author))
                        {
                            await Application.Current.MainPage.DisplayAlert("Message", "Title and Author are required.", "Ok");
                            return;
                        }

                        if (ButtonText == "Save")
                        {
                            //Creating a new Article instance with ViewModel properties
                            Article = new Article
                            {
                                Id = Id,
                                Title = Title,
                                Author = Author,
                                Link = Link
                            };

                            //Save the new Article
                            string result = await _sqliteService.SaveArticle(Article);

                            if (result == string.Empty)
                            {
                                //Send a message to notify about the addition of a new Article
                                MessagingCenter.Send<Article>(Article, "AddArticle");

                                if (Application.Current.MainPage != null)
                                {
                                    await Application.Current.MainPage.Navigation.PopAsync();
                                }
                            }
                            else
                            {
                                await Application.Current.MainPage.DisplayAlert("Message", result, "Ok");
                            }
                        }
                        else
                        {
                            //Creating a new Article instance with ViewModel properties for an update
                            Article = new Article
                            {
                                Id = Id,
                                Title = Title,
                                Author = Author,
                                Link = Link
                            };

                            //Update the existing Article details
                            bool result = await _sqliteService.UpdateArticle(Article);

                            if (result)
                            {
                                //Send a message to notify about the update of the Article
                                MessagingCenter.Send<Article>(Article, "UpdateArticle");
                                await Application.Current.MainPage.Navigation.PopAsync();
                            }
                            else
                            {
                                await Application.Current.MainPage.DisplayAlert("Message", "Data Failed To Update", "Ok");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                    }
                });
            }
        }
    }
}