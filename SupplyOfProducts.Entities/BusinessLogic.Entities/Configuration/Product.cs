using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration
{

    public partial class AbstractProduct
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }

    }

    public partial class Product : AbstractProduct, IProduct
    {

        public Product()
        {

        }

    }



}
