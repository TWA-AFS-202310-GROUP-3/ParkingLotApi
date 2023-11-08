using ParkingLotApi.Models;

namespace ParkingLotApi.Dtos
{
    public class ParkingLotDto
    {
        public string Name { get; set; }
        public int Capacity {  get; set; }
        public string Location { get; set; }

        internal ParkingLot ToEntity()
        {
            return new ParkingLot()
            {
                Name = this.Name,
                Capacity = this.Capacity,
                Location = this.Location
            };
        }
    }
}
