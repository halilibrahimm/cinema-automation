

create view vwSehirSinemaSalon
as
select s.sehirAd,snm.sinemaAd,sln.salonAdi 
from Sehirler s 
inner join Sinema snm on s.sehir_id=snm.sehir_id
inner join Salonlar sln on sln.sinema_id=snm.sinema_id


select *from vwSehirSinemaSalon