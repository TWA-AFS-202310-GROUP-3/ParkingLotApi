using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{
    public class ParkingLotsRepository : IParkingLotsRepository
    {
        private readonly IMongoCollection<ParkingLot> _parkingLotCollection;
        public ParkingLotsRepository(IOptions<ParkingLotsDatabaseSettings> parkingLotDatabaseSettings)
        {
            var mongoClient = new MongoClient(parkingLotDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(parkingLotDatabaseSettings.Value.DatabaseName);
            _parkingLotCollection = mongoDatabase.GetCollection<ParkingLot>(parkingLotDatabaseSettings.Value.CollectionName);
        }
        public async Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot)
        {
            await _parkingLotCollection.InsertOneAsync(parkingLot);
            return await _parkingLotCollection.Find(a => a.Id == parkingLot.Id).FirstAsync();
        }

        public async Task DeleteParkingLot(string parkingLotId)
        {
            await _parkingLotCollection.DeleteOneAsync(x => x.Id == parkingLotId);
        }

        public async Task<List<ParkingLot>> GetAll()
        {
            return await _parkingLotCollection.Find(a => a.Id != null).ToListAsync();
        }

        public async Task<ParkingLot> GetParkingLotById(string parkingLotId)
        {
            return await _parkingLotCollection.Find(a => a.Id == parkingLotId).FirstOrDefaultAsync();
        }

        public async Task<ParkingLot> UpdateParkingLot(string id, ParkingLot parkingLot)
        {
            await _parkingLotCollection.ReplaceOneAsync(x => x.Id == id, parkingLot);
            return await _parkingLotCollection.Find(a => a.Id == parkingLot.Id).FirstAsync();
        }
    }
}
