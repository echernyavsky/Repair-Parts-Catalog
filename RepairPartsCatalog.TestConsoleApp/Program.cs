using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepairPartsCatalog.Domain.Data;
using RepairPartsCatalog.Domain.Entities;

namespace RepairPartsCatalog.TestConsoleApp
{
    class Program
    {
        private static RepairPartsContext context = new RepairPartsContext("DefaultConnection");

        static void Main(string[] args)
        {
            var countries = GetCountries().Select(a => a.Id).ToList();
         
            
        }

        private static IEnumerable<Country> GetCountries()
        {
            return context.Countries.Where(a => a.Name.Contains("a"));
        }
    }
}
