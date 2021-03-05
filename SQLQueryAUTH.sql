USE AUTH;

CREATE TABLE Person (

UserID int IDENTITY (1,1),

FirstName varchar(20),

LastName varchar(30),

Username varchar (20),

UserEmail varchar(40),

UserPhone varchar(40),

UserAddress varchar(80)

PRIMARY KEY (UserID));
 

CREATE TABLE Pass (

UserID int,

Username varchar(30),

PasswordHash varchar(256),

PRIMARY KEY (UserID),
FOREIGN KEY (UserID) references Person (UserID)
);

 

INSERT INTO Person (FirstName, LastName, UserName, UserEmail) VALUES ('Jeremy', 'Ezell', 'admin', 'jeremy.ezell@jmu.edu');

INSERT INTO Pass (UserID, Username, PasswordHash) VALUES ('1','admin', '1000:N4xiyBysNCw3IIJg6tT0lCISUVDIzyk2:GyY1JTgR6NLal1xqOxa0IUzRxvY=');

USE AUTH;

Select * from person;
Select * from pass;