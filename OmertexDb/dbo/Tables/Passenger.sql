CREATE TABLE [dbo].[Passenger]
(
	[Id] INT   IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
    [Firstname] NVARCHAR(50) NULL, 
    [Surname] NVARCHAR(50) NULL, 
    [Birthdate] DATETIME NULL, 
    [DocumentNumber] NVARCHAR(50) NULL, 
    [SeatNumber] INT NULL, 
    [Id_UserCreated] NVARCHAR(128) NULL, 
    
)