using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.ViewViewModels.Main.ImagesContents.URIImagesContents
{
    public class URIImagesViewModel : BaseViewModel
    {
        public string BuilderImageURL { get; } = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTyPrEg-aGBHxfQ_55drufwk0r_ZYXRekNFdplSHS6fHOTGLoX81CQ1qtAHFtE5w3YVOyk:https://pbs.twimg.com/profile_images/1712092662935777280/A3ShxrzK_400x400.jpg&usqp=CAU";

        private ImageSource _getImageSource;

        //Constructor
        public URIImagesViewModel()
        {
            Title = TitleURIImages.URIImagesTitle;
        }

        public ImageSource GetImageSource
        {
            get
            {
                if (_getImageSource == null) 
                {
                    _getImageSource = GetImage();
                }
                return _getImageSource;
            }
        }

        private ImageSource GetImage()
        {
            var imgsrc = new UriImageSource { Uri = new Uri(BuilderImageURL) };
            imgsrc.CachingEnabled = false;
            imgsrc.CacheValidity = TimeSpan.FromHours(1);

            return imgsrc;
        }
    }
}
