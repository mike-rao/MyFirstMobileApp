using MyFirstMobileApp.Models.Entities;

namespace MyFirstMobileApp.ViewViewModels.Main.Articles;

public partial class ArticleMgmtView : ContentPage
{
	public ArticleMgmtView(Article article)
	{
		InitializeComponent();
		BindingContext = new ArticleViewModel();
    }
}