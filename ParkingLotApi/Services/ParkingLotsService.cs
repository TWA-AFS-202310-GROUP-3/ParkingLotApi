using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Repositories;

namespace ParkingLotApi.Services
{
    public class ParkingLotsService
    {
        private readonly IParkingLotsRepository parkingLotsRepository;
        public ParkingLotsService(IParkingLotsRepository parkingLotsRepository)
        {
            this.parkingLotsRepository = parkingLotsRepository;
        }
        public async Task<ParkingLot> AddAsync(ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capacity < 10)
            {
                throw new InvalidCapacityException();
            }
            List<ParkingLot> parkingLots = await GetAsync();
            foreach (var item in parkingLots)
            {
                if ( item.Name ==  parkingLotDto.Name)
                {
                    throw new UsedNameException();
                }
            }
            return await parkingLotsRepository.CreateParkingLot(parkingLotDto.ToEntity());
        }

        public async Task DeleteAsync(string id) =>
            await parkingLotsRepository.DeleteParkingLot(id);

        public async Task<List<ParkingLot>> GetAsync() =>
            await parkingLotsRepository.GetAll();

        public async Task<List<ParkingLot>> GetInPageAsync(int pageIndex)
        {
            List<ParkingLot> parkingLots = await GetAsync();
            int pageSize = 15;
            int pagesToBeSkip = pageSize * (pageIndex - 1);
            if ( pagesToBeSkip >= parkingLots.Count || pageIndex < 1 )
            {
                throw new InvalidPageIndexException();
            }
            return parkingLots.Skip(pagesToBeSkip).Take(pageSize).ToList();
        }

        public async Task<ParkingLot> GetByIdAsync(string id) =>
            await parkingLotsRepository.GetParkingLotById(id);

        public async Task<ParkingLot> UpdateParkingLotAsync(string id, CapacityDto capacityDto)
        {
            ParkingLot parkingLot = await GetByIdAsync(id);
            if (capacityDto.Capacity < 10 || capacityDto.Capacity < parkingLot.Capacity)
            {
                throw new InvalidCapacityException();
            }
            parkingLot.Capacity = capacityDto.Capacity;
            return await parkingLotsRepository.UpdateParkingLot(id, parkingLot);
        }
        
    }
}
