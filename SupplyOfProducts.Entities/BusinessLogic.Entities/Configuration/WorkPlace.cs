using System;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration
{
    public class WorkPlace: IWorkPlace
    {
        public int Id { get; set; }
        public string Code { get; set; }
    }

    
}
