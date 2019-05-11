namespace SupplyOfProducts.Interfaces.BusinessLogic.Entities
{
    public interface IProduct : ICode
    {
        int Id { get; set; }
        string Type { get; set; }
      
    } 
}
