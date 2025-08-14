USE [BD]
GO
/****** Object:  User [alumno]    Script Date: 6/8/2025 10:06:47 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Tareas]    Script Date: 6/8/2025 10:06:47 ******/
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
/****** Object:  Table [dbo].[Usuarios]    Script Date: 6/8/2025 10:06:47 ******/
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
ALTER TABLE [dbo].[Tareas]  WITH CHECK ADD  CONSTRAINT [FK_Tareas_Usuarios] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([id])
GO
ALTER TABLE [dbo].[Tareas] CHECK CONSTRAINT [FK_Tareas_Usuarios]
GO
