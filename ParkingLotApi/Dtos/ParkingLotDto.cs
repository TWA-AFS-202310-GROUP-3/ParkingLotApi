namespace ParkingLotApi.Models
{
    public class ParkingLotDto
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }

        internal ParkingLotEntity ToEntity()
        {
            return new ParkingLotEntity { Name = Name, Capacity = Capacity, Location = Location };
        }
    }
}
