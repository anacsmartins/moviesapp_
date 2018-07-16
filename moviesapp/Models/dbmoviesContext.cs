using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace moviesapp.Models
{
    public partial class dbmoviesContext : DbContext
    {
        public virtual DbSet<TblCustomers> TblCustomers { get; set; }
        public virtual DbSet<TblGenres> TblGenres { get; set; }
        public virtual DbSet<TblLocation> TblLocation { get; set; }
        public virtual DbSet<TblMovies> TblMovies { get; set; }
        public virtual DbSet<TblLogin> TblLogin { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                //optionsBuilder.UseSqlServer(@"Data Source=Usuario-PC\MSSQL12;Initial Catalog=dbmovies;User Id=ana;Password_=Ca22rol76");
                //optionsBuilder.UseSqlServer(@"Server=http:dbappmovies.database.windows.net,1433;Initial Catalog=dbmovies;Persist Security Info=False;User ID={ana};Password_={Ca22rol76};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                optionsBuilder.UseSqlServer(@"Data Source=dbappmovies.database.windows.net;Initial Catalog=dbmovies;User Id=ana;Password_=Ca22rol76"); 
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCustomers>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("tblCustomers");

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__tblCusto__C1FF93094791BC38")
                    .IsUnique();

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreate)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HomeAddress)
                    .HasColumnName("homeAddress")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblGenres>(entity =>
            {
                entity.HasKey(e => e.GenreId);

                entity.ToTable("tblGenres");

                entity.Property(e => e.GenreId).HasColumnName("GenreID");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.DateCreate)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLocation>(entity =>
            {
                entity.HasKey(e => e.LocationId);

                entity.ToTable("tblLocation");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DateLocation).HasDefaultValueSql("(("+DateTime.Now.ToString()+"))")
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MovieId).HasColumnName("MovieID");
            });

            modelBuilder.Entity<TblMovies>(entity =>
            {
                entity.HasKey(e => e.MovieId);

                entity.ToTable("tblMovies");

                entity.Property(e => e.MovieId).HasColumnName("MovieID");

                entity.Property(e => e.GenreId).HasColumnName("GenreID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLogin>(entity =>
            {
                entity.HasKey(e => e.LoginId);

                entity.ToTable("tblLogin");

                entity.Property(e => e.LoginId).HasColumnName("LoginID");                

                entity.Property(e => e.Password_)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);              

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });
        }
    }
}


/*
 
CREATE DATABASE dbmovies

CREATE TABLE tblMovies (      
MovieID int IDENTITY(1,1) NOT NULL PRIMARY KEY,      
Name varchar(30) NOT NULL ,      
DateCreate timestamp NULL ,      
Active bit DEFAULT 1 NULL ,      
GenreID int NOT NULL       
)      
GO      
      
CREATE TABLE tblGenres (      
GenreID int IDENTITY(1,1) NOT NULL PRIMARY KEY,      
Name varchar(30) NOT NULL ,     
DateCreate timestamp NULL ,
Active bit DEFAULT 1 NULL  
)      
GO  


CREATE TABLE tblLocation (      
LocationID int IDENTITY(1,1) NOT NULL PRIMARY KEY,  
DateLocation timestamp NULL ,
MovieID int  NOT NULL  ,
CustomerID int  NOT NULL  
)      
GO  

CREATE TABLE tblCustomers (      
CustomerID int IDENTITY(1,1) NOT NULL PRIMARY KEY,    
Name varchar(30) NOT NULL , 
homeAddress varchar(50) NULL , 
Cpf varchar(14) UNIQUE NOT NULL ,     
Phone varchar(12) NULL ,    
Email varchar(50) ,  
DateCreate timestamp NULL 
)      
GO  


ALTER TABLE tblMovies
ADD CONSTRAINT FK_GenresMovies
FOREIGN KEY (GenreID) REFERENCES tblGenres(GenreID);

ALTER TABLE tblLocation
ADD CONSTRAINT FK_LocationMovies
FOREIGN KEY (MovieID) REFERENCES tblMovies(MovieID);

ALTER TABLE tblLocation
ADD CONSTRAINT FK_LocationCustomers
FOREIGN KEY (CustomerID) REFERENCES tblCustomers(CustomerID);


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

     */
