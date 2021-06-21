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
    public class Rent : IRent
    {
        private CarsContext _db;

        public Rent (CarsContext db)
        {
            _db = db; 
        }
        public CarDetailsViewModel EditRentDetails(int UserId)
        {
            CarDetailsViewModel  RentInfo = new CarDetailsViewModel ();
            var RentDetails = _db.CarDetails.Include(x => x.UserCars).Include(x => x.Interiors).Include(x => x.Exteriors)
                .Include(x => x.Dimensions).Include(x => x.Safeties).Include(x => x.Performances).Include(x => x.Multimedia)
                .Where(x => x.Id == UserId)
                .Select(x => new { x.Interiors, x.Exteriors, x.Multimedia, x.Safeties, x.Performances, x.Dimensions });
            foreach (var Rent in RentDetails)
            {
                CarDetailsViewModel RentModel = new CarDetailsViewModel
                {
                    LuggageBoxCapacity = Rent.Dimensions.FirstOrDefault().LuggageBoxCapacity,
                    Clearance = Rent.Dimensions.FirstOrDefault().Clearance,
                    Width = Rent.Dimensions.FirstOrDefault().Width,
                    Height = Rent.Dimensions.FirstOrDefault().Height,
                    Wheelbase = Rent.Dimensions.FirstOrDefault().Wheelbase,
                    Length = Rent.Dimensions.FirstOrDefault().Length,
                    TrimSize = Rent.Exteriors.FirstOrDefault().TrimSize,
                    RainSensor = Rent.Exteriors.FirstOrDefault().RainSensor,
                    AutoFoldingMirror = Rent.Exteriors.FirstOrDefault().AutoFoldingMirror,
                    PanoramaRoof = Rent.Exteriors.FirstOrDefault().PanoramaRoof,
                    LedDaytimeRunningLamps = Rent.Exteriors.FirstOrDefault().LedDaytimeRunningLamps,
                    Headlamps = Rent.Exteriors.FirstOrDefault().Headlamps,
                    FogLambs = Rent.Exteriors.FirstOrDefault().FogLambs,
                    AutoLighting = Rent.Exteriors.FirstOrDefault().AutoLighting,
                    RearLambs = Rent.Exteriors.FirstOrDefault().RearLambs,
                    SunRoof = Rent.Exteriors.FirstOrDefault().SunRoof,
                    WheelsWithTireSize = Rent.Exteriors.FirstOrDefault().WheelsWithTireSize,
                    LightSensors = Rent.Exteriors.FirstOrDefault().LightSensors,
                    PowerMirrors = Rent.Exteriors.FirstOrDefault().PowerMirrors,
                    PrivacyGlass = Rent.Exteriors.FirstOrDefault().PrivacyGlass,
                    CenterLock = Rent.Interiors.FirstOrDefault().CenterLock,
                    RearParkingSensors = Rent.Interiors.FirstOrDefault().RearParkingSensors,
                    AmbientLighting = Rent.Interiors.FirstOrDefault().AmbientLighting,
                    ElectronicWindow = Rent.Interiors.FirstOrDefault().ElectronicWindow,
                    DriveModeSelect = Rent.Interiors.FirstOrDefault().DriveModeSelect,
                    LeatherTransmission = Rent.Interiors.FirstOrDefault().LeatherTransmission,
                    VariableHeatedDriverPassengerSeat = Rent.Interiors.FirstOrDefault().VariableHeatedDriverPassengerSeat,
                    MovableSteeringWheel = Rent.Interiors.FirstOrDefault().MovableSteeringWheel,
                    RearViewCamera = Rent.Interiors.FirstOrDefault().RearViewCamera,
                    KeylessStartStop = Rent.Interiors.FirstOrDefault().KeylessStartStop,
                    BackHolder = Rent.Interiors.FirstOrDefault().BackHolder,
                    AutoDimmingMirror = Rent.Interiors.FirstOrDefault().AutoDimmingMirror,
                    AutoFoldingBackSeats = Rent.Interiors.FirstOrDefault().AutoFoldingBackSeats,
                    Ac = Rent.Interiors.FirstOrDefault().Ac,
                    Dashboard = Rent.Interiors.FirstOrDefault().Dashboard,
                    FrontCamera = Rent.Interiors.FirstOrDefault().FrontCamera,
                    PassengerSeat = Rent.Interiors.FirstOrDefault().PassengerSeat,
                    LeatherSteeringWheel = Rent.Interiors.FirstOrDefault().LeatherSteeringWheel,
                    PaddleShifters = Rent.Interiors.FirstOrDefault().PaddleShifters,
                    NumberOfSeats = Rent.Interiors.FirstOrDefault().NumberOfSeats,
                    PowerTailgate = Rent.Interiors.FirstOrDefault().PowerTailgate,
                    AcBackSeats = Rent.Interiors.FirstOrDefault().AcBackSeats,
                    DriverSeat = Rent.Interiors.FirstOrDefault().DriverSeat,
                    FrontParkingSensors = Rent.Interiors.FirstOrDefault().FrontParkingSensors,
                    KeylessEntry = Rent.Interiors.FirstOrDefault().KeylessEntry,
                    LeatherSeats = Rent.Interiors.FirstOrDefault().LeatherSeats,
                    MultiFunction = Rent.Interiors.FirstOrDefault().MultiFunction,
                    WirlessCharger = Rent.Multimedia.FirstOrDefault().WirlessCharger,
                    Bluetooth = Rent.Multimedia.FirstOrDefault().Bluetooth,
                    SmartphoneLinkSystem = Rent.Multimedia.FirstOrDefault().SmartphoneLinkSystem,
                    Touchscreen = Rent.Multimedia.FirstOrDefault().Touchscreen,
                    Usb = Rent.Multimedia.FirstOrDefault().Usb,
                    MultifunctionSteeringWheel = Rent.Multimedia.FirstOrDefault().MultifunctionSteeringWheel,
                    CdPlayer = Rent.Multimedia.FirstOrDefault().CdPlayer,
                    Speakers = Rent.Multimedia.FirstOrDefault().Speakers,
                    NavigationSystem = Rent.Multimedia.FirstOrDefault().NavigationSystem,
                    Aux = Rent.Multimedia.FirstOrDefault().Aux,
                    HeadUpDisplay = Rent.Multimedia.FirstOrDefault().HeadUpDisplay,
                    Cylinders = Rent.Performances.FirstOrDefault().Cylinders,
                    FuelTankCapacity = Rent.Performances.FirstOrDefault().FuelTankCapacity,
                    FuelType = Rent.Performances.FirstOrDefault().FuelType,
                    MaxToruqe = Rent.Performances.FirstOrDefault().MaxToruqe,
                    FuelConsumption = Rent.Performances.FirstOrDefault().FuelConsumption,
                    GearShifts = Rent.Performances.FirstOrDefault().GearShifts,
                    Acceleration = Rent.Performances.FirstOrDefault().Acceleration,
                    MaxPower = Rent.Performances.FirstOrDefault().MaxPower,
                    MaxSpeed = Rent.Performances.FirstOrDefault().MaxSpeed,
                    TractionControl = Rent.Safeties.FirstOrDefault().TractionControl,
                    ElectroncStabilityControl = Rent.Safeties.FirstOrDefault().ElectroncStabilityControl,
                    AntiLockBrakingSystem = Rent.Safeties.FirstOrDefault().AntiLockBrakingSystem,
                    TirePressureMonitoring = Rent.Safeties.FirstOrDefault().TirePressureMonitoring,
                    SpeedLimiter = Rent.Safeties.FirstOrDefault().SpeedLimiter,
                    AutoStartStopFunctions = Rent.Safeties.FirstOrDefault().AutoStartStopFunctions,
                    PowerAssistedSteering = Rent.Safeties.FirstOrDefault().PowerAssistedSteering,
                    Immobilizer = Rent.Safeties.FirstOrDefault().Immobilizer,
                    ElectronicBrakeForceDistribution = Rent.Safeties.FirstOrDefault().ElectronicBrakeForceDistribution,
                    ChildSeats = Rent.Safeties.FirstOrDefault().ChildSeats,
                    HillAssist = Rent.Safeties.FirstOrDefault().HillAssist,
                    Airbags = Rent.Safeties.FirstOrDefault().Airbags,
                    ActiveParkAssist = Rent.Safeties.FirstOrDefault().ActiveParkAssist,
                    ElectricHandbrake = Rent.Safeties.FirstOrDefault().ElectricHandbrake,
                    CruiseControl = Rent.Safeties.FirstOrDefault().CruiseControl
            };
              //  RentInfo..Add(RentModel);
            }
            return RentInfo;
        }
    }
}
