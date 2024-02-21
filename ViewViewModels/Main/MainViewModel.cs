using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewModels;
using MyFirstMobileApp.ViewViewModels.Main.BrawlStarCharacters;
using MyFirstMobileApp.ViewViewModels.Main.CollectionsContents;
using MyFirstMobileApp.ViewViewModels.Main.ControlsContents;
using MyFirstMobileApp.ViewViewModels.Main.ImagesContents;
using MyFirstMobileApp.ViewViewModels.Main.StackLayoutContents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFirstMobileApp.ViewViewModels.Main
{
    public class MainViewModel : BaseViewModel
    {
        //Pull button text from Model
        public String StackLayoutButton { get; set; } = TitleMain.StackLayoutButtonName;
        public String ImagesButton { get; set; } = TitleMain.ImagesButtonName;
        public String CollectionsButton { get; set; } = TitleMain.CollectionsButtonName;
        public String ControlsButton { get; set; } = TitleMain.ControlsButtonName;
        public String SQLiteButton { get; set; } = TitleMain.SQLiteButtonName;

        //Button Commands
        public ICommand OnLayoutsClicked { get; set; }
        public ICommand OnImagesClicked { get; set; }
        public ICommand OnCollectionsClicked { get; set; }
        public ICommand OnControlsClicked { get; set; }
        public ICommand OnSQLiteClicked { get; set; }

        public MainViewModel()
        {
            Title = TitleMain.MainTitle;

            //Set Commands
            OnLayoutsClicked = new Command(OnLayoutsClickedAsync);
            OnImagesClicked = new Command(OnImagesClickedAsync);
            OnCollectionsClicked = new Command(OnCollectionsClickedAsync);
            OnControlsClicked = new Command(OnControlsClickedAsync);
            OnSQLiteClicked = new Command(OnSQLiteClickedAsync);
        }

        //Navigation between pages
        private async void OnLayoutsClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new StackLayoutView());
        }
        private async void OnImagesClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ImagesView());
        }
        private async void OnCollectionsClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CollectionsView());
        }
        private async void OnControlsClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ControlsView());
        }
        private async void OnSQLiteClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new BrawlStarCharactersView());
        }
    }
}
