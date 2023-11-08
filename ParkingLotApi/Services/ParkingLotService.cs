﻿using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Repositories;

namespace ParkingLotApi.Services
{
    public class ParkingLotService
    {
        private readonly IParingLotRepository _paringLotRepository;

        public ParkingLotService(IParingLotRepository paringLotRepository)
        {
            _paringLotRepository = paringLotRepository;
        }

        public async Task<ParkingLot> AddSync(ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capacity < 10)
            {
                throw new InvalidCapacityException();
            }

            return await _paringLotRepository.CreateParkingLotAsync(parkingLotDto.ToEntity());
        }
    }
}
