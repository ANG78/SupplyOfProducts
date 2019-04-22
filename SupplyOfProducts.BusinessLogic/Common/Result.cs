using SupplyOfProducts.Interfaces.Common;
using SupplyOfProducts.Interfaces.ICommon;

namespace SupplyOfProducts.BusinessLogic.Common
{
    public class Result : AbstractResult<EnumResultBL>
    {
        public Result(EnumResultBL x, params object[] para) : base(x, x.GetDescription(), para)
        { }

        private  Result() : base(EnumResultBL.OK, EnumResultBL.OK.GetDescription())
        { }

        public static Result Ok = new Result();
    }
}
