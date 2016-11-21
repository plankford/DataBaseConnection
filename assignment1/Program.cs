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

            //Create an instance of the Beverage Entities class
            //BeveragePLankfordEntities beveragePlankfordEntities = new BeveragePLankfordEntities();

            BeverageAPI beverageAPI = new BeverageAPI();

            //Display the Welcome Message to the user
            userInterface.DisplayWelcomeGreeting();

            //Display the Menu and get the response. Store the response in the choice integer
            //This is the 'primer' run of displaying and getting.
            int choice = userInterface.DisplayMenuAndGetResponse();

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
                        string searchQuery = userInterface.GetSearchQuery();
                        string itemInformation = beverageAPI.FindById(searchQuery);
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
                        string[] newItemInformation = userInterface.GetNewItemInformation();
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
                        string updateID = userInterface.GetUpdateString();
                        string updateItemInformation = beverageAPI.FindById(updateID);
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
