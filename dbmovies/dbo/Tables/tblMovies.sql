CREATE TABLE tblMovies (      
MovieID int IDENTITY(1,1) NOT NULL PRIMARY KEY,      
Name varchar(30) NOT NULL ,      
DateCreate timestamp NULL ,      
Active bit DEFAULT 1 NULL ,      
GenreID int NOT NULL       
)
GO
ALTER TABLE tblMovies
ADD CONSTRAINT FK_GenresMovies
FOREIGN KEY (GenreID) REFERENCES tblGenres(GenreID);