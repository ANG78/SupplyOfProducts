using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Services
{
    public interface IGenericService<T>
    {
        T Get(string code);
        IEnumerable<T> GetAll();
        IResult Add(T worker);
        IResult Edit(T worker);
    }
}
