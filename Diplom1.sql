USE [master]
GO
/****** Object:  Database [Diplom]    Script Date: 11.05.2022 04:23:40 ******/
CREATE DATABASE [Diplom]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Diplom', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Diplom.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Diplom_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Diplom_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Diplom] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Diplom].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Diplom] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Diplom] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Diplom] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Diplom] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Diplom] SET ARITHABORT OFF 
GO
ALTER DATABASE [Diplom] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Diplom] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Diplom] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Diplom] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Diplom] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Diplom] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Diplom] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Diplom] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Diplom] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Diplom] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Diplom] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Diplom] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Diplom] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Diplom] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Diplom] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Diplom] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Diplom] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Diplom] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Diplom] SET  MULTI_USER 
GO
ALTER DATABASE [Diplom] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Diplom] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Diplom] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Diplom] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Diplom] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Diplom] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Diplom] SET QUERY_STORE = OFF
GO
USE [Diplom]
GO
/****** Object:  Table [dbo].[Деятельность на ЗУ]    Script Date: 11.05.2022 04:23:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Деятельность на ЗУ](
	[ID_Деятельности] [int] NOT NULL,
	[Наименование деятельности] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Деятельность на ЗУ_1] PRIMARY KEY CLUSTERED 
(
	[ID_Деятельности] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Заявки]    Script Date: 11.05.2022 04:23:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Заявки](
	[ID_Заявки] [int] NOT NULL,
	[ID_Участка] [int] NOT NULL,
	[ID_Пользователя] [int] NOT NULL,
	[ID_Деятельности] [int] NOT NULL,
 CONSTRAINT [PK_Заявки] PRIMARY KEY CLUSTERED 
(
	[ID_Заявки] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Пользователи]    Script Date: 11.05.2022 04:23:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Пользователи](
	[ID_Пользователя] [int] NOT NULL,
	[Логин] [nvarchar](50) NOT NULL,
	[Пароль] [nvarchar](50) NOT NULL,
	[ФИО] [nvarchar](100) NOT NULL,
	[Пол] [nvarchar](7) NOT NULL,
	[Дата рождения] [date] NOT NULL,
	[Гражданство] [nvarchar](50) NOT NULL,
	[Паспорт] [nvarchar](200) NOT NULL,
	[СНИЛС] [char](11) NOT NULL,
	[ИНН] [char](12) NOT NULL,
	[Мобильный телефон] [nvarchar](16) NOT NULL,
	[Адрес электронной почты] [nvarchar](50) NOT NULL,
	[Почтовый адрес] [nvarchar](100) NOT NULL,
	[Адрес регистрации] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Пользователи] PRIMARY KEY CLUSTERED 
(
	[ID_Пользователя] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Участки]    Script Date: 11.05.2022 04:23:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Участки](
	[ID_Участка] [int] NOT NULL,
	[Регион] [nvarchar](100) NOT NULL,
	[Адрес] [nvarchar](200) NOT NULL,
	[Дата постановки на учет] [date] NOT NULL,
	[Площадь ЗУ] [int] NOT NULL,
	[Статус] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Участки] PRIMARY KEY CLUSTERED 
(
	[ID_Участка] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Деятельность на ЗУ] ([ID_Деятельности], [Наименование деятельности]) VALUES (1, N'Деятельность по особой охране и изучению природы')
INSERT [dbo].[Деятельность на ЗУ] ([ID_Деятельности], [Наименование деятельности]) VALUES (2, N'Жилая застройка')
INSERT [dbo].[Деятельность на ЗУ] ([ID_Деятельности], [Наименование деятельности]) VALUES (3, N'Использование лесов')
INSERT [dbo].[Деятельность на ЗУ] ([ID_Деятельности], [Наименование деятельности]) VALUES (4, N'Обеспечение обороны и безопасности')
INSERT [dbo].[Деятельность на ЗУ] ([ID_Деятельности], [Наименование деятельности]) VALUES (5, N'Общественное использование объектов капитального строительства')
INSERT [dbo].[Деятельность на ЗУ] ([ID_Деятельности], [Наименование деятельности]) VALUES (6, N'Отдых')
INSERT [dbo].[Деятельность на ЗУ] ([ID_Деятельности], [Наименование деятельности]) VALUES (7, N'Предпринимательство')
INSERT [dbo].[Деятельность на ЗУ] ([ID_Деятельности], [Наименование деятельности]) VALUES (8, N'Производственная деятельность')
INSERT [dbo].[Деятельность на ЗУ] ([ID_Деятельности], [Наименование деятельности]) VALUES (9, N'Сельскохозяйственное использование')
INSERT [dbo].[Деятельность на ЗУ] ([ID_Деятельности], [Наименование деятельности]) VALUES (10, N'Транспорт')
GO
INSERT [dbo].[Пользователи] ([ID_Пользователя], [Логин], [Пароль], [ФИО], [Пол], [Дата рождения], [Гражданство], [Паспорт], [СНИЛС], [ИНН], [Мобильный телефон], [Адрес электронной почты], [Почтовый адрес], [Адрес регистрации]) VALUES (0, N'remix', N'remix', N'тест', N'Мужской', CAST(N'2002-11-20' AS Date), N'Россия', N'тест', N'12345678900', N'123456789099', N'11234567890', N'ттетс', N'тест', N'тесит')
INSERT [dbo].[Пользователи] ([ID_Пользователя], [Логин], [Пароль], [ФИО], [Пол], [Дата рождения], [Гражданство], [Паспорт], [СНИЛС], [ИНН], [Мобильный телефон], [Адрес электронной почты], [Почтовый адрес], [Адрес регистрации]) VALUES (1, N'test', N'test', N'test', N'Мужской', CAST(N'2001-11-20' AS Date), N'Россия', N'test', N'12345678911', N'123456789123', N'79581434028', N'test@mail.ru', N'test', N'test')
GO
INSERT [dbo].[Участки] ([ID_Участка], [Регион], [Адрес], [Дата постановки на учет], [Площадь ЗУ], [Статус]) VALUES (1, N'Амурская область', N'Амурская область, г. Рячинск', CAST(N'2022-02-24' AS Date), 700, N'Свободен')
GO
ALTER TABLE [dbo].[Участки] ADD  CONSTRAINT [DF_Участки_Статус]  DEFAULT (N'Свободен') FOR [Статус]
GO
ALTER TABLE [dbo].[Заявки]  WITH CHECK ADD  CONSTRAINT [FK_Заявки_Деятельность на ЗУ] FOREIGN KEY([ID_Деятельности])
REFERENCES [dbo].[Деятельность на ЗУ] ([ID_Деятельности])
GO
ALTER TABLE [dbo].[Заявки] CHECK CONSTRAINT [FK_Заявки_Деятельность на ЗУ]
GO
ALTER TABLE [dbo].[Заявки]  WITH CHECK ADD  CONSTRAINT [FK_Заявки_Пользователи] FOREIGN KEY([ID_Пользователя])
REFERENCES [dbo].[Пользователи] ([ID_Пользователя])
GO
ALTER TABLE [dbo].[Заявки] CHECK CONSTRAINT [FK_Заявки_Пользователи]
GO
ALTER TABLE [dbo].[Заявки]  WITH CHECK ADD  CONSTRAINT [FK_Заявки_Участки] FOREIGN KEY([ID_Участка])
REFERENCES [dbo].[Участки] ([ID_Участка])
GO
ALTER TABLE [dbo].[Заявки] CHECK CONSTRAINT [FK_Заявки_Участки]
GO
ALTER TABLE [dbo].[Пользователи]  WITH CHECK ADD  CONSTRAINT [CK_Пользователи_ИНН] CHECK  (([ИНН] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[Пользователи] CHECK CONSTRAINT [CK_Пользователи_ИНН]
GO
ALTER TABLE [dbo].[Пользователи]  WITH CHECK ADD  CONSTRAINT [CK_Пользователи_СНИЛС] CHECK  (([СНИЛС] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[Пользователи] CHECK CONSTRAINT [CK_Пользователи_СНИЛС]
GO
USE [master]
GO
ALTER DATABASE [Diplom] SET  READ_WRITE 
GO
