namespace API_Laohaldus.Models
{
    public class Kasutaja
    {
        public int Id { get; set; }
        public string Kasutajanimi { get; set; }
        public string E_post { get; set; }
        public string Parool { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<Tellimus> Tellimus { get; }
        public Kasutaja(string kasutajanimi, string e_post, string parool, bool isAdmin) 
        {
            Kasutajanimi = kasutajanimi;
            E_post = e_post;
            Parool = parool;
            IsAdmin = isAdmin;
        }
    }
}
