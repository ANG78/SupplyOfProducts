using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.Repository
{

    public interface IGenericCodeReadRepository<T>
    {
        T Get(string code);
    }

    public interface IGenericNotSingleCodeReadRepository<T> 
    {
        IEnumerable<T> Get(string code);
    }

    public interface IGenericReadRepository<T>
    {
        IEnumerable<T> Get();
    }

    public interface IGenericWriteRepository<T>
    {
        void Edit(T item);
        void Add(T item);
    }

    public interface IGenericNotSingleCodeRepository<T> : IGenericReadRepository<T>, IGenericNotSingleCodeReadRepository<T>, IGenericWriteRepository<T>
    {
    }

    public interface IGenericRepository<T> : IGenericReadRepository<T>, IGenericCodeReadRepository<T>, IGenericWriteRepository<T>
    {
  
    }

   
}
