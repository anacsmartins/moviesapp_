CREATE TABLE tblLocation (      
LocationID int IDENTITY(1,1) NOT NULL PRIMARY KEY,  
DateLocation timestamp NULL ,
MovieID int  NOT NULL  ,
CustomerID int  NOT NULL  
)
GO
ALTER TABLE tblLocation
ADD CONSTRAINT FK_LocationMovies
FOREIGN KEY (MovieID) REFERENCES tblMovies(MovieID);
GO
ALTER TABLE tblLocation
ADD CONSTRAINT FK_LocationCustomers
FOREIGN KEY (CustomerID) REFERENCES tblCustomers(CustomerID);