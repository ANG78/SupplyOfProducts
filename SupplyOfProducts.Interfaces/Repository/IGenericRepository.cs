using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.Repository
{
    public interface IGenericRepository<T>
    {
        T Get(string code);
        IEnumerable<T> Get();

        void Edit(T worker);
        void Add(T worker);
    }
}
