using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.Models.Entities
{
    public static class Buttons
    {

        //Edit,  Delete & Submit
        public static ImageSource ButtonEdit { get; } = ImageSource.FromFile("ImageButtons/iconsedit.png");
        public static ImageSource ButtonDelete { get; } = ImageSource.FromFile("ImageButtons/iconsdelete.png");
        public static ImageSource ButtonSubmit { get; } = ImageSource.FromFile("ImageButtons/buttonsubmit.png");

        //DatePicker
        public static ImageSource ButtonDatePickerBlue { get; } = ImageSource.FromFile("ImageButtons/datepickerbuttonblue.png");
        public static ImageSource ButtonDatePickerRed { get; } = ImageSource.FromFile("ImageButtons/datepickerbuttonred.png"); 

        //Picker
        public static ImageSource ButtonPickerBlue { get; } = ImageSource.FromFile("ImageButtons/pickerbuttonblue.png");  
        public static ImageSource ButtonPickerRed { get; } = ImageSource.FromFile("ImageButtons/pickerbuttonred.png");
    }
}
