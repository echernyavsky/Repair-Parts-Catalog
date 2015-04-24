using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Excel;
using RepairPartsCatalog.Business.Contracts;
using RepairPartsCatalog.Business.ViewModels.Helpers;
using RepairPartsCatalog.Domain.Contracts;
using RepairPartsCatalog.Entities.Catalog;

namespace RepairPartsCatalog.Business.Services.Integration
{
    public class ExcelIntegrationService : BaseService, IExcelIntegrationService
    {
        public ExcelIntegrationService(ICatalogUoW catalogUow) : base(catalogUow)
        {

        }

        bool IExcelIntegrationService.LoadDataFromFile(Stream inputStream)
        {
            try
            {
                var parsedData = ParseExcelDocument(inputStream);

                CreateCarTypesAndBrands(parsedData);
                CreateCarModels(parsedData);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        private IEnumerable<ExcelVehicleViewModel> ParseExcelDocument(Stream inputStream)
        {
            var parsedData = new List<ExcelVehicleViewModel>();

            IExcelDataReader excelDataReader = ExcelReaderFactory.CreateBinaryReader(inputStream);
            excelDataReader.IsFirstRowAsColumnNames = true;

            bool firstRow = true;

            while (excelDataReader.Read())
            {
                if (firstRow)
                {
                    firstRow = false;
                    continue;
                }
                
                var vehicle = new ExcelVehicleViewModel()
                {
                    CarType = excelDataReader.GetString(0),
                    CarBrand = excelDataReader.GetString(1),
                    CarModel = excelDataReader.GetString(2),
                    CarModelVersion = excelDataReader.GetString(3),
                    Engine = excelDataReader.GetString(4),
                    EngineType = excelDataReader.GetString(5),
                    KW = excelDataReader.GetString(6),
                    HP = excelDataReader.GetString(7),
                    Fuel = excelDataReader.GetString(8),
                    Year = excelDataReader.GetString(9)
                };

                parsedData.Add(vehicle);
            }

            excelDataReader.Close();

            return parsedData;
        }

        private void CreateCarModels(IEnumerable<ExcelVehicleViewModel> data)
        {
            foreach (var row in data)
            {
                var type = CatalogUow.CarTypes.All().FirstOrDefault(it => it.Name == row.CarType);
                var brand = CatalogUow.CarBrands.All().FirstOrDefault(it => it.Name == row.CarBrand);
                var modelName = string.Format("{0} - {1}", row.CarModel, row.CarModelVersion);
                var model = CatalogUow.CarModels.All().Include(it => it.CarModifications).FirstOrDefault(it => it.Name == modelName) ?? new CarModel()
                {
                    CarBrand = brand,
                    CarType = type,
                    CarModifications = new List<CarModification>(),
                    Name = modelName
                };

                model.CarModifications.Add(new CarModification()
                {
                    Model = model,
                    Engine = row.Engine,
                    EnginePower = GetIntValue(row.KW),
                    EngineHorsePower = GetIntValue(row.HP),
                    EngineType = row.EngineType,
                    EngineFuelType = GetFuelType(row.Fuel),
                    Year = GetIntValue(row.Year)
                });

                CatalogUow.CarModels.InsertOrUpdate(model);
                CatalogUow.Commit();
            }
        }

        private FuelType GetFuelType(string fuel)
        {
            if (string.IsNullOrEmpty(fuel))
            {
                return FuelType.Unknown;
            }

            switch (fuel.ToUpper())
            {
                case "PETROL":
                    return FuelType.Petrol;
                case "DIESEL":
                    return FuelType.Diesel;
                default:
                    return FuelType.Unknown;
            }
        }

        private int GetIntValue(string input)
        {
            int result;
            if (!int.TryParse(input, out result))
            {
                result = -1;
            }

            return result;
        }

        private void CreateCarTypesAndBrands(IEnumerable<ExcelVehicleViewModel> data)
        {
            var carBrands = data.GroupBy(it => it.CarType, it => it.CarBrand, (key, g) => new KeyValuePair<string, IEnumerable<string>>(key, g));

            foreach (var carType in carBrands)
            {
                SaveCarType(carType.Key);

                var brands = carType.Value.Distinct();
                foreach (var brand in brands)
                {
                    SaveCarBrand(brand);
                }
            }

            CatalogUow.Commit();
        }

        private void SaveCarBrand(string brand)
        {
            if (CatalogUow.CarBrands.All().FirstOrDefault(it => it.Name == brand) == null)
            {
                CatalogUow.CarBrands.InsertOrUpdate(new CarBrand()
                {
                    Name = brand,
                    CountryId = 1
                });
            }
        }

        private void SaveCarType(string carType)
        {
            if (CatalogUow.CarTypes.All().FirstOrDefault(it => it.Name == carType) == null)
            {
                CatalogUow.CarTypes.InsertOrUpdate(new CarType()
                {
                    Name = carType
                });
            }
        }
    }
}