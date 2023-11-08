﻿using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{
    public interface IParkingLotsRepository
    {
        public Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot);
        public Task DeleteParkingLot(string parkingLotId);
        public Task<ParkingLot> GetParkingLotById(string parkingLotId);
    }
}
