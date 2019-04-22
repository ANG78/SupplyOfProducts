using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System;

namespace SupplyOfProducts.Entities.BusinessLogic.Entities.Provision
{

    public class ProductSupplied : IProductSupplied
    {
        public int Id { get; set; }
        public int IdProductSupply { get; set; }
        public int IdProductStock { get; set; }
        public int IdParentProductSupplied { get; set; }
        public IProductSupply ProductSupply { get; set; }
        public IProductStock ProductStock { get; set; }    
        public IProductSupplied ParentProductSupplied { get; set; }
    }
}
