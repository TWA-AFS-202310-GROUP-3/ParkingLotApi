using ParkingLotApi.Models;

namespace ParkingLotApi.Repository
{
    public interface IParkingLotsRepository
    {
        Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot);
        Task DeleteParkingLot(string ParkingLotId);
        Task<List<ParkingLot>> GetAllParkingLots();
        Task<ParkingLot> GetById(string ParkingLotId);
        Task<ParkingLot> UpdateParkingLot(string ParkingLotId, ParkingLot updatedParkingLot);
    }
}