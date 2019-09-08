using SupplyOfProducts.Interfaces.Common;
using SupplyOfProducts.Interfaces.ICommon;
using System.Collections.Generic;

namespace SupplyOfProducts.Persistance
{
    /// <summary>
    /// 
    /// </summary>
    public class ResultPersistance : AbstractResult<EnumResultPersistance>
    {
        public ResultPersistance(EnumResultPersistance x, params object[] para) : base(x, x.GetDescription(), para)
        { }

        public ResultPersistance() : base(EnumResultPersistance.OK, EnumResultPersistance.OK.GetDescription())
        { }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="X"></typeparam>
    public class ResultPersistanceObject<X> : AbstractResultObject<EnumResultPersistance, X>
    {
        public ResultPersistanceObject(EnumResultPersistance x, params object[] para) : base(x, x.GetDescription(), para)
        { }

        public ResultPersistanceObject(X item) : base(EnumResultPersistance.OK, item, EnumResultPersistance.OK.GetDescription())
        { }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="X"></typeparam>
    public class ResultPersistanceObjects<X> : AbstractResultObjects<EnumResultPersistance, X>
    {
        public ResultPersistanceObjects(EnumResultPersistance x, params object[] para) : base(x, x.GetDescription(), para)
        { }

        public ResultPersistanceObjects(IList<X> oItems) : base(EnumResultPersistance.OK, oItems, EnumResultPersistance.OK.GetDescription())
        { }
    }
}
