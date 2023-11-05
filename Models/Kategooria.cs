namespace API_Laohaldus.Models
{
    public class Kategooria
    {
        public int Id { get; set; }
        public string Nimetus { get; set; }
        public string Pilt { get; set; }
        public ICollection<Toode> Toode { get; }
        public Kategooria(string nimetus, string pilt) 
        {
            Nimetus = nimetus;
            Pilt = pilt;
        }
    }
}
