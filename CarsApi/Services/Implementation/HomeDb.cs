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
    public class HomeDb : IHome
    {
        private CarsContext _db;

        public HomeDb(CarsContext db)
        {
            _db = db;
        }

        public HomeCarsList GetCarsDate()
        {
            HomeCarsList CarsList = new HomeCarsList();
            List<int> Ids = GenerateIds();

            try
            {
                var Cars = _db.CarDetails
            .Include(i => i.Performances)
            .Include(i => i.ModelClass.Model.Type)
            .Include(i => i.ModelClass.Model)
            .Include(i => i.CarPhotos)
            .Where(w => Ids.Contains(w.Id)).ToList();

                foreach (var car in Cars)
                {
                    HomeCarViewModel CarModel = new HomeCarViewModel
                    {
                        CarDetailsID = car.Id,
                        CarType = car.ModelClass.Model.Type.Name,
                        Cylinders = car.Performances.ToList()[0].Cylinders,
                        Fuel = car.Performances.ToList()[0].FuelType,
                        ImageName = car.CarPhotos.ToList()[0].PhotoName,
                        Price = car.Price,
                        Year = car.ModelClass.Model.Year
                    };
                    CarsList.homeCars.Add(CarModel);
                }

                CarsList.IsSuccess = true;
                return CarsList;

            }
            catch (Exception)
            {

                return new HomeCarsList
                {
                    IsSuccess = false
                };
            }

        }

        private List<int> GenerateIds()
        {
            List<int> Ids = new List<int>();
            Random rnd = new Random();
            int id;
            for (int i = 0; i < 9; i++)
            {
                do
                {
                    id = rnd.Next(176, 266);
                } while (Ids.Contains(id) || (id == 187 || id == 233 || id == 232 || id == 186 || id == 187 || id == 188));
                Ids.Add(id);
            }
            return Ids;
        }
    }
}
