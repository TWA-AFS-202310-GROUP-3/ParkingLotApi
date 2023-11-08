using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Repositories;

namespace ParkingLotApi.Services
{
    public class ParkingLotsService : IParkingLotsService
    {
        private readonly IParkingLotsRepository parkingLotsRepository;
        public ParkingLotsService(IParkingLotsRepository parkingLotsRepository)
        {
            this.parkingLotsRepository = parkingLotsRepository;
        }

        public async Task<ParkingLot> CreateAsync(ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capacity < 10)
            {
                throw new InvalidCapacityException();
            }
            return await parkingLotsRepository.CreateParkingLot(parkingLotDto.ToEntity());
        }

        public async Task DeleteAsync(string parkingLotName)
        {
            await parkingLotsRepository.DeleteParkingLot(parkingLotName);
        }

        public async Task<List<ParkingLot>> GetPage(int pageSize, int pageIndex)
        {
            return await parkingLotsRepository.GetPage(pageSize, pageIndex);
        }

        public async Task<List<ParkingLot>> GetAll()
        {
            return await parkingLotsRepository.Get();
        }

        public async Task<ParkingLot> GetById(string id)
        {
            return await parkingLotsRepository.GetById(id);
        }

        public async Task<ParkingLot> UpdateParkingLotCapacity(string id, ParkingLotDto parkingLotDto)
        {
            ParkingLot updatedParkingLot = await parkingLotsRepository.GetById(id);

            if (updatedParkingLot == null)
            {
                throw new ParkingLotNotFoundException();
            }
            updatedParkingLot.Capacity = parkingLotDto.Capacity;
            return await parkingLotsRepository.UpdateCapacity(id, updatedParkingLot);
        }
    }
}
