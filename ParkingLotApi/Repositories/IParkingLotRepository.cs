using ParkingLotApi.Dtos;
using ParkingLotApi.Models;
namespace ParkingLotApi.Repositories
{
    public interface IParkingLotRepository
    {
        public Task<ParkingLotEntity> CreateParkingLot(ParkingLotEntity parkingLotEntity);
        public Task DeleteParkingLot(string id);
        public Task<List<ParkingLotEntity>> GetParkingLots();
        public Task<ParkingLotEntity> GetParkingLot(string id);
        public Task<ParkingLotEntity> UpdateParkingLot(string id, ParkingLotEntity parkingLotEntity);
    }
}
