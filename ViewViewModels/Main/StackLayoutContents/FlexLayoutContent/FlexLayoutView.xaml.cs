namespace MyFirstMobileApp.ViewViewModels.Main.StackLayoutContents.FlexLayoutContent;

public partial class FlexLayoutView : ContentPage
{
	public FlexLayoutView()
	{
		InitializeComponent();
        BindingContext = new FlexLayoutViewModel();
    }
}