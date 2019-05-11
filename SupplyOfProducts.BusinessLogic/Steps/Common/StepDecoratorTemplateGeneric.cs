using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using System;

namespace SupplyOfProducts.BusinessLogic.Steps.Common
{
    public abstract class StepDecoratorTemplateGeneric<T> : IStep<T>
    {
        public IStep<T> Next { get; set; }

        public StepDecoratorTemplateGeneric(IStep<T> next = null)
        {
            Next = next;
        }

        public IResult Execute(T obj)
        {
            try
            {

                IResult resultCurrent = null;

                try
                {
                    resultCurrent = ExecuteTemplate(obj);
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

                if (resultCurrent == null)
                {
                    return new Result(EnumResultBL.ERROR_BAD_IMPLEMENTATION, this.GetType().ToString());
                }

                if (resultCurrent.ComputeResult().IsError() || Next == null)
                {
                    return resultCurrent;
                }

                if (resultCurrent.ComputeResult().IsOk() && IsOkAndFinish )
                    return resultCurrent;

                return Next.Execute(obj);
            }
            catch (Exception ex)
            {
                return new Result(EnumResultBL.ERROR_UNEXPECTED_EXCEPTION, Next?.Description() + " :" + ex.Message);
            }

        }

        bool IsOkAndFinish { get; set; } = false;
        protected IResult OkAndFinish(string message)
        {
            IsOkAndFinish = true;
            return new Result(EnumResultBL.OK, message);
        }

        protected abstract IResult ExecuteTemplate(T obj);

        public abstract string Description();


    }
}
