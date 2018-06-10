using MongoDB.Driver;

namespace Tamagotchi.DataAccess.Context
{
    public class TamagotchiMongoClient
    {
        private const string CONNECTION_STRING = "mongodb://localhost";
        private const string MONGO_DB = "tamagotchi-009052";

        public IMongoDatabase Database;

        public TamagotchiMongoClient()
        {
            Database = new MongoClient(CONNECTION_STRING).GetDatabase(MONGO_DB);
        }

    }
}