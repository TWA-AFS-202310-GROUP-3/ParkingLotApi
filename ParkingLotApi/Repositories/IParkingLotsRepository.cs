using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{
    public interface IParkingLotsRepository
    {
        public Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot);
        public Task DeleteParkingLot(string parkingLotName);
        public Task<List<ParkingLot>> GetPage(int pageSize, int pageIndex);
        public Task<List<ParkingLot>> Get();
        public Task<ParkingLot> GetById(string id);
    }
}
