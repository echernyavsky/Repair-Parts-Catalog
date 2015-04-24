using System;
using System.IO;

namespace RepairPartsCatalog.Business.Contracts
{
    public interface IExcelIntegrationService : IBaseService
    {
        bool LoadDataFromFile(Stream inputStream);
    }
}