using AutoMapper;
using System;

namespace SupplyOfProducts.BusinessLogic.Mappers
{
    public abstract class ProfileHelper : Profile
    {
        protected T Create<T>(string code)
        {

            dynamic result = (T)Activator.CreateInstance(typeof(T), null);
            result.Code = code;
            return result;
        }
    }




}


