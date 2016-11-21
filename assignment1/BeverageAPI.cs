//Author: Patrick Lankford
//CIS 237
//Assignment 5
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class BeverageAPI
    {
        //Private Variables
        BeveragePLankfordEntities beveragePlankfordEntities = new BeveragePLankfordEntities();

        //Constuctor
        public BeverageAPI()
        {
            
        }

        //Add a new item to the collection
        public void AddNewItem(string id, string description, string pack)
        {
            Beverage newBeverageToAdd = new Beverage();

            newBeverageToAdd.id = id;
            newBeverageToAdd.name = description;
            newBeverageToAdd.pack = pack;

            try
            {
                beveragePlankfordEntities.Beverages.Add(newBeverageToAdd);
                beveragePlankfordEntities.SaveChanges();
            }
            catch (Exception e)
            {
                beveragePlankfordEntities.Beverages.Remove(newBeverageToAdd);
                Console.WriteLine("Beverage not added. One already exists in the collection");
            }

            return;
        }

        //Get The Print String Array For All Items
        public void PrintAllBeverages()
        {
            foreach (Beverage beverage in beveragePlankfordEntities.Beverages)
            {
                Console.WriteLine(beverage.id + " " + beverage.name + " " + beverage.pack + " " + beverage.price);
            }
        }

        //Find an item by it's Id
        public string FindById(string id)
        {
            //Declare return string for the possible found item
           string returnString = null;

            Beverage foundBeverage = beveragePlankfordEntities.Beverages.Find(id);

            if (foundBeverage != null)
            {
                returnString = foundBeverage.id + " " + foundBeverage.name + " " + foundBeverage.pack + " " + foundBeverage.price;
            }
            
            return returnString;
        }

        public void UpdateItem(string id, string name, string pack, string price)
        {
            Beverage beverageToUpdate = beveragePlankfordEntities.Beverages.Find(id);

            beverageToUpdate.name = name;
            beverageToUpdate.pack = pack;
            beverageToUpdate.price = Convert.ToDecimal(price);

            beveragePlankfordEntities.SaveChanges();
        }

        public void DeleteItem(string id)
        {
            //Find the item to delete
            Beverage beverageToDelete = beveragePlankfordEntities.Beverages.Find(id);

            //Delete the item
            beveragePlankfordEntities.Beverages.Remove(beverageToDelete);

            //Save the changes
            beveragePlankfordEntities.SaveChanges();

            //Check and make sure the item was deleted
            beverageToDelete = beveragePlankfordEntities.Beverages.Find(id);
            if (beverageToDelete == null)
            {
                Console.WriteLine("The item has been successfully deleted");
            }
            else
            {
                Console.WriteLine("Item failed to delete");
            }
        }

    }
}
