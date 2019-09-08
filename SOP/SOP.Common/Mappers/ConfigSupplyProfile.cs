using AutoMapper;
using SupplyOfProducts.Api.Controllers.ViewModels;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Interfaces.BusinessLogic;

namespace SupplyOfProducts.BusinessLogic.Mappers
{
    public class ConfigSupplyProfile : ProfileHelper
    {
        public ConfigSupplyProfile()
        {

            CreateMap<IConfigSupply, ConfigSupplyViewModelExt>()
                .ForMember(prod => prod.ProductCode, opt => opt.MapFrom(s => s.Product.Code))
                .ForMember(prod => prod.WorkerCode, opt => opt.MapFrom(s => s.WorkerInWorkPlace.Worker.Code))
                .ForMember(prod => prod.WorkPlaceCode, opt => opt.MapFrom(s => s.WorkerInWorkPlace.WorkPlace.Code))
                .ForMember(prod => prod.AmountSupplied, opt => opt.MapFrom(s => s.SupplyScheduled.Amount))
                ;
            
            CreateMap<ConfigSupplyViewModel, IConfigSupply>().As<ConfigSupply>();
                
            CreateMap<ConfigSupplyViewModel, ConfigSupply>()
                 .ForMember(prod => prod.Product, opt => opt.MapFrom(s => Create<Product>(s.ProductCode) ))
                 .ForMember(prod => prod.WorkerInWorkPlace, opt => opt.MapFrom(s => new WorkerInWorkPlace( Create<Worker>(s.WorkerCode), Create<WorkPlace>(s.WorkPlaceCode))))
                ;
        }

    }

}


