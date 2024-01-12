USE [DB_Tecnan02]
GO
/****** Object:  Table [dbo].[Organizacion]    Script Date: 12/1/2024 09:49:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organizacion](
	[IdOrganizacion] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Pais] [nvarchar](50) NULL,
	[Direccion] [nvarchar](50) NULL,
	[SitioWeb] [nvarchar](50) NULL,
	[telefono] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
 CONSTRAINT [PK_Organizacion] PRIMARY KEY CLUSTERED 
(
	[IdOrganizacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 12/1/2024 09:49:34 ******/
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

