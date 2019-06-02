using System;
using System.Collections.Generic;
using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.Repository;

namespace SupplyOfProducts.BusinessLogic.Services.Generics
{
    public abstract class GenericService<T> : IGenericService<T> where T : IId, ICode
    {
        protected readonly IGenericRepository<T> _repository;
        public GenericService(IGenericRepository<T> workerRepository)
        {
            _repository = workerRepository;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IResult Edit(T item)
        {
            try
            {
                var res = Get(item.Code); 

                if (res == null)
                {
                    return new Result(EnumResultBL.ERROR_CODE_NOT_EXIST, item.Code);
                }

                if (res.Id != item.Id)
                {
                    return new Result(EnumResultBL.ERROR_ALREADY_EXIST_WITH_THIS_CODE, item.Code);
                }


                _repository.Edit(item);
            }
            catch (Exception ex)
            {
                return new Result(EnumResultBL.ERROR_EXCEPTION_PERSISTANCE, ex.Message);
            }
            return Result.Ok;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        public IResult Add(T item)
        {
            try
            {
                var res = Get(item.Code); 

                if (res != null)
                {
                    return new Result(EnumResultBL.ERROR_ALREADY_EXIST_WITH_THIS_CODE, item.Code);
                }

                _repository.Add(item);
            }
            catch (Exception ex)
            {
                return new Result(EnumResultBL.ERROR_EXCEPTION_PERSISTANCE, ex.Message);
            }
            return Result.Ok;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            return _repository.Get();
        }

        public virtual T Get(string code)
        {
            return _repository.Get(code);
        }

    }


}
