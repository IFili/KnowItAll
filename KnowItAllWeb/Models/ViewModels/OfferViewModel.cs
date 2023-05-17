

namespace KnowItAllWeb.Models.ViewModels
{
    public class OfferViewModel
    {
       
        public List<Offer>? OffersList { get; set; }

        public makeOrderViewModel MakeOrderViewModel { get; set; } //sub viewmodel , used by partial views (because only 1 can be used per page)

      
    }
}
