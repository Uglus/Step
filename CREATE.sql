﻿CREATE TABLE [Halls] (
	Id int NOT NULL identity,
	Name nvarchar(50) NOT NULL,
  CONSTRAINT [PK_HALLS] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Session] (
	Id int NOT NULL identity,
	HallId int NOT NULL,
	DateTime datetime NOT NULL,
	FilmId int NOT NULL,
  CONSTRAINT [PK_SESSION] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Plases] (
	Id int NOT NULL identity,
	HallId int NOT NULL,
	Row int NOT NULL,
  CONSTRAINT [PK_PLASES] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Tickets] (
	PlaceId int NOT NULL,
	SessionId int NOT NULL,
	Id int NOT NULL identity,
	DateTime datetime NOT NULL,

  constraint fk_Tickets_SessionId foreign key (SessionId) references Session(Id),
  CONSTRAINT [PK_TICKETS] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Films] (
	Id int NOT NULL identity,
	Name nvarchar(50) NOT NULL,
	CategoryId int NOT NULL,
	AgeId int NOT NULL,
  CONSTRAINT [PK_FILMS] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Category] (
	Id int NOT NULL identity,
	Name nvarchar(50) NOT NULL,
  CONSTRAINT [PK_CATEGORY] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [AgeRestriction] (
	Id int NOT NULL identity,
	Age int NOT NULL,
  CONSTRAINT [PK_AGERESTRICTION] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO

ALTER TABLE [Session] WITH CHECK ADD CONSTRAINT [Session_fk0] FOREIGN KEY ([HallId]) REFERENCES [Halls]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Session] CHECK CONSTRAINT [Session_fk0]
GO
ALTER TABLE [Session] WITH CHECK ADD CONSTRAINT [Session_fk1] FOREIGN KEY ([FilmId]) REFERENCES [Films]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Session] CHECK CONSTRAINT [Session_fk1]
GO

ALTER TABLE [Plases] WITH CHECK ADD CONSTRAINT [Plases_fk0] FOREIGN KEY ([HallId]) REFERENCES [Halls]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Plases] CHECK CONSTRAINT [Plases_fk0]
GO

ALTER TABLE [Tickets] WITH CHECK ADD CONSTRAINT [Tickets_fk0] FOREIGN KEY ([PlaceId]) REFERENCES [Plases]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Tickets] CHECK CONSTRAINT [Tickets_fk0]
GO
--ALTER TABLE [Tickets] WITH CHECK ADD CONSTRAINT [Tickets_fk1] FOREIGN KEY ([SessioId]) REFERENCES [Session]([Id])
--ON UPDATE CASCADE
--GO
--ALTER TABLE [Tickets] CHECK CONSTRAINT [Tickets_fk1]
--GO

ALTER TABLE [Films] WITH CHECK ADD CONSTRAINT [Films_fk0] FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Films] CHECK CONSTRAINT [Films_fk0]
GO
ALTER TABLE [Films] WITH CHECK ADD CONSTRAINT [Films_fk1] FOREIGN KEY ([AgeId]) REFERENCES [AgeRestriction]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Films] CHECK CONSTRAINT [Films_fk1]
GO



