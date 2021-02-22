using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Author: Wyatt T Putnam

namespace Lab1Part3
{
    public class Item
    {
        private String itemName;
        private int itemID;
        private double cost;

        // Default constructor
        public Item()
        {
            itemName = "";
            itemID = 0;
            cost = 0;
        }

        // Overloaded constructor
        public Item(String itemName, int itemID, double cost)
        {
            this.itemName = itemName;
            this.itemID = itemID;
            this.cost = cost;
        }

        // ItemName getter
        public String GetItemName()
        {
            return itemName;
        }

        // ItemID getter
        public int GetItemID()
        {
            return itemID;
        }

        // Cost getter
        public double GetCost()
        {
            return cost;
        }

        // ItemName setter
        public void SetItemName(String itemName)
        {
            this.itemName = itemName;
        }

        // ItemID setter
        public void SetItemID(int itemID)
        {
            this.itemID = itemID;
        }

        // Cost setter
        public void SetCost(double cost)
        {
            this.cost = cost;
        }

        // ToString method returns concatenated member variables.
        public String ToString()
        {
            String itemString = "Name: " + itemName + "\nID: " + itemID + "\nCost: " + cost;
            return itemString;
        }
    }
}