namespace SupplyOfProducts.Interfaces.BusinessLogic.Entities
{
    public interface IProduct : ICode, IId
    {
        string Type { get; set; }
      
    } 
}
