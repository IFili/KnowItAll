using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Column("OfferStatus", TypeName = "int")]
        [Range(0, 1)]
        public int OfferStatusInt { get; set; } // new property for OfferStatus as int


        public bool OfferStatus { get; set; } // whether order is accepted or not

        public int MaterialQuantity { get; set; } // marks the # of items in an order

        public int WoodQty { get; set; }
    
        public int SandQty { get; set; }
     

        public int WaterQty { get; set; }
     

        public int PlasticQty { get; set; }
    

        public int IronQty { get; set; }
     

        public int CopperQty { get; set; }
      


        public int CottonQty { get; set; }

        //public List<Offer> OffersList { get; set; } 
    }
}
