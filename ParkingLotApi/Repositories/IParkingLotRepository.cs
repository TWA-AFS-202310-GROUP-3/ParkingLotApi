using ParkingLotApi.Models;
namespace ParkingLotApi.Repositories
{
    public interface IParkingLotRepository
    {
        public Task<ParkingLotEntity> createParkingLot(ParkingLotEntity parkingLotEntity);
    }
}
