using AutoMapper;
using SupplyOfProducts.Api.Controllers.ViewModels;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System;
using System.Collections.Generic;

namespace SupplyOfProducts.BusinessLogic.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {


            CreateMap<IProduct, ProductViewModel>()
                .IncludeAllDerived()
               .ForMember(prod => prod.Class, opt => opt.MapFrom(x => "PRODUCT"))
               .ForMember(prod => prod.Parts, opt => opt.Ignore());

            CreateMap<IProductPackage, ProductViewModel>()
                .ForMember(prod => prod.Class, opt => opt.MapFrom(x => "PACKAGE"))
                .ForMember(prod => prod.Parts, opt => opt.MapFrom(s => s.Parts));




            CreateMap<ProductViewModel, IProduct>()
                .ConstructUsing((x, ctx) =>
                {
                    if (x.Class == "PACKAGE")
                    {
                        return ctx.Mapper.Map<PackageProduct>(x);
                    }
                    return ctx.Mapper.Map<Product>(x);
                });
            
            CreateMap<ProductViewModel, Product>();

            CreateMap<ProductViewModel, PackageProduct>()
                .ForMember(prod => prod.Parts, opt => opt.MapFrom(s => s.Parts));

          
        }


    }
}
