CREATE TABLE [dbo].[Order]
(
	[Id] INT   IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
    [Id_SpecifiedVoyage] INT NULL, 
    [Id_Status] INT NULL, 
    [Id_User] NVARCHAR(128) NULL, 
    CONSTRAINT [FK_Order_Status] FOREIGN KEY ([Id_Status]) REFERENCES [OrderStatus]([Id]), 
	CONSTRAINT [FK_Order_SpecVoyage] FOREIGN KEY ([Id_SpecifiedVoyage]) REFERENCES [SpecifiedVoyage]([Id])	
)