namespace SupplyOfProducts.Interfaces.BusinessLogic.Entities
{
   

    public interface IWorker : ICode, IId
    {
        
        string Name { get; set; }
    }

    
}
