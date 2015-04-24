using AutoMapper;
using RepairPartsCatalog.Business.ViewModels;
using RepairPartsCatalog.Entities.Catalog;

namespace RepairPartsCatalog.Business.Services.Configurations
{
    public class AutomapperConfiguration : Profile
    {
        protected override void Configure()
        {
            CreateMap<Country, CountryViewModel>();
            CreateMap<CountryViewModel, Country>();

            CreateMap<CarBrand, CarBrandViewModel>()
                .ForMember(m => m.Country, opt => opt.Ignore());
            CreateMap<CarBrandViewModel, CarBrand>()
                .ForMember(m => m.Country, opt => opt.Ignore());
        }

        public override string ProfileName
        {
            get { return this.GetType().Name; }
        }
    }
}