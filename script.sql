USE [BD]
GO
/****** Object:  User [alumno]    Script Date: 20/8/2025 09:02:29 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Tareas]    Script Date: 20/8/2025 09:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tareas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[titulo] [varchar](50) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[fecha] [date] NOT NULL,
	[finalizada] [bit] NOT NULL,
	[idUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Tareas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 20/8/2025 09:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[foto] [varchar](50) NULL,
	[username] [varchar](50) NOT NULL,
	[ultimoLogin] [date] NOT NULL,
	[password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tareas] ON 

INSERT [dbo].[Tareas] ([id], [titulo], [descripcion], [fecha], [finalizada], [idUsuario]) VALUES (4, N'1234', N'123456', CAST(N'2025-08-16' AS Date), 0, 1)
INSERT [dbo].[Tareas] ([id], [titulo], [descripcion], [fecha], [finalizada], [idUsuario]) VALUES (5, N'ToDoList', N'Programacion', CAST(N'2025-08-21' AS Date), 1, 3)
SET IDENTITY_INSERT [dbo].[Tareas] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([id], [nombre], [apellido], [foto], [username], [ultimoLogin], [password]) VALUES (1, N'andi', N'fishman', N'123', N'andifishmann', CAST(N'2025-08-20' AS Date), N'123456789')
INSERT [dbo].[Usuarios] ([id], [nombre], [apellido], [foto], [username], [ultimoLogin], [password]) VALUES (2, N'pedro', N'malowi', N'1', N'pedromalo', CAST(N'2025-08-20' AS Date), N'123456')
INSERT [dbo].[Usuarios] ([id], [nombre], [apellido], [foto], [username], [ultimoLogin], [password]) VALUES (3, N'victoria', N'kriger', N'lokl', N'vickytoria', CAST(N'2025-08-20' AS Date), N'lol11')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[Tareas]  WITH CHECK ADD  CONSTRAINT [FK_Tareas_Usuarios] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([id])
GO
ALTER TABLE [dbo].[Tareas] CHECK CONSTRAINT [FK_Tareas_Usuarios]
GO
