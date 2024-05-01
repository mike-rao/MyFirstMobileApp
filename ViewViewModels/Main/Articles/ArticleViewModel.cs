using MyFirstMobileApp.Models.Entities;
using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewModels;
using System.Collections.ObjectModel;
using MyFirstMobileApp.Models.DataAccess;
using System.Diagnostics;

namespace MyFirstMobileApp.ViewViewModels.Main.Articles
{
    //ViewModel for managing Article data
    public class ArticleViewModel : BaseViewModel
    {
        private readonly SQLiteArticles _sqliteService = new SQLiteArticles();

        //Collection to hold Article data for the UI
        private ObservableCollection<Article> _articleCollection;

        //Property to expose the Article collection to the UI
        public ObservableCollection<Article> ArticleCollection
        {
            get { return _articleCollection; }
            set
            {
                _articleCollection = value;
                OnPropertyChanged();
                Debug.WriteLine($"ArticleCollection Count: {_articleCollection?.Count}");
            }
        }

        //Constructor to initialize the ViewModel
        public ArticleViewModel()
        {
            Title = TitleArticles.TitleArticle;

            //Initialize the Article collection
            ArticleCollection = new ObservableCollection<Article>();

            //Trigger an asynchronous refresh of the Article list data

            Task.Run(async () => await RefreshArticleListData());

            _ = RefreshArticleListData();
        }

        public async Task RefreshArticleListData()
        {
            Article test1 = new Article()
            {
                Id = 1,
                Title = "Hello",
                Link = "test link",
                Author = "Mike"
            };

            await _sqliteService.SaveArticle(test1);

            // Retrieve Article data from the SQLite database
            var Article = await _sqliteService.GetArticle();

            // Update the ViewModel's Article collection with the new data
            ArticleCollection = new ObservableCollection<Article>(Article);
        }

        //Command to navigate to the ArticleMgmtView and handle Adds
        public Command AddCommand
        {
            get
            {
                return new Command<Article>((Article Article) =>
                {
                    //Unsubscribe from events - precautionary step to ensure that there are no existing subscriptions for the specified events
                    MessagingCenter.Unsubscribe<Article>(this, "AddArticle");

                    //Navigate to the ArticleAddView, passing a Article if available
                    Application.Current.MainPage.Navigation.PushAsync(new ArticleMgmtView(Article));

                    //Subscribe to a MessagingCenter event for refreshing data when a new Article is added
                    MessagingCenter.Subscribe<Article>(this, "AddArticle", async (data) =>
                    {
                        //Refresh the Article list data asynchronously
                        await RefreshArticleListData();
                        //Unsubscribe from the MessagingCenter event after refreshing data
                        MessagingCenter.Unsubscribe<Article>(this, "AddArticle");
                    });
                });
            }
        }

        //Command to navigate to the ArticleMgmtView and handle Updates
        public Command UpdateCommand
        {
            get
            {
                return new Command<Article>((Article Article) =>
                {
                    //Unsubscribe from events - precautionary step to ensure that there are no existing subscriptions for the specified events
                    MessagingCenter.Unsubscribe<Article>(this, "UpdateArticle");

                    //Navigate to the ArticleAddView, passing a Article if available
                    Application.Current.MainPage.Navigation.PushAsync(new ArticleMgmtView(Article));

                    //Subscribe to a MessagingCenter event for refreshing data when a new Article is updated
                    MessagingCenter.Subscribe<Article>(this, "UpdateArticle", async (data) =>
                    {
                        // Refresh the Article list data asynchronously
                        await RefreshArticleListData();
                        // Unsubscribe from the MessagingCenter event after refreshing data
                        MessagingCenter.Unsubscribe<Article>(this, "UpdateArticle");
                    });
                });
            }
        }

        //Command to delete a Article and update the collection
        public Command<Article> DeleteCommand
        {
            get
            {
                return new Command<Article>((Article Article) =>
                {
                    //Delete the Article from the SQLite database
                    _ = _sqliteService.DeleteArticle(Article.Id);

                    //Remove the Article from the ViewModel's collection
                    ArticleCollection.Remove(Article);
                });
            }
        }
    }
}


/*
                     //Subscribe to a MessagingCenter event for refreshing data when a new Article is added
                    //MessagingCenter.Subscribe<ArticleAddViewModel, Article>(this, "AddArticle", async (sender, addedArticle) =>
                    MessagingCenter.Subscribe<Article>(this, "AddArticle", async (data) =>
                    {
                        //Refresh the Article list data asynchronously
                        await RefreshArticleListData();

                        //Unsubscribe from the MessagingCenter event after refreshing data
                        MessagingCenter.Unsubscribe<Article>(this, "AddArticle");
                        //MessagingCenter.Unsubscribe<ArticleAddViewModel, Article>(this, "AddArticle");
                    });
*/