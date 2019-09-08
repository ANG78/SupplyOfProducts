using AutoMapper;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Store;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.PersistenceDDBB.Mappers
{
    public class ProductStockProfile : Profile
    {
        public ProductStockProfile()
        {
            CreateMap<IProductStock, ProductStock>();
        }


    }
}
