using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Services
{
  
    public interface IGenericReadService<T>
    {
        T Get(string code);
        IEnumerable<T> GetAll();
    }

    public interface IGenericWriteService<T>
    {
        IResult Add(T item);
        IResult Edit(T item);
    }

    public interface IGenericService<T> : IGenericReadService<T>, IGenericWriteService<T>
    {
    }

    public interface IGenericCodeService<T> : IGenericService<T>
    {
    }
}
