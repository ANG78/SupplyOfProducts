using AutoMapper;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.PersistanceDDBB.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {


            CreateMap<IProduct, Product>()
                .IncludeAllDerived()
               .ForMember(prod => prod.Class, opt => opt.MapFrom(x => "PRODUCT"));

            CreateMap<IProductPackage, Product>()
                .ForMember(prod => prod.Class, opt => opt.MapFrom(x => "PACKAGE"));
                       
        }


    }
}
