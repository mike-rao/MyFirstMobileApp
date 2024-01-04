using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.ViewViewModels.Main.ControlsContents.EntryContents.EntryResultsContents
{
    public class EntryResultsViewModel : BaseViewModel
    {
        private string _entryText;

        public EntryResultsViewModel(string entryText)
        {
            Title = TitleEntry.EntryResultsTitle;
            _entryText = entryText;
        }

        public string EntryText
        {
            get
            {
                return _entryText;
            }

            set
            {
                if (_entryText != value)
                {
                    SetProperty(ref _entryText, value);
                }
            }
        }
    }
}

