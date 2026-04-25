namespace TuneStats.DTOs
{
    public class DashboardDto
    {
        public int ToplamDinleme { get; set; }
        public string Donem { get; set; } = "";
        public int ToplamSanatci { get; set; }
        public int ToplamSarki { get; set; }
        public string EnPopulerTur {  get; set; } = "";
        public string EnCokDinlenenİl {  get; set; } = "";
        public string EnCokDinlenenSanatci { get; set; } = "";
        public List<DinlemeTrendDto> DinlemeTrend { get; set; } = new List<DinlemeTrendDto>();
        public List<TurDto> TurDagilim { get; set; } = new List<TurDto>();
        public List<YasDto> YasDagilim { get; set; } = new List<YasDto>();
        public List<İlDto> İlDagilim { get; set; } = new List<İlDto>();
        public List<İlceDto> İlceDagilim { get; set; } = new List<İlceDto>();
        public List<GunDto> GunDagilim { get; set; } = new List<GunDto>();
        public List<SanatciDto> EnCokDinlenenSanatcilar { get; set; } = new List<SanatciDto>();
        public List<SarkiDto> EnCokDinlenenSarkilar { get; set; } = new List<SarkiDto>();
        public List<TopSehirDto> TopSehirler { get; set; } = new List<TopSehirDto>();
        public List<TopTurDto> TopTurlar { get; set; } = new List<TopTurDto>();
        public string Trending { get; set; } = "";

        public string EnAktifBolge { get; set; } = "";
        public string EnYogunGun { get; set; } = "";
        public AktifYasDto AktifYas { get; set; } = new AktifYasDto(); 
        

    }
}
