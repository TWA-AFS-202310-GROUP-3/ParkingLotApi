using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{
    public interface IParkingLotsRepository
    {
        public Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot);
        public Task DeleteParkingLot(string parkingLotId);
        public Task<List<ParkingLot>> GetAll();
        public Task<ParkingLot> GetParkingLotById(string parkingLotId);
        public Task<ParkingLot> UpdateParkingLot(string id,  ParkingLot parkingLot);
    }
}
