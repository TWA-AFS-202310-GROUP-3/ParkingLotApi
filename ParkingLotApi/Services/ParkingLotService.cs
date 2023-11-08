using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Repositories;

namespace ParkingLotApi.Services
{
    public class ParkingLotService
    {
        private readonly IParkingLotsRepository parkingLotsRepository;

        public ParkingLotService(IParkingLotsRepository parkingLotsRepository)
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

        public async Task DeleteParkingLot(string id)
        {
            if (await parkingLotsRepository.GetParkingLotById(id) == null)
            {
                throw new ParkingLotNotFoundException();
            }
            await parkingLotsRepository.DeleteParkingLotById(id);
        }

        public async Task<List<ParkingLot>> GetParkingLotByPageInfo(int pageIndex)
        {
            int pageSize = 15;

            if (pageIndex < 0)
            {
                throw new PageInfoInvalidException();
            }

            if (pageIndex == 0)
            {
                return await parkingLotsRepository.GetAllParkingLot();
            }
            else
            {
                return await parkingLotsRepository.GetParkingLotByPageInfo(pageIndex, pageSize);
            }
        }

        public async Task<ParkingLot> GetParkingLotById(string id)
        {
            ParkingLot parkingLot = await parkingLotsRepository.GetParkingLotById(id);

            if (parkingLot == null)
            {
                throw new ParkingLotNotFoundException();
            }

            return parkingLot;
        }

        public async Task<ParkingLot> UpdateParkingLot(string id, ParkingLotDto parkingLotDto)
        {
            ParkingLot parkingLot = await parkingLotsRepository.GetParkingLotById(id);
            
            if (parkingLot == null)
            {
                throw new ParkingLotNotFoundException();
            }

            parkingLot.Location = parkingLotDto.Location;
            parkingLot.Capacity = (int)parkingLotDto.Capacity;

            return await parkingLotsRepository.UpdateParkingLotInfo(id, parkingLot);
        }
    }
}
