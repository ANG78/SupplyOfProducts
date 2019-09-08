using System;
using System.Collections.Generic;
using System.Text;

namespace SupplyOfProducts.Interfaces.BusinessLogic
{
    public interface IResultBooking : IResult
    {
        bool TryAgain { get;  }
    }
}
