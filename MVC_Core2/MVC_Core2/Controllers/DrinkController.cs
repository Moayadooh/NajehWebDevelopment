using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Core2.GenericRepo;
using MVC_Core2.ViewModels;

namespace MVC_Core2.Controllers
{
    public class DrinkController : Controller
    {
        private ICategoryRepository _cateRepo; // blank
        private IDrinkRepository _drinkRepo; // blank

        public DrinkController(ICategoryRepository categoryRepository, IDrinkRepository drinkRepository)
        {
            _cateRepo = categoryRepository;// fill data from demo 
            _drinkRepo = drinkRepository; // fill data from demo
        }

        public IActionResult ListDrink()
        {
            DrinkViewModel drinkVM = new DrinkViewModel(); // SingleObject
            drinkVM.GetDrinks = _drinkRepo.AllDrinks; // through dependency injection "services.AddScoped<IDrinkRepository, DrinkRepo>();"
            drinkVM.CategoryName = "Soft and Hot";
            // ViewBag.currentCategory = "soft";

            //return View(_drinkRepo.AllDrinks); // _drinkRepo.AllDrinks --> here the constructor will be called
            return View(drinkVM);
        }
    }
}
