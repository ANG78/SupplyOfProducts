using System;
using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.BusinessLogic
{

    public interface IStep<T>
    {
        IStep<T> Next { get; set; }
        IResult Execute(T condept);
        string Description();
    }

}
 