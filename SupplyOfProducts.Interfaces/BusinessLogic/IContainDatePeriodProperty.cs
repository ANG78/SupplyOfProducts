using System;
using System.Collections.Generic;
using System.Text;

namespace SupplyOfProducts.Interfaces.BusinessLogic
{
    public interface IContainDatePeriodProperty 
    {
        DateTime Date { get; set; }
        DateTime PeriodDate { get; set; }
    }
}
