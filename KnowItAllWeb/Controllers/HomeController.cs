using KnowItAllWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using KnowItAllWeb.Services;
using KnowItAllWeb.Repository;

namespace KnowItAllWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // private readonly OfferRepository _offerRepository;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        
            //_offerRepository = offerRepository;
        }






        public IActionResult Index()
        {



            return View();
        }

        [HttpGet]
        public IActionResult GetMaterials()
        {
            var Materials = new Materials();

            // return View(Materials.MaterialType);

            return View(Materials);   
        }


        [HttpPost]
        public ActionResult CreateOffer(int Wood, int Sand, int Water, int Plastic, int Iron, int Copper, int Cotton)
        {
            Materials materialObject = new Materials();
            Offer offer = new Offer();
            OfferService offerService = new OfferService(offer);

            int counter = 0;
            if (Wood > 0) //before binding values from form to newly instantiated class (materialObject); checking whether there are at least 2 materials
            {
                counter++;
            }
            if (Sand > 0)
            {
                counter++;
            }
            if (Water > 0)
            {
                counter++;
            }
            if (Plastic > 0)
            {
                counter++;
            }
            if (Iron > 0)
            {
                counter++;
            }
            if (Copper > 0)
            {
                counter++;
            }
            if (Cotton > 0)
            {
                counter++;
            }

            if (counter < 2) // if less  than two materials are ordered, throw error
            {
                throw new Exception("Please enter an order for at least 2 material types");
            }

            materialObject.Wood = Wood;
            materialObject.Sand = Sand;
            materialObject.Water = Water;
            materialObject.Plastic = Plastic;
            materialObject.Iron = Iron;
            materialObject.Copper = Copper;
            materialObject.Cotton = Cotton;



            int _offerQuantity = offerService.getQuantity(Wood, Sand, Water, Plastic, Iron, Copper, Cotton);

            offer.MaterialQuantity = _offerQuantity; // we added quantity,   water will be added automatically for every 2nd unit of sand and every 3rd unit of water

            float _price = offerService.getPrice(materialObject.Wood, materialObject.Sand, materialObject.Water, materialObject.Plastic, materialObject.Iron, materialObject.Copper, materialObject.Copper);

            offer.OfferPrice = _price;

            int _timeByPrice = offerService.getTimebyPrice(offer.OfferPrice);
            int _timeByQuantity = offerService.getTimebyQuantity(offer.MaterialQuantity);
            int _totalTime = offerService.calculateTotalTime(_timeByPrice, _timeByQuantity);

            offer.OfferTimeToBuild = _totalTime;

            offer.OfferDate = DateTime.Now;

            //offerService.createOffer(offer);

            Random rnd = new Random(); //used to generate ID
            int _rnd = rnd.Next();

            offer.OfferId = _rnd; //assigning ID to offer

            return View(offer);

        }

       



     




        









    }
}