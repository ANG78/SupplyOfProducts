using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Provision;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using System.Linq;

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


        readonly int numTries = 3;

        protected override IResult ExecuteTemplate(IManagementModelRequest<IProductSupply> obj)
        {
            var itemRequest = obj.Item;
            var resProductStock = _productStockService.GetAvailable(itemRequest.Product);

            if (resProductStock.ComputeResult().IsError())
                return resProductStock;

            itemRequest.ProductsSupplied.Clear();

            foreach (var it in resProductStock.GetItems())
            {
                itemRequest.ProductsSupplied.Add(new ProductSupplied { ProductSupply = itemRequest, ProductStock = it });
            }

            var productsInStock = itemRequest.ProductsSupplied.Select(x => x.ProductStock).ToList();

            var resultBooking = _productStockService.BookingRequest(productsInStock, itemRequest.WorkerInWorkPlaceId);
            if (resultBooking.ComputeResult().IsError())
            {
                _productStockService.BookingRequest(productsInStock, 0);

                if (!resultBooking.TryAgain)
                {
                    return resultBooking;
                }
                return ExecuteTemplate(obj);
            }

            if (itemRequest.Id == 0)
            {
                _productSupplyService.Add(itemRequest);
            }
            else
            {
                _productSupplyService.Edit(itemRequest);
            }
            

            return Result.Ok;
        }

    }
}
