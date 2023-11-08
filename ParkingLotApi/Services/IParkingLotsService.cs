using ParkingLotApi.Dtos;
using ParkingLotApi.Models;

namespace ParkingLotApi.Services
{
    public interface IParkingLotsService
    {
        Task<ParkingLot> CreateAsync(ParkingLotDto parkingLotDto);
        Task DeleteAsync(string parkingLotName);
    }
}
