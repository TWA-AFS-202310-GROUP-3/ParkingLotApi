using ParkingLotApi.Models;

namespace ParkingLotApi.Dtos;

public class ParkingLotDto
{
    public string Name { get; set; } //ctrl+d自动向下复制一行
    public int Capacity { get; set; }
    public string Location { get; set; }

    internal ParkingLot ToEntity()
    {
        return new ParkingLot()
        {
            Name = Name,
            Capacity = Capacity,
            Location = Location
        };
    }
}
