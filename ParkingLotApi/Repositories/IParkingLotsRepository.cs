using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{
    public interface IParkingLotsRepository
    {
        Task<ParkingLotEntity> CreateParkingLot(ParkingLotEntity parkingLo);
    }
}
