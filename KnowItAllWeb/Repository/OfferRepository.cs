using KnowItAllWeb.Models;
using Microsoft.Data.Sqlite;
using System.Data;
using Dapper;

namespace KnowItAllWeb.Repository
{
    public interface IOfferRepository
    {
        List<Offer> getOffer(); //method which connects to DB, to retreive existing offers

        void makeOffer(Offer offer);
        void acceptOffer(Offer offer);   
        void deleteOffer(int offerId);

        List<Offer> getAcceptedOffers();


    }
    public class OfferRepository : IOfferRepository
    {
        private readonly IConfiguration _configuration;
        public OfferRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Offer> getOffer()
        {
            using (IDbConnection connection = new SqliteConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                var query = @"SELECT OfferId, WoodQty, SandQty, WaterQty, PlasticQty, IronQty, CopperQty, CottonQty,
                        materialquantity as MaterialQuantity, price as OfferPrice, time as OfferTimeToBuild,
                        status as OfferStatusInt
                        FROM offers";

                var allOffers = connection.Query<Offer>(query);

				foreach (var offer in allOffers)
				{
					offer.OfferStatus = offer.OfferStatusInt == 1;
				}

				return allOffers.ToList();
            }
        }

        public List<Offer> getAcceptedOffers()
        {
            using (IDbConnection connection = new SqliteConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                var query = @"SELECT OfferId, WoodQty, SandQty, WaterQty, PlasticQty, IronQty, CopperQty, CottonQty,
                        materialquantity as MaterialQuantity, price as OfferPrice, time as OfferTimeToBuild,
                        status as OfferStatusInt
                        FROM offers
                        WHERE status = 1";

                var acceptedOffers = connection.Query<Offer>(query);

                foreach (var offer in acceptedOffers)
                {
                    offer.OfferStatus = true;
                }

                return acceptedOffers.ToList();
            }
        }



        public void makeOffer(Offer offer)
        {
            using (IDbConnection connection = new SqliteConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                var sql = @"INSERT INTO offers (OfferId,WoodQty, SandQty, WaterQty, PlasticQty, IronQty, CopperQty, CottonQty, MaterialQuantity, price, time /*,OfferStatus*/)
            VALUES (@OfferId,@WoodQty, @SandQty, @WaterQty, @PlasticQty, @IronQty, @CopperQty, @CottonQty, @MaterialQuantity, @OfferPrice, @OfferTimeToBuild/*,@OfferStatus*/ )";

                connection.Execute(sql, offer);
            }
        }


        public void acceptOffer(Offer offer)
        {
            using (IDbConnection connection = new SqliteConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                var sql = @"
            UPDATE offers
            SET status = @OfferStatus
            WHERE OfferId = @OfferId";

                connection.Execute(sql, new { OfferStatus = offer.OfferStatusInt, OfferId = offer.OfferId });
            }
        }


        public void deleteOffer(int offerId)
        {
            throw new NotImplementedException();

        }

		
	}
}
