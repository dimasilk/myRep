CREATE TABLE [dbo].[SpecifiedVoyage]
(
	[Id] INT   IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
    [Id_BusStopDeparture] INT NULL, 
    [Id_BusStopArrival] INT NULL, 
    [DatetimeDeparture] DATETIME NULL, 
    [DatetimeArrival] DATETIME NULL, 
    [TravelTime] BIGINT NULL, 
    [VoyageName] NVARCHAR(50) NULL, 
    [VoyageNumber] INT NULL, 
    [NumberOfSeats] INT NULL, 
    [TicketCost] INT NULL, 
    CONSTRAINT [FK_SpecifiedVoyage_BusStopDep] FOREIGN KEY ([Id_BusStopDeparture]) REFERENCES [Busstop]([Id]), 
    CONSTRAINT [FK_SpecifiedVoyage_BusStopArr] FOREIGN KEY ([Id_BusStopArrival]) REFERENCES [Busstop]([Id])
	
)