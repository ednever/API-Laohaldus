namespace API_Laohaldus.Models
{
    public class Arve
    {
        public int Id { get; set; }
        public int KasutajaId { get; set; }
        public DateTime Kuupaev { get; set; }
        public ICollection<TellimusArves> TellimusArves { get; }
        public Arve(int kasutajaId, DateTime kuupaev)
        {
            KasutajaId = kasutajaId;
            Kuupaev = kuupaev;
        }
    }
}
