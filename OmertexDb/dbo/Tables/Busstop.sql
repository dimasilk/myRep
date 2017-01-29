CREATE TABLE [dbo].[Busstop]
(
	[Id] INT   IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Id_BusStopStatus] INT NULL, 
    CONSTRAINT [FK_BusstopStatus] FOREIGN KEY ([Id_BusStopStatus]) REFERENCES [BusStopStatus]([Id])
)