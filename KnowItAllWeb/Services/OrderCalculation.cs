using KnowItAllWeb.Models;
using System.Linq.Expressions;

namespace KnowItAllWeb.Services
{
    public class OrderCalculation
    {
        public float woodPrice = 2.5F;
        public float sandPrice = 4F;
        public float waterPrice = 2F;
        public float plasticPrice = 4.8F;
        public float ironPrice = 3.3F;
        public float copperPrice = 5.1F;
        public float cottonPrice = 2.95F;

        private Order MyOrder { get; set; }
        private Materials MyMaterials { get; set; }

        public OrderCalculation(Order myOrder, Materials materialObject)
        {
            MyOrder = myOrder;
            MyMaterials = materialObject;
            
        }

        

       /* Materials materialObject = new Materials()
        {
            Wood = 2.5F,
            Sand = 4, // if sand is used, there must be 2:1 water 
            Water = 2,
            Plastic = 4.8F,
            Iron = 3.3F,
            Copper = 5.1F,
            Cotton = 2.95F //if cotton is used, there must be 3:1 water
        };*/

        


 

        public float getPrice(double price)
        {
            

           /* Wood woodObject = new Wood();
            Sand sandObject = new Sand();
            Water waterObject = new Water();
            Plastic plasticObject = new Plastic();
            Iron ironObject = new Iron();
            Copper copperObject = new Copper();
            Cotton cottonObject = new Cotton();*/

            
      



        double _price = //najverojatno gresno zasto e so instancirana klasa
                (woodPrice * MyMaterials.Wood)
                + (sandPrice * MyMaterials.Sand)
                + (waterPrice * MyMaterials.Water)
                + (plasticPrice * MyMaterials.Plastic)
                + (ironPrice * MyMaterials.Iron)
                +(copperPrice * MyMaterials.Copper)
                +(cottonPrice * MyMaterials.Cotton);



            _price = price;
            return (float)price;
        }

        public int getTimebyPrice(int time)
        {
            if (time <= 10)
            {
                return 0;
            }
            else if (time > 10 && time <= 25)
            {
                return 7; //maybe needs to be converted to week
            }

            else if (time > 25 && time <= 100)
            {
                return 45; // time is one month and fifteen days
            }

            else  //time>100
            {
                return 180; // time is 6 months, need to convert in months later?
            }
           
         
        }

       /* public int getOrderQuantity (int quantity) // counts the total quantity of items in order
        {
           quantity= materialObject.WoodQty + materialObject.SandQty + materialObject.WaterQty +
                materialObject.PlasticQty + materialObject.IronQty + materialObject.CopperQty + materialObject.CottonQty;

            //maybe here i need to validate 2:1 & 3:1 water ratios for sand,cotton

            //MyOrder.OrderQuantity = quantity;
            //return MyOrder.OrderQuantity
            //mozebi vaka treba?
            
            return quantity;


        }*/

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
                return 21; // add 3 weeks ,maybe need to convert to weeks?
            }

            else  //qty >50
            {
                return 60; //add 2 months, maybe need to convert to months?
            }

          
        }


        public float calculateTotalTime(Order order)
        {
            float TimeByPrice = getTimebyPrice((int)order.OrderPrice);
            float TimeByQuantity = getTimebyQuantity(order.OrderQuantity);
        
            float totalTime = TimeByPrice + TimeByQuantity;

            return totalTime;
        }

        public bool getStatus(bool status)
        {
            return status;

        }

        


    }
}
    




