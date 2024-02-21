﻿using MyFirstMobileApp.Models;
using MyFirstMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMobileApp.ViewViewModels.Main.BrawlStarCharacters
{
    public class BrawlStarCharactersMgmtViewModel : BaseViewModel
    {
        //Properties to bind to the UI
        public List<BrawlStarCharacters> BrawlStarCharactersCollection { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Visited { get; set; }
        public int Id { get; set; }

        //Text for the button based on whether it's an update or save operation
        public string ButtonText { get; set; }

        //Create an instance of the SQLiteImplementation class to handle SQLite database operations,
        //and assign it to the private readonly field _sqliteService for use throughout the class.
        //readonly variable ensures it can only be assigned a value at the time of declaration or in the constructor
        private readonly SQLiteImplementation _sqliteService = new SQLiteImplementation();

        //Constructor to initialize the ViewModel with existing BrawlStarCharacters details if provided
        public BrawlStarCharactersMgmtViewModel(BrawlStarCharacters BrawlStarCharacters)
        {
            //Initialize the collection
            BrawlStarCharactersCollection = new List<BrawlStarCharacters>();

            if (BrawlStarCharacters != null)
            {
                Title = TitleBrawlStarCharacters.TitleUpdateBrawlStarCharacters;

                //If BrawlStarCharacters exists, populate ViewModel properties
                BrawlStarCharactersCollection.Add(BrawlStarCharacters);
                Id = BrawlStarCharacters.Id;
                Country = BrawlStarCharacters.Country;
                City = BrawlStarCharacters.City;
                Visited = BrawlStarCharacters.Visited;

                ButtonText = "Update";
            }
            else
            {
                Title = TitleBrawlStarCharacters.TitleAddBrawlStarCharacters;

                //If no BrawlStarCharacters provided, initialize a new one and set button text to "Save"
                BrawlStarCharactersCollection = new List<BrawlStarCharacters>();

                ButtonText = "Save";
            }
        }

        //Command for saving or updating BrawlStarCharacters details
        public Command<BrawlStarCharacters> PerformSave
        {
            get
            {
                return new Command<BrawlStarCharacters>(async (BrawlStarCharacters BrawlStarCharacters) =>
                {
                    try
                    {
                        //Check for required data before save or update
                        if (string.IsNullOrEmpty(Country) || string.IsNullOrEmpty(City))
                        {
                            await Application.Current.MainPage.DisplayAlert("Message", "Country and City are required.", "Ok");
                            return;
                        }

                        if (ButtonText == "Save")
                        {
                            //Creating a new BrawlStarCharacters instance with ViewModel properties
                            BrawlStarCharacters = new BrawlStarCharacters
                            {
                                Id = Id,
                                Country = Country,
                                City = City,
                                Visited = Visited
                            };

                            //Save the new BrawlStarCharacters
                            string result = await _sqliteService.SaveBrawlStarCharacters(BrawlStarCharacters);

                            if (result == string.Empty)
                            {
                                //Send a message to notify about the addition of a new BrawlStarCharacters
                                MessagingCenter.Send<BrawlStarCharacters>(BrawlStarCharacters, "AddBrawlStarCharacters");

                                if (Application.Current.MainPage != null)
                                {
                                    await Application.Current.MainPage.Navigation.PopAsync();
                                }
                            }
                            else
                            {
                                await Application.Current.MainPage.DisplayAlert("Message", result, "Ok");
                            }
                        }
                        else
                        {
                            //Creating a new BrawlStarCharacters instance with ViewModel properties for an update
                            BrawlStarCharacters = new BrawlStarCharacters
                            {
                                Id = Id,
                                Country = Country,
                                City = City,
                                Visited = Visited
                            };

                            //Update the existing BrawlStarCharacters details
                            bool result = await _sqliteService.UpdateBrawlStarCharacters(BrawlStarCharacters);

                            if (result)
                            {
                                //Send a message to notify about the update of the BrawlStarCharacters
                                MessagingCenter.Send<BrawlStarCharacters>(BrawlStarCharacters, "UpdateBrawlStarCharacters");
                                await Application.Current.MainPage.Navigation.PopAsync();
                            }
                            else
                            {
                                await Application.Current.MainPage.DisplayAlert("Message", "Data Failed To Update", "Ok");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                    }
                });
            }
        }
    }
}
