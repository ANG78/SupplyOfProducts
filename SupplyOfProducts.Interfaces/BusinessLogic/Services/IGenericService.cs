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
        IResult Add(T worker);
        IResult Edit(T worker);
    }

    public interface IGenericService<T> : IGenericReadService<T>, IGenericWriteService<T>
    {
    }
}
