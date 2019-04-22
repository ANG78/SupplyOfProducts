using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;

namespace SupplyOfProducts.BusinessLogic.Steps
{

    public class ValidateAndCompleteProduct : StepDecoratorTemplateGeneric<IRequestMustBeCompleted>
    {
        readonly IProductService productService;

        public ValidateAndCompleteProduct(IProductService _productService, 
                                          IStep<IRequestMustBeCompleted> next = null) : base(next)
        {
            productService = _productService;
        }

        public override string Description()
        {
            return "Check The Product Code";
        }

        protected override IResult ExecuteTemplate(IRequestMustBeCompleted obj)
        {
            if (obj is IContainProductProperty)
            {
                var objCasted = (IContainProductProperty)obj;
                var productObject = productService.Get(objCasted.Product.Code);
                if (productObject != null)
                {
                    objCasted.Product = productObject;
                    objCasted.IdProduct = productObject.Id;
                }


                if (objCasted.Product == null || objCasted.IdProduct == 0)
                {
                    return new Result(EnumResultBL.ERROR_PRODUCT_REQUIRED);
                }
            }

            return Result.Ok;
        }
    }

}
