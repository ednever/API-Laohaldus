namespace API_Laohaldus.Models
{
    public class TellimusArves
    {
        public int Id { get; set; }
        public int TellimusId { get; set; }
        public int ArveId { get; set; }
        public TellimusArves(int tellimusId, int arveId) 
        {
            TellimusId = tellimusId;
            ArveId = arveId;
        }
    }
}
