namespace API_Laohaldus.Models
{
    public class Kategooria
    {
        public int Id { get; set; }
        public string Nimetus { get; set; }
        public ICollection<Toode> Toode { get; }
        public Kategooria(string nimetus) 
        {
            Nimetus = nimetus;
        }
    }
}
