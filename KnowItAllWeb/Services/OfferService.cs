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

        //private Offer MyOffer { get; set; }


        private OfferRepository MyOfferRepository { get; set; }

    
		



		public float getPrice(int wood, int sand, int water, int plastic, int iron, int copper, int cotton)
        {

            float _price = //what if we multiply by zero, will it crash?
                   (woodPrice * (float)wood)
                    + (sandPrice * (float)sand)
                    + (waterPrice * (float)water)
                    + (plasticPrice * (float)plastic)
                    + (ironPrice * (float)iron)
                    + (copperPrice * (float)copper)
                    + (cottonPrice * (float)cotton);


            return _price;

        }

        public int getQuantity(int wood, int sand, int water, int plastic, int iron, int copper, int cotton)
        {
           
            int quantity = wood + sand + water + plastic + iron + copper + cotton;

           
            return quantity;
        }

        public bool ValidateMaterials(int Wood, int Sand, int Water, int Plastic, int Iron, int Copper, int Cotton)
        {
            int counter = 0;
            if (Wood > 0)
            {
                counter++;
            }
            if (Sand > 0)
            {
                if (Water < Sand * 2)
                {
                    throw new Exception("For every sand there must be 2:1 water");
                }

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
                if (Water < Cotton * 3)
                {
                    throw new Exception("For every cotton there must be 3:1 water");
                }
                counter++;
            }

            return counter >= 2;
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

        public int getOrderId()
        {
            Random rnd = new Random();
            int _rnd = rnd.Next(100, 1000);

            return _rnd;
        }

       

    }
}




