﻿// <auto-generated />
using System;
using CarsApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarsApi.Migrations
{
    [DbContext(typeof(CarsContext))]
    partial class CarsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarsApi.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("CarsApi.Models.CarDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsFromSystem")
                        .HasColumnType("bit");

                    b.Property<int?>("ModelClassId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ModelClassId");

                    b.ToTable("CarDetails");
                });

            modelBuilder.Entity("CarsApi.Models.CarPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarDetailsId")
                        .HasColumnType("int");

                    b.Property<string>("PhotoName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarDetailsId");

                    b.ToTable("CarPhoto");
                });

            modelBuilder.Entity("CarsApi.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("CarsApi.Models.Dimension", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarDetailsId")
                        .HasColumnType("int");

                    b.Property<double?>("Clearance")
                        .HasColumnType("float");

                    b.Property<double?>("Height")
                        .HasColumnType("float");

                    b.Property<double?>("Length")
                        .HasColumnType("float");

                    b.Property<double?>("LuggageBoxCapacity")
                        .HasColumnType("float");

                    b.Property<double?>("Wheelbase")
                        .HasColumnType("float");

                    b.Property<double?>("Width")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CarDetailsId");

                    b.ToTable("Dimension");
                });

            modelBuilder.Entity("CarsApi.Models.Exterior", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("AutoFoldingMirror")
                        .HasColumnType("bit");

                    b.Property<bool?>("AutoLighting")
                        .HasColumnType("bit");

                    b.Property<int?>("CarDetailsId")
                        .HasColumnType("int");

                    b.Property<bool?>("FogLambs")
                        .HasColumnType("bit");

                    b.Property<string>("Headlamps")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("LedDaytimeRunningLamps")
                        .HasColumnType("bit");

                    b.Property<bool?>("LightSensors")
                        .HasColumnType("bit");

                    b.Property<bool?>("PanoramaRoof")
                        .HasColumnType("bit");

                    b.Property<bool?>("PowerMirrors")
                        .HasColumnType("bit");

                    b.Property<bool?>("PrivacyGlass")
                        .HasColumnType("bit");

                    b.Property<bool?>("RainSensor")
                        .HasColumnType("bit");

                    b.Property<string>("RearLambs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("SunRoof")
                        .HasColumnType("bit");

                    b.Property<string>("TrimSize")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WheelsWithTireSize")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarDetailsId");

                    b.ToTable("Exterior");
                });

            modelBuilder.Entity("CarsApi.Models.Interior", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ac")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("AcBackSeats")
                        .HasColumnType("bit");

                    b.Property<string>("AmbientLighting")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("AutoDimmingMirror")
                        .HasColumnType("bit");

                    b.Property<bool?>("AutoFoldingBackSeats")
                        .HasColumnType("bit");

                    b.Property<bool?>("BackHolder")
                        .HasColumnType("bit");

                    b.Property<int?>("CarDetailsId")
                        .HasColumnType("int");

                    b.Property<bool?>("CenterLock")
                        .HasColumnType("bit");

                    b.Property<string>("Dashboard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DriveModeSelect")
                        .HasColumnType("int");

                    b.Property<string>("DriverSeat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("ElectronicWindow")
                        .HasColumnType("bit");

                    b.Property<bool?>("FrontCamera")
                        .HasColumnType("bit");

                    b.Property<bool?>("FrontParkingSensors")
                        .HasColumnType("bit");

                    b.Property<bool?>("KeylessEntry")
                        .HasColumnType("bit");

                    b.Property<bool?>("KeylessStartStop")
                        .HasColumnType("bit");

                    b.Property<bool?>("LeatherSeats")
                        .HasColumnType("bit");

                    b.Property<bool?>("LeatherSteeringWheel")
                        .HasColumnType("bit");

                    b.Property<bool?>("LeatherTransmission")
                        .HasColumnType("bit");

                    b.Property<bool?>("MovableSteeringWheel")
                        .HasColumnType("bit");

                    b.Property<bool?>("MultiFunction")
                        .HasColumnType("bit");

                    b.Property<int?>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<bool?>("PaddleShifters")
                        .HasColumnType("bit");

                    b.Property<string>("PassengerSeat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("PowerTailgate")
                        .HasColumnType("bit");

                    b.Property<bool?>("RearParkingSensors")
                        .HasColumnType("bit");

                    b.Property<bool?>("RearViewCamera")
                        .HasColumnType("bit");

                    b.Property<bool?>("VariableHeatedDriverPassengerSeat")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CarDetailsId");

                    b.ToTable("Interior");
                });

            modelBuilder.Entity("CarsApi.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TypeId")
                        .HasColumnType("int");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("TypeId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("CarsApi.Models.ModelClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("ClassName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("ModelId");

                    b.ToTable("ModelClass");
                });

            modelBuilder.Entity("CarsApi.Models.Multimedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Aux")
                        .HasColumnType("bit");

                    b.Property<bool?>("Bluetooth")
                        .HasColumnType("bit");

                    b.Property<int?>("CarDetailsId")
                        .HasColumnType("int");

                    b.Property<bool?>("CdPlayer")
                        .HasColumnType("bit");

                    b.Property<bool?>("HeadUpDisplay")
                        .HasColumnType("bit");

                    b.Property<bool?>("MultifunctionSteeringWheel")
                        .HasColumnType("bit");

                    b.Property<bool?>("NavigationSystem")
                        .HasColumnType("bit");

                    b.Property<string>("SmartphoneLinkSystem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Speakers")
                        .HasColumnType("bit");

                    b.Property<decimal?>("Touchscreen")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool?>("Usb")
                        .HasColumnType("bit");

                    b.Property<bool?>("WirlessCharger")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CarDetailsId");

                    b.ToTable("Multimedia");
                });

            modelBuilder.Entity("CarsApi.Models.Performance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("Acceleration")
                        .HasColumnType("float");

                    b.Property<int?>("CarDetailsId")
                        .HasColumnType("int");

                    b.Property<int?>("Cylinders")
                        .HasColumnType("int");

                    b.Property<double?>("FuelConsumption")
                        .HasColumnType("float");

                    b.Property<double?>("FuelTankCapacity")
                        .HasColumnType("float");

                    b.Property<int?>("FuelType")
                        .HasColumnType("int");

                    b.Property<int?>("GearShifts")
                        .HasColumnType("int");

                    b.Property<string>("MaxPower")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("MaxSpeed")
                        .HasColumnType("float");

                    b.Property<string>("MaxToruqe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarDetailsId");

                    b.ToTable("Performance");
                });

            modelBuilder.Entity("CarsApi.Models.Safety", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("ActiveParkAssist")
                        .HasColumnType("bit");

                    b.Property<int?>("Airbags")
                        .HasColumnType("int");

                    b.Property<bool?>("AntiLockBrakingSystem")
                        .HasColumnType("bit");

                    b.Property<bool?>("AutoStartStopFunctions")
                        .HasColumnType("bit");

                    b.Property<int?>("CarDetailsId")
                        .HasColumnType("int");

                    b.Property<bool?>("ChildSeats")
                        .HasColumnType("bit");

                    b.Property<bool?>("CruiseControl")
                        .HasColumnType("bit");

                    b.Property<bool?>("ElectricHandbrake")
                        .HasColumnType("bit");

                    b.Property<bool?>("ElectroncStabilityControl")
                        .HasColumnType("bit");

                    b.Property<bool?>("ElectronicBrakeForceDistribution")
                        .HasColumnType("bit");

                    b.Property<bool?>("HillAssist")
                        .HasColumnType("bit");

                    b.Property<bool?>("Immobilizer")
                        .HasColumnType("bit");

                    b.Property<string>("PowerAssistedSteering")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("SpeedLimiter")
                        .HasColumnType("bit");

                    b.Property<bool?>("TirePressureMonitoring")
                        .HasColumnType("bit");

                    b.Property<bool?>("TractionControl")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CarDetailsId");

                    b.ToTable("Safety");
                });

            modelBuilder.Entity("CarsApi.Models.SellingData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("AgencyMaintainance")
                        .HasColumnType("bit");

                    b.Property<bool?>("Fabrique")
                        .HasColumnType("bit");

                    b.Property<bool?>("Guarntee")
                        .HasColumnType("bit");

                    b.Property<decimal?>("Km")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserCarId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserCarId");

                    b.ToTable("SellingData");
                });

            modelBuilder.Entity("CarsApi.Models.Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Type");
                });

            modelBuilder.Entity("CarsApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalLicenceNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CarsApi.Models.UserCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarDetailsId")
                        .HasColumnType("int");

                    b.Property<string>("CarLicenseNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarDetailsId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCar");
                });

            modelBuilder.Entity("CarsApi.Models.UserPhone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserPhone");
                });

            modelBuilder.Entity("CarsApi.Models.CarDetails", b =>
                {
                    b.HasOne("CarsApi.Models.ModelClass", "ModelClass")
                        .WithMany("CarDetails")
                        .HasForeignKey("ModelClassId");

                    b.Navigation("ModelClass");
                });

            modelBuilder.Entity("CarsApi.Models.CarPhoto", b =>
                {
                    b.HasOne("CarsApi.Models.CarDetails", "CarDetails")
                        .WithMany("CarPhotos")
                        .HasForeignKey("CarDetailsId");

                    b.Navigation("CarDetails");
                });

            modelBuilder.Entity("CarsApi.Models.Dimension", b =>
                {
                    b.HasOne("CarsApi.Models.CarDetails", "CarDetails")
                        .WithMany("Dimensions")
                        .HasForeignKey("CarDetailsId");

                    b.Navigation("CarDetails");
                });

            modelBuilder.Entity("CarsApi.Models.Exterior", b =>
                {
                    b.HasOne("CarsApi.Models.CarDetails", "CarDetails")
                        .WithMany("Exteriors")
                        .HasForeignKey("CarDetailsId");

                    b.Navigation("CarDetails");
                });

            modelBuilder.Entity("CarsApi.Models.Interior", b =>
                {
                    b.HasOne("CarsApi.Models.CarDetails", "CarDetails")
                        .WithMany("Interiors")
                        .HasForeignKey("CarDetailsId");

                    b.Navigation("CarDetails");
                });

            modelBuilder.Entity("CarsApi.Models.Model", b =>
                {
                    b.HasOne("CarsApi.Models.Brand", "Brand")
                        .WithMany("Models")
                        .HasForeignKey("BrandId");

                    b.HasOne("CarsApi.Models.Type", "Type")
                        .WithMany("Models")
                        .HasForeignKey("TypeId");

                    b.Navigation("Brand");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("CarsApi.Models.ModelClass", b =>
                {
                    b.HasOne("CarsApi.Models.Class", "Class")
                        .WithMany("ModelClasses")
                        .HasForeignKey("ClassId");

                    b.HasOne("CarsApi.Models.Model", "Model")
                        .WithMany("ModelClasses")
                        .HasForeignKey("ModelId");

                    b.Navigation("Class");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("CarsApi.Models.Multimedia", b =>
                {
                    b.HasOne("CarsApi.Models.CarDetails", "CarDetails")
                        .WithMany("Multimedia")
                        .HasForeignKey("CarDetailsId");

                    b.Navigation("CarDetails");
                });

            modelBuilder.Entity("CarsApi.Models.Performance", b =>
                {
                    b.HasOne("CarsApi.Models.CarDetails", "CarDetails")
                        .WithMany("Performances")
                        .HasForeignKey("CarDetailsId");

                    b.Navigation("CarDetails");
                });

            modelBuilder.Entity("CarsApi.Models.Safety", b =>
                {
                    b.HasOne("CarsApi.Models.CarDetails", "CarDetails")
                        .WithMany("Safeties")
                        .HasForeignKey("CarDetailsId");

                    b.Navigation("CarDetails");
                });

            modelBuilder.Entity("CarsApi.Models.SellingData", b =>
                {
                    b.HasOne("CarsApi.Models.UserCar", "UserCar")
                        .WithMany("SellingData")
                        .HasForeignKey("UserCarId");

                    b.Navigation("UserCar");
                });

            modelBuilder.Entity("CarsApi.Models.UserCar", b =>
                {
                    b.HasOne("CarsApi.Models.CarDetails", "CarDetails")
                        .WithMany("UserCars")
                        .HasForeignKey("CarDetailsId");

                    b.HasOne("CarsApi.Models.User", "User")
                        .WithMany("UserCars")
                        .HasForeignKey("UserId");

                    b.Navigation("CarDetails");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarsApi.Models.UserPhone", b =>
                {
                    b.HasOne("CarsApi.Models.User", "User")
                        .WithMany("UserPhones")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarsApi.Models.Brand", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("CarsApi.Models.CarDetails", b =>
                {
                    b.Navigation("CarPhotos");

                    b.Navigation("Dimensions");

                    b.Navigation("Exteriors");

                    b.Navigation("Interiors");

                    b.Navigation("Multimedia");

                    b.Navigation("Performances");

                    b.Navigation("Safeties");

                    b.Navigation("UserCars");
                });

            modelBuilder.Entity("CarsApi.Models.Class", b =>
                {
                    b.Navigation("ModelClasses");
                });

            modelBuilder.Entity("CarsApi.Models.Model", b =>
                {
                    b.Navigation("ModelClasses");
                });

            modelBuilder.Entity("CarsApi.Models.ModelClass", b =>
                {
                    b.Navigation("CarDetails");
                });

            modelBuilder.Entity("CarsApi.Models.Type", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("CarsApi.Models.User", b =>
                {
                    b.Navigation("UserCars");

                    b.Navigation("UserPhones");
                });

            modelBuilder.Entity("CarsApi.Models.UserCar", b =>
                {
                    b.Navigation("SellingData");
                });
#pragma warning restore 612, 618
        }
    }
}
