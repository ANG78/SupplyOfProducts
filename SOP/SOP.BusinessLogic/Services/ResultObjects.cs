using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.Interfaces.Common;
using SupplyOfProducts.Interfaces.ICommon;
using System.Collections.Generic;

namespace SupplyOfProducts.BusinessLogic.Services
{

    public class ResultObjects<X> : AbstractResultObjects<EnumResultBL, X>
    {
        public ResultObjects(EnumResultBL x, params object[] para) : base(x, x.GetDescription(), para)
        { }

        public ResultObjects(IList<X> oItems) : base(EnumResultBL.OK, oItems, EnumResultBL.OK.GetDescription())
        { }
    }
   
}
