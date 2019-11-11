using Microsoft.AspNetCore.Mvc;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Api.Controllers.ViewModels;
using System.Collections.Generic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using AutoMapper;

namespace SupplyOfProducts.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductSupplyController : ControllerGenericNotSingleCodeBase <IProductSupply, ProductSupplyViewModel, ProductSupplyViewModelExt>
    {

        public ProductSupplyController(IMapper mapper,
                                IStep<IManagementModelRetrieverRequest<IProductSupply>> serviceBusinessLogic,
                                IStep<IManagementModelRequest<IProductSupply>> businessLogic)
                    : base(mapper, serviceBusinessLogic, businessLogic)
        {
        }


    }

    
}