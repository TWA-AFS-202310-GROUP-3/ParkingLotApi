using ParkingLotApi.Dtos;
using ParkingLotApi.Models;

namespace ParkingLotApi.Utils
{
    public class DataConverter
    {
        public static ParkingLotEntity ConvertRequestToParkingLotEntity(ParkingLotRequestDto parkingLotRequestDto)
        {
            if (parkingLotRequestDto == null)
            {
                return null;
            }

            return new ParkingLotEntity()
            {
                Name = parkingLotRequestDto.Name,
                Capacity = parkingLotRequestDto.Capacity,
                Location = parkingLotRequestDto.Location
            };
        }

        public static ParkingLotEntity ConvertToParkingLotEntity(ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto == null)
            {
                return null;
            }

            return new ParkingLotEntity()
            {
                Id = parkingLotDto.Id,
                Name = parkingLotDto.Name,
                Capacity = parkingLotDto.Capacity,
                Location = parkingLotDto.Location
            };
        }

        public static ParkingLotDto ConvertToParkingLotDto(ParkingLotEntity parkingLotEntity)
        {
            if (parkingLotEntity == null)
            {
                return null;
            }

            return new ParkingLotDto()
            {
                Id = parkingLotEntity.Id,
                Name = parkingLotEntity.Name,
                Capacity = parkingLotEntity.Capacity,
                Location = parkingLotEntity.Location
            };
        }
    }
}
