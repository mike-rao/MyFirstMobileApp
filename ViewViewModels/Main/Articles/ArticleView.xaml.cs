namespace MyFirstMobileApp.ViewViewModels.Main.Articles;

public partial class ArticleView : ContentPage
{
	public ArticleView()
	{
		InitializeComponent();
        BindingContext = new ArticleViewModel();
    }
}