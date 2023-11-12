namespace API_Laohaldus.Models
{
    public class Toode
    {
        public int Id { get; set; }
        public string Nimetus { get; set; }
        public int Kogus { get; set; }
        public string Uhik { get; set; }
        public decimal Hind { get; set; }
        public string Pilt { get; set; }
        public int KategooriaId { get; set; }
        public ICollection<Tellimus> Tellimus { get; }
        public Toode(string nimetus, int kogus, string uhik, decimal hind, string pilt,int kategooriaId) 
        { 
            Nimetus = nimetus;
            Kogus = kogus;
            Uhik = uhik;
            Hind = hind;
            Pilt = pilt;
            KategooriaId = kategooriaId;
        }
    }
}
