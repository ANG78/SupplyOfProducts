using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration
{

    public abstract partial class AbstractProduct : IProduct
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public string Class { get; set; }

        public abstract EStructure Structure
        {
            get;
        }
    }

    public partial class Product : AbstractProduct, IProduct
    {
        public Product()
        {

        }

        public override EStructure Structure
        {
            get
            {
                return EStructure.PRODUCT;
            }
        }

    }



}
