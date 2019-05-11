using System;
using System.Collections.Generic;
using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.Repository;

namespace SupplyOfProducts.BusinessLogic.Services
{
    public abstract class GenericService<T> : IGenericService<T> where T : ICode, IId
    {
        protected readonly IGenericRepository<T> _repository;
        public GenericService(IGenericRepository<T> workerRepository)
        {
            _repository = workerRepository;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        public IResult Edit(T worker)
        {
            try
            {
                var res = Get( worker.Code);

                if (res == null)
                {
                    return new Result(EnumResultBL.ERROR_CODE_NOT_EXIST, worker.Code);
                }

                if (res.Id != worker.Id)
                {
                    return new Result(EnumResultBL.ERROR_ALREADY_EXIST_WITH_THIS_CODE, worker.Code);
                }


                _repository.Edit(worker);
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
        public IResult Save(T worker)
        {
            try
            {
                var res = Get(worker.Code);

                if (res != null)
                {
                    return new Result(EnumResultBL.ERROR_ALREADY_EXIST_WITH_THIS_CODE, worker.Code);
                }

                _repository.Add(res);
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
        /// <param name="code"></param>
        /// <returns></returns>
        public T Get(string code)
        {
           return _repository.Get(code);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            return _repository.Get();
        }

       
    }
}
