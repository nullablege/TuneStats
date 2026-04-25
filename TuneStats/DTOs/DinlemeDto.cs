namespace TuneStats.DTOs
{
    public class DinlemeDto
    {
        public long DinlemeId { get; set; }
        public string AdSoyad { get; set; } = "";
        public int Yas { get; set; }
        public string Il { get; set; } = "";
        public string Ilce { get; set; } = "";
        public string Sanatci { get; set; } = "";
        public string Sarki { get; set; } = "";
        public string Tur { get; set; } = "";
        public DateTime Tarih { get; set; }
    }
}
