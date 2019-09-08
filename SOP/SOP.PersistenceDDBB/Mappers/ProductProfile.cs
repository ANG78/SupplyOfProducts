using AutoMapper;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.PersistenceDDBB.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {


            CreateMap<IProduct, Product>()
                .IncludeAllDerived()
               .ForMember(prod => prod.Class, opt => opt.MapFrom(x => "PRODUCT"));

            CreateMap<IPackage, Package>()
                .ForMember(prod => prod.Class, opt => opt.MapFrom(x => "PACKAGE"));
                       
        }


    }
}
