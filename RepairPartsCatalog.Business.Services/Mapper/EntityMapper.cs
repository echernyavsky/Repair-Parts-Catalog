using System.Collections.Generic;
using System.Linq;
using RepairPartsCatalog.Business.ViewModels;
using RepairPartsCatalog.Entities.Catalog;
using RepairPartsCatalog.Business.ViewModels.Helpers;
using System;

namespace Mapper
{
    public class EntityMapper
    {
        public static CountryViewModel Map(Country country)
        {
            return new CountryViewModel()
            {
                Code = country.Code,
                Id = country.Id,
                Name = country.Name
            };
        }

        public static IEnumerable<CountryViewModel> Map(IEnumerable<Country> countries)
        {
            return countries.Select(Map);
        }

        public static CarBrandViewModel Map(CarBrand carBrand)
        {
            return new CarBrandViewModel()
            {
                Id = carBrand.Id,
                Name = carBrand.Name,
                CountryName = carBrand.Country.Name,
                CountryId = carBrand.Country.Id
            };
        }

        public static IEnumerable<CarBrandViewModel> Map(IEnumerable<CarBrand> brands)
        {
            return brands.Select(Map);
        }

        public static CarBrand Map(CarBrandViewModel model)
        {
            return new CarBrand()
            {
                Id = model.Id,
                CountryId = model.CountryId,
                Name = model.Name
            };
        }

        public static IEnumerable<CarBrand> Map(IEnumerable<CarBrandViewModel> models)
        {
            return models.Select(Map);
        }

        public static CarType Map(CarTypeViewModel model)
        {
            return new CarType()
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public static CarTypeViewModel Map(CarType model, bool isSelected = false)
        {
            return new CarTypeViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                IsSelected = isSelected
            };
        }

        public static CarTypeViewModel Map(CarType model)
        {
            return new CarTypeViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                IsSelected = false
            };
        }

        public static IEnumerable<CarTypeViewModel> Map(IEnumerable<CarType> models)
        {
            return models.Select(Map);
        }

        public static CarModelViewModel Map(CarModel model)
        {
            return new CarModelViewModel()
            {
                BrandName = model.CarBrand.Name,
                CarBrandId = model.CarBrandId,
                CarTypeId = model.CarTypeId,
                Id = model.Id,
                Name = model.Name,
                TypeName = model.CarType.Name
            };
        }

        public static IEnumerable<CarModelViewModel> Map(IEnumerable<CarModel> models)
        {
            return models.Select(Map);
        }

        public static CarModel Map(CarModelViewModel model)
        {
            return new CarModel
            {
                CarBrandId = model.CarBrandId,
                CarTypeId = model.CarTypeId,
                Name = model.Name
            };
        }

        public static CarModification Map(CsvVehicleViewModel model, long carModelId)
        {
            const double hpToWatt = 745.699872f;

            return new CarModification
            {
                Year = ParseInt(model.ModelYear),
                EngineHorsePower = ParseInt(model.RatedHorsepower),
                EnginePower = (int)Math.Floor(ParseInt(model.RatedHorsepower) * hpToWatt),
                NumberOfCylinders = ParseInt(model.NumberOfCylinders),
                Engine = model.EngineCode,
                TransmissionType = ParseTransmissionType(model.TestedTransmissionTypeCode),
                DriveSystem = ParseDriveSystem(model.DriveSystemCode),
                Weight = ParseInt(model.Weight),
                EngineFuelType = ParseFuelType(model.TestFuelTypeDescription),
                CarModelId = carModelId
            };
        }

        private static TransmissionType ParseTransmissionType(string code)
        {
            switch (code)
            {
                case "SA":
                    return TransmissionType.SA;
                case "M":
                    return TransmissionType.M;
                case "AM":
                    return TransmissionType.AM;
                case "SCV":
                    return TransmissionType.SCV;
                case "CVT":
                    return TransmissionType.CVT;
                case "AMS":
                    return TransmissionType.AMS;
                case "A":
                    return TransmissionType.A;
                default:
                    return TransmissionType.M;
            }
        }

        private static DriveSystem ParseDriveSystem(string code)
        {
            switch (code)
            {
                case "R":
                    return DriveSystem.R;
                case "A":
                    return DriveSystem.A;
                case "F":
                    return DriveSystem.F;
                case "4":
                    return DriveSystem.Four;
                default:
                    return DriveSystem.F;
            }
        }

        private static FuelType ParseFuelType(string description)
        {
            if (description.ToUpper().Contains("GASOLINE"))
            {
                return FuelType.Petrol;
            }

            if (description.ToUpper().Contains("DIESEL"))
            {
                return FuelType.Diesel;
            }

            if (description.ToUpper().Contains("ELECTRICITY"))
            {
                return FuelType.Electricity;
            }

            return FuelType.Unknown;
        }

        private static int ParseInt(string value)
        {
            int val;
            if (int.TryParse(value, out val))
            {
                return val;
            }

            return -1;
        }
    }
}