using ParkingLotApi.Models;

namespace ParkingLotApi.Repository
{
    public interface IParkingLotsRepository
    {
        public Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot);
    }
}
