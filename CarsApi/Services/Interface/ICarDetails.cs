﻿using CarsApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsApi.Services.Interface
{
    public interface ICarDetails
    {
        CarDetailsViewModel ViewCarDetails(int carDetailsId);
    }
}