namespace MyFirstMobileApp.ViewViewModels.Main.ControlsContents.EntryContents.EntryResultsContents;

public partial class EntryResultsView : ContentPage
{
    public EntryResultsView(string entryText)
    {
        InitializeComponent();
        BindingContext = new EntryResultsViewModel(entryText);
    }
}
