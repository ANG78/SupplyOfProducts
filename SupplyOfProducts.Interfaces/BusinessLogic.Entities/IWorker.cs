namespace SupplyOfProducts.Interfaces.BusinessLogic.Entities
{

    public interface IWorker : ICode
    {
        int Id { get; set; }
        string Name { get; set; }
    }

    
}
