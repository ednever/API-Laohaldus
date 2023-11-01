namespace API_Laohaldus.Models
{
    public class Kasutaja
    {
        public int Id { get; set; }
        public string Kasutajanimi { get; set; }
        public string E_post { get; set; }
        public string Parool { get; set; }
        public ICollection<Arve> Arve { get; }
        public Kasutaja(string kasutajanimi, string e_post, string parool) 
        {
            Kasutajanimi = kasutajanimi;
            E_post = e_post;
            Parool = parool;
        }
    }
}
