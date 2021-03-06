USE [master]
GO
/****** Object:  Database [bdLigaLinch]    Script Date: 09/06/2018 03:48:28 ******/
CREATE DATABASE [bdLigaLinch] ON  PRIMARY 
( NAME = N'bdLigaChena', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\bdLigaChena.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'bdLigaChena_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\bdLigaChena_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [bdLigaLinch] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [bdLigaLinch].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [bdLigaLinch] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [bdLigaLinch] SET ANSI_NULLS OFF
GO
ALTER DATABASE [bdLigaLinch] SET ANSI_PADDING OFF
GO
ALTER DATABASE [bdLigaLinch] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [bdLigaLinch] SET ARITHABORT OFF
GO
ALTER DATABASE [bdLigaLinch] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [bdLigaLinch] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [bdLigaLinch] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [bdLigaLinch] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [bdLigaLinch] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [bdLigaLinch] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [bdLigaLinch] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [bdLigaLinch] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [bdLigaLinch] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [bdLigaLinch] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [bdLigaLinch] SET  DISABLE_BROKER
GO
ALTER DATABASE [bdLigaLinch] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [bdLigaLinch] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [bdLigaLinch] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [bdLigaLinch] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [bdLigaLinch] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [bdLigaLinch] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [bdLigaLinch] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [bdLigaLinch] SET  READ_WRITE
GO
ALTER DATABASE [bdLigaLinch] SET RECOVERY FULL
GO
ALTER DATABASE [bdLigaLinch] SET  MULTI_USER
GO
ALTER DATABASE [bdLigaLinch] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [bdLigaLinch] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'bdLigaLinch', N'ON'
GO
USE [bdLigaLinch]
GO
/****** Object:  Table [dbo].[TiposMovimiento]    Script Date: 09/06/2018 03:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TiposMovimiento](
	[IdTipoMovimiento] [bigint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](200) NULL,
	[Monto] [int] NULL,
	[PartidosSuspencion] [int] NULL,
	[UsuarioCrea] [varchar](50) NULL,
	[FechaCrea] [datetime] NULL,
	[UsuarioElimina] [varchar](50) NULL,
	[FechaElimina] [datetime] NULL,
 CONSTRAINT [PK_TiposMovimiento] PRIMARY KEY CLUSTERED 
(
	[IdTipoMovimiento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[TiposMovimiento] ON
INSERT [dbo].[TiposMovimiento] ([IdTipoMovimiento], [Descripcion], [Monto], [PartidosSuspencion], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina]) VALUES (1, N'APORTE LIGA AYUDA SOLIDARIA MAXIMO', 60000, 0, N'jbolivar', CAST(0x0000A948011F637C AS DateTime), NULL, NULL)
INSERT [dbo].[TiposMovimiento] ([IdTipoMovimiento], [Descripcion], [Monto], [PartidosSuspencion], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina]) VALUES (2, N'APORTE LIGA AYUDA SOLIDARIA MEDIO', 40000, 0, N'jbolivar', CAST(0x0000A9480122BFA4 AS DateTime), NULL, NULL)
INSERT [dbo].[TiposMovimiento] ([IdTipoMovimiento], [Descripcion], [Monto], [PartidosSuspencion], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina]) VALUES (3, N'APORTE LIGA AYUDA SOLIDARIA MINIMO', 20000, 0, N'jbolivar', CAST(0x0000A9480122EC2C AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[TiposMovimiento] OFF
/****** Object:  Table [dbo].[Series]    Script Date: 09/06/2018 03:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Series](
	[IdSerie] [bigint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](100) NULL,
	[EdadDesde] [int] NULL,
	[EdadHasta] [int] NULL,
	[UsuarioCrea] [varchar](50) NULL,
	[FechaCrea] [datetime] NULL,
	[UsuarioElimina] [varchar](50) NULL,
	[FechaElimina] [datetime] NULL,
 CONSTRAINT [PK_Series] PRIMARY KEY CLUSTERED 
(
	[IdSerie] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Series] ON
INSERT [dbo].[Series] ([IdSerie], [Descripcion], [EdadDesde], [EdadHasta], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina]) VALUES (1, N'Primera', 18, 45, N'jbolivar', CAST(0x0000A9120008261B AS DateTime), NULL, NULL)
INSERT [dbo].[Series] ([IdSerie], [Descripcion], [EdadDesde], [EdadHasta], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina]) VALUES (2, N'Segunda', 18, 60, N'jbolivar', CAST(0x0000A91200083B7A AS DateTime), NULL, NULL)
INSERT [dbo].[Series] ([IdSerie], [Descripcion], [EdadDesde], [EdadHasta], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina]) VALUES (3, N'Seniors', 34, 48, N'jbolivar', CAST(0x0000A91200088558 AS DateTime), NULL, NULL)
INSERT [dbo].[Series] ([IdSerie], [Descripcion], [EdadDesde], [EdadHasta], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina]) VALUES (6, N'Tercera', 20, 45, N'jbolivar', CAST(0x0000A91E002D990C AS DateTime), NULL, NULL)
INSERT [dbo].[Series] ([IdSerie], [Descripcion], [EdadDesde], [EdadHasta], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina]) VALUES (7, N'test', 34, 343, N'jbolivar', CAST(0x0000A91E002DB8B0 AS DateTime), N'jbolivar', CAST(0x0000A91E0030DB6C AS DateTime))
SET IDENTITY_INSERT [dbo].[Series] OFF
/****** Object:  Table [dbo].[Perfiles]    Script Date: 09/06/2018 03:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Perfiles](
	[IdPerfil] [bigint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[UsuarioCrea] [varchar](50) NULL,
	[FechaCrea] [datetime] NULL,
	[UsuarioElimina] [varchar](50) NULL,
	[FechaElimina] [datetime] NULL,
 CONSTRAINT [PK_Perfiles] PRIMARY KEY CLUSTERED 
(
	[IdPerfil] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Perfiles] ON
INSERT [dbo].[Perfiles] ([IdPerfil], [Descripcion], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina]) VALUES (1, N'Administrador', NULL, CAST(0x0000A917010B5B8D AS DateTime), NULL, NULL)
INSERT [dbo].[Perfiles] ([IdPerfil], [Descripcion], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina]) VALUES (6, N'Estadístico', N'jhenriquez', CAST(0x0000A91800242AFC AS DateTime), NULL, NULL)
INSERT [dbo].[Perfiles] ([IdPerfil], [Descripcion], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina]) VALUES (7, N'Tesorero', N'jbolivar', CAST(0x0000A91800256188 AS DateTime), NULL, NULL)
INSERT [dbo].[Perfiles] ([IdPerfil], [Descripcion], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina]) VALUES (8, N'Club', N'jbolivar', CAST(0x0000A918002576A0 AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Perfiles] OFF
/****** Object:  Table [dbo].[Dirigentes]    Script Date: 09/06/2018 03:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dirigentes](
	[IdDirigente] [int] IDENTITY(1,1) NOT NULL,
	[Rut] [varchar](10) NULL,
	[Nombres] [varchar](100) NULL,
	[Apellidos] [varchar](100) NULL,
	[Telefono] [varchar](25) NULL,
	[Domicilio] [varchar](200) NULL,
	[Cargo] [varchar](50) NULL,
	[Email] [varchar](100) NULL,
	[UsuarioCrea] [varchar](50) NULL,
	[FechaCrea] [datetime] NULL,
	[UsuarioElimina] [varchar](50) NULL,
	[FechaElimina] [datetime] NULL,
 CONSTRAINT [PK_Dirigentes] PRIMARY KEY CLUSTERED 
(
	[IdDirigente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Dirigentes] ON
INSERT [dbo].[Dirigentes] ([IdDirigente], [Rut], [Nombres], [Apellidos], [Telefono], [Domicilio], [Cargo], [Email], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina]) VALUES (1, N'111111111', N'Sin dirigente', NULL, NULL, NULL, NULL, NULL, N'jbolivar', CAST(0x0000A9280013F1B2 AS DateTime), NULL, NULL)
INSERT [dbo].[Dirigentes] ([IdDirigente], [Rut], [Nombres], [Apellidos], [Telefono], [Domicilio], [Cargo], [Email], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina]) VALUES (2, N'33333333-3', N'juanito', N'barros', N'+569 8986677', N'Av. Santa fe 580', N'Presidente', N'jbarros@gmail.com', N'jhenriquez', CAST(0x0000A92801613130 AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Dirigentes] OFF
/****** Object:  Table [dbo].[Canchas]    Script Date: 09/06/2018 03:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Canchas](
	[IdCancha] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Ubicacion] [varchar](100) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Campeonatos]    Script Date: 09/06/2018 03:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Campeonatos](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[NombreCampeonato] [varchar](200) NULL,
	[FechaInicio] [date] NULL,
	[FechaTermino] [date] NULL,
	[UsuarioCrea] [varchar](50) NULL,
	[FechaCrea] [datetime] NULL,
	[UsuarioElimina] [varchar](50) NULL,
	[FechaElimina] [datetime] NULL,
 CONSTRAINT [PK_Campeonatos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Campeonatos] ON
INSERT [dbo].[Campeonatos] ([Id], [NombreCampeonato], [FechaInicio], [FechaTermino], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina]) VALUES (1, N'Apertura 2018', CAST(0xFA3D0B00 AS Date), CAST(0x5D3E0B00 AS Date), N'jbolivar', CAST(0x0000A91E003AA3B8 AS DateTime), NULL, NULL)
INSERT [dbo].[Campeonatos] ([Id], [NombreCampeonato], [FechaInicio], [FechaTermino], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina]) VALUES (4, N'Clausura 2018', CAST(0x7A3E0B00 AS Date), CAST(0x133F0B00 AS Date), N'jbolivar', CAST(0x0000A91E003D8F60 AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Campeonatos] OFF
/****** Object:  Table [dbo].[Usuarios]    Script Date: 09/06/2018 03:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [bigint] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](50) NULL,
	[Password] [varchar](10) NULL,
	[NombreCompleto] [varchar](150) NULL,
	[Foto] [varchar](200) NULL,
	[PerfilId] [bigint] NULL,
	[ClubId] [bigint] NULL,
	[UsuarioCrea] [varchar](50) NULL,
	[FechaCrea] [datetime] NULL,
	[UsuarioElimina] [varchar](50) NULL,
	[FechaElimina] [datetime] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON
INSERT [dbo].[Usuarios] ([IdUsuario], [Login], [Password], [NombreCompleto], [Foto], [PerfilId], [ClubId], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina]) VALUES (3, N'jbolivar', N'neojos', N'Josué Bolivar A', N'\img\fotos\jbolivar.jpg', 1, 1, NULL, CAST(0x0000A90800000000 AS DateTime), NULL, NULL)
INSERT [dbo].[Usuarios] ([IdUsuario], [Login], [Password], [NombreCompleto], [Foto], [PerfilId], [ClubId], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina]) VALUES (4, N'jhenriquez', N'12345', N'José Henriquez', N'\img\fotos\jhenriquez.jpg', 1, 1, N'jbolivar', CAST(0x0000A918000F4D94 AS DateTime), NULL, NULL)
INSERT [dbo].[Usuarios] ([IdUsuario], [Login], [Password], [NombreCompleto], [Foto], [PerfilId], [ClubId], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina]) VALUES (5, N'rbaez', N'123', N'Rogelio Baez T.', N'\img\fotos\rbaez.jpg', 6, 1, N'jbolivar', CAST(0x0000A9190026B7B8 AS DateTime), NULL, NULL)
INSERT [dbo].[Usuarios] ([IdUsuario], [Login], [Password], [NombreCompleto], [Foto], [PerfilId], [ClubId], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina]) VALUES (6, N'elcantar', N'111', N'usuario de El Cantar', N'\img\fotos\elcantar.jpg', 8, 2, N'jbolivar', CAST(0x0000A92701868A84 AS DateTime), NULL, NULL)
INSERT [dbo].[Usuarios] ([IdUsuario], [Login], [Password], [NombreCompleto], [Foto], [PerfilId], [ClubId], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina]) VALUES (7, N'heroes', N'1234', N'usuario Los Heroes', N'\img\fotos\heroes.jpg', 8, 3, N'jbolivar', CAST(0x0000A9270187E564 AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
/****** Object:  Table [dbo].[Egresos]    Script Date: 09/06/2018 03:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Egresos](
	[Folio] [bigint] IDENTITY(1,1) NOT NULL,
	[TipoMovimientoId] [bigint] NULL,
	[ClubId] [bigint] NULL,
	[Fecha] [datetime] NULL,
	[CampeonatoId] [int] NULL,
	[Obasevacion] [varchar](200) NULL,
	[UsuarioId] [bigint] NULL,
 CONSTRAINT [PK_Egresos] PRIMARY KEY CLUSTERED 
(
	[Folio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ingresos]    Script Date: 09/06/2018 03:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ingresos](
	[Folio] [bigint] IDENTITY(1,1) NOT NULL,
	[TipoMovimientoId] [bigint] NULL,
	[ClubId] [bigint] NULL,
	[Fecha] [datetime] NULL,
	[CampeonatoId] [int] NULL,
	[Obasevacion] [varchar](200) NULL,
	[UsuarioId] [bigint] NULL,
 CONSTRAINT [PK_Ingresos] PRIMARY KEY CLUSTERED 
(
	[Folio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Accesos]    Script Date: 09/06/2018 03:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Accesos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [varchar](100) NULL,
	[Nombre] [varchar](200) NULL,
	[PerfilId] [bigint] NULL,
	[Concedido] [int] NULL,
	[UsuarioConcede] [varchar](50) NULL,
	[FechaConcede] [datetime] NULL,
	[UsuarioDenega] [varchar](50) NULL,
	[FechaDenega] [datetime] NULL,
 CONSTRAINT [PK_Accesos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Accesos] ON
INSERT [dbo].[Accesos] ([Id], [Tipo], [Nombre], [PerfilId], [Concedido], [UsuarioConcede], [FechaConcede], [UsuarioDenega], [FechaDenega]) VALUES (1, N'Mantenedores', N'Usuarios', 1, 1, N'jbolivar', CAST(0x0000A9190015E190 AS DateTime), NULL, NULL)
INSERT [dbo].[Accesos] ([Id], [Tipo], [Nombre], [PerfilId], [Concedido], [UsuarioConcede], [FechaConcede], [UsuarioDenega], [FechaDenega]) VALUES (2, N'Mantenedores', N'Clubes', 1, 1, N'jbolivar', CAST(0x0000A9190015E190 AS DateTime), NULL, NULL)
INSERT [dbo].[Accesos] ([Id], [Tipo], [Nombre], [PerfilId], [Concedido], [UsuarioConcede], [FechaConcede], [UsuarioDenega], [FechaDenega]) VALUES (3, N'Mantenedores', N'Perfiles', 1, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accesos] ([Id], [Tipo], [Nombre], [PerfilId], [Concedido], [UsuarioConcede], [FechaConcede], [UsuarioDenega], [FechaDenega]) VALUES (4, N'Mantenedores', N'Accesos', 1, 1, N'jbolivar', CAST(0x0000A9190015E190 AS DateTime), NULL, NULL)
INSERT [dbo].[Accesos] ([Id], [Tipo], [Nombre], [PerfilId], [Concedido], [UsuarioConcede], [FechaConcede], [UsuarioDenega], [FechaDenega]) VALUES (5, N'Mantenedores', N'Jugadores', 1, 1, N'jbolivar', CAST(0x0000A91900166D04 AS DateTime), NULL, NULL)
INSERT [dbo].[Accesos] ([Id], [Tipo], [Nombre], [PerfilId], [Concedido], [UsuarioConcede], [FechaConcede], [UsuarioDenega], [FechaDenega]) VALUES (6, N'Mantenedores', N'Series', 1, 1, N'jbolivar', CAST(0x0000A919001729B0 AS DateTime), NULL, NULL)
INSERT [dbo].[Accesos] ([Id], [Tipo], [Nombre], [PerfilId], [Concedido], [UsuarioConcede], [FechaConcede], [UsuarioDenega], [FechaDenega]) VALUES (7, N'Administrativo', N'IngresoFicha', 6, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accesos] ([Id], [Tipo], [Nombre], [PerfilId], [Concedido], [UsuarioConcede], [FechaConcede], [UsuarioDenega], [FechaDenega]) VALUES (8, N'Tesoreria', N'Pagos', 7, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accesos] ([Id], [Tipo], [Nombre], [PerfilId], [Concedido], [UsuarioConcede], [FechaConcede], [UsuarioDenega], [FechaDenega]) VALUES (10, N'Tesoreria', N'Egresos', 7, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accesos] ([Id], [Tipo], [Nombre], [PerfilId], [Concedido], [UsuarioConcede], [FechaConcede], [UsuarioDenega], [FechaDenega]) VALUES (12, N'Mantenedores', N'Dirigentes', 1, 1, N'jbolivar', CAST(0x0000A921000CFB70 AS DateTime), NULL, NULL)
INSERT [dbo].[Accesos] ([Id], [Tipo], [Nombre], [PerfilId], [Concedido], [UsuarioConcede], [FechaConcede], [UsuarioDenega], [FechaDenega]) VALUES (13, N'Mantenedores', N'Directivas', 1, 1, N'jbolivar', CAST(0x0000A92300059358 AS DateTime), NULL, NULL)
INSERT [dbo].[Accesos] ([Id], [Tipo], [Nombre], [PerfilId], [Concedido], [UsuarioConcede], [FechaConcede], [UsuarioDenega], [FechaDenega]) VALUES (14, N'Administrativo', N'Inscripciones', 8, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accesos] ([Id], [Tipo], [Nombre], [PerfilId], [Concedido], [UsuarioConcede], [FechaConcede], [UsuarioDenega], [FechaDenega]) VALUES (15, N'Mantenedores', N'Jugadores', 8, 1, N'jbolivar', CAST(0x0000A9270188A918 AS DateTime), NULL, NULL)
INSERT [dbo].[Accesos] ([Id], [Tipo], [Nombre], [PerfilId], [Concedido], [UsuarioConcede], [FechaConcede], [UsuarioDenega], [FechaDenega]) VALUES (16, N'Mantenedores', N'Resultados', 6, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accesos] ([Id], [Tipo], [Nombre], [PerfilId], [Concedido], [UsuarioConcede], [FechaConcede], [UsuarioDenega], [FechaDenega]) VALUES (17, N'Mantenedores', N'Jugadores', 6, 0, NULL, NULL, N'jhenriquez', CAST(0x0000A928016054E0 AS DateTime))
INSERT [dbo].[Accesos] ([Id], [Tipo], [Nombre], [PerfilId], [Concedido], [UsuarioConcede], [FechaConcede], [UsuarioDenega], [FechaDenega]) VALUES (18, N'Mantenedores', N'Pases', 8, 1, N'jhenriquez', CAST(0x0000A9280175B7E0 AS DateTime), NULL, NULL)
INSERT [dbo].[Accesos] ([Id], [Tipo], [Nombre], [PerfilId], [Concedido], [UsuarioConcede], [FechaConcede], [UsuarioDenega], [FechaDenega]) VALUES (19, N'Administrativo', N'Pases', 6, 1, N'jhenriquez', CAST(0x0000A928017638C8 AS DateTime), NULL, NULL)
INSERT [dbo].[Accesos] ([Id], [Tipo], [Nombre], [PerfilId], [Concedido], [UsuarioConcede], [FechaConcede], [UsuarioDenega], [FechaDenega]) VALUES (20, N'Mantenedores', N'TiposMovimiento', 1, 1, N'jbolivar', CAST(0x0000A948011EE744 AS DateTime), NULL, NULL)
INSERT [dbo].[Accesos] ([Id], [Tipo], [Nombre], [PerfilId], [Concedido], [UsuarioConcede], [FechaConcede], [UsuarioDenega], [FechaDenega]) VALUES (21, N'Administrativo', N'Inscripciones', 6, 1, N'jbolivar', CAST(0x0000A953003462F0 AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Accesos] OFF
/****** Object:  Table [dbo].[Directivas]    Script Date: 09/06/2018 03:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Directivas](
	[IdDirectiva] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
	[DirigenteId] [int] NULL,
	[Observacion] [varchar](200) NULL,
	[UsuarioCrea] [varchar](50) NULL,
	[FechaCrea] [datetime] NULL,
	[UsuarioElimina] [varchar](50) NULL,
	[FechaElimina] [datetime] NULL,
 CONSTRAINT [PK_Directiva] PRIMARY KEY CLUSTERED 
(
	[IdDirectiva] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Directivas] ON
INSERT [dbo].[Directivas] ([IdDirectiva], [Descripcion], [DirigenteId], [Observacion], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina]) VALUES (1, N'Sin directiva', 1, NULL, N'jbolivar', CAST(0x0000A928001442AD AS DateTime), NULL, NULL)
INSERT [dbo].[Directivas] ([IdDirectiva], [Descripcion], [DirigenteId], [Observacion], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina]) VALUES (2, N'El Cantar', 2, N'Este se integro el dia ldjflf', N'jhenriquez', CAST(0x0000A92801618338 AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Directivas] OFF
/****** Object:  Table [dbo].[Clubes]    Script Date: 09/06/2018 03:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clubes](
	[IdClub] [bigint] IDENTITY(1,1) NOT NULL,
	[Rut] [varchar](10) NULL,
	[Nombre] [varchar](200) NULL,
	[Direccion] [varchar](200) NULL,
	[Telefono] [varchar](20) NULL,
	[Email] [varchar](200) NULL,
	[NumeroPersonalidadJuridica] [varchar](50) NULL,
	[NumeroRegistroCivil] [varchar](50) NULL,
	[Logo] [varchar](200) NULL,
	[DirectivaId] [int] NULL,
	[UsuarioCrea] [varchar](50) NULL,
	[FechaCrea] [datetime] NULL,
	[UsuarioElimina] [varchar](50) NULL,
	[FechaElimina] [datetime] NULL,
 CONSTRAINT [PK_Clubes] PRIMARY KEY CLUSTERED 
(
	[IdClub] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Clubes] ON
INSERT [dbo].[Clubes] ([IdClub], [Rut], [Nombre], [Direccion], [Telefono], [Email], [NumeroPersonalidadJuridica], [NumeroRegistroCivil], [Logo], [DirectivaId], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina]) VALUES (1, N'111111111', N'Sin club', NULL, NULL, NULL, NULL, NULL, N'', 1, N'jbolivar', CAST(0x0000A9280014A2D0 AS DateTime), NULL, NULL)
INSERT [dbo].[Clubes] ([IdClub], [Rut], [Nombre], [Direccion], [Telefono], [Email], [NumeroPersonalidadJuridica], [NumeroRegistroCivil], [Logo], [DirectivaId], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina]) VALUES (2, N'11111111-1', N'Atlético El Cantar', N'No registra', N'No registra', N'No registra', N'No registra', N'No registra', N'', 2, N'jbolivar', CAST(0x0000A92800161C28 AS DateTime), NULL, NULL)
INSERT [dbo].[Clubes] ([IdClub], [Rut], [Nombre], [Direccion], [Telefono], [Email], [NumeroPersonalidadJuridica], [NumeroRegistroCivil], [Logo], [DirectivaId], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina]) VALUES (3, N'22222222-2', N'Villa Los Heroes', N'No registra', N'No registra', N'No registra', N'No registra', N'155988', N'\img\logos_club\los_heroes.jpg', 1, N'jbolivar', CAST(0x0000A92800176574 AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Clubes] OFF
/****** Object:  Table [dbo].[Fixture]    Script Date: 09/06/2018 03:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fixture](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CampeonatoId] [bigint] NULL,
	[FechaAJugar] [int] NULL,
	[ClubIdLocal] [bigint] NULL,
	[ClubIdVisita] [bigint] NULL,
	[CanchaId] [int] NULL,
 CONSTRAINT [PK_Fixture] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jugadores]    Script Date: 09/06/2018 03:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Jugadores](
	[IdJugador] [bigint] IDENTITY(1,1) NOT NULL,
	[Rut] [nvarchar](10) NULL,
	[Apellidos] [varchar](200) NULL,
	[Nombres] [varchar](200) NULL,
	[Foto] [varchar](200) NULL,
	[FechaNacimiento] [date] NULL,
	[SerieId] [bigint] NULL,
	[ClubId] [bigint] NULL,
	[FechaInscripcion] [datetime] NULL,
	[UsuarioCrea] [varchar](50) NULL,
	[FechaCrea] [datetime] NULL,
	[UsuarioElimina] [varchar](50) NULL,
	[FechaElimina] [datetime] NULL,
	[Validado] [int] NULL,
	[Inscrito] [int] NULL,
 CONSTRAINT [PK_Jugadores] PRIMARY KEY CLUSTERED 
(
	[IdJugador] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Jugadores] ON
INSERT [dbo].[Jugadores] ([IdJugador], [Rut], [Apellidos], [Nombres], [Foto], [FechaNacimiento], [SerieId], [ClubId], [FechaInscripcion], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina], [Validado], [Inscrito]) VALUES (1, N'18912954-8', N'Bolivar', N'Josué', N'\img\fotos_jugadores\jbolivar.jpg', CAST(0xB4090B00 AS Date), 3, 3, CAST(0x0000A92801676965 AS DateTime), N'jbolivar', CAST(0x0000A92800183ABC AS DateTime), NULL, NULL, 0, 0)
INSERT [dbo].[Jugadores] ([IdJugador], [Rut], [Apellidos], [Nombres], [Foto], [FechaNacimiento], [SerieId], [ClubId], [FechaInscripcion], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina], [Validado], [Inscrito]) VALUES (2, N'17255976-K', N'Vega Espinoza', N'Jaime Antonio', N'\img\fotos_jugadores\jaimevega.jpg', CAST(0xC6150B00 AS Date), 3, 3, CAST(0x0000A92801676965 AS DateTime), N'elcantar', CAST(0x0000A92800206A0C AS DateTime), NULL, NULL, 0, 0)
INSERT [dbo].[Jugadores] ([IdJugador], [Rut], [Apellidos], [Nombres], [Foto], [FechaNacimiento], [SerieId], [ClubId], [FechaInscripcion], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina], [Validado], [Inscrito]) VALUES (3, N'7133529-1', N'soto', N'rogelio', NULL, CAST(0xE4140B00 AS Date), 1, 3, CAST(0x0000A92801676965 AS DateTime), N'heroes', CAST(0x0000A92801627248 AS DateTime), NULL, NULL, 0, 0)
INSERT [dbo].[Jugadores] ([IdJugador], [Rut], [Apellidos], [Nombres], [Foto], [FechaNacimiento], [SerieId], [ClubId], [FechaInscripcion], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina], [Validado], [Inscrito]) VALUES (4, N'7093290-3', N'Ulloa Contreras', N'Francisco', N'\img\fotos_jugadores\juanvargas.jpg', CAST(0xFDE80A00 AS Date), 1, 2, CAST(0x0000A92801676965 AS DateTime), N'elcantar', CAST(0x0000A9280163E498 AS DateTime), NULL, NULL, 0, 0)
INSERT [dbo].[Jugadores] ([IdJugador], [Rut], [Apellidos], [Nombres], [Foto], [FechaNacimiento], [SerieId], [ClubId], [FechaInscripcion], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina], [Validado], [Inscrito]) VALUES (5, N'7093290-3', N'suarez', N'pedro', NULL, CAST(0xBA140B00 AS Date), 1, 2, CAST(0x0000A92801676965 AS DateTime), N'elcantar', CAST(0x0000A9280164B9E0 AS DateTime), NULL, NULL, 0, 0)
INSERT [dbo].[Jugadores] ([IdJugador], [Rut], [Apellidos], [Nombres], [Foto], [FechaNacimiento], [SerieId], [ClubId], [FechaInscripcion], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina], [Validado], [Inscrito]) VALUES (6, N'9573365-4', N'Troncoso Rojas', N'Manuel', NULL, CAST(0xE3310B00 AS Date), 3, 2, CAST(0x0000A92E01684027 AS DateTime), N'elcantar', CAST(0x0000A928016548D8 AS DateTime), NULL, NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[Jugadores] OFF
/****** Object:  Table [dbo].[RegistroFechaJugada]    Script Date: 09/06/2018 03:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RegistroFechaJugada](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CampeonatoId] [bigint] NOT NULL,
	[ClubId] [bigint] NOT NULL,
	[JugadorId] [bigint] NOT NULL,
	[Jugo] [int] NULL,
	[Goles] [int] NULL,
	[Expulsado] [int] NULL,
	[Lesionado] [int] NULL,
	[UsuarioCrea] [varchar](50) NULL,
	[FechaCrea] [datetime] NULL,
	[UsuarioElimina] [varchar](50) NULL,
	[FechaElimina] [datetime] NULL,
 CONSTRAINT [PK_RegistroFechaJugada] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[RegistroFechaJugada] ON
INSERT [dbo].[RegistroFechaJugada] ([Id], [CampeonatoId], [ClubId], [JugadorId], [Jugo], [Goles], [Expulsado], [Lesionado], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina]) VALUES (1, 1, 3, 1, 1, 2, 0, 0, N'jbolivar', CAST(0x0000A9490002BA70 AS DateTime), NULL, NULL)
INSERT [dbo].[RegistroFechaJugada] ([Id], [CampeonatoId], [ClubId], [JugadorId], [Jugo], [Goles], [Expulsado], [Lesionado], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina]) VALUES (2, 1, 3, 2, 1, 4, 0, 0, N'jbolivar', CAST(0x0000A9490006D344 AS DateTime), NULL, NULL)
INSERT [dbo].[RegistroFechaJugada] ([Id], [CampeonatoId], [ClubId], [JugadorId], [Jugo], [Goles], [Expulsado], [Lesionado], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina]) VALUES (3, 1, 2, 4, 1, 0, 0, 1, N'jbolivar', CAST(0x0000A953001EE415 AS DateTime), NULL, NULL)
INSERT [dbo].[RegistroFechaJugada] ([Id], [CampeonatoId], [ClubId], [JugadorId], [Jugo], [Goles], [Expulsado], [Lesionado], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina]) VALUES (4, 1, 2, 5, 1, 2, 0, 0, N'jbolivar', CAST(0x0000A953001FAD24 AS DateTime), NULL, NULL)
INSERT [dbo].[RegistroFechaJugada] ([Id], [CampeonatoId], [ClubId], [JugadorId], [Jugo], [Goles], [Expulsado], [Lesionado], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina]) VALUES (5, 1, 2, 6, 0, 0, 1, 0, N'jbolivar', CAST(0x0000A9530026BFEC AS DateTime), NULL, NULL)
INSERT [dbo].[RegistroFechaJugada] ([Id], [CampeonatoId], [ClubId], [JugadorId], [Jugo], [Goles], [Expulsado], [Lesionado], [UsuarioCrea], [FechaCrea], [UsuarioElimina], [FechaElimina]) VALUES (6, 4, 3, 2, 1, 3, 0, 0, N'jbolivar', CAST(0x0000A9530028B6A8 AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[RegistroFechaJugada] OFF
/****** Object:  Default [DF_TiposMovimiento_FechaCrea]    Script Date: 09/06/2018 03:48:29 ******/
ALTER TABLE [dbo].[TiposMovimiento] ADD  CONSTRAINT [DF_TiposMovimiento_FechaCrea]  DEFAULT (getdate()) FOR [FechaCrea]
GO
/****** Object:  Default [DF_Series_FechaCrea]    Script Date: 09/06/2018 03:48:29 ******/
ALTER TABLE [dbo].[Series] ADD  CONSTRAINT [DF_Series_FechaCrea]  DEFAULT (getdate()) FOR [FechaCrea]
GO
/****** Object:  Default [DF_Perfiles_FechaCrea]    Script Date: 09/06/2018 03:48:29 ******/
ALTER TABLE [dbo].[Perfiles] ADD  CONSTRAINT [DF_Perfiles_FechaCrea]  DEFAULT (getdate()) FOR [FechaCrea]
GO
/****** Object:  Default [DF_Dirigentes_FechaCrea]    Script Date: 09/06/2018 03:48:29 ******/
ALTER TABLE [dbo].[Dirigentes] ADD  CONSTRAINT [DF_Dirigentes_FechaCrea]  DEFAULT (getdate()) FOR [FechaCrea]
GO
/****** Object:  Default [DF_Campeonatos_FechaCrea1]    Script Date: 09/06/2018 03:48:29 ******/
ALTER TABLE [dbo].[Campeonatos] ADD  CONSTRAINT [DF_Campeonatos_FechaCrea1]  DEFAULT (getdate()) FOR [FechaCrea]
GO
/****** Object:  Default [DF_Usuarios_FechaCrea]    Script Date: 09/06/2018 03:48:29 ******/
ALTER TABLE [dbo].[Usuarios] ADD  CONSTRAINT [DF_Usuarios_FechaCrea]  DEFAULT (getdate()) FOR [FechaCrea]
GO
/****** Object:  Default [DF_Accesos_FechaCrea]    Script Date: 09/06/2018 03:48:29 ******/
ALTER TABLE [dbo].[Accesos] ADD  CONSTRAINT [DF_Accesos_FechaCrea]  DEFAULT (getdate()) FOR [FechaConcede]
GO
/****** Object:  Default [DF_Directivas_FechaCrea]    Script Date: 09/06/2018 03:48:29 ******/
ALTER TABLE [dbo].[Directivas] ADD  CONSTRAINT [DF_Directivas_FechaCrea]  DEFAULT (getdate()) FOR [FechaCrea]
GO
/****** Object:  Default [DF_Clubes_FechaCrea]    Script Date: 09/06/2018 03:48:29 ******/
ALTER TABLE [dbo].[Clubes] ADD  CONSTRAINT [DF_Clubes_FechaCrea]  DEFAULT (getdate()) FOR [FechaCrea]
GO
/****** Object:  Default [DF_Jugadores_FechaInscripcion]    Script Date: 09/06/2018 03:48:29 ******/
ALTER TABLE [dbo].[Jugadores] ADD  CONSTRAINT [DF_Jugadores_FechaInscripcion]  DEFAULT (getdate()) FOR [FechaInscripcion]
GO
/****** Object:  Default [DF_Jugadores_FechaCrea]    Script Date: 09/06/2018 03:48:29 ******/
ALTER TABLE [dbo].[Jugadores] ADD  CONSTRAINT [DF_Jugadores_FechaCrea]  DEFAULT (getdate()) FOR [FechaCrea]
GO
/****** Object:  Default [DF_Jugadores_Validado]    Script Date: 09/06/2018 03:48:29 ******/
ALTER TABLE [dbo].[Jugadores] ADD  CONSTRAINT [DF_Jugadores_Validado]  DEFAULT ((0)) FOR [Validado]
GO
/****** Object:  Default [DF_Jugadores_Inscrito]    Script Date: 09/06/2018 03:48:29 ******/
ALTER TABLE [dbo].[Jugadores] ADD  CONSTRAINT [DF_Jugadores_Inscrito]  DEFAULT ((0)) FOR [Inscrito]
GO
/****** Object:  Default [DF_RegistroFechaJugada_Goles]    Script Date: 09/06/2018 03:48:29 ******/
ALTER TABLE [dbo].[RegistroFechaJugada] ADD  CONSTRAINT [DF_RegistroFechaJugada_Goles]  DEFAULT ((0)) FOR [Goles]
GO
/****** Object:  Default [DF_RegistroFechaJugada_FechaCrea]    Script Date: 09/06/2018 03:48:29 ******/
ALTER TABLE [dbo].[RegistroFechaJugada] ADD  CONSTRAINT [DF_RegistroFechaJugada_FechaCrea]  DEFAULT (getdate()) FOR [FechaCrea]
GO
/****** Object:  ForeignKey [FK_Usuarios_Perfiles]    Script Date: 09/06/2018 03:48:29 ******/
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Perfiles] FOREIGN KEY([PerfilId])
REFERENCES [dbo].[Perfiles] ([IdPerfil])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Perfiles]
GO
/****** Object:  ForeignKey [FK_Egresos_TiposMovimiento]    Script Date: 09/06/2018 03:48:29 ******/
ALTER TABLE [dbo].[Egresos]  WITH CHECK ADD  CONSTRAINT [FK_Egresos_TiposMovimiento] FOREIGN KEY([TipoMovimientoId])
REFERENCES [dbo].[TiposMovimiento] ([IdTipoMovimiento])
GO
ALTER TABLE [dbo].[Egresos] CHECK CONSTRAINT [FK_Egresos_TiposMovimiento]
GO
/****** Object:  ForeignKey [FK_Ingresos_TiposMovimiento]    Script Date: 09/06/2018 03:48:29 ******/
ALTER TABLE [dbo].[Ingresos]  WITH CHECK ADD  CONSTRAINT [FK_Ingresos_TiposMovimiento] FOREIGN KEY([TipoMovimientoId])
REFERENCES [dbo].[TiposMovimiento] ([IdTipoMovimiento])
GO
ALTER TABLE [dbo].[Ingresos] CHECK CONSTRAINT [FK_Ingresos_TiposMovimiento]
GO
/****** Object:  ForeignKey [FK_Accesos_Perfiles]    Script Date: 09/06/2018 03:48:29 ******/
ALTER TABLE [dbo].[Accesos]  WITH CHECK ADD  CONSTRAINT [FK_Accesos_Perfiles] FOREIGN KEY([PerfilId])
REFERENCES [dbo].[Perfiles] ([IdPerfil])
GO
ALTER TABLE [dbo].[Accesos] CHECK CONSTRAINT [FK_Accesos_Perfiles]
GO
/****** Object:  ForeignKey [FK_Directiva_Dirigentes]    Script Date: 09/06/2018 03:48:29 ******/
ALTER TABLE [dbo].[Directivas]  WITH CHECK ADD  CONSTRAINT [FK_Directiva_Dirigentes] FOREIGN KEY([DirigenteId])
REFERENCES [dbo].[Dirigentes] ([IdDirigente])
GO
ALTER TABLE [dbo].[Directivas] CHECK CONSTRAINT [FK_Directiva_Dirigentes]
GO
/****** Object:  ForeignKey [FK_Clubes_Directiva]    Script Date: 09/06/2018 03:48:29 ******/
ALTER TABLE [dbo].[Clubes]  WITH CHECK ADD  CONSTRAINT [FK_Clubes_Directiva] FOREIGN KEY([DirectivaId])
REFERENCES [dbo].[Directivas] ([IdDirectiva])
GO
ALTER TABLE [dbo].[Clubes] CHECK CONSTRAINT [FK_Clubes_Directiva]
GO
/****** Object:  ForeignKey [FK_Fixture_Campeonatos]    Script Date: 09/06/2018 03:48:29 ******/
ALTER TABLE [dbo].[Fixture]  WITH CHECK ADD  CONSTRAINT [FK_Fixture_Campeonatos] FOREIGN KEY([CampeonatoId])
REFERENCES [dbo].[Campeonatos] ([Id])
GO
ALTER TABLE [dbo].[Fixture] CHECK CONSTRAINT [FK_Fixture_Campeonatos]
GO
/****** Object:  ForeignKey [FK_Fixture_Clubes]    Script Date: 09/06/2018 03:48:29 ******/
ALTER TABLE [dbo].[Fixture]  WITH CHECK ADD  CONSTRAINT [FK_Fixture_Clubes] FOREIGN KEY([ClubIdLocal])
REFERENCES [dbo].[Clubes] ([IdClub])
GO
ALTER TABLE [dbo].[Fixture] CHECK CONSTRAINT [FK_Fixture_Clubes]
GO
/****** Object:  ForeignKey [FK_Fixture_Clubes1]    Script Date: 09/06/2018 03:48:29 ******/
ALTER TABLE [dbo].[Fixture]  WITH CHECK ADD  CONSTRAINT [FK_Fixture_Clubes1] FOREIGN KEY([ClubIdVisita])
REFERENCES [dbo].[Clubes] ([IdClub])
GO
ALTER TABLE [dbo].[Fixture] CHECK CONSTRAINT [FK_Fixture_Clubes1]
GO
/****** Object:  ForeignKey [FK_Jugadores_Clubes]    Script Date: 09/06/2018 03:48:29 ******/
ALTER TABLE [dbo].[Jugadores]  WITH CHECK ADD  CONSTRAINT [FK_Jugadores_Clubes] FOREIGN KEY([ClubId])
REFERENCES [dbo].[Clubes] ([IdClub])
GO
ALTER TABLE [dbo].[Jugadores] CHECK CONSTRAINT [FK_Jugadores_Clubes]
GO
/****** Object:  ForeignKey [FK_Jugadores_Series]    Script Date: 09/06/2018 03:48:29 ******/
ALTER TABLE [dbo].[Jugadores]  WITH CHECK ADD  CONSTRAINT [FK_Jugadores_Series] FOREIGN KEY([SerieId])
REFERENCES [dbo].[Series] ([IdSerie])
GO
ALTER TABLE [dbo].[Jugadores] CHECK CONSTRAINT [FK_Jugadores_Series]
GO
/****** Object:  ForeignKey [FK_RegistroFechaJugada_Jugadores]    Script Date: 09/06/2018 03:48:29 ******/
ALTER TABLE [dbo].[RegistroFechaJugada]  WITH CHECK ADD  CONSTRAINT [FK_RegistroFechaJugada_Jugadores] FOREIGN KEY([JugadorId])
REFERENCES [dbo].[Jugadores] ([IdJugador])
GO
ALTER TABLE [dbo].[RegistroFechaJugada] CHECK CONSTRAINT [FK_RegistroFechaJugada_Jugadores]
GO
