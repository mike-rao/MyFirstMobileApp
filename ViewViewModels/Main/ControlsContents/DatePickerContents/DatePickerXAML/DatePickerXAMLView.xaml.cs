using MyFirstMobileApp.Models;

namespace MyFirstMobileApp.ViewViewModels.Main.ControlsContents.DatePickerContents.DatePickerXAML;

public partial class DatePickerXAMLView : ContentPage
{
    private DateTime _oStartDateSelected = new DateTime(DateTime.Now.Year, 1, 1);
    private DateTime _startDateSelected = new DateTime(DateTime.Now.Year, 1, 1);
    private DateTime _oEndDateSelected = new DateTime(DateTime.Now.Year, 12, 31);
    private DateTime _endDateSelected = new DateTime(DateTime.Now.Year, 12, 31);

    private bool _startDatePickerLoaded = false;
    private bool _endDatePickerLoaded = false;

    public DatePickerXAMLView()
    {
        InitializeComponent();
        BindingContext = new DatePickerXAMLViewModel();

        this.SetDatePickerEventHandlers();
    }

    private void SetDatePickerEventHandlers()
    {
        /**************************************************
		 * We wil set the Date, Min Date, and Max Date here
		**************************************************/

        //Detach the event handlers
        StartDatePicker.DateSelected -= StartDatePicker_DateSelected;
        EndDatePicker.DateSelected -= EndDatePicker_DateSelected;

        //Set the inital dates for the DatePickers
        StartDatePicker.Date = _startDateSelected;
        //Setting Min and Max Dates for DatePicker to limit years that will display
        StartDatePicker.MinimumDate = _startDateSelected;
        StartDatePicker.MaximumDate = _endDateSelected;

        //Set the initial dates for the DatePickers
        EndDatePicker.Date = _endDateSelected;
        //Setting Min and Max Dates for DatePicker to limit years that will display
        EndDatePicker.MinimumDate = _startDateSelected;
        EndDatePicker.MaximumDate = _endDateSelected;

        //Reattach the event handlers
        StartDatePicker.DateSelected += StartDatePicker_DateSelected;
        EndDatePicker.DateSelected += EndDatePicker_DateSelected;
    }

    private void StartDatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        if (!_startDatePickerLoaded)
        {
            _startDateSelected = e.NewDate;
            _oStartDateSelected = e.OldDate;
            _startDatePickerLoaded = true;
        }
    }

    private void EndDatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        if (!_endDatePickerLoaded)
        {
            _endDateSelected = e.NewDate;
            _oEndDateSelected = e.OldDate;
            _endDatePickerLoaded = true;
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        string msg = string.Empty;

        if (_oStartDateSelected.ToShortDateString() == _startDateSelected.ToShortDateString() &&
            _oEndDateSelected.ToShortDateString() == _endDateSelected.ToShortDateString())
        {
            msg = "The dates were not changed! \n\n" +
                  "Start Date: " + _oStartDateSelected.ToShortDateString() + "\n" +
                  "End Date: " + _oEndDateSelected.ToShortDateString();
        }
        else
        {
            msg = "The dates were changed! \n\n" +
                  "Original start date selected was: " + _oStartDateSelected.ToShortDateString() + "\n" +
                  "Original end date selected was: " + _oEndDateSelected.ToShortDateString() + "\n" +
                  "New start date selected was: " + _startDateSelected.ToShortDateString() + "\n" +
                  "New end date selected was: " + _endDateSelected.ToShortDateString();
        }

        await Application.Current.MainPage.DisplayAlert(TitleDatePicker.DatePickerXAMLTitle, msg, "OK");
    }
}