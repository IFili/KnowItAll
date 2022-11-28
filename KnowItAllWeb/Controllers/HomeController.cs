using KnowItAllWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using KnowItAllWeb.Services;

namespace KnowItAllWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        OrderCalculation orderCalculation;
       

        public HomeController(ILogger<HomeController> logger, OrderCalculation orderCalculation)
        {
            _logger = logger;
            this.orderCalculation = orderCalculation;
        }






        public IActionResult Index()
        {
        
            return View();
        }

        [HttpGet]
        public IActionResult GetMaterials()
        {
            var Materials = new Materials();
            Console.WriteLine(Materials);

            return View(Materials);
        }


        [HttpPost]
        public IActionResult CreateOffer(int _wood,int _sand,int _water,int _plastic,int _iron, int _copper, int _cotton)
        {
            Materials materialObject = new Materials();

             materialObject.Wood = _wood;
             materialObject.Sand = _sand;
             materialObject.Water = _water;
             materialObject.Plastic = _plastic;
             materialObject.Iron = _iron;
             materialObject.Copper = _copper;
             materialObject.Cotton = _cotton;

            
            
          
            return View(materialObject);
        }

       
        

       

       
    }
}