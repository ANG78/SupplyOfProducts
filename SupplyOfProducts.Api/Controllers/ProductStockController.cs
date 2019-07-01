using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SupplyOfProducts.Api.Controllers.ViewModels;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;

namespace SupplyOfProducts.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductStockController : ControllerGenericBaseComplete<IProductStock,  ProductStockViewModel, ProductStockViewModel>
    {
        public ProductStockController(IMapper mapper,
                                   IStep<IManagementModelRetrieverRequest<IProductStock>> serviceBusinessLogic,
                                   IStep<IManagementModelRequest<IProductStock>> businessLogic)
            : base(mapper, serviceBusinessLogic, businessLogic)
        {

        }
    }

   
}
