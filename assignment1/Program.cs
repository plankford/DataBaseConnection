//Author: Patrick Lankford
//CIS 237
//Assignment 5
/*
 * The Menu Choices Displayed By The UI
 * 1. Load Wine List From CSV
 * 2. Print The Entire List Of Items
 * 3. Search For An Item
 * 4. Add New Item To The List
 * 5. Exit Program
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
           

            //Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();

            //Create and instance of the BeverageAPI
            BeverageAPI beverageAPI = new BeverageAPI();

            //Display the Welcome Message to the user
            userInterface.DisplayWelcomeGreeting();

            //Display the Menu and get the response. Store the response in the choice integer
            //This is the 'primer' run of displaying and getting.
            int choice = userInterface.DisplayMenuAndGetResponse();

            //While the user choice is not 6 we will continue to display the menu
            while (choice != 6)
            {
                switch (choice)
                {
                    case 1:
                        //Print Entire List Of Items
                        beverageAPI.PrintAllBeverages();
                        break;

                    case 2:
                        //Search For An Item
                        //Create the string that will be used to search for and item
                        string searchQuery = userInterface.GetSearchQuery();

                        //Find the beverage item using the searchQuery string
                        string itemInformation = beverageAPI.FindById(searchQuery);

                        //See if there is an item in the string. If the string is null then the item does not exist
                        if (itemInformation != null)
                        {
                            userInterface.DisplayItemFound(itemInformation);
                        }
                        else
                        {
                            userInterface.DisplayItemFoundError();
                        }
                        break;

                    case 3:
                        //Add A New Item To The List
                        //Create the string for the new item
                        string[] newItemInformation = userInterface.GetNewItemInformation();

                        //Check to see if the item already exists in the collection
                        //If the item exist display the message that it does
                        if (beverageAPI.FindById(newItemInformation[0]) == null)
                        {
                            beverageAPI.AddNewItem(newItemInformation[0], newItemInformation[1], newItemInformation[2]);
                            userInterface.DisplayAddWineItemSuccess();
                        }
                        else
                        {
                            userInterface.DisplayItemAlreadyExistsError();
                        }
                        break;
                    case 4:
                        //Update An Existing item 
                        //Create the string for the updated item                       
                        string updateID = userInterface.GetUpdateString();

                        //Find the item that will be updated to display for the user
                        string updateItemInformation = beverageAPI.FindById(updateID);

                        //If the item exist in the collection it will be displayed for the user to update
                        //If no item exist display the error message that it was not found
                        if (updateItemInformation != null)
                        {
                           string[] updateInformation = userInterface.DisplayUpdateString(updateItemInformation);
                           beverageAPI.UpdateItem(updateID, updateInformation[0], updateInformation[1], updateInformation[2]);
                        }
                        else
                        {
                            userInterface.DisplayItemFoundError();
                        }
                        
                        break;

                    case 5:
                        //Delete An Existing item
                        string deleteString = userInterface.GetDeleteString();
                        beverageAPI.DeleteItem(deleteString);
                        break;
                }

                //Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }

        }
    }
}
