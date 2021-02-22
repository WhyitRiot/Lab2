using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Author: Wyatt T Putnam

namespace Lab1Part3
{
    public class Inventory
    {
        private int size;
        private int inventoryID;
        private String date;
        private int customerID;
        private Item[] inventoryArray;

        // Default constructor
        public Inventory()
        {
            size = 10;
            inventoryID = 0;
            date = "01/01/1970";
            inventoryArray = new Item[size];
        }

        // Overloaded constructor
        public Inventory(int size, int inventoryID, String date, int customerID)
        {
            this.size = size;
            this.inventoryID = inventoryID;
            this.date = date;
            this.customerID = customerID;
            inventoryArray = new Item[size];
        }

        // AddItem method adds an item to the inventoryArray at the next null index
        public int AddItem(String itemName, int itemID, double cost)
        {
            for (int i = 0; i < size; i++)
            {
                if (inventoryArray[i] == null)
                {
                    inventoryArray[i] = new Item(itemName, itemID, cost);
                    return 1;
                }
            }
            return 0;
        }

        // RemoveItem method removes a specific item from the inventoryArray
        public int RemoveItem(int itemID)
        {
            for (int i = 0; i < size; i++)
            {
                if (inventoryArray[i].GetItemID() == itemID)
                {
                    inventoryArray[i] = null;
                    return 1;
                }
            }
            return 0;
        }

        // Size getter
        public int GetSize()
        {
            return size;
        }

        // InventoryID getter
        public int GetInventoryID()
        {
            return inventoryID;
        }

        // Date getter
        public String GetDate()
        {
            return date;
        }

        // CustomerID getter
        public int GetCustomerID()
        {
            return customerID;
        }

        // ItemID getter
        public Item GetItemID(int itemID)
        {
            for (int i = 0; i < size; i++)
            {
                if (inventoryArray[i].GetItemID() == itemID)
                {
                    return inventoryArray[i];
                }
            }
            return null;
        }

        // Size setter
        public void SetSize(int size)
        {
            this.size = size;
        }

        // InventoryID setter
        public void SetInventoryID(int inventoryID)
        {
            this.inventoryID = inventoryID;
        }

        // Date setter
        public void SetDate(String date)
        {
            this.date = date;
        }

        // CustomerID setter
        public void SetCustomerID(int customerID)
        {
            this.customerID = customerID;
        }

        // ToString method returns all member variables and a list of items in the inventory.
        public String ToString()
        {
            String inventoryString = "Size: " + size + "\nID: " + inventoryID + "\nDate :" + date + "\nCustomer ID: " + customerID + "\n";
            for (int i = 0; i < size; i++)
            {
                if (inventoryArray[i] != null)
                {
                    inventoryString += (i + 1) + ": " + inventoryArray[i].GetItemName() + "\n";
                }
                else
                {
                    break;
                }
            }
            return inventoryString;
        }
    }
}