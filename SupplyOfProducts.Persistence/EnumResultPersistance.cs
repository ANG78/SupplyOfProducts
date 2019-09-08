using SupplyOfProducts.Interfaces.Common;
using SupplyOfProducts.Interfaces.ICommon;
using System.Collections.Generic;

namespace SupplyOfProducts.Persistance
{

    public enum EnumResultPersistance
    {
        [Description("OK")]
        OK = 0,

        [Description("Department is requiered: {0}")]
        ERROR_UNEXPECTED_EXCEPTION,
    }

}
