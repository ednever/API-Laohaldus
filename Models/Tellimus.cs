namespace API_Laohaldus.Models
{
    public class Tellimus
    {
        public int Id { get; set; }
        public int TooteId { get; set; }
        public int Kogus { get; set; }
        public ICollection<TellimusArves> TellimusArves { get; }
        public Tellimus(int tooteId, int kogus) 
        { 
            TooteId = tooteId;
            Kogus = kogus;
        }
    }
}
