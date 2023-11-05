namespace API_Laohaldus.Models
{
    public class Tellimus
    {
        public int Id { get; set; }
        public int ToodeId { get; set; }
        public int Kogus { get; set; }
        public int KasutajaId { get; set; }       
        public ICollection<TellimusArves> TellimusArves { get; }
        public Tellimus(int toodeId, int kogus, int kasutajaId) 
        { 
            ToodeId = toodeId;
            Kogus = kogus;
            KasutajaId = kasutajaId;
        }
    }
}
