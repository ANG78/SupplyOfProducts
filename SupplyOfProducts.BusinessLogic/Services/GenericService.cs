using System;
using System.Collections.Generic;
using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.Repository;

namespace SupplyOfProducts.BusinessLogic.Services
{
    public abstract class GenericService<T> : IGenericService<T> where T : IId
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
                var res = Check(item);

                if (res == null)
                {
                    return new Result(EnumResultBL.ERROR_CODE_NOT_EXIST, GetString(item));
                }

                if (res.Id != item.Id)
                {
                    return new Result(EnumResultBL.ERROR_ALREADY_EXIST_WITH_THIS_CODE, GetString(item));
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
                var res = Check(item);

                if (res != null)
                {
                    return new Result(EnumResultBL.ERROR_ALREADY_EXIST_WITH_THIS_CODE, GetString(item));
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

        protected abstract T Check(T item);

        protected abstract string GetString(T item);

        public virtual T Get(string code)
        {
            return _repository.Get(code);
        }
    }


    public abstract class GenericServiceCode<T> : GenericService<T>, IGenericService<T> where T : ICode, IId
    {
        public GenericServiceCode(IGenericRepository<T> workerRepository):base(workerRepository)
        {
            
        }
        
        protected override string GetString(T item)
        {
            return item.Code;
        }

        protected override T Check(T item)
        {
           return  Get(item.Code);
        }
    }
}
