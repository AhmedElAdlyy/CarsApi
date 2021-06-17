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
    public class CarsDetailsDb : ICarDetails
    {
        private CarsContext _db;

        public CarsDetailsDb(CarsContext db)
        {
            _db = db;
        }


        public CarDetailsViewModel ViewCarDetails(int carDetailsId)
        {
            var details = _db.CarDetails
                .Include(i => i.CarPhotos)
                .Include(i => i.ModelClass)
                .Include(i => i.ModelClass.Model)
                .Include(i => i.ModelClass.Model.Brand)
                .Include(i=>i.ModelClass.Model.Type)
                .FirstOrDefault(f => f.Id == carDetailsId);



            var dimensions = _db.Dimension.FirstOrDefault(f => f.CarDetailsId == carDetailsId);
            var exterior = _db.Exterior.FirstOrDefault(f => f.CarDetailsId == carDetailsId);
            var interior = _db.Interior.FirstOrDefault(f => f.CarDetailsId == carDetailsId);
            var safety = _db.Safety.FirstOrDefault(f => f.CarDetailsId == carDetailsId);
            var multimedia = _db.Multimedia.FirstOrDefault(f => f.CarDetailsId == carDetailsId);
            var performance = _db.Performance.FirstOrDefault(f => f.CarDetailsId == carDetailsId);

            if (details == null)
                return new CarDetailsViewModel
                {
                    IsSuccess = false
                };

            CarDetailsViewModel model =  new CarDetailsViewModel
            {
                IsSuccess = true,

                Price = details.Price,
                CarName = details.ModelClass.Model.Brand.Name + " " + details.ModelClass.Model.Name + " " + details.ModelClass.Model.Year,
                ClassName = details.ModelClass.ClassName,
                CarType = details.ModelClass.Model.Type.Name,

                LuggageBoxCapacity = dimensions.LuggageBoxCapacity,
                Clearance = dimensions.Clearance,
                Width = dimensions.Width,
                Height = dimensions.Height,
                Wheelbase = dimensions.Wheelbase,
                Length = dimensions.Length,
                TrimSize = exterior.TrimSize,
                RainSensor = exterior.RainSensor,
                AutoFoldingMirror = exterior.AutoFoldingMirror,
                PanoramaRoof = exterior.PanoramaRoof,
                LedDaytimeRunningLamps = exterior.LedDaytimeRunningLamps,
                Headlamps = exterior.Headlamps,
                FogLambs = exterior.FogLambs,
                AutoLighting = exterior.AutoLighting,
                RearLambs = exterior.RearLambs,
                SunRoof = exterior.SunRoof,
                WheelsWithTireSize = exterior.WheelsWithTireSize,
                LightSensors = exterior.LightSensors,
                PowerMirrors = exterior.PowerMirrors,
                PrivacyGlass = exterior.PrivacyGlass,
                CenterLock = interior.CenterLock,
                RearParkingSensors = interior.RearParkingSensors,
                AmbientLighting = interior.AmbientLighting,
                ElectronicWindow = interior.ElectronicWindow,
                DriveModeSelect = interior.DriveModeSelect,
                LeatherTransmission = interior.LeatherTransmission,
                VariableHeatedDriverPassengerSeat = interior.VariableHeatedDriverPassengerSeat,
                MovableSteeringWheel = interior.MovableSteeringWheel,
                RearViewCamera = interior.RearViewCamera,
                KeylessStartStop = interior.KeylessStartStop,
                BackHolder = interior.BackHolder,
                AutoDimmingMirror = interior.AutoDimmingMirror,
                AutoFoldingBackSeats = interior.AutoFoldingBackSeats,
                Ac = interior.Ac,
                Dashboard = interior.Dashboard,
                FrontCamera = interior.FrontCamera,
                PassengerSeat = interior.PassengerSeat,
                LeatherSteeringWheel = interior.LeatherSteeringWheel,
                PaddleShifters = interior.PaddleShifters,
                NumberOfSeats = interior.NumberOfSeats,
                PowerTailgate = interior.PowerTailgate,
                AcBackSeats = interior.AcBackSeats,
                DriverSeat = interior.DriverSeat,
                FrontParkingSensors = interior.FrontParkingSensors,
                KeylessEntry = interior.KeylessEntry,
                LeatherSeats = interior.LeatherSeats,
                MultiFunction = interior.MultiFunction,
                WirlessCharger = multimedia.WirlessCharger,
                Bluetooth = multimedia.Bluetooth,
                SmartphoneLinkSystem = multimedia.SmartphoneLinkSystem,
                Touchscreen = multimedia.Touchscreen,
                Usb = multimedia.Usb,
                MultifunctionSteeringWheel = multimedia.MultifunctionSteeringWheel,
                CdPlayer = multimedia.CdPlayer,
                Speakers = multimedia.Speakers,
                NavigationSystem = multimedia.NavigationSystem,
                Aux = multimedia.Aux,
                HeadUpDisplay = multimedia.HeadUpDisplay,
                Cylinders = performance.Cylinders,
                FuelTankCapacity = performance.FuelTankCapacity,
                FuelType = performance.FuelType,
                MaxToruqe = performance.MaxToruqe,
                FuelConsumption = performance.FuelConsumption,
                GearShifts = performance.GearShifts,
                Acceleration = performance.Acceleration,
                MaxPower = performance.MaxPower,
                MaxSpeed = performance.MaxSpeed,
                TractionControl = safety.TractionControl,
                ElectroncStabilityControl = safety.ElectroncStabilityControl,
                AntiLockBrakingSystem = safety.AntiLockBrakingSystem,
                TirePressureMonitoring = safety.TirePressureMonitoring,
                SpeedLimiter = safety.SpeedLimiter,
                AutoStartStopFunctions = safety.AutoStartStopFunctions,
                PowerAssistedSteering = safety.PowerAssistedSteering,
                Immobilizer = safety.Immobilizer,
                ElectronicBrakeForceDistribution = safety.ElectronicBrakeForceDistribution,
                ChildSeats = safety.ChildSeats,
                HillAssist = safety.HillAssist,
                Airbags = safety.Airbags,
                ActiveParkAssist = safety.ActiveParkAssist,
                ElectricHandbrake = safety.ElectricHandbrake,
                CruiseControl = safety.CruiseControl
            };

            foreach (var photo in details.CarPhotos)
            {
                model.PhotosNames.Add(photo.PhotoName);
            }

            return model;
        }
    }
}
