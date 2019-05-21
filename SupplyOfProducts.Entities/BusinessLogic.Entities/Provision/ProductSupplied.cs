using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System;

namespace SupplyOfProducts.Entities.BusinessLogic.Entities.Provision
{

    public partial class ProductSupplied : IProductSupplied
    {
        public int Id { get; set; }
        public int ProductSupplyId { get; set; }
        public int ProductStockId { get; set; }
        public int ParentProductSuppliedId { get; set; }
        public IProductSupply ProductSupply { get; set; }
        public IProductStock ProductStock { get; set; }    
        public IProductSupplied ParentProductSupplied { get; set; }

       
    }
}
