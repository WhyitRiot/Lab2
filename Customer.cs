using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Author: Wyatt T Putnam, Cole Schweikert, Shaima Sorchi

namespace Lab1Part3
{
    public class Customer
    {
        private String firstName;
        private String lastName;
        private int customerID;
        private String phone;
        private String address;

        // Default constructor
        public Customer()
        {
            firstName = "";
            lastName = "";
            customerID = 0;
            phone = "";
            address = "";
        }
        // Overloaded constructor
        public Customer(String firstName, String lastName, int customerID, String phone, String address)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.customerID = customerID;
            this.phone = phone;
            this.address = address;
        }

        // FirstName getter and setter
        public String FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        // LastName getter and setter
        public String LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        // SetName method allows a change to both firstName AND lastName if entire name is changed
        public void SetName(String firstName, String lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
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

        // Phone's getter and setter
        public String Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }

        // Address getter and setter
        public String Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        // ToString method concatenates all member variables with newline characters to create a neat list of attributes.
        public String ToString()
        {
            String customerString = lastName + ", " + firstName + "\n" + customerID + "\n" + phone + "\n" + address;
            return customerString;
        }
    }
}