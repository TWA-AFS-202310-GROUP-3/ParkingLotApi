using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{
    public interface IParkingLotsRepository
    {
        Task<ParkingLotEntity> CreateParkingLotAsync(ParkingLotEntity parkingLo);
        Task<bool> DeleteParkingLotAsync(string id);
    }
}
