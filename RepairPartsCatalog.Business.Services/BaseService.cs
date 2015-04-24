using RepairPartsCatalog.Business.Contracts;
using RepairPartsCatalog.Domain.Contracts;

namespace RepairPartsCatalog.Business.Services
{
    public class BaseService : IBaseService
    {
        protected readonly ICatalogUoW CatalogUow;

        public BaseService(ICatalogUoW catalogUoW)
        {
            this.CatalogUow = catalogUoW;
        }
    }
}