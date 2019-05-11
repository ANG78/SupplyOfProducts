namespace SupplyOfProducts.Interfaces.BusinessLogic
{
    public interface IUnitOfWork
    {
        int SaveChanges();
        void Rollback();
    }
}
 