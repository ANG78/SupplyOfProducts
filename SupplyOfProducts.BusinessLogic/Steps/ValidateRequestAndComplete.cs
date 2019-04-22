using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;

namespace SupplyOfProducts.BusinessLogic.Steps
{
    public class ValidateRequestAndComplete<T> : StepDecoratorTemplateGeneric<T>
    {
        public IStep<IRequestMustBeCompleted> _intialSteps { get; set; }
        public ValidateRequestAndComplete(IStep<IRequestMustBeCompleted> intialSteps, IStep<T> next = null) : base(next)
        {
            _intialSteps = intialSteps;
        }

        public override string Description()
        {
            return "Execute the Common steps";
        }

        protected override IResult ExecuteTemplate(T obj)
        {
            if (obj is IRequestMustBeCompleted)
            {
                 return _intialSteps.Execute((IRequestMustBeCompleted)obj);
            }
            return Result.Ok;
        }
    }
}
