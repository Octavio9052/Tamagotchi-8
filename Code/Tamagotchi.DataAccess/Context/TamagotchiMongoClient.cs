using MongoDB.Driver;

namespace Tamagotchi.DataAccess.Context
{
    public class TamagotchiMongoClient
    {
        private const string MongoDb = "tamagotchi-009052";

        public readonly IMongoDatabase Database;

        public TamagotchiMongoClient(string connectionString)
        {
            Database = new MongoClient(connectionString).GetDatabase(MongoDb);
        }


    }
}