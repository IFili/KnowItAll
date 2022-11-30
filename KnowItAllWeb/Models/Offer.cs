using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KnowItAllWeb.Models
{
    public class Offer
    {
        [Required]
       public int OfferId {get;set;}
        //mozebi remote tag za validacija podocna [Remote("IsUnique")]

        [Required]
        public float OfferPrice { get;set;}

        [Required]
        public int OfferTimeToBuild { get; set; } // represents the time it takes to build an order

        public DateTime OfferDate { get; set; } // will be used to mark when order is made

        public bool OfferStatus { get; set; } // whether order is accepted or not

        public int MaterialQuantity { get; set; } // marks the # of items in an order

        //public List<Offer> OffersList { get; set; } 
    }
}
