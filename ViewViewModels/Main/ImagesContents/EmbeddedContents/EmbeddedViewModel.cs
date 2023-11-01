using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.ViewViewModels.Main.ImagesContents.EmbeddedContents
{
    public class EmbeddedViewModel : BaseViewModel
    {
        public EmbeddedViewModel()
        {
            Title = TitleEmbedded.EmbeddedTitle;
        }

        public ImageSource GetImageSource
        {
            get
            {
                return ImageSource.FromFile("Images/aarnavchitari.jpg");
            }
        }
    }
}
