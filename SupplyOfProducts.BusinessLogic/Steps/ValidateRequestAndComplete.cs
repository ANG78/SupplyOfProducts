using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;

namespace SupplyOfProducts.BusinessLogic.Steps
{
   

    public class ValidateRequestAndComplete<T> : StepDecoratorTemplateGeneric<T>, ICompositorSteps<IRequestMustBeCompleted>
    {
        public IStep<IRequestMustBeCompleted> Steps { get; private set; }
        public ValidateRequestAndComplete(IStep<IRequestMustBeCompleted> intialSteps, IStep<T> next = null) : base(next)
        {
            Steps = intialSteps;
        }

        public override string Description()
        {
            return "Execute the Common steps";
        }

        protected override IResult ExecuteTemplate(T obj)
        {
            if (obj is IRequestMustBeCompleted)
            {
                 return Steps.Execute((IRequestMustBeCompleted)obj);
            }
            return Result.Ok;
        }
    }
}
