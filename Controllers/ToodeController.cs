﻿using API_Laohaldus.Data;
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

        [HttpGet("{kategooriaId}")]
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
    }
}