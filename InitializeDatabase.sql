CREATE SCHEMA Teams AUTHORIZATION dbo
GO

CREATE TABLE Teams.Persons
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[SurName] VARCHAR(255) NOT NULL,
	[Name] VARCHAR(200) NULL,
	CONSTRAINT [PK_teams_Persons_Id] PRIMARY KEY ([Id] ASC)
)
GO

CREATE TABLE Teams.Countries
(
	[Id] INTEGER NOT NULL,
	[Name] VARCHAR(255) NULL,
	CONSTRAINT [PK_teams_Countries_Id] PRIMARY KEY ([Id] ASC)
)
GO

CREATE TABLE Teams.CountryTeams
(
	[Id] INTEGER NOT NULL,
	[CountryId] INTEGER NOT NULL,
	[Name] VARCHAR(200) NULL,
	CONSTRAINT [PK_teams_CountryTeams_Id] PRIMARY KEY ([Id] ASC)
)
GO

CREATE TABLE Teams.TeamNames
(
    [Id] INTEGER NOT NULL,
	[Name] VARCHAR(200) NULL,
	CONSTRAINT [PK_TeamNames_Id] PRIMARY KEY ([Id] ASC)
)
GO

INSERT INTO teams.TeamNames VALUES (1, 'A');
INSERT INTO Teams.TeamNames VALUES (2, 'B');
INSERT INTO Teams.TeamNames VALUES (3, 'C');
INSERT INTO Teams.TeamNames VALUES (4, 'D');
INSERT INTO Teams.TeamNames VALUES (5, 'E');
INSERT INTO Teams.TeamNames VALUES (6, 'F');
INSERT INTO Teams.TeamNames VALUES (7, 'G');
INSERT INTO Teams.TeamNames VALUES (8, 'H');

INSERT INTO teams.Countries VALUES (1, 'Turkiye');
INSERT INTO Teams.Countries VALUES (2, 'Almanya');
INSERT INTO Teams.Countries VALUES (3, 'Fransa');
INSERT INTO Teams.Countries VALUES (4, 'Hollanda');
INSERT INTO Teams.Countries VALUES (5, 'Portekiz');
INSERT INTO Teams.Countries VALUES (6, 'Italya');
INSERT INTO Teams.Countries VALUES (7, 'Ispanya');
INSERT INTO Teams.Countries VALUES (8, 'Belcika');

INSERT INTO Teams.CountryTeams VALUES (1,1, 'Adesso Istanbul');
INSERT INTO Teams.CountryTeams VALUES (2,1, 'Adesso Izmir');
INSERT INTO Teams.CountryTeams VALUES (3,1, 'Adesso Ankara');
INSERT INTO Teams.CountryTeams VALUES (4,1, 'Adesso Antalya');
INSERT INTO Teams.CountryTeams VALUES (5,2, 'Adesso Berlin');
INSERT INTO Teams.CountryTeams VALUES (6,2, 'Adesso Franfurt');
INSERT INTO Teams.CountryTeams VALUES (7,2, 'Adesso Munih');
INSERT INTO Teams.CountryTeams VALUES (8,2, 'Adesso Dortmunt');
INSERT INTO Teams.CountryTeams VALUES (9,3, 'Adesso Paris');
INSERT INTO Teams.CountryTeams VALUES (10,3, 'Adesso Marsilya');
INSERT INTO Teams.CountryTeams VALUES (11,3, 'Adesso Lice');
INSERT INTO Teams.CountryTeams VALUES (12,3, 'Adesso Lyon');
INSERT INTO Teams.CountryTeams VALUES (13,4, 'Adesso Amsterdam');
INSERT INTO Teams.CountryTeams VALUES (14,4, 'Adesso Rotterdam');
INSERT INTO Teams.CountryTeams VALUES (15,4, 'Adesso Lahey');
INSERT INTO Teams.CountryTeams VALUES (16,4, 'Adesso Eindhoven');
INSERT INTO Teams.CountryTeams VALUES (17,5, 'Adesso Lisbon');
INSERT INTO Teams.CountryTeams VALUES (18,5, 'Adesso Porto');
INSERT INTO Teams.CountryTeams VALUES (19,5, 'Adesso Braga');
INSERT INTO Teams.CountryTeams VALUES (20,5, 'Adesso Coimbra');
INSERT INTO Teams.CountryTeams VALUES (21,6, 'Adesso Roma');
INSERT INTO Teams.CountryTeams VALUES (22,6, 'Adesso Milano');
INSERT INTO Teams.CountryTeams VALUES (23,6, 'Adesso Venedik');
INSERT INTO Teams.CountryTeams VALUES (24,6, 'Adesso Napoli');
INSERT INTO Teams.CountryTeams VALUES (25,7, 'Adesso Sevilla');
INSERT INTO Teams.CountryTeams VALUES (26,7, 'Adesso Madrid');
INSERT INTO Teams.CountryTeams VALUES (27,7, 'Adesso Barselona');
INSERT INTO Teams.CountryTeams VALUES (28,7, 'Adesso Granada');
INSERT INTO Teams.CountryTeams VALUES (29,8, 'Adesso Bruksel');
INSERT INTO Teams.CountryTeams VALUES (30,8, 'Adesso Brugge');
INSERT INTO Teams.CountryTeams VALUES (31,8, 'Adesso Gent');
INSERT INTO Teams.CountryTeams VALUES (32,8, 'Adesso Anvers');
GO
--INSERT INTO orders.Customers VALUES ('C75399FC-CD06-4F61-93E8-0D2147B00557', 'mehmet97ali@gmail.com', 'Mehmet Ali Tosun');

CREATE SCHEMA app AUTHORIZATION dbo
GO

CREATE TABLE app.OutboxMessages
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[OccurredOn] DATETIME2 NOT NULL,
	[Type] VARCHAR(255) NOT NULL,
	[Data] VARCHAR(MAX) NOT NULL,
	[ProcessedDate] DATETIME2 NULL,
	CONSTRAINT [PK_app_OutboxMessages_Id] PRIMARY KEY ([Id] ASC)
)
GO

CREATE TABLE app.InternalCommands
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[EnqueueDate] DATETIME2 NOT NULL,
	[Type] VARCHAR(255) NOT NULL,
	[Data] VARCHAR(MAX) NOT NULL,
	[ProcessedDate] DATETIME2 NULL,
	CONSTRAINT [PK_app_InternalCommands_Id] PRIMARY KEY ([Id] ASC)
)
GO

CREATE VIEW teams.v_Persons
AS
(
	SELECT
		[Person].[Id],
		[Person].[Surname],
		[Person].[Name]
	FROM [teams].[Persons] AS [Person]
)
GO

CREATE VIEW teams.v_CountryTeams
AS
(
SELECT
	[CountryTeam].[Id],
	[CountryTeam].[CountryId],
	[CountryTeam].[Name]
FROM [teams].[CountryTeams] AS [CountryTeam]
)
GO