using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Repository;

namespace ParkingLotApi.Services
{
    public class ParkingLotsService
    {
        private readonly IParkingLotsRepository parkingLotsRepository;
        public ParkingLotsService(IParkingLotsRepository parkingLotsRepository)
        {
            this.parkingLotsRepository = parkingLotsRepository;
        }

        public async Task<ParkingLot> AddAsync(ParkingLotDto parkingLotDto) //Task<返回值的类型>
        {
            if (parkingLotDto.Capacity < 10)
            {
                throw new InvalidCapacityException();
            }

            return await parkingLotsRepository.CreateParkingLot(parkingLotDto.ToEntity());
            //用外界传进来的dto，return parkinglot给repo
        }

        public async Task DeleteAsync(string parkingLotId)
        {
            await parkingLotsRepository.DeleteParkingLot(parkingLotId);
        }

        public async Task<List<ParkingLot>> GetOnePageAsync(int pageIndex)
        {
            List<ParkingLot> allParkingLots = await parkingLotsRepository.GetAllParkingLots();
            int pageSize = 15;
            int startIndex = (pageIndex - 1) * pageSize;
            return allParkingLots.Skip(startIndex).Take(pageSize).ToList();
        }

        public async Task<ParkingLot> GetByIdAsync(string parkingLotId)
        {
            return await parkingLotsRepository.GetById(parkingLotId);
        }

        public async Task<ParkingLot> UpdateParkingLotCapacityAsync(int capacity, string parkingLotId)
        {
            if (capacity < 10)
            {
                throw new InvalidCapacityException();
            }

            var parkingLot = await parkingLotsRepository.GetById(parkingLotId);
            var updatedParkingLot = new ParkingLot()
            {
                Capacity = capacity,
                Id = parkingLot.Id,
                Name = parkingLot.Name,
                Location = parkingLot.Location
            };
            
            return await parkingLotsRepository.UpdateParkingLot(parkingLotId, updatedParkingLot);

        }

    }
}
