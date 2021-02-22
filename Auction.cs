using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Author: Wyatt T Putnam

namespace Lab1Part3
{
    // Class Auction extends Service
    public class Auction : Service
    {
        private int empID;

        // Default constructor
        public Auction()
        {
            empID = 0;
        }
        // Overloaded constructor
        public Auction(int empID, int customerID, int serviceID, int inventoryID, String date, double serviceCost) : base(customerID, serviceID, inventoryID, date, serviceCost)
        {
            this.empID = empID;
        }
        // EmpID getter and setter
        public int EmpID
        {
            get
            {
                return empID;
            }
            set
            {
                empID = value;
            }
        }
        // Auction's ToString method overrides Service's ToString
        public String ToString()
        {
            String auctionString = "Service type: Auction \n" + "Employee ID: " + empID + "\n" + base.ToString();
            return auctionString;
        }
    }
}