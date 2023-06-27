CREATE DATABASE [HospitalApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HospitalApp', FILENAME = N'C:\HospitalApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HospitalApp_log', FILENAME = N'C:\HospitalApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

USE [HospitalApp]
GO
/****** Object:  Table [dbo].[Cabinet]    Script Date: 27.06.2023 21:44:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cabinet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Num] [smallint] NOT NULL,
 CONSTRAINT [PK_Cabinet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[District]    Script Date: 27.06.2023 21:44:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[District](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Num] [smallint] NOT NULL,
 CONSTRAINT [PK_District] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctor]    Script Date: 27.06.2023 21:44:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[CabinetId] [int] NOT NULL,
	[SpecializationId] [int] NOT NULL,
	[DistrictId] [int] NULL,
 CONSTRAINT [PK_Doctor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 27.06.2023 21:44:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Surname] [nvarchar](30) NOT NULL,
	[Patronymic] [nvarchar](30) NULL,
	[Address] [nvarchar](100) NOT NULL,
	[BirthdayDate] [datetime] NOT NULL,
	[Gender] [bit] NOT NULL,
	[DistrictId] [int] NOT NULL,
 CONSTRAINT [PK_Patient] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Specialization]    Script Date: 27.06.2023 21:44:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specialization](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Specialization] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cabinet] ON 
GO
INSERT [dbo].[Cabinet] ([Id], [Num]) VALUES (1, 100)
GO
INSERT [dbo].[Cabinet] ([Id], [Num]) VALUES (2, 101)
GO
INSERT [dbo].[Cabinet] ([Id], [Num]) VALUES (3, 102)
GO
INSERT [dbo].[Cabinet] ([Id], [Num]) VALUES (4, 200)
GO
INSERT [dbo].[Cabinet] ([Id], [Num]) VALUES (5, 203)
GO
INSERT [dbo].[Cabinet] ([Id], [Num]) VALUES (6, 205)
GO
INSERT [dbo].[Cabinet] ([Id], [Num]) VALUES (7, 301)
GO
INSERT [dbo].[Cabinet] ([Id], [Num]) VALUES (8, 303)
GO
INSERT [dbo].[Cabinet] ([Id], [Num]) VALUES (9, 310)
GO
SET IDENTITY_INSERT [dbo].[Cabinet] OFF
GO
SET IDENTITY_INSERT [dbo].[District] ON 
GO
INSERT [dbo].[District] ([Id], [Num]) VALUES (1, 1)
GO
INSERT [dbo].[District] ([Id], [Num]) VALUES (2, 2)
GO
INSERT [dbo].[District] ([Id], [Num]) VALUES (3, 5)
GO
INSERT [dbo].[District] ([Id], [Num]) VALUES (4, 10)
GO
INSERT [dbo].[District] ([Id], [Num]) VALUES (5, 15)
GO
INSERT [dbo].[District] ([Id], [Num]) VALUES (6, 20)
GO
SET IDENTITY_INSERT [dbo].[District] OFF
GO
SET IDENTITY_INSERT [dbo].[Doctor] ON 
GO
INSERT [dbo].[Doctor] ([Id], [FullName], [CabinetId], [SpecializationId], [DistrictId]) VALUES (1, N'Замкова Фаина Михайловна', 1, 3, NULL)
GO
INSERT [dbo].[Doctor] ([Id], [FullName], [CabinetId], [SpecializationId], [DistrictId]) VALUES (2, N'Петрова Надежда Федоровна', 2, 2, NULL)
GO
SET IDENTITY_INSERT [dbo].[Doctor] OFF
GO
SET IDENTITY_INSERT [dbo].[Patient] ON 
GO
INSERT [dbo].[Patient] ([Id], [Name], [Surname], [Patronymic], [Address], [BirthdayDate], [Gender], [DistrictId]) VALUES (1, N'Петров', N'Аркадий', N'Валериевич', N'Сосновая ул., 30 д., 5 кв.', CAST(N'2010-05-24T00:00:00.000' AS DateTime), 1, 3)
GO
SET IDENTITY_INSERT [dbo].[Patient] OFF
GO
SET IDENTITY_INSERT [dbo].[Specialization] ON 
GO
INSERT [dbo].[Specialization] ([Id], [Name]) VALUES (1, N'Участковый врач')
GO
INSERT [dbo].[Specialization] ([Id], [Name]) VALUES (2, N'Терапевт')
GO
INSERT [dbo].[Specialization] ([Id], [Name]) VALUES (3, N'Педиатр')
GO
INSERT [dbo].[Specialization] ([Id], [Name]) VALUES (4, N'Кардиолог')
GO
INSERT [dbo].[Specialization] ([Id], [Name]) VALUES (5, N'Рентгенлог')
GO
INSERT [dbo].[Specialization] ([Id], [Name]) VALUES (6, N'Хирург')
GO
INSERT [dbo].[Specialization] ([Id], [Name]) VALUES (7, N'Окулист')
GO
SET IDENTITY_INSERT [dbo].[Specialization] OFF
GO
ALTER TABLE [dbo].[Patient] ADD  CONSTRAINT [DF_Patient_Gender]  DEFAULT ((0)) FOR [Gender]
GO
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [FK_Doctor_Cabinet] FOREIGN KEY([CabinetId])
REFERENCES [dbo].[Cabinet] ([Id])
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [FK_Doctor_Cabinet]
GO
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [FK_Doctor_District] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[District] ([Id])
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [FK_Doctor_District]
GO
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [FK_Doctor_Specialization] FOREIGN KEY([SpecializationId])
REFERENCES [dbo].[Specialization] ([Id])
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [FK_Doctor_Specialization]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient_District] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[District] ([Id])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_District]
GO
