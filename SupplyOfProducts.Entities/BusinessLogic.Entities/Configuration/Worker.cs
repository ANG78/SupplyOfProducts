using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration
{
    public class Worker : IWorker
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; } 
    }

}
