namespace TuneStats.DTOs
{
    public class TableDto
    {
        public List<DinlemeDto> Dinlemeler { get; set; } = new List<DinlemeDto>();
        public int ToplamKayit { get; set; }
        public int GosterilenKayit { get; set; }
        public int FarkliSanatci { get; set; }
        public int FarkliSehir { get; set; }
        public int FarkliTur { get; set; }
        public int Sayfa { get; set; }
        public int SayfaBoyutu { get; set; }
        public int ToplamSayfa { get; set; }
        public long? ArananId { get; set; }
        public string Donem { get; set; } = "";
    }
}
