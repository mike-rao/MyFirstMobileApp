namespace MyFirstMobileApp.ViewViewModels.Main.StackLayoutContents.AbsoluteLayoutContents;

public partial class AbsoluteLayoutView : ContentPage
{
	public AbsoluteLayoutView()
	{
		InitializeComponent();
        BindingContext = new AbsoluteLayoutViewModel();
    }
}