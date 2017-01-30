CREATE TABLE [dbo].[Ticket]
(
	[Id] INT   IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
    [Id_SpecifiedVoyage] INT NULL, 
    [Id_Status] INT NULL, 
    [Id_Passenger] INT NULL, 
    [info] NVARCHAR(50) NULL, 
    [Id_Order] INT NULL, 
    [Id_User] NVARCHAR(128) NULL, 
    [SeatNumber] INT NULL, 
    CONSTRAINT [FK_Ticket_Status] FOREIGN KEY ([Id_Status]) REFERENCES [TicketStatus]([Id]),
	CONSTRAINT [FK_Ticket_Passenger] FOREIGN KEY ([Id_Passenger]) REFERENCES [Passenger]([Id]),
	CONSTRAINT [FK_Ticket_SpecVoyage] FOREIGN KEY ([Id_SpecifiedVoyage]) REFERENCES [SpecifiedVoyage]([Id]), 
    CONSTRAINT [FK_Ticket_Order] FOREIGN KEY ([Id_Order]) REFERENCES [Order]([Id])

)