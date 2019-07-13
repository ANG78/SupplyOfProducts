using SupplyOfProducts.Interfaces.BusinessLogic;
using System;

namespace SupplyOfProducts.Api.Common
{
    public interface IObserverEvent
    {
        void Start<T>(T pData, IStep<T> pStep);
        void Finish<T>(T pData, IStep<T> pStep, IResult res);
        void Exception<T>(T pData, IStep<T> pStep, Exception ex);
    }

}
