using ParkingLotApi.Dtos;
using ParkingLotApi.Models;

namespace ParkingLotApi.Services
{
    public interface IParkingLotsService
    {
        Task<ParkingLot> CreateAsync(ParkingLotDto parkingLotDto);
        Task DeleteAsync(string parkingLotName);
        Task<List<ParkingLotDto>> GetPage(int pageSize, int pageIndex);
        Task<List<ParkingLotDto>> GetAll();
        Task<ParkingLot> GetById(string id);
    }
}
