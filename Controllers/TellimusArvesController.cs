using API_Laohaldus.Data;
using API_Laohaldus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Laohaldus.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TellimusArvesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TellimusArvesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("lisa")]
        public bool Add([FromBody] string[] massiiv)
        {

            for (int i = 0; i < massiiv.Length; i++)
            {
                string[] parts = massiiv[i].Split('.');

                foreach (var tellimus in _context.Tellimused)
                {
                    if (tellimus.ToodeId == int.Parse(parts[0]) && tellimus.Kogus == int.Parse(parts[1]))
                    {
                        _context.TellimusedArves.Add(new TellimusArves(tellimus.Id, _context.Arved.ToList().Last().Id));
                        _context.SaveChanges();
                    }
                }               
            }
            //Пофиксить баг с добавлением в базу данных >>> попробовать добавлять список в бд
            //Осталось затестить "1.2", "5.1"

            return true;
        }
    }
}