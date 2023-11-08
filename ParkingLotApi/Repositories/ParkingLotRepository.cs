using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{
    public class ParkingLotRepository : IParkingLotRepository
    {
        private readonly IMongoCollection<ParkingLotEntity> parkingLotCollection;

        public ParkingLotRepository(IOptions<ParkingLotDatabaseSettings> parkingLotDatabaseSetting)
        {
            var mongoClient = new MongoClient(parkingLotDatabaseSetting.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(parkingLotDatabaseSetting.Value.DatabaseName);
            parkingLotCollection = mongoDatabase.GetCollection<ParkingLotEntity>(parkingLotDatabaseSetting.Value.CollectionName);
        }


        public async Task<ParkingLotEntity> createParkingLot(ParkingLotEntity parkingLotEntity)
        {
            await parkingLotCollection.InsertOneAsync(parkingLotEntity);
            return await parkingLotCollection.Find(a => a.Name == parkingLotEntity.Name).FirstOrDefaultAsync();
        }
    }
}
