using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration
{
    public partial class WorkPlace: IWorkPlace
    {
        public int Id { get; set; }
        public string Code { get; set; }

    }

    
}
