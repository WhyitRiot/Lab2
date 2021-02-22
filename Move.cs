using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Author: Wyatt T Putnam

namespace Lab1Part3
{
    // Move extends Service
    public class Move : Service
    {
        private int empID;
        private String originAddress;
        private String destAddress;

        // Default constructor
        public Move()
        {
            empID = 0;
            originAddress = "";
            destAddress = "";
        }

        // Overloaded constructor
        public Move(int empID, String originAddress, String destAddress, int customerID, int serviceID, int inventoryID, String date, double serviceCost) : base(customerID, serviceID, inventoryID, date, serviceCost)
        {
            this.empID = empID;
            this.originAddress = originAddress;
            this.destAddress = destAddress;
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

        // OriginAddress getter and setter
        public String OriginAddress
        {
            get
            {
                return originAddress;
            }
            set
            {
                originAddress = value;
            }
        }

        // DestAddress getter and setter
        public String DestAddress
        {
            get
            {
                return destAddress;
            }
            set
            {
                destAddress = value;
            }
        }

        // ToString method returns all member variables and inheritted variables.
        public String ToString()
        {
            String moveString = "Employee ID: " + empID + "\nOrigin Address: " + originAddress + "\nDestination Address: " + destAddress + "\n" + base.ToString();
            return moveString;
        }

    }
}