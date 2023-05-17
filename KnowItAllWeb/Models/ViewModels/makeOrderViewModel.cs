using System.ComponentModel.DataAnnotations;

namespace KnowItAllWeb.Models.ViewModels
{
	public class makeOrderViewModel
	{
       

        public int WoodQty { get; set; }

        public int SandQty { get; set; }


        public int WaterQty { get; set; }


        public int PlasticQty { get; set; }


        public int IronQty { get; set; }


        public int CopperQty { get; set; }

        public int CottonQty { get; set; }

		//[Required] //We will need some sort of validation...
        public int MaterialQuantity { get; set; }
    }
}
