
USE [dbmovies]
GO

INSERT INTO [dbo].[tblGenres]
           (Name ,Active)
     VALUES
           ('Ação',1)
GO

INSERT INTO [dbo].[tblGenres]
           (Name ,Active)
     VALUES
           ('Drama',1)
GO

INSERT INTO [dbo].[tblGenres]
           (Name ,Active)
     VALUES
           ('Aventura',1)
GO

INSERT INTO [dbo].[tblGenres]
           (Name ,Active)
     VALUES
           ('Comedia',1)
GO

INSERT INTO [dbo].[tblGenres]
           (Name ,Active)
     VALUES
           ('Terror',1)
GO

INSERT INTO [dbo].[tblGenres]
           (Name ,Active)
     VALUES
           ('Romance',1)
GO

INSERT INTO [dbo].[tblGenres]
           (Name ,Active)
     VALUES
           ('Documentário',1)
GO

INSERT INTO [dbo].[tblGenres]
           (Name ,Active)
     VALUES
           ('Fantasia',1)
GO

INSERT INTO [dbo].[tblGenres]
           (Name ,Active)
     VALUES
           ('Ficcção',1)
GO

INSERT INTO [dbo].[tblGenres]
           (Name ,Active)
     VALUES
           ('Nacional',1)
GO

USE [dbmovies]
GO

INSERT INTO [dbo].[tblCustomers]
           (Name, homeAddress ,Cpf ,Phone ,Email, DateCreate)
     VALUES
           ('Ana Martins','Poços de Caldas - MG', '084.000.705-14', '35998388202'
           , 'anamartins.sistemas@gmail.com' , DEFAULT )
GO

INSERT INTO [dbo].[tblCustomers]
           (Name
           ,homeAddress
           ,Cpf
           ,Phone
           ,Email, DateCreate)
     VALUES
           ('Carolina Martins'
           ,'Poços de Caldas - MG'
           , '083.000.704-14'
           , '35998388202'
           , 'carolinamartins.sistemas@gmail.com' , DEFAULT )
GO

INSERT INTO [dbo].[tblCustomers]
           (Name
           ,homeAddress
           ,Cpf
           ,Phone
           ,Email, DateCreate)
     VALUES
           ('Ana Silva'
           ,'Poços de Caldas - MG'
           , '082.000.706-14'
           , '35998388202'
           , 'ana.sistemas@gmail.com' , DEFAULT )
GO

INSERT INTO [dbo].[tblCustomers]
           (Name
           ,homeAddress
           ,Cpf
           ,Phone
           ,Email, DateCreate)
     VALUES
           ('Carolina Silva'
           ,'Poços de Caldas - MG'
           , '085.000.707-14'
           , '35998388202'
           , 'carolina.sistemas@gmail.com' , DEFAULT )
GO

INSERT INTO [dbo].[tblCustomers]
           (Name
           ,homeAddress
           ,Cpf
           ,Phone
           ,Email, DateCreate)
     VALUES
           ('João Martins'
           ,'Poços de Caldas - MG'
           , '088.000.706-14'
           , '35998388202'
           , 'joao.sistemas@gmail.com' , DEFAULT )
GO

INSERT INTO [dbo].[tblCustomers]
           (Name
           ,homeAddress
           ,Cpf
           ,Phone
           ,Email, DateCreate)
     VALUES
           ('André Martins'
           ,'Poços de Caldas - MG'
           , '081.000.709-14'
           , '35998388202'
           , 'andre.sistemas@gmail.com' , DEFAULT )
GO

INSERT INTO [dbo].[tblCustomers]
           (Name
           ,homeAddress
           ,Cpf
           ,Phone
           ,Email, DateCreate)
     VALUES
           ('Marcos Eduardo'
           ,'Poços de Caldas - MG'
           , '068.000.709-14'
           , '35998388202'
           , 'marcoseduardo@gmail.com' , DEFAULT )
GO

INSERT INTO [dbo].[tblCustomers]
           (Name
           ,homeAddress
           ,Cpf
           ,Phone
           ,Email, DateCreate)
     VALUES
           ('Ricardo Nogueira'
           ,'Poços de Caldas - MG'
           , '078.000.719-14'
           , '35998388202'
           , 'ricardo.sistemas@gmail.com' , DEFAULT )
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('Logan',1)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('Mulher Maravilha',1)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('Atômica',1)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('Star Wars - Os Últimos Jedi',1)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('Velozes & Furiosos 8',1)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('Jumanji: Bem-Vindo à Selva',2)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('Rei Arthur - A Lenda da Espada',2)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('Três Homens em Conflito',2)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('2001: Uma Odisseia no Espaço',2)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('O Senhor dos Anéis',2)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('Um Sonho de Liberdade',3)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('A Lista de Schindler',3)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('A Vida é Bela',3)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('Sempre ao Seu Lado',3)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('Histórias Cruzadas',3)
GO

USE [dbmovies]
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('One Direction: This Is Us',4)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('Katy Perry: Part of Me',4)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('O Sal da Terra',4)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('Cássia Eller',4)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('O Jardim das Aflições',4)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('A Bela e a Fera',5)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('A Viagem de Chihiro',5)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('Harry Potter -Câmara Secreta',5)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('Deadpool',5)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('O Mágico de Oz',5)
GO

USE [dbmovies]
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('Guerra nas Estrelas',6)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('Interestelar',6)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('A Origem',6)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('X-Men: Dias um Futuro',6)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           (' Matrix',6)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('Nada a Perder',7)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('Tropa de Elite 2',7)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('Nosso Lar',7)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('O Palhaço',7)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('Eu Te Amo',7)
GO

USE [dbmovies]
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('Corra!',8)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('Deixa ela entrar',8)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('IT',8)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('Audição',8)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('Sobrenatural',8)
GO

USE [dbmovies]
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('A Ressaca',9)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('As Branquelas',9)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('Click',9)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('Intocáveis',9)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('Monstros S.A',9)
GO

USE [dbmovies]
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('Simplesmente Acontece',10)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('Titanic',10)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('A Culpa é das Estrelas',10)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('Hoje Eu Quero Voltar Sozinho',10)
GO

INSERT INTO [dbo].[tblMovies]
           (Name,GenreID)
     VALUES
           ('Diário de uma Paixão',10)
GO
