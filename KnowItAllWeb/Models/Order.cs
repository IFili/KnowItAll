namespace KnowItAllWeb.Models
{
    public class Order
    {
       public int OrderId {get;set;}

        public float OrderPrice { get;set;}

        public int OrderTimeToBuild { get; set; } // represents the time it takes to build an order

        public DateTime OrderDate { get; set; } // will be used to mark when order is made

        public bool OrderStatus { get; set; } // whether order is accepted or not

        public int OrderQuantity { get; set; } // marks the # of items in an order

    }
}
