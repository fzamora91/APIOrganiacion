USE [DB_Tecnan02]
GO
/****** Object:  Table [dbo].[Organizacion]    Script Date: 11/1/2024 22:23:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organizacion](
	[IdOrganizacion] [nchar](10) NULL,
	[Nombre] [nchar](10) NULL,
	[Pais] [nchar](10) NULL,
	[Direccion] [nchar](10) NULL,
	[SitioWeb] [nchar](10) NULL,
	[telefono] [nchar](10) NULL,
	[email] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 11/1/2024 22:23:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Producto] [nvarchar](50) NULL,
	[Precio] [float] NULL,
	[Fecha_Vencimiento] [date] NULL,
	[Creado_Por] [nvarchar](50) NULL,
	[Fecha_Creacion] [date] NULL,
	[Modificado_Por] [nchar](10) NULL,
	[Ultima_Modificacion] [date] NULL
) ON [PRIMARY]
GO
