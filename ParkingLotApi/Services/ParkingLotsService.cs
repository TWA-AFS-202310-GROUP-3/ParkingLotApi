using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Repositories;
using System;

namespace ParkingLotApi.Services
{
    public class ParkingLotsService
    {
        private readonly IParkingLotsRepository _parkingLotsRepository;
        public ParkingLotsService(IParkingLotsRepository parkingLotsRepository) {
            _parkingLotsRepository = parkingLotsRepository;
        }
        public async Task<ParkingLotEntity> AddAsync(ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capacity < 10)
            {
                throw new InvalidCapacityException("The capacity should be no less than 10");
            }
            return await _parkingLotsRepository.CreateParkingLotAsync(parkingLotDto.ToEntity());
        }

        public async Task<bool> RemoveAsync(string id)
        {
            return await _parkingLotsRepository.DeleteParkingLotAsync(id);
        }

        public async Task<List<ParkingLotEntity>> GetOnePageParkingLots(int pageIndex)
        {
            var allParkingLots =  await _parkingLotsRepository.GetAllAsync();
            int pageSize = 15;
            int startIdx = (int)((pageIndex - 1) * pageSize);
            return allParkingLots.Skip(startIdx).Take((int)pageSize).ToList();
        }

        public async Task<ParkingLotEntity> GetByIdAsync(string id)
        {
            return await _parkingLotsRepository.GetByIdAsync(id);
        }

        public IParkingLotsRepository Get_parkingLotsRepository()
        {
            return _parkingLotsRepository;
        }

        public async Task<ParkingLotEntity?> UpdateCapacity(string id, int capacity)
        {
            var parkingLot = await _parkingLotsRepository.GetByIdAsync(id);
            if (parkingLot != null)
            {
                var updatedParkingLot = new ParkingLotEntity()
                {
                    Capacity = capacity,
                    Id = parkingLot.Id,
                    Name = parkingLot.Name,
                    Location = parkingLot.Location
                };
                return await _parkingLotsRepository.UpdateCapacity(id, updatedParkingLot);
            }
            return null;
        }
    }
}
