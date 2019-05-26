using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.Repository
{

    public interface IGenericReadRepository<T>
    {
        T Get(string code);
        IEnumerable<T> Get();

    }

    public interface IGenericWriteRepository<T>
    {
        void Edit(T worker);
        void Add(T worker);
    }

    public interface IGenericRepository<T> : IGenericReadRepository<T>, IGenericWriteRepository<T>
    {
  
    }
}
