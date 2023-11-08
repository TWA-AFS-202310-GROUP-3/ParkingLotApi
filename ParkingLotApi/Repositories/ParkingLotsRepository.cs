using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{

    public class ParkingLotsRepository : IParkingLotsRepository
    {
        private readonly IMongoCollection<ParkingLotEntity> _parkingLotsCollection;
        public ParkingLotsRepository(IOptions<ParkingLotsDatabaseSettings> parkingLotsDatabaseSettings)
        {
            var mongoClient = new MongoClient(parkingLotsDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(parkingLotsDatabaseSettings.Value.DatabaseName);
            _parkingLotsCollection = mongoDatabase.GetCollection<ParkingLotEntity>(parkingLotsDatabaseSettings.Value.CollectionName);

        }

        public async Task<ParkingLotEntity> CreateParkingLot(ParkingLotEntity parkingLot)
        {
            await _parkingLotsCollection.InsertOneAsync(parkingLot);
            return await _parkingLotsCollection.Find(a => a.Name == parkingLot.Name).FirstAsync();
        }
    }
}
