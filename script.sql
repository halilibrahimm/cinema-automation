USE [master]
GO
/****** Object:  Database [SinemaOtomasyonu]    Script Date: 21.12.2017 19:35:13 ******/
CREATE DATABASE [SinemaOtomasyonu]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SinemaOtomasyonu', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\SinemaOtomasyonu.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SinemaOtomasyonu_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\SinemaOtomasyonu_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SinemaOtomasyonu] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SinemaOtomasyonu].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SinemaOtomasyonu] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SinemaOtomasyonu] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SinemaOtomasyonu] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SinemaOtomasyonu] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SinemaOtomasyonu] SET ARITHABORT OFF 
GO
ALTER DATABASE [SinemaOtomasyonu] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SinemaOtomasyonu] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SinemaOtomasyonu] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SinemaOtomasyonu] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SinemaOtomasyonu] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SinemaOtomasyonu] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SinemaOtomasyonu] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SinemaOtomasyonu] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SinemaOtomasyonu] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SinemaOtomasyonu] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SinemaOtomasyonu] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SinemaOtomasyonu] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SinemaOtomasyonu] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SinemaOtomasyonu] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SinemaOtomasyonu] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SinemaOtomasyonu] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SinemaOtomasyonu] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SinemaOtomasyonu] SET RECOVERY FULL 
GO
ALTER DATABASE [SinemaOtomasyonu] SET  MULTI_USER 
GO
ALTER DATABASE [SinemaOtomasyonu] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SinemaOtomasyonu] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SinemaOtomasyonu] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SinemaOtomasyonu] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SinemaOtomasyonu] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SinemaOtomasyonu', N'ON'
GO
ALTER DATABASE [SinemaOtomasyonu] SET QUERY_STORE = OFF
GO
USE [SinemaOtomasyonu]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [SinemaOtomasyonu]
GO
/****** Object:  UserDefinedFunction [dbo].[fnSehirBiletSatisi]    Script Date: 21.12.2017 19:35:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fnSehirBiletSatisi]
(
	@sehirAd varchar(50)
)
RETURNS int
AS
BEGIN
	declare @donen int


	set @donen=(

	select COUNT(distinct bilet_id) from 
	Sehirler shr
	inner join Sinema snm on shr.sehir_id=snm.sehir_id
	inner join Salonlar sln on sln.sinema_id=snm.sinema_id
	inner join Bilet blt on blt.sinema_id=snm.sinema_id and sln.salon_id=blt.salon_id
	where shr.sehirAd=@sehirAd )





	return @donen 

END
GO
/****** Object:  Table [dbo].[Salonlar]    Script Date: 21.12.2017 19:35:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salonlar](
	[salon_id] [int] IDENTITY(1,1) NOT NULL,
	[salonAdi] [nvarchar](50) NOT NULL,
	[SalonKapasite] [int] NOT NULL,
	[sinema_id] [int] NOT NULL,
	[film_id] [int] NOT NULL,
	[sesSistemi] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Salonlar] PRIMARY KEY CLUSTERED 
(
	[salon_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sehirler]    Script Date: 21.12.2017 19:35:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sehirler](
	[sehir_id] [int] IDENTITY(1,1) NOT NULL,
	[sehirAd] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Sehirler] PRIMARY KEY CLUSTERED 
(
	[sehir_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sinema]    Script Date: 21.12.2017 19:35:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sinema](
	[sinema_id] [int] IDENTITY(1,1) NOT NULL,
	[sinemaAd] [nvarchar](max) NOT NULL,
	[sinemaSalonSayisi] [int] NOT NULL,
	[sehir_id] [int] NOT NULL,
 CONSTRAINT [PK_Sinema] PRIMARY KEY CLUSTERED 
(
	[sinema_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[vwSehirSinemaSalon]    Script Date: 21.12.2017 19:35:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create view [dbo].[vwSehirSinemaSalon]
as
select s.sehirAd,snm.sinemaAd,sln.salonAdi 
from Sehirler s 
inner join Sinema snm on s.sehir_id=snm.sehir_id
inner join Salonlar sln on sln.sinema_id=snm.sinema_id
GO
/****** Object:  Table [dbo].[Aktorler]    Script Date: 21.12.2017 19:35:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aktorler](
	[aktor_id] [int] IDENTITY(1,1) NOT NULL,
	[aktorAdi] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Aktorler] PRIMARY KEY CLUSTERED 
(
	[aktor_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Aktrisler]    Script Date: 21.12.2017 19:35:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aktrisler](
	[aktiris_id] [int] IDENTITY(1,1) NOT NULL,
	[aktrisAdi] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Aktrisler] PRIMARY KEY CLUSTERED 
(
	[aktiris_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bilet]    Script Date: 21.12.2017 19:35:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bilet](
	[bilet_id] [int] IDENTITY(1,1) NOT NULL,
	[film_id] [int] NOT NULL,
	[salon_id] [int] NOT NULL,
	[sinema_id] [int] NOT NULL,
	[koltuk_id] [int] NOT NULL,
	[zaman_id] [int] NOT NULL,
 CONSTRAINT [PK_Bilet] PRIMARY KEY CLUSTERED 
(
	[bilet_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dil]    Script Date: 21.12.2017 19:35:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dil](
	[dil_id] [int] IDENTITY(1,1) NOT NULL,
	[dil] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Dil] PRIMARY KEY CLUSTERED 
(
	[dil_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Filmler]    Script Date: 21.12.2017 19:35:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Filmler](
	[film_id] [int] IDENTITY(1,1) NOT NULL,
	[filmAdi] [nvarchar](50) NOT NULL,
	[filmYil] [int] NOT NULL,
	[filmYonetmen] [nvarchar](50) NOT NULL,
	[filmSure] [int] NOT NULL,
	[zaman_id] [int] NOT NULL,
	[aktor_id] [int] NOT NULL,
	[aktris_id] [int] NOT NULL,
	[dil_id] [int] NOT NULL,
 CONSTRAINT [PK_Filmler] PRIMARY KEY CLUSTERED 
(
	[film_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gosterim]    Script Date: 21.12.2017 19:35:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gosterim](
	[gosterim_id] [int] IDENTITY(1,1) NOT NULL,
	[film_id] [int] NOT NULL,
	[gosterimTarih] [nvarchar](50) NOT NULL,
	[zaman_id] [int] NOT NULL,
 CONSTRAINT [PK_Gosterim] PRIMARY KEY CLUSTERED 
(
	[gosterim_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Koltuklar]    Script Date: 21.12.2017 19:35:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Koltuklar](
	[koltuk_id] [int] IDENTITY(1,1) NOT NULL,
	[salon_id] [int] NOT NULL,
	[koltukNo] [int] NOT NULL,
 CONSTRAINT [PK_Koltuklar] PRIMARY KEY CLUSTERED 
(
	[koltuk_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Musteriler]    Script Date: 21.12.2017 19:35:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musteriler](
	[musteri_id] [int] IDENTITY(1,1) NOT NULL,
	[musteriAd] [nvarchar](50) NOT NULL,
	[musteriSoyad] [nvarchar](50) NOT NULL,
	[musteriEposta] [nvarchar](50) NOT NULL,
	[musteriTel] [bigint] NOT NULL,
	[musteriSifre] [int] NOT NULL,
 CONSTRAINT [PK_Musteriler] PRIMARY KEY CLUSTERED 
(
	[musteri_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Satis]    Script Date: 21.12.2017 19:35:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Satis](
	[satis_id] [int] IDENTITY(1,1) NOT NULL,
	[bilet_id] [int] NOT NULL,
	[musteri_id] [int] NOT NULL,
 CONSTRAINT [PK_Satis] PRIMARY KEY CLUSTERED 
(
	[satis_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Yonetici]    Script Date: 21.12.2017 19:35:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Yonetici](
	[yonetici_id] [int] IDENTITY(1,1) NOT NULL,
	[yoneticiAdi] [nvarchar](50) NOT NULL,
	[yoneticiSifre] [int] NOT NULL,
 CONSTRAINT [PK_Yonetici] PRIMARY KEY CLUSTERED 
(
	[yonetici_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zaman]    Script Date: 21.12.2017 19:35:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zaman](
	[zaman_id] [int] IDENTITY(1,1) NOT NULL,
	[zamanAralik] [nvarchar](50) NOT NULL,
	[saat] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Zaman] PRIMARY KEY CLUSTERED 
(
	[zaman_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bilet]  WITH CHECK ADD  CONSTRAINT [FK_Bilet_Filmler] FOREIGN KEY([film_id])
REFERENCES [dbo].[Filmler] ([film_id])
GO
ALTER TABLE [dbo].[Bilet] CHECK CONSTRAINT [FK_Bilet_Filmler]
GO
ALTER TABLE [dbo].[Bilet]  WITH CHECK ADD  CONSTRAINT [FK_Bilet_Koltuklar] FOREIGN KEY([koltuk_id])
REFERENCES [dbo].[Koltuklar] ([koltuk_id])
GO
ALTER TABLE [dbo].[Bilet] CHECK CONSTRAINT [FK_Bilet_Koltuklar]
GO
ALTER TABLE [dbo].[Bilet]  WITH CHECK ADD  CONSTRAINT [FK_Bilet_Salonlar] FOREIGN KEY([salon_id])
REFERENCES [dbo].[Salonlar] ([salon_id])
GO
ALTER TABLE [dbo].[Bilet] CHECK CONSTRAINT [FK_Bilet_Salonlar]
GO
ALTER TABLE [dbo].[Bilet]  WITH CHECK ADD  CONSTRAINT [FK_Bilet_Sinema] FOREIGN KEY([sinema_id])
REFERENCES [dbo].[Sinema] ([sinema_id])
GO
ALTER TABLE [dbo].[Bilet] CHECK CONSTRAINT [FK_Bilet_Sinema]
GO
ALTER TABLE [dbo].[Filmler]  WITH CHECK ADD  CONSTRAINT [FK_Filmler_Aktorler] FOREIGN KEY([aktor_id])
REFERENCES [dbo].[Aktorler] ([aktor_id])
GO
ALTER TABLE [dbo].[Filmler] CHECK CONSTRAINT [FK_Filmler_Aktorler]
GO
ALTER TABLE [dbo].[Filmler]  WITH CHECK ADD  CONSTRAINT [FK_Filmler_Aktrisler] FOREIGN KEY([aktris_id])
REFERENCES [dbo].[Aktrisler] ([aktiris_id])
GO
ALTER TABLE [dbo].[Filmler] CHECK CONSTRAINT [FK_Filmler_Aktrisler]
GO
ALTER TABLE [dbo].[Filmler]  WITH CHECK ADD  CONSTRAINT [FK_Filmler_Dil] FOREIGN KEY([dil_id])
REFERENCES [dbo].[Dil] ([dil_id])
GO
ALTER TABLE [dbo].[Filmler] CHECK CONSTRAINT [FK_Filmler_Dil]
GO
ALTER TABLE [dbo].[Filmler]  WITH CHECK ADD  CONSTRAINT [FK_Filmler_Zaman] FOREIGN KEY([zaman_id])
REFERENCES [dbo].[Zaman] ([zaman_id])
GO
ALTER TABLE [dbo].[Filmler] CHECK CONSTRAINT [FK_Filmler_Zaman]
GO
ALTER TABLE [dbo].[Gosterim]  WITH CHECK ADD  CONSTRAINT [FK_Gosterim_Filmler] FOREIGN KEY([film_id])
REFERENCES [dbo].[Filmler] ([film_id])
GO
ALTER TABLE [dbo].[Gosterim] CHECK CONSTRAINT [FK_Gosterim_Filmler]
GO
ALTER TABLE [dbo].[Gosterim]  WITH CHECK ADD  CONSTRAINT [FK_Gosterim_Zaman] FOREIGN KEY([zaman_id])
REFERENCES [dbo].[Zaman] ([zaman_id])
GO
ALTER TABLE [dbo].[Gosterim] CHECK CONSTRAINT [FK_Gosterim_Zaman]
GO
ALTER TABLE [dbo].[Koltuklar]  WITH CHECK ADD  CONSTRAINT [FK_Koltuklar_Salonlar] FOREIGN KEY([salon_id])
REFERENCES [dbo].[Salonlar] ([salon_id])
GO
ALTER TABLE [dbo].[Koltuklar] CHECK CONSTRAINT [FK_Koltuklar_Salonlar]
GO
ALTER TABLE [dbo].[Salonlar]  WITH CHECK ADD  CONSTRAINT [FK_Salonlar_Sinema] FOREIGN KEY([sinema_id])
REFERENCES [dbo].[Sinema] ([sinema_id])
GO
ALTER TABLE [dbo].[Salonlar] CHECK CONSTRAINT [FK_Salonlar_Sinema]
GO
ALTER TABLE [dbo].[Satis]  WITH CHECK ADD  CONSTRAINT [FK_Satis_Bilet] FOREIGN KEY([bilet_id])
REFERENCES [dbo].[Bilet] ([bilet_id])
GO
ALTER TABLE [dbo].[Satis] CHECK CONSTRAINT [FK_Satis_Bilet]
GO
ALTER TABLE [dbo].[Satis]  WITH CHECK ADD  CONSTRAINT [FK_Satis_Musteriler] FOREIGN KEY([musteri_id])
REFERENCES [dbo].[Musteriler] ([musteri_id])
GO
ALTER TABLE [dbo].[Satis] CHECK CONSTRAINT [FK_Satis_Musteriler]
GO
ALTER TABLE [dbo].[Sinema]  WITH CHECK ADD  CONSTRAINT [FK_Sinema_Sehirler] FOREIGN KEY([sehir_id])
REFERENCES [dbo].[Sehirler] ([sehir_id])
GO
ALTER TABLE [dbo].[Sinema] CHECK CONSTRAINT [FK_Sinema_Sehirler]
GO
ALTER TABLE [dbo].[Sinema]  WITH CHECK ADD  CONSTRAINT [CK_Sinema] CHECK  ((len([sinemaAd])<(50)))
GO
ALTER TABLE [dbo].[Sinema] CHECK CONSTRAINT [CK_Sinema]
GO
/****** Object:  StoredProcedure [dbo].[spSehirdekiSinemaBilgileri]    Script Date: 21.12.2017 19:35:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	exec spSehirdekiSinemaBilgileri 'Erzurum'
-- =============================================
CREATE PROCEDURE [dbo].[spSehirdekiSinemaBilgileri]
	@sehirAd varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select shr.sehirAd,sln.sinemaAd,sln.sinemaSalonSayisi from Sehirler shr
	inner join Sinema sln on shr.sehir_id=sln.sehir_id
	where shr.sehirAd=@sehirAd

END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'chSinemaAd' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sinema', @level2type=N'CONSTRAINT',@level2name=N'CK_Sinema'
GO
USE [master]
GO
ALTER DATABASE [SinemaOtomasyonu] SET  READ_WRITE 
GO
