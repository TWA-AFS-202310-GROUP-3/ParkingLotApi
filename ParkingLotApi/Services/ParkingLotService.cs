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
    }
}
