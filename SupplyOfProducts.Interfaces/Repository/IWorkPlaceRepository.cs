using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupplyOfProducts.Interfaces.Repository
{
    public interface IWorkPlaceRepository
    {
        IWorkPlace Get(string code);
    }

}
