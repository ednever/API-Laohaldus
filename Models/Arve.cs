namespace API_Laohaldus.Models
{
    public class Arve
    {
        public int Id { get; set; }
        public DateTime Kuupaev { get; set; }
        public ICollection<TellimusArves> TellimusArves { get; }
        public Arve(DateTime kuupaev)
        {           
            Kuupaev = kuupaev;
        }
    }
}
