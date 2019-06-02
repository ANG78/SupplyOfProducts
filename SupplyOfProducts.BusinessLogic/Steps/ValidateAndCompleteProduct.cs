using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using System;

namespace SupplyOfProducts.BusinessLogic.Steps
{

    public class ValidateAndCompleteProduct : StepDecoratorTemplateGeneric<IRequestMustBeCompleted>
    {
        readonly IProductService productService;

        public ValidateAndCompleteProduct(IProductService _productService)
        {
            productService = _productService;
        }

        public override string Description()
        {
            return "Check The Product Code";
        }

       

        protected override IResult ExecuteTemplate(IRequestMustBeCompleted obj)
        {

            IContainProductProperty objToProces = null;
            obj.HelperCast(obj, ref objToProces);

            if (objToProces != null)
            {
                return Process(objToProces);
            }

            if (obj is IContainProductProperty)
            {
                var objCasted = (IContainProductProperty)obj;
                return Process(objCasted);
            }

            return Result.Ok;
        }

        private IResult Process(IContainProductProperty objCasted)
        {
            var productObject = productService.Get(objCasted.Product.Code);
            if (productObject != null)
            {
                objCasted.Product = productObject;
                objCasted.ProductId = productObject.Id;
            }


            if (objCasted.Product == null || objCasted.ProductId == 0)
            {
                return new Result(EnumResultBL.ERROR_PRODUCT_REQUIRED);
            }
            return Result.Ok;
        }
    }

}
