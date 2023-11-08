using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{
    public interface IParkingLotsRepository
    {
        public Task<ParkingLot> CreateParkingLot(ParkingLot parking);
        public Task<ParkingLot> GetParkingLotById(string id);
        public Task DeleteParkingLotById(string id);
        public Task<List<ParkingLot>> GetParkingLotByPageInfo(int pageIndex, int pageSize);
        public Task<List<ParkingLot>> GetAllParkingLot();
    }
}
