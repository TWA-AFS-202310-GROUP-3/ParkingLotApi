using ParkingLotApi.Dtos;
using ParkingLotApi.Models;

namespace ParkingLotApi.Utils
{
    public class DataConverter
    {
        public static ParkingLotEntity ConvertToParkingLotEntity(ParkingLotDto parkingLotDto)
        {
            return new ParkingLotEntity()
            {
                Name = parkingLotDto.Name,
                Capacity = parkingLotDto.Capacity,
                Location = parkingLotDto.Location
            };
        }
    }
}
