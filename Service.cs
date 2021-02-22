using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Author: Wyatt T Putnam

namespace Lab1Part3
{
    public class Service
    {
        private int customerID;
        private int serviceID;
        private int inventoryID;
        private String date;
        private double serviceCost;

        //Default constructor
        public Service()
        {
            customerID = 0;
            serviceID = 0;
            inventoryID = 0;
            date = "";
            serviceCost = 0;
        }

        // Overloaded constructor
        public Service(int customerID, int serviceID, int inventoryID, String date, double serviceCost)
        {
            this.customerID = customerID;
            this.serviceID = serviceID;
            this.inventoryID = inventoryID;
            this.date = date;
            this.serviceCost = serviceCost;
        }

        // CustomerID getter and setter
        public int CustomerID
        {
            get
            {
                return customerID;
            }
            set
            {
                customerID = value;
            }
        }

        // ServiceID getter and setter
        public int ServiceID
        {
            get
            {
                return serviceID;
            }
            set
            {
                serviceID = value;
            }
        }

        // InventoryID getter and setter
        public int InventoryID
        {
            get
            {
                return inventoryID;
            }
            set
            {
                inventoryID = value;
            }
        }

        // Date getter and setter
        public String Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }

        // ServiceCost getter and setter
        public double ServiceCost
        {
            get
            {
                return serviceCost;
            }
            set
            {
                serviceCost = value;
            }
        }

        // ToString method returns concatenated member variables.
        public String ToString()
        {
            String serviceString = "Customer ID: " + customerID + "\nID: " + serviceID + "\nInventory ID: " + inventoryID + "\nDate: " + date + "\nCost :" + serviceCost;
            return serviceString;
        }

    }
}