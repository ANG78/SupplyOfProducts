using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.Common;
using SupplyOfProducts.Interfaces.ICommon;

namespace SupplyOfProducts.BusinessLogic.Common
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="X"></typeparam>
    public class ResultObject<X> : AbstractResultObject<EnumResultBL, X>
    {
        public ResultObject(EnumResultBL x, params object[] para) : base(x, x.GetDescription(), para)
        { }

        public ResultObject(EnumResultBL x, IResult res) : base(x, res.Message(), null)
        { }

        public ResultObject(X item) : base(EnumResultBL.OK, item, EnumResultBL.OK.GetDescription())
        { }


    }
}
