using SupplyOfProducts.Api.Controllers.ViewModels;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Provision;
using SupplyOfProducts.Interfaces.BusinessLogic;
using System;

namespace SupplyOfProducts.BusinessLogic.Mappers
{
    public class ProductSupplyProfile : ProfileHelper
    {
        public ProductSupplyProfile()
        {

            CreateMap<IProductSupply, ProductSupplyViewModelExt>()
                .ForMember(prod => prod.ProductCode, opt => opt.MapFrom(s => s.Product.Code))
                .ForMember(prod => prod.WorkerCode, opt => opt.MapFrom(s => s.WorkerInWorkPlace.Worker.Code))
                .ForMember(prod => prod.WorkPlaceCode, opt => opt.MapFrom(s => s.WorkerInWorkPlace.WorkPlace.Code))
                .ForMember(prod => prod.ProductsSupplied, opt => opt.MapFrom(s => s.ProductsSupplied))
                ;


            CreateMap<ProductSupplyViewModel, IProductSupply>()
                .ConstructUsing((x, ctx) =>
                {
                    return ctx.Mapper.Map<ProductSupply>(x);
                })
                ;


            CreateMap<ProductSupplyViewModel, ProductSupply>()
                 .ForMember(prod => prod.Date, opt => opt.MapFrom(s => s.Date ?? DateTime.Now ))
                 .ForMember(prod => prod.Product, opt => opt.MapFrom(s => Create<Product>(s.ProductCode)))
                 .ForMember(prod => prod.WorkerInWorkPlace, opt => opt.MapFrom(s => new WorkerInWorkPlace(Create<Worker>(s.WorkerCode), Create<WorkPlace>(s.WorkPlaceCode))))
                ;
        }

   
    }
  
}


