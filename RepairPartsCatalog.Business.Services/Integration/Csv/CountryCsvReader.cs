using System.Collections.Generic;
using RepairPartsCatalog.Business.Contracts;
using RepairPartsCatalog.Entities.Catalog;
using System.IO;

namespace RepairPartsCatalog.Business.Services.Integration.Csv
{
    public class CountryCsvReader : IBaseCsvReader<Country>
    {
        /// <summary>
        /// Struture: Code, Name
        /// </summary>
        /// <param name="inputStream"></param>
        /// <returns></returns>
        public IEnumerable<Country> Read(Stream inputStream)
        {
            var countries = new List<Country>();

            using (var fileReader = new StreamReader(inputStream))
            {
                while(!fileReader.EndOfStream)
                {
                    var line = fileReader.ReadLine();
                    var temp = line.Split(',');
                    var country = new Country()
                    {
                        Code = temp[0],
                        Name = temp[1]
                    };

                    countries.Add(country);
                }
            }

            return countries;
        }
    }
}