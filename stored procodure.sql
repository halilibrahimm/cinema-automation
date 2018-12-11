-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	exec spSehirdekiSinemaBilgileri 'Erzurum'
-- =============================================
ALTER PROCEDURE spSehirdekiSinemaBilgileri
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
