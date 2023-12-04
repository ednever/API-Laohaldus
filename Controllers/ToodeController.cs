using API_Laohaldus.Data;
using API_Laohaldus.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Laohaldus.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToodeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ToodeController(ApplicationDbContext context)
        {
            _context = context;
            //Test
            //_context.Tooted.Add(new Toode("Voodi 1", 8, "tk", 10, "https://static.on24.ee/images/a/k%D1%80%D0%BE%D0%B2%D0%B0%D1%82%D1%8C-aurora-160x200-%D1%81%D0%BC-423899-2799370.jpg", 1));
            //_context.Tooted.Add(new Toode("Voodi 2", 5, "tk", 15, "https://feshmebel.com.ua/image/cache/catalog/Halmar/Krovat/Yovella/1-300x300.jpg", 1));
            //_context.Tooted.Add(new Toode("Voodi 3", 2, "tk", 45, "https://asanastore.ru/images/virtuemart/product/Krovat-Mede.jpg", 1));
            //_context.Tooted.Add(new Toode("Voodi 4", 7, "tk", 27, "https://dom35.by/upload/medialibrary/a65/%D0%BA%D1%80%D0%BE%D0%B2%D0%B0%D1%82%D1%8C%20%D1%81%20%D1%8F%D1%89%D0%B8%D0%BA%D0%BE%D0%BC%20%D0%B4%D0%BB%D1%8F%20%D0%B1%D0%B5%D0%BB%D1%8C%D1%8F.jpg", 1));
            //_context.Tooted.Add(new Toode("Voodi 5", 1, "tk", 150, "https://asanastore.ru/images/virtuemart/product/Krovat-Noli-nedorogo.jpg", 1));
            //_context.SaveChanges();
        }
        [HttpGet]
        public List<Toode> Get()
        {
            return _context.Tooted.ToList();
        }
        [HttpGet("{id}")]
        public Toode GetByID(int id)
        {
            var toode = _context.Tooted.Find(id);
            if (toode != null)
                return toode;

            return null;
        }

        [HttpGet("kat/{kategooriaId}")]
        public List<Toode> GetByKategooriaID(int kategooriaId)
        {
            List<Toode> tootedKategoorias = new List<Toode>();
            foreach (Toode toode in _context.Tooted)
            {
                if (toode.KategooriaId == kategooriaId)
                    tootedKategoorias.Add(toode);
            }
            return tootedKategoorias; 
        }
        [HttpPost]
        public List<Toode> Add([FromBody] string[] massiiv)
        {
            foreach (Toode toode in _context.Tooted)
            {
                if (toode.Nimetus == massiiv[0])
                {
                    return _context.Tooted.ToList();
                }
            }
            _context.Tooted.Add(new Toode(massiiv[0], int.Parse(massiiv[1]), massiiv[2], decimal.Parse(massiiv[3]), massiiv[4], int.Parse(massiiv[5])));
            _context.SaveChanges();

            return _context.Tooted.ToList();
        }
        [HttpDelete("{id}")]
        public List<Toode> Delete(int id)
        {
            var toode = _context.Tooted.Find(id);

            if (toode == null)
                return _context.Tooted.ToList();
            
            _context.Tooted.Remove(toode);
            _context.SaveChanges();
            return _context.Tooted.ToList();
        }
        [HttpPut]
        public List<Toode> Update([FromBody] string[] massiiv)
        {
            var toode = _context.Tooted.Find(int.Parse(massiiv[0]));

            if (toode == null)
                return _context.Tooted.ToList();

            toode.Nimetus = massiiv[1];
            toode.Kogus = int.Parse(massiiv[2]);
            toode.Uhik = massiiv[3];
            toode.Hind = decimal.Parse(massiiv[4]);
            toode.Pilt = massiiv[5];
            toode.KategooriaId = int.Parse(massiiv[6]);

            _context.Tooted.Update(toode);
            _context.SaveChanges();
            return _context.Tooted.ToList();
        }
    }
}