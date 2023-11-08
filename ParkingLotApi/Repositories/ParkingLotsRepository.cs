using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{
    public class ParkingLotsRepository : IParkingLotsRepository
    {
        private readonly IMongoCollection<ParkingLot> _parkingLotCollection;
        public ParkingLotsRepository(IOptions<ParkingLotDatabaseSettings> parkingLotDatabaseSettings)
        {
            var mongoClient = new MongoClient(parkingLotDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(parkingLotDatabaseSettings.Value.DatabaseName);
            _parkingLotCollection = mongoDatabase.GetCollection<ParkingLot>(parkingLotDatabaseSettings.Value.CollectionName);
        }
        public async Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot)
        {
            await _parkingLotCollection.InsertOneAsync(parkingLot);
            return await _parkingLotCollection.Find(a => a.Name == parkingLot.Name).FirstAsync();
        }

        public async Task DeleteParkingLot(string parkingLotName)
        {
            await _parkingLotCollection.DeleteOneAsync(p => p.Name == parkingLotName);
        }

        public async Task<List<ParkingLot>> GetPage(int pageSize, int pageIndex)
        {
            int skip = (pageIndex - 1) * pageSize;
            return await _parkingLotCollection.Find(p => true).Skip(skip).Limit(pageSize).ToListAsync();
        }

        public async Task<List<ParkingLot>> Get()
        {
            return await _parkingLotCollection.Find(p => true).ToListAsync();
        }

        public async Task<ParkingLot> GetById(string id)
        {
            return await _parkingLotCollection.Find(p => p.Id == id).FirstAsync();
        }

        public async Task<ParkingLot> UpdateCapacity(string id, ParkingLot parkingLot)
        {
            await _parkingLotCollection.ReplaceOneAsync(p => p.Id == id, parkingLot);
            return parkingLot;
        }
    }
}
