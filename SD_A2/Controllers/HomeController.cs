using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SD_A2.Models;

namespace SD_A2.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ViewResult Start()
        {
            return View("Start");
        }

        [HttpGet]
        public ViewResult Main()
        {
            
            return View("Main");
        }    
        [HttpPost]
        public ViewResult Main(Drinks drink)
        {
            //check which button was clicked and whether all information were collected
            if (ModelState.IsValid)
            {                  
                Repo.AddResponse(drink);
                if (new Random().Next(0, 101) > 40) { drink.CupNum = true; } else { drink.CupNum = false; }
                if (new Random().Next(0, 101) > 40) { drink.SyrupNum = true; } else { drink.SyrupNum = false; }
                if (new Random().Next(0, 101) > 40) { drink.CO2Num = true; } else { drink.CO2Num = false; }
                if (new Random().Next(0, 101) > 40) { drink.ChillPlate = true; } else { drink.ChillPlate = false; }
                return View("GetDrink", drink);
            }
            else
            {
                //there is a validation error              
                return View();
            }
        }

        [HttpGet]
        public ViewResult GetDrink()
        {         
            return View("GetDrink");
        }
        [HttpPost]
        public ViewResult GetDrink(Drinks drink)
        {
            if (Request.Form["accept"].Contains("yes") == true)
            {
                drink.Acceptance = true;
                Repo.AddResponse(drink);
                return View("Thanks", drink);
            }
            else if (Request.Form["acceptco2"].Contains("yes") == true) 
            {
                drink.Acceptance = true;
                drink.CO2 = "0";
                Repo.AddResponse(drink);
                return View("Thanks", drink);
            }
            else if (Request.Form["acceptlg"].Contains("yes") == true)
            {
                drink.Acceptance = true;
                drink.DrinkSizes = Drinks.Sizes.Large;
                Repo.AddResponse(drink);
                return View("Thanks", drink);
            }
            else if (Request.Form["acceptsm"].Contains("yes") == true)
            {
                drink.Acceptance = true;
                drink.DrinkSizes = Drinks.Sizes.Small;
                Repo.AddResponse(drink);
                return View("Thanks", drink);
            }
            else if (Request.Form["acceptap"].Contains("yes") == true)
            {
                drink.Acceptance = true;
                drink.DrinkFlavours = Drinks.Flavours.Apple;
                Repo.AddResponse(drink);
                return View("Thanks", drink);
            }
            else if (Request.Form["acceptor"].Contains("yes") == true)
            {
                drink.Acceptance = true;
                drink.DrinkFlavours = Drinks.Flavours.Orange;
                Repo.AddResponse(drink);
                return View("Thanks", drink);
            }
            else
            {  
                drink.Acceptance = false;
                Repo.AddResponse(drink);
                return View("Thanks", drink);
            }
        }

        public ViewResult Thanks()
        {
            return View("Thanks");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
