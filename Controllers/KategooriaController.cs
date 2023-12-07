using API_Laohaldus.Data;
using API_Laohaldus.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Laohaldus.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KategooriaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public KategooriaController(ApplicationDbContext context)
        {
            _context = context;
            //Test
            //_context.Kategooriad.Add(new Kategooria("Voodid", "https://tsenter.ee/wp-content/uploads/2018/05/a-6.jpg"));
            //_context.Kategooriad.Add(new Kategooria("Lauad", "https://idhome.ee/wp-content/uploads/2022/02/114207.jpeg"));
            //_context.Kategooriad.Add(new Kategooria("Toolid", "https://dimir-dv.ru/images/catalog/divani_new/kreslo_monreal/kreslo_monreal_17.jpg"));
            //_context.Kategooriad.Add(new Kategooria("Diivanid", "https://isku.ee/wp-content/uploads/2021/12/Hopper_3-1-1500x1000.jpg"));
            //_context.Kategooriad.Add(new Kategooria("Riidekapid", "https://static.on24.ee/images/a/%D1%88%D0%BA%D0%B0%D1%84-%D0%BF%D0%BB%D0%B0%D1%82%D1%8F%D0%BD%D0%BE%D0%B8-click-90-cm-387194-2441908.jpg"));
            //_context.SaveChanges();
        }



        [HttpGet]
        public List<Kategooria> Get()
        {
            return _context.Kategooriad.ToList();
        }

        [HttpGet("{id}")]
        public string GetNameByID(int id)
        {
            var kategooria = _context.Kategooriad.Find(id);
            if (kategooria != null)
                return kategooria.Nimetus;    
            
            return null;
        }
    }
}