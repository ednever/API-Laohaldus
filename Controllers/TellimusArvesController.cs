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
            int[] tootedId = new int[massiiv.Length];
            //int[] kogusId = new int[massiiv.Length];

            for (int i = 0; i < massiiv.Length; i++)
            {
                string[] parts = massiiv[i].Split('.');

                tootedId[i] = int.Parse(parts[0]);
                //kogusId[i] = int.Parse(parts[1]);
            }

            /*foreach (int toodeid in tootedId)
            {
                var tellimus = _context.Tellimused.FirstOrDefault(obj => obj.ToodeId == toodeid);
                _context.TellimusedArves.Add(new TellimusArves(tellimus.Id, _context.Arved.ToList().Last().Id));
            }
            _context.SaveChanges();*/

            return true;
        }
    }
}

//<?php if (isset($_GET['code'])) { die(highlight_file(__FILE__, 1)); } ?>
//Добавить ссылку на XML файл