using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;
using TuneStats.Context;
using TuneStats.DTOs;
using TuneStats.Models;

namespace TuneStats.Controllers
{
    public class HomeController : Controller
    {
        private readonly DapperContext _context;

        public HomeController(DapperContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var value = new DashboardDto();
            var connection = _context.CreateConnection();
            var query = "select count(*) from Dinlemeler";
            value.ToplamDinleme = await connection.QueryFirstAsync<int>(query);
            query = "select max(Tarih) from Dinlemeler";
            var DonemTarih = await connection.QueryFirstOrDefaultAsync<DateTime?>(query);
            value.Donem = DonemTarih.HasValue ? DonemTarih.Value.ToString("MMMM yyyy", new CultureInfo("tr-TR")) : "";
            query = "select count(distinct Sanatci) from Dinlemeler";
            value.ToplamSanatci = await connection.QueryFirstAsync<int>(query);
            query = "select count(distinct Sarki) from Dinlemeler";
            value.ToplamSarki = await connection.QueryFirstAsync<int>(query);
            query = "select top 1 Tur from Dinlemeler group by Tur order by Count(*) desc";
            value.EnPopulerTur = await connection.QueryFirstOrDefaultAsync<string>(query) ?? "";
            query = "select top 1 Il from Dinlemeler group by Il order by Count(*) desc";
            value.EnCokDinlenenİl = await connection.QueryFirstOrDefaultAsync<string>(query) ?? "";
            query = "select top 1 Sanatci from Dinlemeler group by Sanatci order by Count(*) desc";
            value.EnCokDinlenenSanatci = await connection.QueryFirstOrDefaultAsync<string>(query) ?? "";

            if (value.ToplamDinleme == 0)
            {
                value.DinlemeTrend = new List<DinlemeTrendDto>();
                value.TurDagilim = new List<TurDto>();
                value.YasDagilim = new List<YasDto>();
                value.İlDagilim = new List<İlDto>();
                value.İlceDagilim = new List<İlceDto>();
                value.GunDagilim = new List<GunDto>();
                value.EnCokDinlenenSanatcilar = new List<SanatciDto>();
                value.EnCokDinlenenSarkilar = new List<SarkiDto>();
                value.TopSehirler = new List<TopSehirDto>();
                value.TopTurlar = new List<TopTurDto>();
                value.Trending = "";
                value.EnAktifBolge = "";
                value.EnYogunGun = "";
                value.AktifYas = new AktifYasDto { BaslangicYas = "0", BitisYas = "0" };

                return View(value);
            }

            query = "select Tarih, Dinlenme, cast((Dinlenme * 100.0) / @toplamDinleme as decimal(18,2)) as Oran from (select top 9 cast(Tarih as date) as Tarih, count(*) as Dinlenme from Dinlemeler group by cast(Tarih as date) order by Tarih desc) as Trend order by Tarih";
            value.DinlemeTrend = (await connection.QueryAsync<DinlemeTrendDto>(query, new { toplamDinleme = value.ToplamDinleme })).ToList();
            query = "select Tur as TurAdi, count(*) as TurDinlenme, cast((count(*) * 100.0) / @toplamDinleme as decimal(18,2)) as TurDinlenmeOrani from Dinlemeler group by Tur order by TurDinlenme desc, TurAdi";
            value.TurDagilim = (await connection.QueryAsync<TurDto>(query, new { toplamDinleme = value.ToplamDinleme })).ToList();
            value.EnPopulerTur = value.TurDagilim.FirstOrDefault()?.TurAdi ?? "";
            var YasDagilim = new List<YasDto>();
            query = "select count(*) from Dinlemeler where Yas>=13 and 17>=Yas";
            var Yas1713 = new YasDto();
            Yas1713.BaslangicYas = 13;
            Yas1713.BitisYas = 17;
            Yas1713.Dinlenme = await connection.QueryFirstAsync<int>(query);
            Yas1713.Oran = value.ToplamDinleme == 0 ? 0 : (Yas1713.Dinlenme * 100) / value.ToplamDinleme;
            YasDagilim.Add(Yas1713);
            query = "select count(*) from Dinlemeler where Yas>=18 and 24>=Yas";
            var Yas2418 = new YasDto();
            Yas2418.BaslangicYas = 18;
            Yas2418.BitisYas = 24;
            Yas2418.Dinlenme = await connection.QueryFirstAsync<int>(query);
            Yas2418.Oran = value.ToplamDinleme == 0 ? 0 : (Yas2418.Dinlenme * 100) / value.ToplamDinleme;
            YasDagilim.Add(Yas2418);
            query = "select count(*) from Dinlemeler where Yas>=25 and 34>=Yas";
            var Yas2534 = new YasDto();
            Yas2534.BaslangicYas = 25;
            Yas2534.BitisYas = 34;
            Yas2534.Dinlenme = await connection.QueryFirstAsync<int>(query);
            Yas2534.Oran = value.ToplamDinleme == 0 ? 0 : (Yas2534.Dinlenme * 100) / value.ToplamDinleme;
            YasDagilim.Add(Yas2534);
            query = "select count(*) from Dinlemeler where Yas>=35 and 44>=Yas";
            var Yas3544 = new YasDto();
            Yas3544.BaslangicYas = 35;
            Yas3544.BitisYas = 44;
            Yas3544.Dinlenme = await connection.QueryFirstAsync<int>(query);
            Yas3544.Oran = value.ToplamDinleme == 0 ? 0 : (Yas3544.Dinlenme * 100) / value.ToplamDinleme;
            YasDagilim.Add(Yas3544);
            query = "select count(*) from Dinlemeler where Yas>=45 and 54>=Yas";
            var Yas4554 = new YasDto();
            Yas4554.BaslangicYas = 45;
            Yas4554.BitisYas = 54;
            Yas4554.Dinlenme = await connection.QueryFirstAsync<int>(query);
            Yas4554.Oran = value.ToplamDinleme == 0 ? 0 : (Yas4554.Dinlenme * 100) / value.ToplamDinleme;
            YasDagilim.Add(Yas4554);
            query = "select count(*) from Dinlemeler where Yas>=55 and 100>=Yas";
            var Yas55 = new YasDto();
            Yas55.BaslangicYas = 55;
            Yas55.BitisYas = 100;
            Yas55.Dinlenme = await connection.QueryFirstAsync<int>(query);
            Yas55.Oran = value.ToplamDinleme == 0 ? 0 : (Yas55.Dinlenme * 100) / value.ToplamDinleme;
            YasDagilim.Add(Yas55);
            value.YasDagilim = YasDagilim;

            query = "select top 10 Il as İlAdi, count(*) as Dinlenme, cast((count(*) * 100.0) / @toplamDinleme as decimal(18,2)) as Oran from Dinlemeler group by Il order by Dinlenme desc";
            value.İlDagilim = (await connection.QueryAsync<İlDto>(query, new { toplamDinleme = value.ToplamDinleme })).ToList();

            query = "select top 10 Ilce as İlceAdi, count(*) as Dinlenme, cast((count(*) * 100.0) / @toplamDinleme as decimal(18,2)) as Oran from Dinlemeler group by Ilce order by Dinlenme desc";
            value.İlceDagilim = (await connection.QueryAsync<İlceDto>(query, new { toplamDinleme = value.ToplamDinleme })).ToList();

            List<GunDto> GunDagilim = new List<GunDto>();

            query = "SET DATEFIRST 1; select count(*) from Dinlemeler where DATEPART(WEEKDAY, Tarih) = 1";
            var Pzt = new GunDto();
            Pzt.GunAdi = "Pazartesi";
            Pzt.Dinlenme = await connection.QueryFirstAsync<int>(query);
            Pzt.Oran = value.ToplamDinleme == 0 ? 0 : (Pzt.Dinlenme * 100) / value.ToplamDinleme;
            GunDagilim.Add(Pzt);

            query = "SET DATEFIRST 1; select count(*) from Dinlemeler where DATEPART(WEEKDAY, Tarih) = 2";
            var Sali = new GunDto();
            Sali.GunAdi = "Salı";
            Sali.Dinlenme = await connection.QueryFirstAsync<int>(query);
            Sali.Oran = value.ToplamDinleme == 0 ? 0 : (Sali.Dinlenme * 100) / value.ToplamDinleme;
            GunDagilim.Add(Sali);

            query = "SET DATEFIRST 1; select count(*) from Dinlemeler where DATEPART(WEEKDAY, Tarih) = 3";
            var Carsamba = new GunDto();
            Carsamba.GunAdi = "Çarşamba";
            Carsamba.Dinlenme = await connection.QueryFirstAsync<int>(query);
            Carsamba.Oran = value.ToplamDinleme == 0 ? 0 : (Carsamba.Dinlenme * 100) / value.ToplamDinleme;
            GunDagilim.Add(Carsamba);

            query = "SET DATEFIRST 1; select count(*) from Dinlemeler where DATEPART(WEEKDAY, Tarih) = 4";
            var Persembe = new GunDto();
            Persembe.GunAdi = "Perşembe";
            Persembe.Dinlenme = await connection.QueryFirstAsync<int>(query);
            Persembe.Oran = value.ToplamDinleme == 0 ? 0 : (Persembe.Dinlenme * 100) / value.ToplamDinleme;
            GunDagilim.Add(Persembe);

            query = "SET DATEFIRST 1; select count(*) from Dinlemeler where DATEPART(WEEKDAY, Tarih) = 5";
            var Cuma = new GunDto();
            Cuma.GunAdi = "Cuma";
            Cuma.Dinlenme = await connection.QueryFirstAsync<int>(query);
            Cuma.Oran = value.ToplamDinleme == 0 ? 0 : (Cuma.Dinlenme * 100) / value.ToplamDinleme;
            GunDagilim.Add(Cuma);

            query = "SET DATEFIRST 1; select count(*) from Dinlemeler where DATEPART(WEEKDAY, Tarih) = 6";
            var Cumartesi = new GunDto();
            Cumartesi.GunAdi = "Cumartesi";
            Cumartesi.Dinlenme = await connection.QueryFirstAsync<int>(query);
            Cumartesi.Oran = value.ToplamDinleme == 0 ? 0 : (Cumartesi.Dinlenme * 100) / value.ToplamDinleme;
            GunDagilim.Add(Cumartesi);

            query = "SET DATEFIRST 1; select count(*) from Dinlemeler where DATEPART(WEEKDAY, Tarih) = 7";
            var Pazar = new GunDto();
            Pazar.GunAdi = "Pazar";
            Pazar.Dinlenme = await connection.QueryFirstAsync<int>(query);
            Pazar.Oran = value.ToplamDinleme == 0 ? 0 : (Pazar.Dinlenme * 100) / value.ToplamDinleme;
            GunDagilim.Add(Pazar);

            value.GunDagilim = GunDagilim;

            query = "select top 10 Sanatci as SanatciAdi, count(*) as Dinlenme, cast((count(*) * 100.0) / @toplamDinleme as decimal(18,2)) as Oran from Dinlemeler group by Sanatci order by Dinlenme desc";
            value.EnCokDinlenenSanatcilar = (await connection.QueryAsync<SanatciDto>(query, new { toplamDinleme = value.ToplamDinleme })).ToList();

            query = "select top 10 Sarki as SarkiAdi, Sanatci as SanatciAdi, count(*) as Dinlenme from Dinlemeler group by Sarki, Sanatci order by Dinlenme desc";
            value.EnCokDinlenenSarkilar = (await connection.QueryAsync<SarkiDto>(query)).ToList();

            query = "select top 5 Il as SehirAdi, count(*) as Oran from Dinlemeler group by Il order by Oran desc";
            value.TopSehirler = (await connection.QueryAsync<TopSehirDto>(query)).ToList();
            var EnYuksekSehir = value.TopSehirler.Any() ? value.TopSehirler.Max(x => x.Oran) : 0;
            foreach (var Sehir in value.TopSehirler)
            {
                Sehir.Oran = EnYuksekSehir == 0 ? 0 : (Sehir.Oran * 100) / EnYuksekSehir;
            }

            query = "select top 5 Tur as TurAdi, count(*) as Oran from Dinlemeler group by Tur order by Oran desc, TurAdi";
            value.TopTurlar = (await connection.QueryAsync<TopTurDto>(query)).ToList();
            var EnYuksekTur = value.TopTurlar.Any() ? value.TopTurlar.Max(x => x.Oran) : 0;
            foreach (var Tur in value.TopTurlar)
            {
                Tur.Oran = EnYuksekTur == 0 ? 0 : (Tur.Oran * 100) / EnYuksekTur;
            }

            value.Trending = value.EnPopulerTur;

            query = "SELECT TOP 1 Il FROM Dinlemeler GROUP BY Il ORDER BY COUNT(*) DESC";
            value.EnAktifBolge = await connection.QueryFirstOrDefaultAsync<string>(query) ?? "";

            query = "SET LANGUAGE Turkish; SET DATEFIRST 1; SELECT TOP 1 DATENAME(WEEKDAY, Tarih) AS GunAdi FROM Dinlemeler GROUP BY DATEPART(WEEKDAY, Tarih), DATENAME(WEEKDAY, Tarih) ORDER BY COUNT(*) DESC";
            value.EnYogunGun = await connection.QueryFirstOrDefaultAsync<string>(query) ?? "";

            query = "select avg(cast(Yas as decimal(18,2))) from Dinlemeler";
            var OrtYas = await connection.QueryFirstOrDefaultAsync<decimal>(query);
            var AktifYasDto = new AktifYasDto();
            AktifYasDto.BaslangicYas = ((int)OrtYas - 4).ToString();
            AktifYasDto.BitisYas = ((int)OrtYas + 4).ToString();
            value.AktifYas = AktifYasDto;

            return View(value);
        }
        public async Task<IActionResult> Table(int sayfa = 1, long? id = null)
        {
            var value = new TableDto();
            var connection = _context.CreateConnection();
            var donemTarih = await connection.QueryFirstOrDefaultAsync<DateTime?>("select max(Tarih) from Dinlemeler");
            value.Donem = donemTarih.HasValue ? donemTarih.Value.ToString("MMMM yyyy", new CultureInfo("tr-TR")) : "";
            var sayfaBoyutu = 15;
            if (sayfa < 1)
            {
                sayfa = 1;
            }

            var where = id == null ? "" : " where DinlemeId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            parameters.Add("@offset", (sayfa - 1) * sayfaBoyutu);
            parameters.Add("@sayfaBoyutu", sayfaBoyutu);

            var query = "select count(*) from Dinlemeler" + where;
            value.ToplamKayit = await connection.QueryFirstAsync<int>(query, parameters);
            value.ToplamSayfa = (int)Math.Ceiling(value.ToplamKayit / (decimal)sayfaBoyutu);
            value.Sayfa = sayfa;
            value.SayfaBoyutu = sayfaBoyutu;
            value.ArananId = id;

            query = "select DinlemeId, AdSoyad, Yas, Il, Ilce, Sanatci, Sarki, Tur, Tarih from Dinlemeler" + where + " order by DinlemeId offset @offset rows fetch next @sayfaBoyutu rows only";
            value.Dinlemeler = (await connection.QueryAsync<DinlemeDto>(query, parameters)).ToList();
            value.GosterilenKayit = value.Dinlemeler.Count;

            query = "select count(distinct Sanatci) from Dinlemeler" + where;
            value.FarkliSanatci = await connection.QueryFirstAsync<int>(query, parameters);
            query = "select count(distinct Il) from Dinlemeler" + where;
            value.FarkliSehir = await connection.QueryFirstAsync<int>(query, parameters);
            query = "select count(distinct Tur) from Dinlemeler" + where;
            value.FarkliTur = await connection.QueryFirstAsync<int>(query, parameters);

            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(DinlemeDto model, int sayfa = 1)
        {
            var connection = _context.CreateConnection();
            var query = "update Dinlemeler set AdSoyad=@AdSoyad, Yas=@Yas, Il=@Il, Ilce=@Ilce, Sanatci=@Sanatci, Sarki=@Sarki, Tur=@Tur where DinlemeId=@DinlemeId";
            await connection.ExecuteAsync(query, model);

            return RedirectToAction("Table", new { sayfa });
        }

        public async Task<IActionResult> Delete(long id, int sayfa = 1)
        {
            var connection = _context.CreateConnection();
            var query = "delete from Dinlemeler where DinlemeId=@id";
            await connection.ExecuteAsync(query, new { id });

            return RedirectToAction("Table", new { sayfa });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
