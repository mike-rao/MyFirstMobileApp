using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewModels;
using MyFirstMobileApp.ViewViewModels.Main.ImagesContents.ActivityIndicatorContents;
using MyFirstMobileApp.ViewViewModels.Main.ImagesContents.EmbeddedContents;
using MyFirstMobileApp.ViewViewModels.Main.ImagesContents.URIImagesContents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFirstMobileApp.ViewViewModels.Main.ImagesContents
{
    public class ImagesViewModel : BaseViewModel
    {
        //Pull button text from Model
        public String URIImagesButtonName { get; set; } = TitleImages.URIImagesButtonName;
        public String EmbeddedButtonName { get; set; } = TitleImages.EmbeddedButtonName;
        public String ActivityIndicatorButtonName { get; set; } = TitleImages.ActivityIndicatorButtonName;

        //Button Commands
        public ICommand OnURIImagesClicked { get; set; }
        public ICommand OnEmbeddedClicked { get; set; }
        public ICommand OnActivityIndicatorClicked { get; set; }

        //Constructor
        public ImagesViewModel()
        {
            Title = TitleImages.ImagesTitle;

            //Set Commands
            OnURIImagesClicked = new Command(OnURIImagesClickedAsync);
            OnEmbeddedClicked = new Command(OnEmbeddedClickedAsync);
            OnActivityIndicatorClicked = new Command(OnActivityIndicatorClickedAsync);
        }

        //Navigation between pages
        private async void OnURIImagesClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new URIImagesView());
        }
        private async void OnEmbeddedClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new EmbeddedView());
        }
        private async void OnActivityIndicatorClickedAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ActivityIndicatorView());
        }
    }
}
