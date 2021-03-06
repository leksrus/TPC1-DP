USE [master]
GO
/****** Object:  Database [CCCP Gym-Fitness]    Script Date: 22/11/2016 02:14:18 p.m. ******/
CREATE DATABASE [CCCP Gym-Fitness]
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CCCP Gym-Fitness].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CCCP Gym-Fitness] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CCCP Gym-Fitness] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CCCP Gym-Fitness] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CCCP Gym-Fitness] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CCCP Gym-Fitness] SET ARITHABORT OFF 
GO
ALTER DATABASE [CCCP Gym-Fitness] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CCCP Gym-Fitness] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CCCP Gym-Fitness] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CCCP Gym-Fitness] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CCCP Gym-Fitness] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CCCP Gym-Fitness] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CCCP Gym-Fitness] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CCCP Gym-Fitness] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CCCP Gym-Fitness] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CCCP Gym-Fitness] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CCCP Gym-Fitness] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CCCP Gym-Fitness] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CCCP Gym-Fitness] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CCCP Gym-Fitness] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CCCP Gym-Fitness] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CCCP Gym-Fitness] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CCCP Gym-Fitness] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CCCP Gym-Fitness] SET RECOVERY FULL 
GO
ALTER DATABASE [CCCP Gym-Fitness] SET  MULTI_USER 
GO
ALTER DATABASE [CCCP Gym-Fitness] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CCCP Gym-Fitness] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CCCP Gym-Fitness] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CCCP Gym-Fitness] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CCCP Gym-Fitness', N'ON'
GO
USE [CCCP Gym-Fitness]
GO
/****** Object:  Table [dbo].[BackupDB]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BackupDB](
	[id_backup] [int] NOT NULL,
	[dbname] [nvarchar](50) NOT NULL,
	[fecha_hora] [date] NOT NULL,
	[dbsize] [int] NOT NULL,
 CONSTRAINT [PK_Backup] PRIMARY KEY CLUSTERED 
(
	[id_backup] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[idtarjeta] [nvarchar](50) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[apellido] [nvarchar](50) NOT NULL,
	[direccion] [nvarchar](50) NOT NULL,
	[telefono] [nvarchar](50) NOT NULL,
	[fecha_nacimiento] [date] NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[dni] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[idtarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Deporte]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deporte](
	[id_deporte] [int] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[precio] [decimal](18, 3) NOT NULL,
	[tipo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Deporte] PRIMARY KEY CLUSTERED 
(
	[id_deporte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DVV]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DVV](
	[id_table] [nvarchar](10) NOT NULL,
	[hash] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_DVV] PRIMARY KEY CLUSTERED 
(
	[id_table] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ejercicio]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ejercicio](
	[id_ejercicio] [int] NOT NULL,
	[nombre_ejercicio] [int] NOT NULL,
	[observacion] [nvarchar](100) NOT NULL,
	[dia_entrenamiento] [int] NOT NULL,
	[id_rutina] [int] NOT NULL,
 CONSTRAINT [PK_Ejercicio] PRIMARY KEY CLUSTERED 
(
	[id_ejercicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Familia]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia](
	[id_familia] [nvarchar](50) NOT NULL,
	[descripcion] [nvarchar](50) NOT NULL,
	[principal] [bit] NOT NULL,
 CONSTRAINT [PK_Familia] PRIMARY KEY CLUSTERED 
(
	[id_familia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lang_Exeption]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lang_Exeption](
	[function_name] [nvarchar](50) NOT NULL,
	[id_exepmsg] [int] NOT NULL,
	[id_idioma] [int] NOT NULL,
	[texto] [nvarchar](120) NOT NULL,
 CONSTRAINT [PK_Lang_Exeption_1] PRIMARY KEY CLUSTERED 
(
	[function_name] ASC,
	[id_exepmsg] ASC,
	[id_idioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lang_Interface]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lang_Interface](
	[id_form] [nvarchar](50) NOT NULL,
	[id_control] [nvarchar](50) NOT NULL,
	[id_idioma] [int] NOT NULL,
	[texto] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Lang_Interface] PRIMARY KEY CLUSTERED 
(
	[id_control] ASC,
	[id_idioma] ASC,
	[id_form] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lang_Log]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lang_Log](
	[type_event] [int] NOT NULL,
	[id_idioma] [int] NOT NULL,
	[texto] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Lang_Log_1] PRIMARY KEY CLUSTERED 
(
	[type_event] ASC,
	[id_idioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Language]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[id_idioma] [int] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[id_idioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Log]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[id_log] [int] NOT NULL,
	[fecha_hora] [datetime] NOT NULL,
	[nickname] [nvarchar](50) NOT NULL,
	[type_event] [nvarchar](50) NOT NULL,
	[detalles] [nvarchar](50) NOT NULL,
	[dvh] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[id_log] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Membresia]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Membresia](
	[idtarjeta] [nvarchar](50) NOT NULL,
	[id_deporte] [int] NOT NULL,
	[asistencia] [datetime] NOT NULL,
 CONSTRAINT [PK_Cliente_Deporte] PRIMARY KEY CLUSTERED 
(
	[idtarjeta] ASC,
	[id_deporte] ASC,
	[asistencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Oferta]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Oferta](
	[id_oferta] [int] NOT NULL,
	[fecha_vigencia] [date] NOT NULL,
	[fecha_fin] [date] NOT NULL,
	[estado] [int] NOT NULL,
	[tipo] [int] NOT NULL,
	[descripcion] [nvarchar](100) NOT NULL,
	[id_deporte] [int] NOT NULL,
 CONSTRAINT [PK_Oferta] PRIMARY KEY CLUSTERED 
(
	[id_oferta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Patente]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patente](
	[id_patente] [nvarchar](50) NOT NULL,
	[id_familia] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Patente] PRIMARY KEY CLUSTERED 
(
	[id_familia] ASC,
	[id_patente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rutina]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rutina](
	[id_rutina] [int] NOT NULL,
	[nombre_rutina] [int] NOT NULL,
	[idtarjeta] [nvarchar](50) NOT NULL,
	[nombre_prof] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Rutina_1] PRIMARY KEY CLUSTERED 
(
	[id_rutina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[idtarjeta] [nvarchar](50) NOT NULL,
	[id_deporte] [int] NOT NULL,
	[fecha_pago] [date] NOT NULL,
	[monto] [decimal](18, 3) NOT NULL,
	[cantidad_clases] [int] NOT NULL,
	[dvh] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[idtarjeta] ASC,
	[id_deporte] ASC,
	[fecha_pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Turno]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turno](
	[id_turno] [int] NOT NULL,
	[dia] [nvarchar](10) NOT NULL,
	[hora] [time](0) NOT NULL,
	[id_deporte] [int] NOT NULL,
 CONSTRAINT [PK_Turno] PRIMARY KEY CLUSTERED 
(
	[id_turno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User_Data]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Data](
	[id_nickname] [nvarchar](50) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[apellido] [nvarchar](50) NOT NULL,
	[DNI] [nvarchar](50) NOT NULL,
	[telefono] [nvarchar](50) NOT NULL,
	[cargo] [nvarchar](50) NOT NULL,
	[fecha_ingreso] [date] NOT NULL,
 CONSTRAINT [PK_User_Data] PRIMARY KEY CLUSTERED 
(
	[id_nickname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User_Familia]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Familia](
	[nickname] [nvarchar](50) NOT NULL,
	[id_familia] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User_Familia_1] PRIMARY KEY CLUSTERED 
(
	[nickname] ASC,
	[id_familia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[nickname] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[estado] [bit] NOT NULL,
	[id_idioma] [int] NOT NULL,
	[dvh] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[nickname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Cliente] ([idtarjeta], [nombre], [apellido], [direccion], [telefono], [fecha_nacimiento], [email], [dni]) VALUES (N'11111', N'Pablo', N'Cortes', N'Garson 355', N'4-296-87-45', CAST(N'1986-08-14' AS Date), N'pablo_cortes@hotmail.com', N'32.335.655')
INSERT [dbo].[Cliente] ([idtarjeta], [nombre], [apellido], [direccion], [telefono], [fecha_nacimiento], [email], [dni]) VALUES (N'22222', N'Juan', N'Gonzales', N'San Juan 1234', N'4-365-45-25', CAST(N'1990-10-20' AS Date), N'jgonzales@gmail.com', N'35.256.333')
INSERT [dbo].[Deporte] ([id_deporte], [nombre], [precio], [tipo]) VALUES (1, N'cross fit', CAST(100.000 AS Decimal(18, 3)), N'GYM')
INSERT [dbo].[Deporte] ([id_deporte], [nombre], [precio], [tipo]) VALUES (2, N'gimnasio ', CAST(550.000 AS Decimal(18, 3)), N'GYM')
INSERT [dbo].[Deporte] ([id_deporte], [nombre], [precio], [tipo]) VALUES (3, N'aerobic', CAST(70.000 AS Decimal(18, 3)), N'Fitness')
INSERT [dbo].[Deporte] ([id_deporte], [nombre], [precio], [tipo]) VALUES (4, N'aerodance', CAST(80.000 AS Decimal(18, 3)), N'Fitness')
INSERT [dbo].[Deporte] ([id_deporte], [nombre], [precio], [tipo]) VALUES (5, N'yoga', CAST(100.000 AS Decimal(18, 3)), N'Fitness')
INSERT [dbo].[Deporte] ([id_deporte], [nombre], [precio], [tipo]) VALUES (6, N'boxeo', CAST(150.000 AS Decimal(18, 3)), N'Fitness')
INSERT [dbo].[Deporte] ([id_deporte], [nombre], [precio], [tipo]) VALUES (7, N'Tae bo', CAST(140.000 AS Decimal(18, 3)), N'Fitness')
INSERT [dbo].[Deporte] ([id_deporte], [nombre], [precio], [tipo]) VALUES (8, N'may thai', CAST(150.000 AS Decimal(18, 3)), N'Fitness')
INSERT [dbo].[Deporte] ([id_deporte], [nombre], [precio], [tipo]) VALUES (9, N'aikido', CAST(180.000 AS Decimal(18, 3)), N'Fitness')
INSERT [dbo].[Deporte] ([id_deporte], [nombre], [precio], [tipo]) VALUES (10, N'tbc', CAST(130.000 AS Decimal(18, 3)), N'Fitness')
INSERT [dbo].[DVV] ([id_table], [hash]) VALUES (N'log', N'B17868313F90164D')
INSERT [dbo].[DVV] ([id_table], [hash]) VALUES (N'ticket', N'1A4375CC5F067B4D')
INSERT [dbo].[DVV] ([id_table], [hash]) VALUES (N'user', N'86057E691A32F040')
INSERT [dbo].[Familia] ([id_familia], [descripcion], [principal]) VALUES (N'M0001', N'Mantenimiento', 1)
INSERT [dbo].[Familia] ([id_familia], [descripcion], [principal]) VALUES (N'MB001', N'Backup', 0)
INSERT [dbo].[Familia] ([id_familia], [descripcion], [principal]) VALUES (N'ML001', N'Logs', 0)
INSERT [dbo].[Familia] ([id_familia], [descripcion], [principal]) VALUES (N'MP001', N'Perfiles', 0)
INSERT [dbo].[Familia] ([id_familia], [descripcion], [principal]) VALUES (N'MU001', N'Usuarios', 0)
INSERT [dbo].[Familia] ([id_familia], [descripcion], [principal]) VALUES (N'N0001', N'Menu', 1)
INSERT [dbo].[Familia] ([id_familia], [descripcion], [principal]) VALUES (N'NA001', N'Administrativos', 0)
INSERT [dbo].[Familia] ([id_familia], [descripcion], [principal]) VALUES (N'NA002', N'Cargar Oferta', 0)
INSERT [dbo].[Familia] ([id_familia], [descripcion], [principal]) VALUES (N'NC001', N'Coordinacion', 0)
INSERT [dbo].[Familia] ([id_familia], [descripcion], [principal]) VALUES (N'NP001', N'Profesores', 0)
INSERT [dbo].[Familia] ([id_familia], [descripcion], [principal]) VALUES (N'NR001', N'Recepcion', 0)
INSERT [dbo].[Familia] ([id_familia], [descripcion], [principal]) VALUES (N'NR002', N'Registrar Cliente', 0)
INSERT [dbo].[Familia] ([id_familia], [descripcion], [principal]) VALUES (N'NR003', N'Inscribir Cliente', 0)
INSERT [dbo].[Familia] ([id_familia], [descripcion], [principal]) VALUES (N'NR004', N'Marcar Ingreso', 0)
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Adm_Backups', 1, 1, N'Restore Data Base Will Close the Application. Do you Want to Procede? ')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Adm_Backups', 1, 2, N'Рестор Закроет Программу. Вы Хотите Продолжить?')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Adm_Backups', 1, 3, N'Restore de Base Cerrar la Aplicacion. Esta Seguro de Continuar?')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'AsignarPermisos', 1, 1, N'Policy Added')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'AsignarPermisos', 1, 2, N'Права Добавленны')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'AsignarPermisos', 1, 3, N'Permisos Agregado')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'AsignarPermisos', 2, 1, N'Something Wrong')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'AsignarPermisos', 2, 2, N'Что то пошло не так')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'AsignarPermisos', 2, 3, N'Algo Salio Mal')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Backup', 1, 1, N'Select a Valid Path and DB Name')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Backup', 1, 2, N'Выберети правельную Руту и Имя Базы')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Backup', 1, 3, N'Seleccione una Ruta Valida y Nombre de BD')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Backup', 2, 1, N'System')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Backup', 2, 2, N'Система')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Backup', 2, 3, N'Sistema')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Backup', 3, 1, N'Choose Option: Specific Day or List All')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Backup', 3, 2, N'Выберети Опцию: Число или Показать Все')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Backup ', 3, 3, N'Seleccion una Opcion: por Fecha o Listar Todos')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'BuscarCliente', 1, 1, N'Complete Id Card')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'BuscarCliente', 1, 2, N'Заполните Номер Карты')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'BuscarCliente', 1, 3, N'Complete Id Tarjeta')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CambiarEstadoOferta', 1, 1, N'Change Successful')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CambiarEstadoOferta', 1, 2, N'Изменения Успешны')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CambiarEstadoOferta', 1, 3, N'Modificacion Exitosa')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CambiarEstadoOferta', 2, 1, N'Change Faild')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CambiarEstadoOferta', 2, 2, N'Изменения не Приняты')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CambiarEstadoOferta', 2, 3, N'Modificacion Fallida')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CambioIdioma', 1, 1, N'Do you realy want this?')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CambioIdioma', 1, 2, N'Вы в правду хотите поменять язык?')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CambioIdioma', 1, 3, N'Realmente desea cambiar el idioma?')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CambioIdioma', 2, 1, N'System')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CambioIdioma', 2, 2, N'Система')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CambioIdioma', 2, 3, N'Sistema')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CambioIdioma', 3, 1, N'This Language is in use right now')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CambioIdioma', 3, 2, N'Этот язык ипользуется в настоящий момент')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CambioIdioma', 3, 3, N'Este Lenguaje se esta usando en el momento actual')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Carga_usuario', 1, 1, N'Complete the values')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Carga_usuario', 1, 2, N'Заполните Данные')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Carga_usuario', 1, 3, N'Complete los Datos')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Carga_usuario', 2, 1, N'System')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Carga_usuario', 2, 2, N'Система')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Carga_usuario', 2, 3, N'Sistema')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Carga_usuario', 3, 1, N'Select language')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Carga_usuario', 3, 2, N'Выберете Язык')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Carga_usuario', 3, 3, N'Seleccione Idioma')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CargarCliente', 1, 1, N'System')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CargarCliente', 1, 2, N'Система')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CargarCliente', 1, 3, N'Sistema')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CargarCliente', 2, 1, N'Check First Name or Last Name')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CargarCliente', 2, 2, N'Проверьте Имя или Фамилию')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CargarCliente', 2, 3, N'Revise Apellido o Nombre')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CargarCliente', 3, 1, N'Check Phone or DNI')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CargarCliente', 3, 2, N'Проверьте Телефон или ДНИ')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CargarCliente', 3, 3, N'Revise Telefono o DNI')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CargarCliente', 4, 1, N'Check e-mail')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CargarCliente', 4, 2, N'Проверте э-мейл')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CargarCliente', 4, 3, N'Revise e-mail')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CargarCliente', 5, 1, N'Check one Option')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CargarCliente', 5, 2, N'Выберите одну из Опций')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CargarCliente', 5, 3, N'Seleccione una Opcion')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CargarCliente', 6, 1, N'Check Id Card')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CargarCliente', 6, 2, N'Проверте Номер Карты')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CargarCliente', 6, 3, N'Revise el ID de Tarjeta')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CargarCliente', 7, 1, N'Complete Valid Address')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CargarCliente', 7, 2, N'Заполните Правельный Адресс')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CargarCliente', 7, 3, N'Complete Direccion Valida')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CargarOferta', 1, 1, N'Complete Description Dialog')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CargarOferta', 1, 2, N'Заполните Текст Описания')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CargarOferta', 1, 3, N'Comlete Texto de Descripcion')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CargarOferta', 2, 1, N'Promo Register Complete')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CargarOferta', 2, 2, N'Сохранение Акции Завершено')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CargarOferta', 2, 3, N'Registro de Promocion Completado')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CargarOferta', 3, 1, N'Promo Register Failed')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CargarOferta', 3, 2, N'Сохранение Акции не Удалось')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'CargarOferta', 3, 3, N'Registro de Promocion Fallido')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Coordinacion', 1, 1, N'Select an Option')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Coordinacion', 1, 2, N'Выберите Опцию')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Coordinacion', 1, 3, N'Seleccione una Opcion')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Coordinacion', 2, 1, N'The Promo is Already Active')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Coordinacion', 2, 2, N'Скидка уже Действует')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Coordinacion', 2, 3, N'La Promocion ya se Encuentra Activa')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Coordinacion', 3, 1, N'The Promo is Already Suspended')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Coordinacion', 3, 2, N'Скидка уже Отменена')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Coordinacion', 3, 3, N'La Promocion ya Esta Suspendida')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'EleminarEjercicio', 1, 1, N'Data Removed')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'EleminarEjercicio', 1, 2, N'Данные Успешно Удалены')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'EleminarEjercicio', 1, 3, N'Datos Eliminados con Exito')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'EleminarEjercicio', 2, 1, N'Data Remove Failed')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'EleminarEjercicio', 2, 2, N'Удаление Данных не Удалась')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'EleminarEjercicio', 2, 3, N'Fallo de Remover Datos')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'GestorPermisos', 1, 1, N'Are you Sure you want exit the application?')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'GestorPermisos', 1, 2, N'Вы Уверены что Хотите Выйти из Программы?')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'GestorPermisos', 1, 3, N'Esta seguro que Decea Salir de la Aplicacion?')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'GestorPermisos', 2, 1, N'You Made some Chenges in User Policy, you Need Choose Apply Button to Restar the Application ')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'GestorPermisos', 2, 2, N'Вы Произвели Изменения в Правах Пользователя, Пожалуйста Нажмите Применить что бы Перезапустить Программу')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'GestorPermisos', 2, 3, N'Usted Realizo Cambios en los Permisos de Usuario, Por favor Seleccione Boton Aplicar para Refrescar la Aplicacion ')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'GuardarEjercicios', 1, 1, N'Data Save Ok')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'GuardarEjercicios', 1, 2, N'Данные Сохранены')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'GuardarEjercicios', 1, 3, N'Datos Guardados')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'GuardarEjercicios', 2, 1, N'Data Save Failed')
GO
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'GuardarEjercicios', 2, 2, N'Сохранение Данных не Удалась')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'GuardarEjercicios', 2, 3, N'Salvado de Datos Fallo')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'HacerBackup', 1, 1, N'DB Backup Finalized Ok')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'HacerBackup', 1, 2, N'Бэкап Базы Успешно Завершен')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'HacerBackup', 1, 3, N'El Backup Finalizo con Exito')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'HacerBackup', 2, 1, N'Backup Fails')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'HacerBackup', 2, 2, N'Бэкап не Удался')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'HacerBackup', 2, 3, N'Backup Fallido')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Login', 1, 1, N'Access Granted')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Login', 1, 2, N'Доступ Авторизирован')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Login', 1, 3, N'Acceso Autorizado')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Login', 2, 1, N'Access Denie')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Login', 2, 2, N'Доступ Запрещен')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Login', 2, 3, N'Acceso Denegado')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Login', 3, 1, N'Missing user or password')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Login', 3, 2, N'Отсутвует Имя Пользователя или Пароль')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Login', 3, 3, N'Falta Usuario o la Contraseña')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Login', 4, 1, N'System')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Login', 4, 2, N'Система')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'Login', 4, 3, N'Sistema')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'MarcarIngreso', 1, 1, N'Select Client and Sport Type from the Options')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'MarcarIngreso', 1, 2, N'Выберите Клиента и Тип Спорта из Опций')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'MarcarIngreso', 1, 3, N'Seleccione un Cliente y un Tipo de Deporte de las Opciones Ofrecidas')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'MarcarIngreso', 2, 1, N'All Paymens are Overcome')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'MarcarIngreso', 2, 2, N'Все Платежи Просроченны')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'MarcarIngreso', 2, 3, N'Todos los Pagos Estan Vencidos')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'MarcarIngreso', 3, 1, N'There are no More Asistance Avaible, Pleaze Do a Payment')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'MarcarIngreso', 3, 2, N'Больше нету Уроков в Наличии, Пожалуйсто оплатите Уроки')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'MarcarIngreso', 3, 3, N'No hay mas Cantidad de Clases Disponibles, Por favor Realziar el Pago')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'MarcarIngreso', 4, 1, N'Asistance registered')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'MarcarIngreso', 4, 2, N'Вход на Урок Зарегестрирован')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'MarcarIngreso', 4, 3, N'Ingreso Registrado')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'MarcarIngreso', 5, 1, N'Save Data Failed')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'MarcarIngreso', 5, 2, N'Сохранение Данных не Удалось')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'MarcarIngreso', 5, 3, N'Registro de Datos Fallo')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'MDI_Closing', 1, 1, N'System')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'MDI_Closing', 1, 2, N'Система')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'MDI_Closing', 1, 3, N'Sistema')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'MDI_Closing', 2, 1, N'Do you want exit the app?')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'MDI_Closing', 2, 2, N'Вы хотите выйти из программы?')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'MDI_Closing', 2, 3, N'Realmente desea salir?')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'MDI_Load', 1, 1, N'Integrity of DB Fail. Call you System Administrator')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'MDI_Load', 1, 2, N'Валидация Базы Данных Провалена. Вызовите Админа Системы')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'MDI_Load', 1, 3, N'Validacion de Integridad Fallida. Llame a un Administrador del Sistema')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'MDI_Load', 2, 1, N'System')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'MDI_Load', 2, 2, N'Система')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'MDI_Load', 2, 3, N'Sistema')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'ModificarUsuario', 1, 1, N'Changes Apply')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'ModificarUsuario', 1, 2, N'Изменения Приняты')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'ModificarUsuario', 1, 3, N'Modificacion Realizada')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'ModificarUsuario', 2, 1, N'Changes Fail')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'ModificarUsuario', 2, 2, N'Изменения Отлонены')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'RegistrarCliente', 1, 1, N'Data Save Ok')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'RegistrarCliente', 1, 2, N'Данные Сохранены')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'RegistrarCliente', 1, 3, N'Registro Completado Ok')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'RegistrarCliente', 2, 1, N'Data Save Fail')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'RegistrarCliente', 2, 2, N'Данные не Сохраненны')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'RegistrarCliente', 2, 3, N'Registro Fallido')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'RegistrarCliente', 3, 1, N'Update Data Comlete')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'RegistrarCliente', 3, 2, N'Данные Модицифированны')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'RegistrarCliente', 3, 3, N'Datos Modificados')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'RegistrarCliente', 4, 1, N'Update Data Fail')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'RegistrarCliente', 4, 2, N'Модификация Данных не Удалась')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'RegistrarCliente', 4, 3, N'Modificacion Fallida')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'RegistrarPago', 1, 1, N'Payment Registered Ok')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'RegistrarPago', 1, 2, N'Платеж Зарегестрирован Успешно')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'RegistrarPago', 1, 3, N'Pago Registrado con Exito')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'RegistrarPago', 2, 1, N'Payment Register Fails')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'RegistrarPago', 2, 2, N'Платеж Небыл Зарегестрирован')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'RegistrarPago', 2, 3, N'Registro de Pago Fallido')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'RegistrarUsuario', 1, 1, N'User Registered Ok')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'RegistrarUsuario', 1, 2, N'Пользователь Зарегестрирован')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'RegistrarUsuario', 1, 3, N'Usuario Registrado Ok')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'RegistrarUsuario', 2, 1, N'User Register Fail')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'RegistrarUsuario', 2, 2, N'Регистрация Пользователя не Удалась')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'RegistrarUsuario', 2, 3, N'Registro de Usuario Fallo')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'RemoverPermisos', 1, 1, N'Policy Removed')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'RemoverPermisos', 1, 2, N'Права Удалены')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'RemoverPermisos', 1, 3, N'Permiso Quitado')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'SalirToolStripMenuItem_Click', 1, 1, N'Do you what close the sesion?')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'SalirToolStripMenuItem_Click', 1, 2, N'Вы точно хотите выйти?')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'SalirToolStripMenuItem_Click', 1, 3, N'Realmente desea salir?')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'SalirToolStripMenuItem_Click', 2, 1, N'Close Sesion')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'SalirToolStripMenuItem_Click', 2, 2, N'Закрыть Сесию')
INSERT [dbo].[Lang_Exeption] ([function_name], [id_exepmsg], [id_idioma], [texto]) VALUES (N'SalirToolStripMenuItem_Click', 2, 3, N'Cerrar Sesion')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'AdministrativoToolStripMenuItem', 1, N'&Administrative')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'AdministrativoToolStripMenuItem', 2, N'&Менеджеры')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'AdministrativoToolStripMenuItem', 3, N'&Administrativos')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'WelcomeForm', N'ApplicationTitle', 1, N'CCCP GYM && Fitness')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'WelcomeForm', N'ApplicationTitle', 2, N'CCCP GYM && Fitness')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'WelcomeForm', N'ApplicationTitle', 3, N'CCCP GYM && Fitness')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'BackupToolStripMenuItem', 1, N'&Backups')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'BackupToolStripMenuItem', 2, N'&Бэкапы')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'BackupToolStripMenuItem', 3, N'&Backups')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Button1', 1, N'Search')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Logs', N'Button1', 1, N'List the Log')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Permisos', N'Button1', 1, N'Refresh All')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Button1', 1, N'Save Info')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Login', N'Button1', 1, N'Confirm')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo', N'Button1', 1, N'Show Report')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo_Oferta', N'Button1', 1, N'Save Promo')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Coordinacion', N'Button1', 1, N'Activate')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores', N'Button1', 1, N'Search Client')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores_Rutina', N'Button1', 1, N'Add')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion', N'Button1', 1, N'Register Client')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Button1', 1, N'Accept')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Button1', 1, N'Check times')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc_Conf', N'Button1', 1, N'Accept')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Button1', 2, N'Поиск')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Logs', N'Button1', 2, N'Показать Лог')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Permisos', N'Button1', 2, N'Обновить все')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Button1', 2, N'Сохранить ')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Login', N'Button1', 2, N'Подтвердить')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo', N'Button1', 2, N'Загрузить Отчет')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo_Oferta', N'Button1', 2, N'Сохранить Промо Акцию')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Coordinacion', N'Button1', 2, N'Внедрить')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores', N'Button1', 2, N'Поиск Клиента')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores_Rutina', N'Button1', 2, N'Добавить')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion', N'Button1', 2, N'Зарегестрировать Клиента')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Button1', 2, N'Принять')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Button1', 2, N'Посмотреть Часы')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc_Conf', N'Button1', 2, N'Принять')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Button1', 3, N'Buscar')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Logs', N'Button1', 3, N'Listar Bitacora')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Permisos', N'Button1', 3, N'Refrescar Todo')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Button1', 3, N'Salvar Datos')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Login', N'Button1', 3, N'Confirmar')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo', N'Button1', 3, N'Mostrar Reporte')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo_Oferta', N'Button1', 3, N'Guardar Oferta')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Coordinacion', N'Button1', 3, N'Activar')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores', N'Button1', 3, N'Buscar Cliente')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores_Rutina', N'Button1', 3, N'Agregar')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion', N'Button1', 3, N'Registrar Cliente')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Button1', 3, N'Aceptar')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Button1', 3, N'Chequear Horarios')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc_Conf', N'Button1', 3, N'Aceptar')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Button2', 1, N'Do Backup')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Logs', N'Button2', 1, N'Close')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Permisos', N'Button2', 1, N'Apply ')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Button2', 1, N'Search')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Login', N'Button2', 1, N'Exit')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo', N'Button2', 1, N'Create Promotion')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo_Oferta', N'Button2', 1, N'Cancel')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Coordinacion', N'Button2', 1, N'Check Promos')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores', N'Button2', 1, N'New Routine')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores_Rutina', N'Button2', 1, N'Save')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion', N'Button2', 1, N'Enroll Client')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Button2', 1, N'Search')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Button2', 1, N'Check Discount')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc_Conf', N'Button2', 1, N'Cancel')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Button2', 2, N'Сделать Бэкап')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Logs', N'Button2', 2, N'Закрыть')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Permisos', N'Button2', 2, N'Применить')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Button2', 2, N'Поиск')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Login', N'Button2', 2, N'Выход')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo', N'Button2', 2, N'Загрузить Промо Акцию')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo_Oferta', N'Button2', 2, N'Отмена')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Coordinacion', N'Button2', 2, N'Посмотреть Скидки')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores', N'Button2', 2, N'Новая Рутина')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores_Rutina', N'Button2', 2, N'Сохранить')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion', N'Button2', 2, N'Записать Клиента')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Button2', 2, N'Поиск')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Button2', 2, N'Посмотреть Скидки')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc_Conf', N'Button2', 2, N'Отменить')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Button2', 3, N'Realizar Backup')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Logs', N'Button2', 3, N'Cerrar')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Permisos', N'Button2', 3, N'Aplicar')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Button2', 3, N'Buscar')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Login', N'Button2', 3, N'Salir')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo', N'Button2', 3, N'Cargar Oferta')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo_Oferta', N'Button2', 3, N'Cancelar')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Coordinacion', N'Button2', 3, N'Ver Ofertas')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores', N'Button2', 3, N'Nueva Rutina')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores_Rutina', N'Button2', 3, N'Guardar')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion', N'Button2', 3, N'Inscribir Cliente')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Button2', 3, N'Buscar')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Button2', 3, N'Ver Descuentos')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc_Conf', N'Button2', 3, N'Cancelar')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Button3', 1, N'Do Restore')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Permisos', N'Button3', 1, N'Close')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Button3', 1, N'Exit')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Coordinacion', N'Button3', 1, N'Suspend')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores', N'Button3', 1, N'Modify Routine')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores_Rutina', N'Button3', 1, N'Quit')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion', N'Button3', 1, N'Search Client')
GO
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Button3', 1, N'Exit')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Button3', 1, N'Enroll')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Button3', 2, N'Сделать Рестор')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Permisos', N'Button3', 2, N'Закрыть')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Button3', 2, N'Выход')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Coordinacion', N'Button3', 2, N'Отменить')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores', N'Button3', 2, N'Изменить Рутину')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores_Rutina', N'Button3', 2, N'Выйти')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion', N'Button3', 2, N'Найти Клиента')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Button3', 2, N'Выйти')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Button3', 2, N'Записать')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Button3', 3, N'Realizar Restore')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Permisos', N'Button3', 3, N'Cerrar')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Button3', 3, N'Salir')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Coordinacion', N'Button3', 3, N'Suspender')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores', N'Button3', 3, N'Modificar Rutina')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores_Rutina', N'Button3', 3, N'Salir')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion', N'Button3', 3, N'Buscar Cliente')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Button3', 3, N'Salir')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Button3', 3, N'Inscribir')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Button4', 1, N'Close')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores_Rutina', N'Button4', 1, N'Remove')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion', N'Button4', 1, N'Cheking')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Button4', 1, N'Exit')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Button4', 2, N'Закрыть')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores_Rutina', N'Button4', 2, N'Удалить')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion', N'Button4', 2, N'Зарегестрировать Вход')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Button4', 2, N'Выход')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Button4', 3, N'Cerrar')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores_Rutina', N'Button4', 3, N'Quitar')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion', N'Button4', 3, N'Marcar Ingreso')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Button4', 3, N'Salir')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Button5', 1, N'...')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Button5', 1, N'Search Client')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Button5', 2, N'...')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Button5', 2, N'Поиск Клиента')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Button5', 3, N'...')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Button5', 3, N'Buscar Cliente')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Button6', 1, N'List DB ')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Button6', 1, N'Enroll')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Button6', 2, N'Показать Имена Баз')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Button6', 2, N'Записать')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Button6', 3, N'Listar BD')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Button6', 3, N'Inscribir')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Button7', 1, N'...')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Button7', 1, N'Back')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Button7', 2, N'...')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Button7', 2, N'Назад')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Button7', 3, N'...')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Button7', 3, N'Volver')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'CoordinacionToolStripMenuItem', 1, N'&Coordinators')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'CoordinacionToolStripMenuItem', 2, N'&Администрация')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'CoordinacionToolStripMenuItem', 3, N'&Coordinadores')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'WelcomeForm', N'Copyright', 1, N'Copyright')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'WelcomeForm', N'Copyright', 2, N'Права')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'WelcomeForm', N'Copyright', 3, N'Copyright')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Form', 1, N'Backup Management')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Logs', N'Form', 1, N'Logs Management')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Permisos', N'Form', 1, N'Profile Manager')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Form', 1, N'Users Management')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Login', N'Form', 1, N'Log In')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'Form', 1, N'CCCP GYM & Fitness')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo', N'Form', 1, N'Administration Management')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo_Oferta', N'Form', 1, N'Promotions Load')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Coordinacion', N'Form', 1, N'Management')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores', N'Form', 1, N'Check Routine')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores_Rutina', N'Form', 1, N'Exercises')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion', N'Form', 1, N'Reception')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Form', 1, N'Client Registry')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Form', 1, N'Inscription')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc_Conf', N'Form', 1, N'Confirmation')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Form', 2, N'Администрирование Бэкапов')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Logs', N'Form', 2, N'Администрирование Логов')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Permisos', N'Form', 2, N'Настройки Профилей')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Form', 2, N'Администрирование Пользователей')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Login', N'Form', 2, N'Вход')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'Form', 2, N'СССР Гжим и Фитнес')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo', N'Form', 2, N'Администрация')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo_Oferta', N'Form', 2, N'Создание Промо Акций')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Coordinacion', N'Form', 2, N'Управление')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores', N'Form', 2, N'Регистрация Рутины')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores_Rutina', N'Form', 2, N'Упражнения')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion', N'Form', 2, N'Ресепшн')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Form', 2, N'Регистрация Клиента')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Form', 2, N'Запись')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc_Conf', N'Form', 2, N'Подтверждение')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Form', 3, N'Gestion de Backups')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Logs', N'Form', 3, N'Gestion de Bitacora')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Permisos', N'Form', 3, N'Gestion de Perfiles')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Form', 3, N'Gestion de Usuarios')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Login', N'Form', 3, N'Acceso')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'Form', 3, N'CCCP GYM & Fitness')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo', N'Form', 3, N'Gestion Administrativa')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo_Oferta', N'Form', 3, N'Carga de Promociones')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Coordinacion', N'Form', 3, N'Coordinacion')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores', N'Form', 3, N'Carga de Rutina')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores_Rutina', N'Form', 3, N'Ejercicios')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion', N'Form', 3, N'Recepcion')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Form', 3, N'Registro de Cliente')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Form', 3, N'Inscripcion')
GO
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc_Conf', N'Form', 3, N'Confirmacion')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'GestorGruposToolStripMenuItem', 1, N'&Groups')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'GestorGruposToolStripMenuItem', 2, N'&Группы')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'GestorGruposToolStripMenuItem', 3, N'&Grupos')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'GestorUsuariosToolStripMenuItem', 1, N'&Users')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'GestorUsuariosToolStripMenuItem', 2, N'&Пользователи')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'GestorUsuariosToolStripMenuItem', 3, N'&Usuarios')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores', N'GroupBox1', 1, N'Serach Client')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores', N'GroupBox1', 2, N'Поиск Клиента')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores', N'GroupBox1', 3, N'Busqueda de Cliente')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'HelpToolStripMenuItem', 1, N'&Help')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'HelpToolStripMenuItem', 2, N'&Помощь')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'HelpToolStripMenuItem', 3, N'&Ayuda')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'IdiomasToolStripMenuItem', 1, N'&Languages')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'IdiomasToolStripMenuItem', 2, N'&Языки')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'IdiomasToolStripMenuItem', 3, N'&Idiomas')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Label1', 1, N'Date of Backup')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Logs', N'Label1', 1, N'Query Date')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Permisos', N'Label1', 1, N'List of Access:')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Label1', 1, N'User ID')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Login', N'Label1', 1, N'User Nickname')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo', N'Label1', 1, N'From:')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo_Oferta', N'Label1', 1, N'Type of Promotion')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Coordinacion', N'Label1', 1, N'Activity')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores', N'Label1', 1, N'Id Card')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores_Rutina', N'Label1', 1, N'Day Number')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion', N'Label1', 1, N'Id Card')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Label1', 1, N'First Name')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Label1', 1, N'Name of Activity')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Label1', 2, N'Число Бэкапа')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Logs', N'Label1', 2, N'Число Запроса')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Permisos', N'Label1', 2, N'Список Доступов:')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Label1', 2, N'Пользователь')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Login', N'Label1', 2, N'Пользователь')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo', N'Label1', 2, N'Начиная:')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo_Oferta', N'Label1', 2, N'Промо Акция')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Coordinacion', N'Label1', 2, N'Спорт Заняти')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores', N'Label1', 2, N'Номер Карты')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores_Rutina', N'Label1', 2, N'День Тренировки')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion', N'Label1', 2, N'Номер Карты')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Label1', 2, N'Имя')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Label1', 2, N'Название Тренировки')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Label1', 3, N'Fecha de backup')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Logs', N'Label1', 3, N'Fecha de Query')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Permisos', N'Label1', 3, N'Lista de Permisos:')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Label1', 3, N'ID Usuario')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Login', N'Label1', 3, N'Usuario')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo', N'Label1', 3, N'Desde:')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo_Oferta', N'Label1', 3, N'Tipo de Promo')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Coordinacion', N'Label1', 3, N'Deportes')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores', N'Label1', 3, N'Id Tarjeta')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores_Rutina', N'Label1', 3, N'Dia de Entrenamiento')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion', N'Label1', 3, N'Id Tarjeta')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Label1', 3, N'Nombre')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Label1', 3, N'Nombre de Deporte')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Label2', 1, N'Backup File:')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Permisos', N'Label2', 1, N'List of Users:')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Label2', 1, N'Name')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Login', N'Label2', 1, N'Password')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo', N'Label2', 1, N'Until:')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo_Oferta', N'Label2', 1, N'Effective Date')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores', N'Label2', 1, N'Type of Routine')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores_Rutina', N'Label2', 1, N'Exercises')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Label2', 1, N'Last Name')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Label2', 1, N'Id Card')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Label2', 2, N'Файл Бэкапа')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Permisos', N'Label2', 2, N' Список Пользователей:')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Label2', 2, N'Имя')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Login', N'Label2', 2, N'Пароль')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo', N'Label2', 2, N'Заканчивая:')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo_Oferta', N'Label2', 2, N'Число Старта')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores', N'Label2', 2, N'Тип Рутины')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores_Rutina', N'Label2', 2, N'Упражнения')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Label2', 2, N'Фамилия')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Label2', 2, N'Номер Карты')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Label2', 3, N'Archivo Backup: ')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Permisos', N'Label2', 3, N'Lista de Usuarios:')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Label2', 3, N'Nombre')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Login', N'Label2', 3, N'Contraseña')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo', N'Label2', 3, N'Hasta:')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo_Oferta', N'Label2', 3, N'Fecha de Vigencia')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores', N'Label2', 3, N'Tipo de Rutina')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores_Rutina', N'Label2', 3, N'Ejercicios')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Label2', 3, N'Apellido')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Label2', 3, N'Id Tarjeta')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Label3', 1, N'Backup Route:')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Label3', 1, N'Last Name')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo_Oferta', N'Label3', 1, N'Finish Date')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores', N'Label3', 1, N'Trainer:')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores_Rutina', N'Label3', 1, N'Observations')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Label3', 1, N'DNI')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Label3', 1, N'Sport Type')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Label3', 2, N'Фамилия')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo_Oferta', N'Label3', 2, N'Число Конца')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores', N'Label3', 2, N'Тренер:')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores_Rutina', N'Label3', 2, N'Заметки')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Label3', 2, N'ДНИ')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Label3', 2, N'Вид Спорта')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Label3', 3, N'Ruta Backup: ')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Label3', 3, N'Apellido')
GO
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo_Oferta', N'Label3', 3, N'Fecha de Finalizacion')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores', N'Label3', 3, N'Prof:')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores_Rutina', N'Label3', 3, N'Observaciones')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Label3', 3, N'DNI')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Label3', 3, N'Tipo de Deporte')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Label4', 1, N'Instance Name')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Label4', 1, N'DNI')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo_Oferta', N'Label4', 1, N'Description')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores', N'Label4', 1, N'Name')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores_Rutina', N'Label4', 1, N'Actual Exercises')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Label4', 1, N'Birthdate')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Label4', 1, N'Promotion')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Label4', 2, N'Название Базы')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Label4', 2, N'ДНИ')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo_Oferta', N'Label4', 2, N'Описание')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores', N'Label4', 2, N'Имя')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores_Rutina', N'Label4 ', 2, N'Сохраненные Упражнения')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Label4', 2, N'День Рожденья')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Label4', 2, N'Промо Акция')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Label4', 3, N'Nombre de Instancia')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Label4', 3, N'DNI')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo_Oferta', N'Label4', 3, N'Descripcion')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores', N'Label4', 3, N'Nombre')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Label4', 3, N'Fecha de Nacimiento')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Label4', 3, N'Promocion')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Label5', 1, N'Phone')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo_Oferta', N'Label5', 1, N'Sport Assigned')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores_Rutina', N'Label5', 1, N'New Exercises')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Label5', 1, N'Address')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Label5', 1, N'Numbre of Classes')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Label5', 2, N'Телефон')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo_Oferta', N'Label5', 2, N'Вид Спорта')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores_Rutina', N'Label5', 2, N'Новые Упражнения')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Label5', 2, N'Адресс')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Label5', 2, N'Количество Уроков')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Label5', 3, N'Telefono')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Administrativo_Oferta', N'Label5', 3, N' Deporte Asignado')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores_Rutina', N'Label5', 3, N'Nuevos Ejercicios')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Label5', 3, N'Domicilio')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'Label5', 3, N'Cantidad de Clases')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Label6', 1, N'Job Title')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Label6', 1, N'Phone')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Label6', 2, N'Должность')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Label6', 2, N'Телефон')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Label6', 3, N'Cargo')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Label6', 3, N'Telefono')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Label7', 1, N'Date of Admision')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Label7', 1, N'E-mail')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Label7', 2, N'Принят')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Label7', 2, N'Эмейл')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Label7', 3, N'Fecha de Ingreso')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Label7', 3, N'E-mail')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Label8', 1, N'Default Language')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Label8', 1, N'Id Card')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Label8', 2, N'Язык по Дефолту')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Label8', 2, N'Номер Карты')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'Label8', 3, N'Idioma por Defecto')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'Label8', 3, N'Id Tarjeta')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Profesores_Rutina', N'Lable4', 3, N'Ejercicios Existentes')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'Lavel3', 2, N'Рута Бэкапа:')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'LogsToolStripMenuItem', 1, N'&Logs')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'LogsToolStripMenuItem', 2, N'&Логи')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'LogsToolStripMenuItem', 3, N'&Bitacora')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'MantenimientoToolStripMenuItem', 1, N'&Mantenance')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'MantenimientoToolStripMenuItem', 2, N'&Администрирование')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'MantenimientoToolStripMenuItem', 3, N'&Mantenimiento')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'MenuToolStripMenuItem', 1, N'&Menu')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'MenuToolStripMenuItem', 2, N'&Меню')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'MenuToolStripMenuItem', 3, N'&Menu')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'PermisosToolStripMenuItem', 1, N'&Privilege')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'PermisosToolStripMenuItem', 2, N'&Права')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'PermisosToolStripMenuItem', 3, N'&Permisos')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'ProfesoresToolStripMenuItem', 1, N'&Gym Teachers')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'ProfesoresToolStripMenuItem', 2, N'&Тренеры Спорт Зала')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'ProfesoresToolStripMenuItem', 3, N'&Profesores de GYM')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'RadioButton1', 1, N'Specific Date')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'RadioButton1', 1, N'Create New User')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Coordinacion', N'RadioButton1', 1, N'All')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'RadioButton1', 1, N'New Client')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'RadioButton1', 2, N'Определенный День')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'RadioButton1', 2, N'Создать Нового ')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Coordinacion', N'RadioButton1', 2, N'Все')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'RadioButton1', 2, N'Новый Клиент')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'RadioButton1', 3, N'Por Fecha')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'RadioButton1', 3, N'Crear Nuevo Usuario')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Coordinacion', N'RadioButton1', 3, N'Todos')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'RadioButton1', 3, N'Nuevo Cliente')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'RadioButton2', 1, N'List All')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'RadioButton2', 1, N'Disable a User')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Coordinacion', N'RadioButton2', 1, N'Pending')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'RadioButton2', 1, N'Modify Client Data')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'RadioButton2', 2, N'Показать Все')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'RadioButton2', 2, N'Отключить Пользователя ')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Coordinacion', N'RadioButton2', 2, N'Не Завершенные')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'RadioButton2', 2, N'Изменить Данные Клиента')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Backups', N'RadioButton2', 3, N'Todos')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'RadioButton2', 3, N'Desabilitar a un Usuario')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Coordinacion', N'RadioButton2', 3, N'Pendientes')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_AltaCli', N'RadioButton2', 3, N'Modificar Cliente')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'RadioButton3', 1, N'Modify User Data')
GO
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Coordinacion', N'RadioButton3', 1, N'Suspended')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'RadioButton3', 2, N'Изменить Данные ')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Coordinacion', N'RadioBUtton3', 2, N'Отменненые ')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Adm_Usuarios', N'RadioButton3', 3, N'Modificar datos de Usuario')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Coordinacion', N'RadioButton3', 3, N'Suspendidos')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'RecepcionToolStripMenuItem', 1, N'&Reception')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'RecepcionToolStripMenuItem', 2, N'&Ресепшн')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'RecepcionToolStripMenuItem', 3, N'&Recepcion')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'SalirToolStripMenuItem', 1, N'&Log Off')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'SalirToolStripMenuItem', 2, N'&Выйти')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'MDI', N'SalirToolStripMenuItem', 3, N'&Cerrar Sesion')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'TabPage1', 1, N'Main')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'TabPage1', 2, N'Основной')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'TabPage1', 3, N'Principal')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'TabPage2', 1, N'Payment')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'TabPage2', 2, N'Платежи')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'Ne_Recepcion_Insc', N'TabPage2', 3, N'Pagos')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'WelcomeForm', N'Version', 1, N'Version 1.00')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'WelcomeForm', N'Version', 2, N'Версия 1.00')
INSERT [dbo].[Lang_Interface] ([id_form], [id_control], [id_idioma], [texto]) VALUES (N'WelcomeForm', N'Version', 3, N'Version 1.00')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (1, 1, N'Form Open')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (1, 2, N'Открытое Окно')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (1, 3, N'Formulario Abireto')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (2, 1, N'Log in')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (2, 2, N'Вошол')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (2, 3, N'Acceder')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (3, 1, N'Logg off')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (3, 2, N'Выйти')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (3, 3, N'Salir')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (4, 1, N'Backup')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (4, 2, N'Бэкап')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (4, 3, N'Backup')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (5, 1, N'Restore')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (5, 2, N'Рестор')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (5, 3, N'Restore')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (6, 1, N'Lnaguage change')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (6, 2, N'Изменение Языка')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (6, 3, N'Cambio de Idioma')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (7, 1, N'User Create')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (7, 2, N'Создание Пользователя')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (7, 3, N'Creacion de Usuario')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (8, 1, N'User Disable')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (8, 2, N'Прикрытие Пользователя')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (8, 3, N'Desabilitacion de Usuario')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (9, 1, N'User Modifier ')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (9, 2, N'Изменение Поьзователя')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (9, 3, N'Modificacion de Usuario')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (10, 1, N'Password Change')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (10, 2, N'Изменение Пароля')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (10, 3, N'Cambio de Contraseña')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (11, 1, N'Client Registration')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (11, 2, N'Регистрирование  Клиента')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (11, 3, N'Registro de Cliente')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (12, 1, N'Client Inscription')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (12, 2, N'Запись Клиента')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (12, 3, N'Iscripcion de Cliente')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (13, 1, N'Access Registration')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (13, 2, N'Регистрация Входа')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (13, 3, N'Registro de Acceso')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (14, 1, N'Discount Registration')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (14, 2, N'Регистрация Скидки')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (14, 3, N'Registro de Decuento')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (15, 1, N'Discount Approval')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (15, 2, N'Разрешение для Скидки')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (15, 3, N'Aprobacion de Descuento')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (16, 1, N'Routine Registration ')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (16, 2, N'Регистрация Рутины')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (16, 3, N'Registro de Rutina')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (17, 1, N'Reporting Access')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (17, 2, N'Репортинг ')
INSERT [dbo].[Lang_Log] ([type_event], [id_idioma], [texto]) VALUES (17, 3, N'Reporte')
INSERT [dbo].[Language] ([id_idioma], [nombre]) VALUES (1, N'ENG')
INSERT [dbo].[Language] ([id_idioma], [nombre]) VALUES (2, N'RU')
INSERT [dbo].[Language] ([id_idioma], [nombre]) VALUES (3, N'ESP')
INSERT [dbo].[Log] ([id_log], [fecha_hora], [nickname], [type_event], [detalles], [dvh]) VALUES (1, CAST(N'2016-11-21 17:45:53.747' AS DateTime), N'Admin', N'1', N'Login', N'5AA8065B8D95D856')
INSERT [dbo].[Log] ([id_log], [fecha_hora], [nickname], [type_event], [detalles], [dvh]) VALUES (2, CAST(N'2016-11-21 17:45:56.707' AS DateTime), N'Admin', N'2', N'Adm_Usuarios', N'EEDCE3F9F003783E')
INSERT [dbo].[Log] ([id_log], [fecha_hora], [nickname], [type_event], [detalles], [dvh]) VALUES (3, CAST(N'2016-11-21 17:46:35.913' AS DateTime), N'Admin', N'7', N'Adm_Usuarios', N'78F85EBE7D7CFD03')
INSERT [dbo].[Log] ([id_log], [fecha_hora], [nickname], [type_event], [detalles], [dvh]) VALUES (4, CAST(N'2016-11-21 17:48:09.370' AS DateTime), N'Admin', N'2', N'MDI', N'2C01109727E2F18E')
INSERT [dbo].[Log] ([id_log], [fecha_hora], [nickname], [type_event], [detalles], [dvh]) VALUES (5, CAST(N'2016-11-22 11:53:09.780' AS DateTime), N'Admin', N'1', N'Login', N'F9A67363784754F1')
INSERT [dbo].[Log] ([id_log], [fecha_hora], [nickname], [type_event], [detalles], [dvh]) VALUES (6, CAST(N'2016-11-22 11:53:12.800' AS DateTime), N'Admin', N'3', N'Adm_Permisos', N'9C93C3BAAF788592')
INSERT [dbo].[Log] ([id_log], [fecha_hora], [nickname], [type_event], [detalles], [dvh]) VALUES (7, CAST(N'2016-11-22 11:58:40.583' AS DateTime), N'Admin', N'1', N'Login', N'DA502E8A4A6EC08E')
INSERT [dbo].[Log] ([id_log], [fecha_hora], [nickname], [type_event], [detalles], [dvh]) VALUES (8, CAST(N'2016-11-22 11:58:56.783' AS DateTime), N'Admin', N'3', N'Adm_Permisos', N'5B5AAB6F7D78C02B')
INSERT [dbo].[Log] ([id_log], [fecha_hora], [nickname], [type_event], [detalles], [dvh]) VALUES (9, CAST(N'2016-11-22 14:02:30.337' AS DateTime), N'Admin', N'1', N'Login', N'80CB96F8C43CEC08')
INSERT [dbo].[Log] ([id_log], [fecha_hora], [nickname], [type_event], [detalles], [dvh]) VALUES (10, CAST(N'2016-11-22 14:02:34.630' AS DateTime), N'Admin', N'2', N'Adm_Usuarios', N'DDC3F3915169E24A')
INSERT [dbo].[Log] ([id_log], [fecha_hora], [nickname], [type_event], [detalles], [dvh]) VALUES (11, CAST(N'2016-11-22 14:03:07.097' AS DateTime), N'Admin', N'7', N'Adm_Usuarios', N'6AB95F9913950FBB')
INSERT [dbo].[Log] ([id_log], [fecha_hora], [nickname], [type_event], [detalles], [dvh]) VALUES (12, CAST(N'2016-11-22 14:03:15.653' AS DateTime), N'Admin', N'3', N'Adm_Permisos', N'6F8E249DA86B6BA8')
INSERT [dbo].[Log] ([id_log], [fecha_hora], [nickname], [type_event], [detalles], [dvh]) VALUES (13, CAST(N'2016-11-22 14:05:31.883' AS DateTime), N'Admin', N'1', N'Login', N'F118AE18B41B1B0A')
INSERT [dbo].[Log] ([id_log], [fecha_hora], [nickname], [type_event], [detalles], [dvh]) VALUES (14, CAST(N'2016-11-22 14:05:34.963' AS DateTime), N'Admin', N'3', N'Adm_Permisos', N'CE4B9D6CBA0DB71E')
INSERT [dbo].[Membresia] ([idtarjeta], [id_deporte], [asistencia]) VALUES (N'11111', 8, CAST(N'2016-11-04 15:31:35.223' AS DateTime))
INSERT [dbo].[Membresia] ([idtarjeta], [id_deporte], [asistencia]) VALUES (N'11111', 8, CAST(N'2016-11-04 15:31:38.483' AS DateTime))
INSERT [dbo].[Oferta] ([id_oferta], [fecha_vigencia], [fecha_fin], [estado], [tipo], [descripcion], [id_deporte]) VALUES (1, CAST(N'2016-10-18' AS Date), CAST(N'2018-01-31' AS Date), 1, 0, N'Promocion asisten dos personas y paga una sola', 2)
INSERT [dbo].[Oferta] ([id_oferta], [fecha_vigencia], [fecha_fin], [estado], [tipo], [descripcion], [id_deporte]) VALUES (2, CAST(N'2016-10-18' AS Date), CAST(N'2016-12-08' AS Date), 2, 2, N'Descuendo de 20%', 2)
INSERT [dbo].[Oferta] ([id_oferta], [fecha_vigencia], [fecha_fin], [estado], [tipo], [descripcion], [id_deporte]) VALUES (3, CAST(N'2016-10-18' AS Date), CAST(N'2017-05-05' AS Date), 2, 3, N'Descuento 30%', 1)
INSERT [dbo].[Oferta] ([id_oferta], [fecha_vigencia], [fecha_fin], [estado], [tipo], [descripcion], [id_deporte]) VALUES (4, CAST(N'2016-10-19' AS Date), CAST(N'2016-12-14' AS Date), 0, 2, N'Descuento de 20%', 1)
INSERT [dbo].[Oferta] ([id_oferta], [fecha_vigencia], [fecha_fin], [estado], [tipo], [descripcion], [id_deporte]) VALUES (5, CAST(N'2016-05-05' AS Date), CAST(N'2016-08-05' AS Date), 1, 5, N'Descuento 50%', 3)
INSERT [dbo].[Oferta] ([id_oferta], [fecha_vigencia], [fecha_fin], [estado], [tipo], [descripcion], [id_deporte]) VALUES (6, CAST(N'2016-08-08' AS Date), CAST(N'2017-03-01' AS Date), 1, 3, N'Descuento 30%', 6)
INSERT [dbo].[Patente] ([id_patente], [id_familia]) VALUES (N'MB001', N'M0001')
INSERT [dbo].[Patente] ([id_patente], [id_familia]) VALUES (N'ML001', N'M0001')
INSERT [dbo].[Patente] ([id_patente], [id_familia]) VALUES (N'MP001', N'M0001')
INSERT [dbo].[Patente] ([id_patente], [id_familia]) VALUES (N'MU001', N'M0001')
INSERT [dbo].[Patente] ([id_patente], [id_familia]) VALUES (N'NA001', N'N0001')
INSERT [dbo].[Patente] ([id_patente], [id_familia]) VALUES (N'NC001', N'N0001')
INSERT [dbo].[Patente] ([id_patente], [id_familia]) VALUES (N'NP001', N'N0001')
INSERT [dbo].[Patente] ([id_patente], [id_familia]) VALUES (N'NR001', N'N0001')
INSERT [dbo].[Patente] ([id_patente], [id_familia]) VALUES (N'NA002', N'NA001')
INSERT [dbo].[Patente] ([id_patente], [id_familia]) VALUES (N'NR002', N'NR001')
INSERT [dbo].[Patente] ([id_patente], [id_familia]) VALUES (N'NR003', N'NR001')
INSERT [dbo].[Patente] ([id_patente], [id_familia]) VALUES (N'NR004', N'NR001')
INSERT [dbo].[Ticket] ([idtarjeta], [id_deporte], [fecha_pago], [monto], [cantidad_clases], [dvh]) VALUES (N'11111', 1, CAST(N'2016-11-21' AS Date), CAST(100.000 AS Decimal(18, 3)), 0, N'B308824C9F3FD00F')
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (1, N'lunes', CAST(N'10:00:00' AS Time), 3)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (2, N'lunes', CAST(N'11:00:00' AS Time), 3)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (3, N'lunes ', CAST(N'12:00:00' AS Time), 3)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (4, N'jueves', CAST(N'10:00:00' AS Time), 3)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (5, N'jueves', CAST(N'11:00:00' AS Time), 3)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (6, N'jueves', CAST(N'12:00:00' AS Time), 3)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (7, N'martes', CAST(N'16:00:00' AS Time), 3)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (8, N'martes', CAST(N'17:00:00' AS Time), 3)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (9, N'martes', CAST(N'18:00:00' AS Time), 3)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (10, N'martes', CAST(N'19:00:00' AS Time), 3)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (11, N'martes', CAST(N'20:00:00' AS Time), 3)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (12, N'viernes', CAST(N'16:00:00' AS Time), 3)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (13, N'viernes', CAST(N'17:00:00' AS Time), 3)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (14, N'viernes', CAST(N'18:00:00' AS Time), 3)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (15, N'viernes', CAST(N'19:00:00' AS Time), 3)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (16, N'viernes', CAST(N'20:00:00' AS Time), 3)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (17, N'miercoles', CAST(N'09:00:00' AS Time), 4)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (18, N'miercoles', CAST(N'10:00:00' AS Time), 4)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (19, N'miercoles', CAST(N'11:00:00' AS Time), 4)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (20, N'miercoles', CAST(N'12:00:00' AS Time), 4)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (21, N'lunes', CAST(N'18:00:00' AS Time), 4)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (22, N'lunes', CAST(N'19:00:00' AS Time), 4)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (23, N'lunes', CAST(N'20:00:00' AS Time), 4)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (24, N'jueves', CAST(N'18:00:00' AS Time), 4)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (25, N'jueves', CAST(N'19:00:00' AS Time), 4)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (26, N'jueves', CAST(N'20:00:00' AS Time), 4)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (27, N'lunes', CAST(N'09:00:00' AS Time), 5)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (28, N'lunes', CAST(N'10:00:00' AS Time), 5)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (29, N'lunes', CAST(N'11:00:00' AS Time), 5)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (30, N'viernes', CAST(N'09:00:00' AS Time), 5)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (31, N'viernes', CAST(N'10:00:00' AS Time), 5)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (32, N'viernes', CAST(N'11:00:00' AS Time), 5)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (33, N'martes', CAST(N'18:00:00' AS Time), 5)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (34, N'martes', CAST(N'19:00:00' AS Time), 5)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (35, N'martes', CAST(N'20:00:00' AS Time), 5)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (36, N'jueves', CAST(N'19:00:00' AS Time), 5)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (37, N'jueves', CAST(N'20:00:00' AS Time), 5)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (38, N'sabado', CAST(N'09:00:00' AS Time), 5)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (39, N'sabado', CAST(N'10:00:00' AS Time), 5)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (40, N'sabado', CAST(N'11:00:00' AS Time), 5)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (41, N'sabado', CAST(N'16:00:00' AS Time), 5)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (42, N'sabado', CAST(N'17:00:00' AS Time), 5)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (43, N'sabado', CAST(N'18:00:00' AS Time), 5)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (44, N'sabado', CAST(N'19:00:00' AS Time), 5)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (45, N'martes', CAST(N'10:00:00' AS Time), 6)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (46, N'martes', CAST(N'11:00:00' AS Time), 6)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (48, N'martes', CAST(N'12:00:00' AS Time), 6)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (49, N'martes', CAST(N'18:00:00' AS Time), 6)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (50, N'martes', CAST(N'19:00:00' AS Time), 6)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (51, N'martes', CAST(N'20:00:00' AS Time), 6)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (52, N'jueves', CAST(N'10:00:00' AS Time), 6)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (53, N'jueves', CAST(N'11:00:00' AS Time), 6)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (54, N'jueves', CAST(N'12:00:00' AS Time), 6)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (55, N'jueves', CAST(N'18:00:00' AS Time), 6)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (56, N'jueves', CAST(N'19:00:00' AS Time), 6)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (57, N'jueves', CAST(N'20:00:00' AS Time), 6)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (58, N'sabado', CAST(N'16:00:00' AS Time), 6)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (59, N'sabado', CAST(N'17:00:00' AS Time), 6)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (60, N'sabado', CAST(N'18:00:00' AS Time), 6)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (61, N'sabado', CAST(N'19:00:00' AS Time), 6)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (62, N'sabado', CAST(N'20:00:00' AS Time), 6)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (63, N'lunes', CAST(N'09:00:00' AS Time), 7)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (64, N'lunes', CAST(N'10:00:00' AS Time), 7)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (65, N'lunes', CAST(N'11:00:00' AS Time), 7)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (66, N'lunes', CAST(N'16:00:00' AS Time), 7)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (67, N'lunes', CAST(N'17:00:00' AS Time), 7)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (68, N'lunes', CAST(N'18:00:00' AS Time), 7)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (69, N'lunes', CAST(N'19:00:00' AS Time), 7)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (70, N'lunes', CAST(N'20:00:00' AS Time), 7)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (71, N'viernes', CAST(N'09:00:00' AS Time), 7)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (72, N'viernes', CAST(N'10:00:00' AS Time), 7)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (73, N'viernes', CAST(N'11:00:00' AS Time), 7)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (74, N'viernes', CAST(N'12:00:00' AS Time), 7)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (75, N'viernes', CAST(N'16:00:00' AS Time), 7)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (76, N'viernes', CAST(N'17:00:00' AS Time), 7)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (77, N'viernes', CAST(N'18:00:00' AS Time), 7)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (78, N'viernes', CAST(N'19:00:00' AS Time), 7)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (79, N'viernes', CAST(N'20:00:00' AS Time), 7)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (80, N'miercoles', CAST(N'18:00:00' AS Time), 8)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (81, N'miercoles', CAST(N'19:00:00' AS Time), 8)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (82, N'miercoles', CAST(N'20:00:00' AS Time), 8)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (83, N'jueves', CAST(N'18:00:00' AS Time), 8)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (84, N'jueves', CAST(N'19:00:00' AS Time), 8)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (85, N'jueves', CAST(N'20:00:00' AS Time), 8)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (86, N'sabado', CAST(N'18:00:00' AS Time), 8)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (87, N'sabado', CAST(N'19:00:00' AS Time), 8)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (88, N'sabado', CAST(N'20:00:00' AS Time), 8)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (89, N'lunes', CAST(N'15:00:00' AS Time), 9)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (90, N'lunes', CAST(N'16:00:00' AS Time), 9)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (91, N'lunes', CAST(N'18:00:00' AS Time), 9)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (92, N'lunes', CAST(N'19:00:00' AS Time), 9)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (93, N'miercoles', CAST(N'15:00:00' AS Time), 9)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (94, N'miercoles', CAST(N'16:00:00' AS Time), 9)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (95, N'miercoles', CAST(N'17:00:00' AS Time), 9)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (96, N'miercoles', CAST(N'18:00:00' AS Time), 9)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (97, N'miercoles', CAST(N'19:00:00' AS Time), 9)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (98, N'miercoles', CAST(N'20:00:00' AS Time), 9)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (99, N'viernes', CAST(N'15:00:00' AS Time), 9)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (100, N'viernes', CAST(N'16:00:00' AS Time), 9)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (101, N'viernes', CAST(N'17:00:00' AS Time), 9)
GO
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (102, N'viernes', CAST(N'18:00:00' AS Time), 9)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (103, N'viernes', CAST(N'19:00:00' AS Time), 9)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (104, N'martes', CAST(N'10:00:00' AS Time), 10)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (105, N'martes', CAST(N'11:00:00' AS Time), 10)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (106, N'martes', CAST(N'12:00:00' AS Time), 10)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (107, N'martes', CAST(N'17:00:00' AS Time), 10)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (108, N'martes', CAST(N'18:00:00' AS Time), 10)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (109, N'martes', CAST(N'19:00:00' AS Time), 10)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (110, N'jueves', CAST(N'10:00:00' AS Time), 10)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (111, N'jueves', CAST(N'11:00:00' AS Time), 10)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (112, N'jueves', CAST(N'16:00:00' AS Time), 10)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (113, N'jueves', CAST(N'17:00:00' AS Time), 10)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (114, N'jueves', CAST(N'18:00:00' AS Time), 10)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (115, N'jueves', CAST(N'19:00:00' AS Time), 10)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (116, N'jueves', CAST(N'20:00:00' AS Time), 10)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (117, N'sabado', CAST(N'15:00:00' AS Time), 10)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (118, N'sabado', CAST(N'16:00:00' AS Time), 10)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (119, N'sabado', CAST(N'17:00:00' AS Time), 10)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (120, N'sabado', CAST(N'18:00:00' AS Time), 10)
INSERT [dbo].[Turno] ([id_turno], [dia], [hora], [id_deporte]) VALUES (121, N'sabado', CAST(N'19:00:00' AS Time), 10)
INSERT [dbo].[User_Data] ([id_nickname], [nombre], [apellido], [DNI], [telefono], [cargo], [fecha_ingreso]) VALUES (N'Admin', N'Aleks', N'Kotylev', N'18.856.078', N'4-682-98-03', N'Sysadmin', CAST(N'2016-08-01' AS Date))
INSERT [dbo].[User_Data] ([id_nickname], [nombre], [apellido], [DNI], [telefono], [cargo], [fecha_ingreso]) VALUES (N'Prof01', N'Max', N'Power', N'30.111.567', N'4-278-91-82', N'Gym Trainer', CAST(N'2016-11-01' AS Date))
INSERT [dbo].[User_Data] ([id_nickname], [nombre], [apellido], [DNI], [telefono], [cargo], [fecha_ingreso]) VALUES (N'recep01', N'Ana', N'Kurnikova', N'90.444.111', N'4-666-23-41', N'Administrative Reception', CAST(N'2016-11-03' AS Date))
INSERT [dbo].[User_Familia] ([nickname], [id_familia]) VALUES (N'Admin', N'M0001')
INSERT [dbo].[User_Familia] ([nickname], [id_familia]) VALUES (N'Admin', N'MB001')
INSERT [dbo].[User_Familia] ([nickname], [id_familia]) VALUES (N'Admin', N'ML001')
INSERT [dbo].[User_Familia] ([nickname], [id_familia]) VALUES (N'Admin', N'MP001')
INSERT [dbo].[User_Familia] ([nickname], [id_familia]) VALUES (N'Admin', N'MU001')
INSERT [dbo].[User_Familia] ([nickname], [id_familia]) VALUES (N'Admin', N'N0001')
INSERT [dbo].[User_Familia] ([nickname], [id_familia]) VALUES (N'Admin', N'NA001')
INSERT [dbo].[User_Familia] ([nickname], [id_familia]) VALUES (N'Admin', N'NA002')
INSERT [dbo].[User_Familia] ([nickname], [id_familia]) VALUES (N'Admin', N'NC001')
INSERT [dbo].[User_Familia] ([nickname], [id_familia]) VALUES (N'Admin', N'NP001')
INSERT [dbo].[User_Familia] ([nickname], [id_familia]) VALUES (N'Admin', N'NR001')
INSERT [dbo].[User_Familia] ([nickname], [id_familia]) VALUES (N'Admin', N'NR002')
INSERT [dbo].[User_Familia] ([nickname], [id_familia]) VALUES (N'Admin', N'NR003')
INSERT [dbo].[User_Familia] ([nickname], [id_familia]) VALUES (N'Admin', N'NR004')
INSERT [dbo].[User_Familia] ([nickname], [id_familia]) VALUES (N'recep01', N'N0001')
INSERT [dbo].[User_Familia] ([nickname], [id_familia]) VALUES (N'recep01', N'NR001')
INSERT [dbo].[User_Familia] ([nickname], [id_familia]) VALUES (N'recep01', N'NR002')
INSERT [dbo].[User_Familia] ([nickname], [id_familia]) VALUES (N'recep01', N'NR003')
INSERT [dbo].[User_Familia] ([nickname], [id_familia]) VALUES (N'recep01', N'NR004')
INSERT [dbo].[Usuario] ([nickname], [password], [estado], [id_idioma], [dvh]) VALUES (N'Admin', N'fORRNGKa8yYj1WaiuGE0728PF1fkz+NDVB10/sXLmcY=', 1, 1, N'68A1FE08C190D623')
INSERT [dbo].[Usuario] ([nickname], [password], [estado], [id_idioma], [dvh]) VALUES (N'Prof01', N'fORRNGKa8yYj1WaiuGE0728PF1fkz+NDVB10/sXLmcY=', 1, 1, N'147D6F9DAA753B39')
INSERT [dbo].[Usuario] ([nickname], [password], [estado], [id_idioma], [dvh]) VALUES (N'recep01', N'fORRNGKa8yYj1WaiuGE0728PF1fkz+NDVB10/sXLmcY=', 1, 2, N'12E43AA3A5348D94')
ALTER TABLE [dbo].[Ejercicio]  WITH CHECK ADD  CONSTRAINT [FK_Ejercicio_Rutina] FOREIGN KEY([id_rutina])
REFERENCES [dbo].[Rutina] ([id_rutina])
GO
ALTER TABLE [dbo].[Ejercicio] CHECK CONSTRAINT [FK_Ejercicio_Rutina]
GO
ALTER TABLE [dbo].[Lang_Exeption]  WITH CHECK ADD  CONSTRAINT [FK_Lang_Exeption_Language] FOREIGN KEY([id_idioma])
REFERENCES [dbo].[Language] ([id_idioma])
GO
ALTER TABLE [dbo].[Lang_Exeption] CHECK CONSTRAINT [FK_Lang_Exeption_Language]
GO
ALTER TABLE [dbo].[Lang_Interface]  WITH CHECK ADD  CONSTRAINT [FK_Lang_Interface_Language] FOREIGN KEY([id_idioma])
REFERENCES [dbo].[Language] ([id_idioma])
GO
ALTER TABLE [dbo].[Lang_Interface] CHECK CONSTRAINT [FK_Lang_Interface_Language]
GO
ALTER TABLE [dbo].[Lang_Log]  WITH CHECK ADD  CONSTRAINT [FK_Lang_Log_Language] FOREIGN KEY([id_idioma])
REFERENCES [dbo].[Language] ([id_idioma])
GO
ALTER TABLE [dbo].[Lang_Log] CHECK CONSTRAINT [FK_Lang_Log_Language]
GO
ALTER TABLE [dbo].[Log]  WITH CHECK ADD  CONSTRAINT [FK_Log_Usuario] FOREIGN KEY([nickname])
REFERENCES [dbo].[Usuario] ([nickname])
GO
ALTER TABLE [dbo].[Log] CHECK CONSTRAINT [FK_Log_Usuario]
GO
ALTER TABLE [dbo].[Membresia]  WITH CHECK ADD  CONSTRAINT [FK_Membresia_Cliente] FOREIGN KEY([idtarjeta])
REFERENCES [dbo].[Cliente] ([idtarjeta])
GO
ALTER TABLE [dbo].[Membresia] CHECK CONSTRAINT [FK_Membresia_Cliente]
GO
ALTER TABLE [dbo].[Membresia]  WITH CHECK ADD  CONSTRAINT [FK_Membresia_Deporte] FOREIGN KEY([id_deporte])
REFERENCES [dbo].[Deporte] ([id_deporte])
GO
ALTER TABLE [dbo].[Membresia] CHECK CONSTRAINT [FK_Membresia_Deporte]
GO
ALTER TABLE [dbo].[Oferta]  WITH CHECK ADD  CONSTRAINT [FK_Oferta_Deporte] FOREIGN KEY([id_deporte])
REFERENCES [dbo].[Deporte] ([id_deporte])
GO
ALTER TABLE [dbo].[Oferta] CHECK CONSTRAINT [FK_Oferta_Deporte]
GO
ALTER TABLE [dbo].[Patente]  WITH CHECK ADD  CONSTRAINT [FK_Patente_Familia] FOREIGN KEY([id_familia])
REFERENCES [dbo].[Familia] ([id_familia])
GO
ALTER TABLE [dbo].[Patente] CHECK CONSTRAINT [FK_Patente_Familia]
GO
ALTER TABLE [dbo].[Patente]  WITH CHECK ADD  CONSTRAINT [FK_Patente_Familia1] FOREIGN KEY([id_patente])
REFERENCES [dbo].[Familia] ([id_familia])
GO
ALTER TABLE [dbo].[Patente] CHECK CONSTRAINT [FK_Patente_Familia1]
GO
ALTER TABLE [dbo].[Rutina]  WITH CHECK ADD  CONSTRAINT [FK_Rutina_Cliente1] FOREIGN KEY([idtarjeta])
REFERENCES [dbo].[Cliente] ([idtarjeta])
GO
ALTER TABLE [dbo].[Rutina] CHECK CONSTRAINT [FK_Rutina_Cliente1]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Cliente] FOREIGN KEY([idtarjeta])
REFERENCES [dbo].[Cliente] ([idtarjeta])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Cliente]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Deporte] FOREIGN KEY([id_deporte])
REFERENCES [dbo].[Deporte] ([id_deporte])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Deporte]
GO
ALTER TABLE [dbo].[Turno]  WITH CHECK ADD  CONSTRAINT [FK_Turno_Deporte] FOREIGN KEY([id_deporte])
REFERENCES [dbo].[Deporte] ([id_deporte])
GO
ALTER TABLE [dbo].[Turno] CHECK CONSTRAINT [FK_Turno_Deporte]
GO
ALTER TABLE [dbo].[User_Data]  WITH CHECK ADD  CONSTRAINT [FK_User_Data_Usuario] FOREIGN KEY([id_nickname])
REFERENCES [dbo].[Usuario] ([nickname])
GO
ALTER TABLE [dbo].[User_Data] CHECK CONSTRAINT [FK_User_Data_Usuario]
GO
ALTER TABLE [dbo].[User_Familia]  WITH CHECK ADD  CONSTRAINT [FK_User_Familia_Familia] FOREIGN KEY([id_familia])
REFERENCES [dbo].[Familia] ([id_familia])
GO
ALTER TABLE [dbo].[User_Familia] CHECK CONSTRAINT [FK_User_Familia_Familia]
GO
ALTER TABLE [dbo].[User_Familia]  WITH CHECK ADD  CONSTRAINT [FK_User_Familia_Usuario] FOREIGN KEY([nickname])
REFERENCES [dbo].[Usuario] ([nickname])
GO
ALTER TABLE [dbo].[User_Familia] CHECK CONSTRAINT [FK_User_Familia_Usuario]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Language] FOREIGN KEY([id_idioma])
REFERENCES [dbo].[Language] ([id_idioma])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Language]
GO
/****** Object:  StoredProcedure [dbo].[Buscar_Cliente]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Buscar_Cliente]	
@idtarjeta nvarchar(50)
as
begin
select idtarjeta, nombre, apellido, dni,direccion, fecha_nacimiento,
telefono, email 
from Cliente 
where idtarjeta=@idtarjeta 
end


GO
/****** Object:  StoredProcedure [dbo].[Cargar_ejercicios]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Cargar_ejercicios]
@id_rutina int, @dia_entrenamiento int, @nombre_ejercicio int, @observacion nvarchar(50)
as 
begin
declare @id_ej int
set @id_ej=(select count (id_ejercicio ) from Ejercicio)
if @id_ej>0
begin
set @id_ej= (select max (id_ejercicio) from Ejercicio)
end
set @id_ej+=1
insert into Ejercicio(id_ejercicio,id_rutina,dia_entrenamiento,nombre_ejercicio,observacion)
values (@id_ej,@id_rutina,@dia_entrenamiento,@nombre_ejercicio,@observacion)
end

GO
/****** Object:  StoredProcedure [dbo].[Check_logs]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Check_logs]
@datetimestart datetime
as
begin
declare  @datetimefinish datetime
set @datetimefinish = @datetimestart + 1
select fecha_hora, nickname,type_event,detalles,dvh  from Log where fecha_hora between @datetimestart and @datetimefinish
end


GO
/****** Object:  StoredProcedure [dbo].[ContarPatentes]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ContarPatentes]
@id_familia nvarchar(50)
as
begin
select id_familia, id_patente
from Patente
where @id_familia=id_familia
end


GO
/****** Object:  StoredProcedure [dbo].[Crear_bkplog]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Crear_bkplog]
@fecha_hora datetime, @dbname nvarchar(50), @dbsize int
as
begin
declare @id int
set @id=(select count(*) from BackupDB)
if @id>0
begin
set @id=(select max (id_backup) from BackupDB )
end
set @id+=1
insert into BackupDB (id_backup, fecha_hora, dbname,dbsize)
values (@id, @fecha_hora,@dbname,@dbsize)
end


GO
/****** Object:  StoredProcedure [dbo].[Crear_rutina]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Crear_rutina]
@idtarjeta nvarchar(50), @nombre_prof nvarchar(50), @nombre_rutina int
as 
begin
declare @id_rutina int
set @id_rutina=(select count (id_rutina ) from Rutina)
if @id_rutina>0
begin
set @id_rutina= (select max (id_rutina) from Rutina)
end
set @id_rutina+=1
insert into Rutina (id_rutina,idtarjeta,nombre_prof,nombre_rutina)
values (@id_rutina,@idtarjeta,@nombre_prof,@nombre_rutina)
end

GO
/****** Object:  StoredProcedure [dbo].[Crear_usuario]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Crear_usuario]
@user nvarchar(50),@password nvarchar(50), @estado bit, @dvh nvarchar(50), @nombre nvarchar(50),
@apellido nvarchar(50), @dni nvarchar(50), @telefono nvarchar(50), @cargo nvarchar(50), @fecha_ingreso date, @id_idioma int
as
begin
insert into Usuario(nickname,password, estado,id_idioma, dvh)
values (@user, @password, @estado,@id_idioma, @dvh)
insert into User_Data(id_nickname,nombre,apellido,DNI,telefono,cargo,fecha_ingreso)
values(@user,@nombre,@apellido,@dni,@telefono,@cargo,@fecha_ingreso)
end

GO
/****** Object:  StoredProcedure [dbo].[Eleminar_permisos]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Eleminar_permisos]
@id_name nvarchar(50), @id_familia nvarchar(50)
as
begin
delete from User_Familia 
where @id_name=nickname and @id_familia = id_familia 
end

GO
/****** Object:  StoredProcedure [dbo].[Generar_permisos]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Generar_permisos]
@id_name nvarchar(50), @id_familia nvarchar(50)
as
begin
insert into User_Familia (id_familia,nickname)
values (@id_familia, @id_name )
end
 

GO
/****** Object:  StoredProcedure [dbo].[Insertar_DVV]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Insertar_DVV]
@id_tabla int, @codigo nvarchar(50)
as
begin
insert into DVV(id_table,hash)
values (@id_tabla,@codigo)
end


GO
/****** Object:  StoredProcedure [dbo].[Insertar_oferta]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Insertar_oferta]
@fecha_vigencia date, @fecha_fin date, @estado int, @tipo int, @detalles nvarchar(100), @id_deporte int
as
begin
declare @id_oferta int
set @id_oferta = (select count (id_oferta) from Oferta )
if @id_oferta >0
begin
set @id_oferta = (select max (id_oferta) from Oferta )
end
set @id_oferta +=1

insert into Oferta (id_oferta, fecha_vigencia , fecha_fin , estado, tipo, descripcion , id_deporte)
values (@id_oferta, @fecha_vigencia, @fecha_fin, @estado,@tipo,@detalles,@id_deporte )
end


GO
/****** Object:  StoredProcedure [dbo].[Listar_DeporteCliente]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Listar_DeporteCliente]
@fecha_desde date, @fecha_hasta date
as
begin
select Deporte.nombre, Deporte.id_deporte, Deporte.precio, Deporte.tipo,
Ticket.fecha_pago, Ticket.monto,Ticket.cantidad_clases, Cliente.nombre, Cliente.apellido, 
cliente.dni,cliente.fecha_nacimiento, Cliente.direccion, Cliente.email, Cliente.telefono ,
 Cliente.idtarjeta, Ticket.dvh 
from Deporte inner join Ticket on Deporte.id_deporte =Ticket.id_deporte inner join Cliente 
on Ticket.idtarjeta=Cliente.idtarjeta 
where Ticket.fecha_pago between @fecha_desde and @fecha_hasta 
end


GO
/****** Object:  StoredProcedure [dbo].[Listar_deportes]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Listar_deportes]
as
begin
select id_deporte,nombre,precio,tipo 
from Deporte 
end

GO
/****** Object:  StoredProcedure [dbo].[Listar_todas_ofertas]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Listar_todas_ofertas]
as
begin
select id_oferta, fecha_vigencia, fecha_fin, estado , tipo, descripcion, id_deporte 
from Oferta 
end


GO
/****** Object:  StoredProcedure [dbo].[Listar_todos_ticket]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Listar_todos_ticket]
as
begin
select id_deporte, idtarjeta, cantidad_clases, fecha_pago, monto, dvh
from Ticket
end


GO
/****** Object:  StoredProcedure [dbo].[Marcar_ingreso]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Marcar_ingreso]
@id_cliente nvarchar(50), @id_deporte int, @fecha datetime
as
begin
insert into Membresia(idtarjeta,id_deporte,asistencia )
values (@id_cliente,@id_deporte,@fecha)
end



GO
/****** Object:  StoredProcedure [dbo].[Modificar_Cliente]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Modificar_Cliente]	
@idtarjeta nvarchar(50), @nombre nvarchar(50), @apellido nvarchar(50), 
@dni nvarchar(50), @direccion nvarchar(50), @email nvarchar(50), 
@fecha_nacimiento date, @telefono nvarchar(50)
as
begin
update Cliente 
set nombre=@nombre, apellido=@apellido, dni=@dni, direccion=@direccion, email=@email, fecha_nacimiento=@fecha_nacimiento,
telefono=@telefono 
where idtarjeta=@idtarjeta 
end


GO
/****** Object:  StoredProcedure [dbo].[Modificar_DVV]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Modificar_DVV]
@id_tabla nvarchar(10), @codigo nvarchar(50)
as
begin
update DVV
set hash=@codigo
where id_table=@id_tabla
end


GO
/****** Object:  StoredProcedure [dbo].[Modificar_oferta]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Modificar_oferta]
@id_oferta int, @fecha_vigencia date, @fecha_fin date, @estado int, @tipo int, @detalles nvarchar(100), @id_deporte int
as
begin
update Oferta 
set fecha_vigencia= @fecha_vigencia,fecha_fin= @fecha_fin,
estado= @estado,tipo=@tipo,descripcion=@detalles,id_deporte= @id_deporte
where @id_oferta=id_oferta 
end


GO
/****** Object:  StoredProcedure [dbo].[Modificar_usuario]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Modificar_usuario]
@user nvarchar(50), @password nvarchar(50), @estado bit, @dvh nvarchar(50), @nombre nvarchar(50),
@apellido nvarchar(50), @dni nvarchar(50), @telefono nvarchar(50), @cargo nvarchar(50), @fecha_ingreso date, @id_idioma int
as
begin
update Usuario 
set password=@password,estado=@estado, dvh=@dvh, id_idioma=@id_idioma 
where nickname=@user
update User_Data 
set nombre=@nombre, apellido=@apellido, DNI=@dni, telefono=@telefono, cargo=@cargo, fecha_ingreso=@fecha_ingreso 
where id_nickname=@user
end

GO
/****** Object:  StoredProcedure [dbo].[Quitar_ejercicio]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Quitar_ejercicio]
@id_ejercicio int
as
begin
delete from Ejercicio
where @id_ejercicio=id_ejercicio
end

GO
/****** Object:  StoredProcedure [dbo].[Registrar_Cliente]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Registrar_Cliente]	
@idtarjeta nvarchar(50), @nombre nvarchar(50), @apellido nvarchar(50), 
@dni nvarchar(50), @direccion nvarchar(50), @email nvarchar(50), 
@fecha_nacimiento date, @telefono nvarchar(50)
as
begin
insert into Cliente (idtarjeta, nombre,apellido,direccion,dni,email,fecha_nacimiento,telefono)
values (@idtarjeta, @nombre, @apellido,@direccion,@dni,@email,@fecha_nacimiento,@telefono)
end


GO
/****** Object:  StoredProcedure [dbo].[Registrar_pago]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Registrar_pago]
@id_tarjeta nvarchar(50), @id_deporte int, @fecha_pago date, @monto decimal(18, 3), 
@cantidad_clases int, @dvh nvarchar(50)
as
begin
insert into Ticket (idtarjeta,id_deporte,fecha_pago,monto,cantidad_clases,dvh)
values (@id_tarjeta,@id_deporte,@fecha_pago,@monto,@cantidad_clases,@dvh)
end


GO
/****** Object:  StoredProcedure [dbo].[Save_log]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Save_log]
@date_time datetime, @userid nvarchar(50), @type_error nvarchar(50), @detalle nvarchar(50), @dvh  nvarchar(50)
as
begin
declare @id_log int
set @id_log=(select count (id_log ) from Log)
if @id_log>0
begin
set @id_log= (select max (id_log) from Log)
end
set @id_log+=1

insert into Log (id_log,fecha_hora,nickname,type_event, detalles, dvh)
values (@id_log,@date_time,@userid,@type_error,@detalle, @dvh) 
end


GO
/****** Object:  StoredProcedure [dbo].[Seleccionar_bkplogs]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Seleccionar_bkplogs]
@fecha_hora date
as
begin
select fecha_hora, dbname, dbsize
from BackupDB
where @fecha_hora=fecha_hora 
end


GO
/****** Object:  StoredProcedure [dbo].[Seleccionar_DVV]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Seleccionar_DVV]
as
begin
select id_table,hash
from DVV
end


GO
/****** Object:  StoredProcedure [dbo].[Seleccionar_logs]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Seleccionar_logs]
as
begin
select fecha_hora,nickname,type_event,detalles,dvh
from Log
end


GO
/****** Object:  StoredProcedure [dbo].[Seleccionar_usuarios]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Seleccionar_usuarios]
as
begin
select nickname,password, estado, id_idioma,dvh
from Usuario
end

GO
/****** Object:  StoredProcedure [dbo].[SeleccionarFamilias]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SeleccionarFamilias]
as
begin
select id_familia, descripcion, principal
from Familia
end


GO
/****** Object:  StoredProcedure [dbo].[SeleccionarPatentes]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SeleccionarPatentes]
@id_familia nvarchar(50)
as
begin
select Patente.id_patente, descripcion
from Familia inner join Patente on Familia.id_familia=Patente.id_patente
where @id_familia=Patente.id_familia
end


GO
/****** Object:  StoredProcedure [dbo].[SeleccionarPermisoUser]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SeleccionarPermisoUser]
@nickname nvarchar(50)
as
begin
select Familia.id_familia, Familia.descripcion, Familia.principal 
from Usuario inner join User_Familia on Usuario.nickname=User_Familia.nickname inner join
Familia on User_Familia.id_familia=Familia.id_familia 
where @nickname=Usuario.nickname 
end


GO
/****** Object:  StoredProcedure [dbo].[Seleccionartodos_bkplogs]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Seleccionartodos_bkplogs]
as
begin
select fecha_hora,dbname, dbsize
from BackupDB
end


GO
/****** Object:  StoredProcedure [dbo].[sp_Backup_Database]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Backup_Database] 
-- Add the parameters for the stored procedure here
 
@DBName nvarchar(255), 
@Location nvarchar(255)   
 
AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
 
SET NOCOUNT ON;
 
Declare @DBFileName nvarchar(255)
 
Set @DBFileName = datename(DD,getdate())+'_'+datename(M,getdate())+'_'+
datename(YYYY,getdate())+'_'+replace(replace(@DBName,':','_'),'\','_')+'.bak'
 
Select @DBFileName as Nombre_Base
 
EXEC ('BACKUP DATABASE ['+ @DBName +'] TO  DISK = N'''+ @Location + 
        @DBFileName +''' WITH COPY_ONLY,  NAME = N'''+ @DBName +'-Full Database Backup''')
END

GO
/****** Object:  StoredProcedure [dbo].[sp_Restore_Database]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_Restore_Database]
@DBName nvarchar(100), @Location nvarchar(200), @DeleteIfExists bit = 0
AS
BEGIN
  DECLARE @S VARCHAR(MAX);
 
  IF EXISTS(SELECT * FROM sys.DATABASES WHERE name = @DBName ) 
  BEGIN
    IF  ( @DeleteIfExists=1 )
    BEGIN
      SET @S =
           'ALTER DATABASE '+@DBName+' SET single_user WITH rollback immediate; '+
           'DROP DATABASE '+@DBName + '; ';
      EXECUTE(@S);
    END
    ELSE
      RETURN; -- Nothing to do
  END;
 
  SET @S =
      'restore DATABASE '+@DBName + ' ' +
      'FROM DISK = '''+@Location + '''  ' +
      'WITH '+
        'Recovery, ';
        
  EXECUTE (@S);
END







GO
/****** Object:  StoredProcedure [dbo].[Traer_Ejercicios]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Traer_Ejercicios]
@id_rutina as int
as
begin
select Ejercicio.id_ejercicio,Ejercicio.dia_entrenamiento,  Ejercicio.nombre_ejercicio , Ejercicio.observacion 
from Rutina inner join Ejercicio on Rutina.id_rutina=Ejercicio.id_rutina 
where @id_rutina=Rutina.id_rutina
end

GO
/****** Object:  StoredProcedure [dbo].[Traer_idiomas]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Traer_idiomas]
as
begin
select id_idioma, nombre
from Language
end


GO
/****** Object:  StoredProcedure [dbo].[Traer_idiomas_log]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Traer_idiomas_log]
as
begin 
select id_idioma, type_event,texto
from Lang_Log
end


GO
/****** Object:  StoredProcedure [dbo].[Traer_mensajes]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Traer_mensajes]
as
begin
select function_name,id_exepmsg,id_idioma,texto
from Lang_Exeption
end


GO
/****** Object:  StoredProcedure [dbo].[Traer_rutina]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Traer_rutina]
@id_tarjeta nvarchar(50)
as
begin
select Rutina.id_rutina,Rutina.nombre_rutina,Rutina.nombre_prof 
from Cliente inner join Rutina on Cliente.idtarjeta=Rutina.idtarjeta 
where Cliente.idtarjeta=@id_tarjeta
 end


GO
/****** Object:  StoredProcedure [dbo].[Traer_todas_rutinas]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Traer_todas_rutinas]
as
begin 
select id_rutina, nombre_rutina,nombre_prof 
from Rutina 
end

GO
/****** Object:  StoredProcedure [dbo].[Traer_traduccion]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Traer_traduccion]
as
begin
select id_form,id_control, id_idioma,texto 
from Lang_Interface
end


GO
/****** Object:  StoredProcedure [dbo].[Turnos_deporte]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Turnos_deporte]
@nombre_deporte nvarchar(50)
as
begin
select dia, hora
from turno inner join deporte on turno.id_deporte=deporte.id_deporte
where Deporte.nombre=@nombre_deporte
order by 
 CASE
          WHEN turno.dia = 'domingo' THEN 1
          WHEN turno.dia = 'lunes' THEN 2
          WHEN turno.dia = 'martes' THEN 3
          WHEN turno.dia = 'miercoles' THEN 4
          WHEN turno.dia = 'jueves' THEN 5
          WHEN turno.dia = 'viernes' THEN 6
          WHEN turno.dia = 'sabado' THEN 7
     END ASC, turno.hora
end

GO
/****** Object:  StoredProcedure [dbo].[Validar_asistencia]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Validar_asistencia]
@id_tarjeta as nvarchar(50)
as
begin
select Cliente.idtarjeta,Cliente.nombre,Cliente.apellido,Cliente.dni,Cliente.direccion,
Cliente.telefono,Cliente.fecha_nacimiento,Cliente.email,Membresia.asistencia,
Deporte.nombre,Deporte.precio,Deporte.tipo,Deporte.id_deporte 
from Cliente inner join Membresia on Cliente.idtarjeta=Membresia.idtarjeta inner join Deporte on
Membresia.id_deporte=Deporte.id_deporte
where Cliente.idtarjeta=@id_tarjeta 
end

GO
/****** Object:  StoredProcedure [dbo].[Validar_pago]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Validar_pago]
@id_tarjeta as nvarchar(50)
as
begin
select Cliente.idtarjeta,Cliente.nombre,Cliente.apellido,Cliente.dni,Cliente.direccion,Cliente.telefono,
Cliente.fecha_nacimiento,Cliente.email,Ticket.cantidad_clases,Ticket.fecha_pago,Ticket.monto,
Deporte.nombre,Deporte.precio,Deporte.tipo,Deporte.id_deporte, Ticket.dvh  
from Cliente inner join Ticket on Cliente.idtarjeta=Ticket.idtarjeta inner join Deporte on
Ticket.id_deporte=Deporte.id_deporte
where Cliente.idtarjeta=@id_tarjeta 
end

GO
/****** Object:  StoredProcedure [dbo].[Validar_usuario]    Script Date: 22/11/2016 02:14:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Validar_usuario]
@user nvarchar(50)
as
begin
select nickname, password, estado, id_idioma, dvh, apellido,nombre,DNI,telefono,cargo,fecha_ingreso
from Usuario inner join User_Data on Usuario.nickname = User_Data.id_nickname 
where @user=nickname
end


GO
USE [master]
GO
ALTER DATABASE [CCCP Gym-Fitness] SET  READ_WRITE 
GO
