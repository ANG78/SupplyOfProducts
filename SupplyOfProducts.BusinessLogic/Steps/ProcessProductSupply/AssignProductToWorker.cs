using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Provision;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;

namespace SupplyOfProducts.BusinessLogic.Steps.ProcessProductSupply
{

    public class AssignProductToWorker : StepDecoratorTemplateGeneric<IProductSupply>
    {
        readonly IProductSupplyService _productSupplyService;
        readonly IProductStockService _productStockService;

        public AssignProductToWorker(IProductSupplyService productSupplyService,
                                     IProductStockService productStockService,
                                     IStep<IProductSupply> next = null) : base(next)
        {
            _productSupplyService = productSupplyService;
            _productStockService = productStockService;

        }

        public override string Description()
        {
            return "Assignation of one Product in Stock when processing a Product Supply Request";
        }

        protected override IResult ExecuteTemplate(IProductSupply obj)
        {
            var productStock = _productStockService.GetAvailable(obj.Product);

            if (productStock == null)
                return new Result(EnumResultBL.ERROR_NO_PRODUCT_AVAILABE, obj.Product.Code);

            obj.ProductSupplied = new ProductSupplied { ProductSupply = obj, ProductStock = productStock };

            var resultBooking = _productStockService.BookingRequest(obj.ProductSupplied.ProductStock, obj.IdWorkerInWorkPlace);
            if (resultBooking.ComputeResult().IsError())
            {
                _productStockService.BookingRequest(obj.ProductSupplied.ProductStock, 0);

                if (!resultBooking.TryAgain)
                {
                    return resultBooking;
                }
                return ExecuteTemplate(obj);
            }

            _productSupplyService.Save(obj);

            return Result.Ok;
        }

    }
}
