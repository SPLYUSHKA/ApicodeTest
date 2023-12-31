USE [ApricodeGames]
GO
/****** Object:  Table [dbo].[Developers]    Script Date: 06.07.2023 11:05:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Developers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK_Developers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GameGenre]    Script Date: 06.07.2023 11:05:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GameGenre](
	[GamesId] [int] NOT NULL,
	[GenresId] [int] NOT NULL,
 CONSTRAINT [PK_GameGenre] PRIMARY KEY CLUSTERED 
(
	[GamesId] ASC,
	[GenresId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Games]    Script Date: 06.07.2023 11:05:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Games](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](300) NOT NULL,
	[DeveloperId] [int] NOT NULL,
 CONSTRAINT [PK_Games] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 06.07.2023 11:05:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Developers] ON 

INSERT [dbo].[Developers] ([Id], [Name]) VALUES (1, N'Capcom')
INSERT [dbo].[Developers] ([Id], [Name]) VALUES (2, N'Id Software')
INSERT [dbo].[Developers] ([Id], [Name]) VALUES (3, N'Blizzard')
INSERT [dbo].[Developers] ([Id], [Name]) VALUES (4, N'Mojang Studios')
SET IDENTITY_INSERT [dbo].[Developers] OFF
GO
INSERT [dbo].[GameGenre] ([GamesId], [GenresId]) VALUES (1, 1)
INSERT [dbo].[GameGenre] ([GamesId], [GenresId]) VALUES (1, 2)
INSERT [dbo].[GameGenre] ([GamesId], [GenresId]) VALUES (2, 3)
INSERT [dbo].[GameGenre] ([GamesId], [GenresId]) VALUES (3, 3)
INSERT [dbo].[GameGenre] ([GamesId], [GenresId]) VALUES (4, 3)
INSERT [dbo].[GameGenre] ([GamesId], [GenresId]) VALUES (5, 3)
INSERT [dbo].[GameGenre] ([GamesId], [GenresId]) VALUES (3, 4)
INSERT [dbo].[GameGenre] ([GamesId], [GenresId]) VALUES (4, 4)
INSERT [dbo].[GameGenre] ([GamesId], [GenresId]) VALUES (6, 5)
GO
SET IDENTITY_INSERT [dbo].[Games] ON 

INSERT [dbo].[Games] ([Id], [Title], [DeveloperId]) VALUES (1, N'Resident Evil Village', 1)
INSERT [dbo].[Games] ([Id], [Title], [DeveloperId]) VALUES (2, N'Monster Hunter: World', 1)
INSERT [dbo].[Games] ([Id], [Title], [DeveloperId]) VALUES (3, N'Sekiro: Shadows Die Twice', 2)
INSERT [dbo].[Games] ([Id], [Title], [DeveloperId]) VALUES (4, N'Dark Souls 3', 2)
INSERT [dbo].[Games] ([Id], [Title], [DeveloperId]) VALUES (5, N'Diablo', 3)
INSERT [dbo].[Games] ([Id], [Title], [DeveloperId]) VALUES (6, N'Minecraft', 4)
SET IDENTITY_INSERT [dbo].[Games] OFF
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([Id], [Name]) VALUES (1, N'Survival')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (2, N'Horror')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (3, N'Action-RPG')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (4, N'Adventure')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (5, N'Sandbox')
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
ALTER TABLE [dbo].[GameGenre]  WITH CHECK ADD  CONSTRAINT [FK_GameGenre_Games_GamesId] FOREIGN KEY([GamesId])
REFERENCES [dbo].[Games] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GameGenre] CHECK CONSTRAINT [FK_GameGenre_Games_GamesId]
GO
ALTER TABLE [dbo].[GameGenre]  WITH CHECK ADD  CONSTRAINT [FK_GameGenre_Genres_GenresId] FOREIGN KEY([GenresId])
REFERENCES [dbo].[Genres] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GameGenre] CHECK CONSTRAINT [FK_GameGenre_Genres_GenresId]
GO
ALTER TABLE [dbo].[Games]  WITH CHECK ADD  CONSTRAINT [FK_Games_Developers_DeveloperId] FOREIGN KEY([DeveloperId])
REFERENCES [dbo].[Developers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Games] CHECK CONSTRAINT [FK_Games_Developers_DeveloperId]
GO
