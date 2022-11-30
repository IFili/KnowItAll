using KnowItAllWeb.Models;
using System.Linq.Expressions;
using KnowItAllWeb.Repository;

namespace KnowItAllWeb.Services
{
    public class OfferService
    {
        public float woodPrice = 2.5F;
        public float sandPrice = 4F;
        public float waterPrice = 2F;
        public float plasticPrice = 4.8F;
        public float ironPrice = 3.3F;
        public float copperPrice = 5.1F;
        public float cottonPrice = 2.95F;

        private Offer MyOffer { get; set; }
        private Materials MyMaterials { get; set; }

        private OfferRepository MyOfferRepository { get; set; }


        public OfferService(Offer myOffer) //zapamti da gi vratis vo zagrada , Materials materialObject, OfferRepository offerRepository
        {
            MyOffer = myOffer;
            //MyMaterials = materialObject;
            //MyOfferRepository = offerRepository;

        }



        public float getPrice(int wood, int sand, int water, int plastic, int iron , int copper, int cotton)
        {

        float _price = //what if we multiply by zero, will it crash?
                (woodPrice * wood)
                + (sandPrice * sand)
                + (waterPrice * water)
                + (plasticPrice * plastic)
                + (ironPrice * iron)
                +(copperPrice * copper)
                +(cottonPrice * cotton);

           
            return _price;

        }

        public int getQuantity(int wood, int sand, int water, int plastic, int iron, int copper, int cotton) 
        {
           

            if(sand /2 ==1) 
            {
                water++; //water is added automatically for every 2 units of sand
                
            }

           if (cotton /3 ==1)
            {
                water++; //water is added automatically for every 3 units of cotton
            }

            int quantity = wood + sand + water + plastic + iron + copper + cotton;

            return quantity;
        }

        public int getTimebyPrice(float price)
        {
            if (price <= 10)
            {
                return 0;
            }
            else if (price > 10 && price <= 25)
            {
                return 7; 
            }

            else if (price > 25 && price <= 100)
            {
                return 45; 
            }

            else  //time>100
            {
                return 180; 
            }
           
         
        }

       

        public int getTimebyQuantity(int Quantity)
        {
           

            if (Quantity <= 3)
            {
                return 0; 
            }

            else if (Quantity > 3 && Quantity <= 12)
            {
               return 3;
            }
            else if (Quantity > 12 && Quantity <= 50)
            {
                return 21; 
            }

            else  //qty >50
            {
                return 60; 
            }

          
        }


       

        public int calculateTotalTime(int price, int quantity)
        {
            int timeByPrice = getTimebyPrice(price);
            int timeByQuantity = getTimebyQuantity(quantity); 
            
            int totalTime = timeByPrice + timeByQuantity;
            return totalTime;
        }

        public bool getStatus(bool status) //meant to be used in a table view
        {
            return status;

        }

        
        public Offer createOffer(Offer offer) //orginal :List<Materials>materials
        {
            //okolu pravilata za cotton i sand
            // mora da ima validacija sto ako ne e uspesna ke frli exception 
          
            //prvo go kreiras objektot offer od materials
           
            //MyOfferRepository.addOffer(offer,materials);
         

      
            //ja prais kalkulacijata so materials za da go kreiras offerot
            
            //otkako ke ja zavrsis taa kalkulacija, za offerot imas cena,i imas time
            //otkako ke go kreiras offerot kako objekt, kako so imas instanca vo kontroler od servisot, taka imas instanca vo servisot od repository***



            //so repository go povikuvas addOffer ** OD REPOSITORY ; so ova go stavas vo BAZA
            //pri addOffer da go vrati kreiraniot offer TUKA.


            //return vrateniot offer 

            //ako nema opcija da bide vraten tuka, offerot ke ima unique id
            //sigurno ima opcija kako da kreiras unique id za offerot
            //u toj slucaj ke ima addOffer, pa ke ima getOffer spored id-to (toa e createOffer)

            throw new NotImplementedException();


        }

    }
}
    




