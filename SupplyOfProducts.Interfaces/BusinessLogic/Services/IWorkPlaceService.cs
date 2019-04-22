using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Services
{
    public interface IWorkPlaceService
    {
        IResultObject<IWorkPlace> Get(string code);
    }
}
