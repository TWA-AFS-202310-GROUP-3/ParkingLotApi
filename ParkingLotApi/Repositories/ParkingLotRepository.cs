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


        public async Task<ParkingLotEntity> CreateParkingLot(ParkingLotEntity parkingLotEntity)
        {
            ParkingLotEntity existed = await parkingLotCollection.Find(a => a.Name == parkingLotEntity.Name).FirstOrDefaultAsync();
            if (existed != null)
            {
                return null;
            }
            await parkingLotCollection.InsertOneAsync(parkingLotEntity);
            return await parkingLotCollection.Find(a => a.Name.Equals(parkingLotEntity.Name)).FirstOrDefaultAsync();
        }

        public async Task DeleteParkingLot(string id)
        {
            await parkingLotCollection.FindOneAndDeleteAsync(a => a.Id == id);
        }

        public async Task<ParkingLotEntity> GetParkingLot(string id)
        {
            return await parkingLotCollection.Find(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<ParkingLotEntity>> GetParkingLots()
        {
            return await parkingLotCollection.Find(_ => true).ToListAsync();
        }

        public async Task<ParkingLotEntity> UpdateParkingLot(string id, ParkingLotEntity parkingLotEntity)
        {
            return await parkingLotCollection.FindOneAndReplaceAsync(a => a.Id == id, parkingLotEntity);
        }
    }
}
