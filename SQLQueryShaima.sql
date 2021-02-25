Use Lab2;

CREATE TABLE Customer
(
CustomerID int,
FirstName varchar(8000),
LastName varchar(8000),
Phone varchar(8000),
"Address" varchar(8000),

PRIMARY KEY (CustomerID)
);
CREATE TABLE Employee
(
empID int,
firstName varchar(8000),
lastName varchar(8000),
phone varchar(8000),

PRIMARY KEY (empID)
);
CREATE TABLE "Service"
(
CustomerID int,
ServiceID int,
InventoryID int,
"Date" varchar(8000),
ServiceCost float,

PRIMARY KEY (ServiceID),
FOREIGN KEY (CustomerID) REFERENCES Customer (CustomerID)
);
CREATE TABLE "Move"
(
ServiceID int,
empID int,
originAddress varchar(8000),
destAddress varchar(8000),

FOREIGN KEY (ServiceID) REFERENCES "Service" (ServiceID),
FOREIGN KEY (empID) REFERENCES Employee (empID)
);
CREATE TABLE Auction
(
ServiceID int,
empID int,

FOREIGN KEY (ServiceID) REFERENCES "Service" (ServiceID),
FOREIGN KEY (empID) REFERENCES Employee (empID)
);
CREATE TABLE Item
(
itemID int,
itemName varchar(8000),
itemCost float,

PRIMARY KEY (itemID)
);
CREATE TABLE Inventory
(
inventoryID int,
CustomerID int,
itemID int,
"date" varchar(8000),

PRIMARY KEY (inventoryID),
FOREIGN KEY (CustomerID) REFERENCES Customer (CustomerID),
FOREIGN KEY (itemID) REFERENCES Item (itemID)
);

CREATE TABLE Service_Ticket
(
ServiceTicketID int,
TicketStatus varchar(8000),
TicketOpenDate date,
CustomerID int,
ServiceID int,
empID int,

PRIMARY KEY (ServiceTicketID),
FOREIGN KEY (CustomerID) REFERENCES Customer (CustomerID),
FOREIGN KEY (empID) REFERENCES Employee (empID)
);

CREATE TABLE TicketHistory
(
TicketHistoryID int,
TicketChangeDate varchar(8000),
ServiceTicketID int,
empID int,

PRIMARY KEY (TicketHistoryID),
FOREIGN KEY (ServiceTicketID) REFERENCES Service_Ticket (ServiceTicketID),
FOREIGN KEY (empID) REFERENCES Employee (empID)
);

CREATE TABLE DetailsNote
(
DetailsNoteID int,
ServiceTicketID int,
NoteTitle varchar(50),
NoteBody varchar(8000),

PRIMARY KEY (DetailsNoteID),
FOREIGN KEY (ServiceTicketID) REFERENCES Service_Ticket (ServiceTicketID)
);



ALTER TABLE Customer
ADD Email varchar(8000),
ContactMethod varchar(8000),
ServiceType varchar(8000),
MethodType varchar(8000);




INSERT INTO Customer (CustomerID, FirstName, LastName, Phone, "Address", Email, ContactMethod, MethodType, ServiceType) VALUES
(1, 'Wyatt', 'Putnam', '757-817-2307', '123 Street, Harrisonburg, VA, 22801', 'WyattPutnam@email.com', '','','Moving')
INSERT INTO Customer (CustomerID, FirstName, LastName, Phone, "Address", Email, ContactMethod, MethodType, ServiceType) VALUES
(2, 'Jim', 'Halpert', '570-555-6127', '123 Avenue, Scranton, PA, 18503','JimHalpert@email.com', '','','Auction')
INSERT INTO Customer (CustomerID, FirstName, LastName, Phone, "Address", Email, ContactMethod, MethodType, ServiceType) VALUES
(3, 'Pam', 'Beesly', '570-555-6128', '123 Avenue, Scranton, PA, 18503', 'PamBeesly@email.com','','','Moving')

INSERT INTO Employee (empID, firstName, lastName, phone) VALUES
(1, 'James', 'Bond', '555-555-5565')

INSERT INTO Employee (empID, firstName, lastName, phone) VALUES
(2, 'Jason', 'Bourne', '555-555-5566')

INSERT INTO Employee (empID, firstName, lastName, phone) VALUES
(3, 'Austin', 'Powers', '555-555-5567')

INSERT INTO "Service" (CustomerID, ServiceID, InventoryID, "Date", ServiceCost) VALUES
(1, 1, 1, '02/01/2021', 50)

INSERT INTO Service_Ticket (ServiceTicketID, TicketStatus, TicketOpenDate, CustomerID, ServiceID, empID) VALUES
(1, 'Open', '02/12/2021', 1, 1, 1)

INSERT INTO TicketHistory (TicketHistoryID, TicketChangeDate, ServiceTicketID, empID) Values
(1, '02/12/2021', 1, 1)

INSERT INTO Item (itemID, itemName, itemCost) VALUES
(1, 'Lamp', 100)

INSERT INTO Inventory (inventoryID, CustomerID, ItemID, "date") VALUES
(1, 1, 1, '02/01/2021')

INSERT INTO "Service" (CustomerID, ServiceID, InventoryID, "Date", ServiceCost) VALUES
(2, 2, 2, '02/01/2021', 25)

INSERT INTO Item (itemID, itemName, itemCost) VALUES
(2, 'Couch', 1000)

INSERT INTO Inventory (inventoryID, CustomerID, ItemID, "date") VALUES
(2, 2, 2, '02/01/2021')

INSERT INTO "Service" (CustomerID, ServiceID, InventoryID, "Date", ServiceCost) VALUES
(3, 3, 3, '02/01/2021', 66)

INSERT INTO Item (itemID, itemName, itemCost) VALUES
(3, 'Bed', 500)

INSERT INTO Inventory (inventoryID, CustomerID, ItemID, "date") VALUES
(3, 3, 3, '02/01/2021')

INSERT INTO "Move" (ServiceID, empID, originAddress, destAddress) VALUES
(1, 1, '123 Street, Harrisonburg, VA, 22801', '124 Street, Harrisonburg, VA, 22801')

INSERT INTO "Move" (ServiceID, empID, originAddress, destAddress) VALUES
(2, 2, '123 Avenue, Scranton, PA, 18503', '124 Avenue, Scranton, PA, 18503')

INSERT INTO Auction (ServiceID, empID) VALUES
(3, 3)

select * from Customer;