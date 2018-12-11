-- ================================================
-- Template generated from Template Explorer using:
-- Create Scalar Function (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	select dbo.fnSehirBiletSatisi(5,2) toplamBiletSatisi
-- =============================================
ALTER FUNCTION fnSehirBiletSatisi
(
	@sehirId int,
	@zamanId int
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
	where shr.sehir_id=@sehirId and blt.zaman_id=@zamanId)





	return @donen 

END
GO

