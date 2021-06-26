using CarsApi.Models;
using CarsApi.Services.Interface;
using CarsApi.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsApi.Services.Implementation
{
    public class SellDb : ISell
    {
        private CarsContext _db;

        public SellDb(CarsContext db)
        {
            _db = db;
        }


        public MessageResponseViewModel EnterSellingData(SellingDataViewModel model, int carDetailsId)
        {
            UserCar userCar = _db.UserCar.FirstOrDefault(f => f.CarDetailsId == carDetailsId);
            if (userCar == null)
                return new MessageResponseViewModel
                {
                    IsSuccess = false,
                    Message = "car not found"
                };

            SellingData selling = new SellingData
            {
                Km = model.Km,
                Fabrique = model.Fabrique,
                AgencyMaintainance = model.Maintainance,
                Notes = model.Notes,
                Guarntee = model.Guarntee,
                UserCarId = userCar.Id
            };

            try
            {
                _db.SellingData.Add(selling);
                _db.SaveChanges();
                return new MessageResponseViewModel
                {
                    IsSuccess = true,
                    Message = "your data saved successfully"
                };
            }
            catch (Exception)
            {
                return new MessageResponseViewModel
                {
                    IsSuccess = false,
                    Message = "something went wrong try again"
                };

            }
        }
    }
}
