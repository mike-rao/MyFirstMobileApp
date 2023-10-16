namespace MyFirstMobileApp.ViewViewModels.AbsoluteLayoutContents;

public partial class AbsoluteLayoutView : ContentPage
{
	public AbsoluteLayoutView()
	{
		InitializeComponent();
        BindingContext = new AbsoluteLayoutViewModel();
    }
}