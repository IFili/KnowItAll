using KnowItAllWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using KnowItAllWeb.Services;
using KnowItAllWeb.Repository;
using KnowItAllWeb.Models.ViewModels;

namespace KnowItAllWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOfferRepository _offerRepository;

        // private readonly OfferRepository _offerRepository;


        public HomeController(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;

           
        }


        public IActionResult Index(OfferViewModel? model)
        {
            var offers = _offerRepository.getOffer();
          
            var viewModel = new OfferViewModel
            {
                OffersList = offers,
				//MakeOrder = new makeOrderViewModel()
                //newOrder = new makeOrderViewModel()

			};

            if (TempData.ContainsKey("Message"))
            {
                ViewBag.Message = TempData["Message"];
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateOffer(int Wood, int Sand, int Water, int Plastic, int Iron, int Copper, int Cotton)
        {
          //  Materials materialObject = new Materials();
            Offer offerObject = new Offer();
            OfferService offerService = new OfferService();
            

          

            offerObject.WoodQty = Wood;
            offerObject.SandQty = Sand;
            offerObject.WaterQty = Water;
            offerObject.PlasticQty = Plastic;
            offerObject.IronQty = Iron;
            offerObject.CopperQty = Copper;
            offerObject.CottonQty = Cotton;
            
            int _offerQuantity = offerService.getQuantity(Wood, Sand, Water, Plastic, Iron, Copper, Cotton);

            offerObject.MaterialQuantity = _offerQuantity; // we added quantity,   water will be added automatically for every 2nd unit of sand and every 3rd unit of water

            if (!offerService.ValidateMaterials(Wood, Sand, Water, Plastic, Iron, Copper, Cotton))
            {
                throw new Exception("Please enter an order for at least 2 material types");
            }


            float _price = offerService.getPrice(offerObject.WoodQty, offerObject.SandQty, offerObject.WaterQty, offerObject.PlasticQty, offerObject.IronQty, offerObject.CopperQty, offerObject.CottonQty);

            offerObject.OfferPrice = _price;

            int _timeByPrice = offerService.getTimebyPrice(offerObject.OfferPrice);
            int _timeByQuantity = offerService.getTimebyQuantity(offerObject.MaterialQuantity);
            int _totalTime = offerService.calculateTotalTime(_timeByPrice, _timeByQuantity);

            offerObject.OfferTimeToBuild = _totalTime;

            int numberId = offerService.getOrderId();

            offerObject.OfferId = numberId;




            //if (offerObject.OfferId > 0)
            //{
            //    _offerRepository.makeOffer(offerObject);
            //}
            //else
            //    _offerRepository.acceptOffer(offerObject);
            _offerRepository.makeOffer(offerObject);

			//return View(offerObject);
			//return RedirectToAction("Index");

			return View(offerObject);




		}

        public IActionResult getAcceptedOffers()
		{
            var offers = _offerRepository.getAcceptedOffers();

            var viewModel = new OfferViewModel
            {
                OffersList = offers,
            };
            return View(viewModel);
		}




        [HttpPost]
        public IActionResult AcceptSelectedOffers(int[] offerIds)
        {
            foreach (int offerId in offerIds)
            {
                Offer offer = new Offer
                {
                    OfferId = offerId,
                    OfferStatusInt = 1,
                    OfferStatus = true 

            };

                _offerRepository.acceptOffer(offer);
            }

            return Ok("Selected offers have been accepted.");
        }




        [HttpPost]
        public IActionResult AcceptOffer(int offerId)
        {
            Offer offerObject = new Offer();
            offerObject.OfferId = offerId;
            offerObject.OfferStatusInt = 1;
            offerObject.OfferStatus = true;

            _offerRepository.acceptOffer(offerObject);




            TempData["Message"] = "Selected offer has been accepted.";

            return RedirectToAction("Index");
        }
















    }
}