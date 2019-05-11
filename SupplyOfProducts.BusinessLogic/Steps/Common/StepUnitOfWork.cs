using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using System;

namespace SupplyOfProducts.BusinessLogic.Steps.Common
{
    public class StepUnitOfWork<T> : IStep<T>
    {
        readonly IUnitOfWork _currentContext;
        public StepUnitOfWork(IUnitOfWork context)
        {
            _currentContext = context;
        }

        public IStep<T> Next { get; set; }

        public virtual string Description()
        {
            return "Commit or rollback the all changes at this point";
        }

        public IResult Execute(T obj)
        {
            IResult resultCurrent = null;

            if (Next == null)
            {
                return Result.Ok;
            }

            try
            {
                resultCurrent = Next.Execute(obj);

                if (resultCurrent.ComputeResult().IsOk())
                {
                    int resNum = _currentContext.SaveChanges();

                }
                else
                {
                    _currentContext.Rollback();
                    return resultCurrent;
                }

                return Result.Ok;
            }
            catch (Exception ex)
            {
                return new Result(EnumResultBL.ERROR_UNEXPECTED_EXCEPTION, "STEP::" +
                                this.GetType().ToString() +
                                " => " +
                                Description() +
                                " :" +
                                ex.Message);
            }
        }
    }
}
