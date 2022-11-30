using KnowItAllWeb.Models;
using Microsoft.Data.Sqlite;
using System.Data;
using Dapper;

namespace KnowItAllWeb.Repository
{
    public interface IOfferRepository
    {
        List<Offer> getOffer(); //method which connects to DB, to retreive existing offers

        void addOffer(Offer offer, Materials materials);
        void update(Offer offer);   
        void delete(int offerId);
        
    }
    public class OfferRepository : IOfferRepository
    {
        private readonly IConfiguration _configuration;
        public OfferRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Offer> getOffer() //Offer offer, Materials materials
        {
            using (IDbConnection connection = new
                SqliteConnection(_configuration.GetConnectionString("ConnectionString"))) //remember to add stuff in appsetings.json
            {
                var query =
                     @"SELECT * FROM Offer";

                var allOffers = connection.Query<Offer>(query);

                return allOffers.ToList();
                   
            }
        }

       
        
        public void addOffer(Offer offer, Materials materials)
        {
            using(IDbConnection connection = new SqliteConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                var sql = "INSERT INTO Offers(id,time,price,status,Wood,Sand,Water,Plastic,Iron,Copper,Cotton) Values(@id,@time,@price,@status,@wood,@sand,@water,@plastic,@iron,@copper,@cotton)";
                connection.Execute(sql, offer);
            }

        }

        public void update(Offer offer)
        {
            throw new NotImplementedException();

        }

        public void delete(int offerId)
        {
            throw new NotImplementedException();

        }

       

    }
}
