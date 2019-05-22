using System;

namespace SupplyOfProducts.Interfaces.BusinessLogic
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        void Rollback();
    }
}
 