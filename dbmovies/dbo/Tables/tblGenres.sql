CREATE TABLE tblGenres (      
GenreID int IDENTITY(1,1) NOT NULL PRIMARY KEY,      
Name varchar(30) NOT NULL ,     
DateCreate timestamp NULL ,
Active bit DEFAULT 1 NULL  
)