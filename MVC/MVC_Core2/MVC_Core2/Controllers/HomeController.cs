using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Core2.GenericRepo;

namespace MVC_Core2.Controllers
{
    public class HomeController : Controller
    {
        private IDrinkRepository _drinkRepo;

        public HomeController(IDrinkRepository drinkRepository)
        {
            _drinkRepo = drinkRepository;
        }

        public IActionResult Index()
        {
            var model = _drinkRepo.DrinksOfweek.Where(x => x.IsDrinkOfWeek == true);
            if (model == null)
                return NotFound();
            return View(model);
        }
    }
}
