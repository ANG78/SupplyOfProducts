using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Provision;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;

namespace SupplyOfProducts.BusinessLogic.Steps.ProcessProductSupply
{

    public class AssignProductToWorker : StepDecoratorTemplateGeneric<IManagementModelRequest<IProductSupply>>
    {
        readonly IProductSupplyService _productSupplyService;
        readonly IProductStockService _productStockService;

        public AssignProductToWorker(IProductSupplyService productSupplyService,
                                     IProductStockService productStockService,
                                     IStep<IManagementModelRequest<IProductSupply>> next = null) : base(next)
        {
            _productSupplyService = productSupplyService;
            _productStockService = productStockService;

        }

        public override string Description()
        {
            return "Assignation of one Product in Stock when processing a Product Supply Request";
        }

        protected override IResult ExecuteTemplate(IManagementModelRequest<IProductSupply> obj)
        {
            var itemRequest = obj.Item;
            var productStock = _productStockService.GetAvailable(itemRequest.Product);

            if (productStock == null)
                return new Result(EnumResultBL.ERROR_NO_PRODUCT_AVAILABE, itemRequest.Product.Code);

            itemRequest.ProductsSupplied.Add(  new ProductSupplied { ProductSupply = itemRequest, ProductStock = productStock });

            var resultBooking = _productStockService.BookingRequest(productStock, itemRequest.WorkerInWorkPlaceId);
            if (resultBooking.ComputeResult().IsError())
            {
                _productStockService.BookingRequest(productStock, 0);

                if (!resultBooking.TryAgain)
                {
                    return resultBooking;
                }
                return ExecuteTemplate(obj);
            }
           
            _productSupplyService.Save(itemRequest);

            return Result.Ok;
        }

    }
}
