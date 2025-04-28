-- MySQL schema
CREATE DATABASE library_management_system;
USE library_management_system;

CREATE TABLE Users (
    UserID INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(50) NOT NULL,
    UserType VARCHAR(10) NOT NULL CHECK (UserType IN ('Admin', 'Basic')),
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE Books (
    BookID INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Author VARCHAR(100) NOT NULL,
    Category VARCHAR(50) NOT NULL,
    ISBN VARCHAR(20) NOT NULL UNIQUE,
    Availability VARCHAR(10) NOT NULL DEFAULT 'Available' CHECK (Availability IN ('Available', 'Borrowed')),
    AddedDate DATETIME DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE BorrowedBooks (
    BorrowID INT AUTO_INCREMENT PRIMARY KEY,
    BookID INT NOT NULL,
    UserID INT NOT NULL,
    BorrowDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    ReturnDate DATETIME,
    Status VARCHAR(10) NOT NULL DEFAULT 'Active' CHECK (Status IN ('Active', 'Returned')),
    FOREIGN KEY (BookID) REFERENCES Books(BookID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

INSERT INTO Users (Username, Password, UserType) 
VALUES ('admin', 'admin123', 'Admin');