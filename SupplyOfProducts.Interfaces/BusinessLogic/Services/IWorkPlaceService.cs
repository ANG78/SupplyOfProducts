using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Services
{
    public interface IWorkPlaceService : IGenericService<IWorkPlace>
    {
        IResultObject<IWorkPlace> CheckExist(string code);
    }
}
