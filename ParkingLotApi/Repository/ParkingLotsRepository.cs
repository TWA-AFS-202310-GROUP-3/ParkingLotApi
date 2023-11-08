using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ParkingLotApi.Models;

namespace ParkingLotApi.Repository
{
    public class ParkingLotsRepository : IParkingLotsRepository //alt+enter implement members in interface

    {
        private readonly IMongoCollection<ParkingLot> _parkingLotCollection; //连mongodb数据库

        public ParkingLotsRepository(IOptions<ParkingLotDatabaseSettings> parkingLotDatabaseSettings)
        {
            var mongoClient = new MongoClient(parkingLotDatabaseSettings.Value.ConnectionString); //connections tring连接到数据库url
            var mongoDatabase = mongoClient.GetDatabase(parkingLotDatabaseSettings.Value.DatabaseName); //通过客户端连接相应数据库

            _parkingLotCollection = mongoDatabase.GetCollection<ParkingLot>(parkingLotDatabaseSettings.Value.CollectionName); //用database取相应collection

            //从数据存储的地方获取collection
        }

        public async Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot) //repo是最底层的，所以用parkinglot,Dto是外界和controller的对象
        {
            await _parkingLotCollection.InsertOneAsync(parkingLot);
            return await _parkingLotCollection.Find(a => a.Name == parkingLot.Name).FirstAsync(); //find created item by name
        }

        public async Task DeleteParkingLot(string ParkingLotId) //没有给return的值就不用return await
        {
            await _parkingLotCollection.DeleteOneAsync(p => p.Id == ParkingLotId);
        }

        public async Task<List<ParkingLot>> GetAllParkingLots()
        {
            return await _parkingLotCollection.Find(_ => true).ToListAsync();
        }

        public async Task<ParkingLot> GetById(string ParkingLotId)
        {
            return await _parkingLotCollection.Find(p => p.Id == ParkingLotId).FirstAsync();
        }

        public async Task<ParkingLot> UpdateParkingLot(string ParkingLotId, ParkingLot updatedParkingLot)
        {
            await _parkingLotCollection.ReplaceOneAsync(p => p.Id == ParkingLotId, updatedParkingLot);
            return await GetById(ParkingLotId);
        }
    }
}