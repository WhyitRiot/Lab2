using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Author: Wyatt T Putnam

namespace Lab1Part3
{
    public class Employee
    {
        private int empID;
        private String firstName;
        private String lastName;
        private String phone;

        // Default constructor
        public Employee()
        {
            empID = 0;
            firstName = "";
            lastName = "";
            phone = "";
        }

        // Overloaded constructor
        public Employee(int empID, String firstName, String lastName, String phone)
        {
            this.empID = empID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phone = phone;
        }

        // EmpID getter
        public int GetEmpID()
        {
            return empID;
        }

        // FirstName getter
        public String GetFirstName()
        {
            return firstName;
        }

        // LastName getter
        public String GetLastName()
        {
            return lastName;
        }

        // Phone getter
        public String GetPhone()
        {
            return phone;
        }

        // EmpID getter
        public void GetEmpID(int empID)
        {
            this.empID = empID;
        }

        // SetName method changes both firstName AND lastName
        public void SetName(String firstName, String lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        // Phone setter
        public void SetPhone(String phone)
        {
            this.phone = phone;
        }

        // ToString method returns neat list of member variables
        public String ToString()
        {
            String empString = "Name: " + lastName + ", " + firstName + "\nID: " + empID + "\nPhone: " + phone;
            return empString;
        }
    }
}