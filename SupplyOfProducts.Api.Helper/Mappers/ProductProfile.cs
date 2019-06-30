using AutoMapper;
using SupplyOfProducts.Api.Controllers.ViewModels;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SupplyOfProducts.BusinessLogic.Mappers
{

    public partial class ProductProfile : Profile
    {
        public ProductProfile()
        {

            CreateMap<IProduct, ProductViewModel>()
                .IncludeAllDerived();
              // .ForMember(prod => prod.Class, opt => opt.MapFrom(x => EStructure.PRODUCT.String()));

            CreateMap<IPackage, ProductComplexViewModel>()
              //  .ForMember(prod => prod.Class, opt => opt.MapFrom(x => EStructure.PACKAGE.String()))
                .ForMember(prod => prod.Parts, opt => opt.MapFrom(s => s.Parts));


            //////////////////////////////
            CreateMap<ProductComplexViewModel, IProduct>()
                .ConstructUsing((x, ctx) =>
                {
                    //if (x.Class == EStructure.PACKAGE.String())
                    //{
                        return ctx.Mapper.Map<Package>(x);
                    //}
                    //return ctx.Mapper.Map<Product>(x);
                });

            CreateMap<ProductViewModel, Product>();

            CreateMap<ProductComplexViewModel, Package>()
                .ForMember(prod => prod.Parts, opt => { opt.MapFrom<CustomIEnumrableResolver>(); });


            CreateMap<ProductViewModel, ProductPart>()
                .ForMember(prod => prod.Product, opt => { opt.MapFrom(s => s); })
                .ForMember(prod => prod.ParentProduct, opt => { opt.MapFrom(s => s); });

        }


        public class CustomIEnumrableResolver : IValueResolver<ProductComplexViewModel, Package, IEnumerable<IProduct>>
        {

            public IEnumerable<IProduct> Resolve(ProductComplexViewModel source, Package destination, IEnumerable<IProduct> destMember, ResolutionContext context)
            {
                if (source.Parts != null)
                {

                    source.Parts.ToList().ForEach(x => destination.Add(context.Mapper.Map<IProduct>(x)));

                }
                //return destination.Parts;
                return null;
            }
        }



    }

}


