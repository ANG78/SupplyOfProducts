using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.ICommon;

namespace SupplyOfProducts.BusinessLogic.Services
{
    public class ResultBooking : Result, IResultBooking
    {
        public ResultBooking(EnumResultBL x, params object[] para) : base(x, x.GetDescription(), para)
        { }

        public bool TryAgain
        {
            get
            {
                return Code == EnumResultBL.ERROR_PRODUCT_IN_STOCK_WAS_ALREADY_BOOKED;
            }
        }
    }
}

