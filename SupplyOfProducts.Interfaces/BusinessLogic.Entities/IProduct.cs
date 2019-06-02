namespace SupplyOfProducts.Interfaces.BusinessLogic.Entities
{
    public enum EStructure
    {
        PRODUCT,
        PACKAGE
    }

    public static class TypeExtension
    {
        public static string String(this EStructure e)
        {
            return e.ToString();
        }
    }


    public interface IProduct : ICode, IId
    {
        string Type { get; set; }
        EStructure Structure { get;  }
    } 
}
