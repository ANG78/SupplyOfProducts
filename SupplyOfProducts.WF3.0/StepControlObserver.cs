using Newtonsoft.Json;
using SupplyOfProducts.Api.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using System;

namespace SupplyOfProducts.WF3._0
{
    public class StepControlObserver : IObserverEvent
    {
        UIStepControl Container;
        public StepControlObserver(UIStepContainer form)
        {
            HelperUI.ModifyMethod(form, () =>
            {
                Container = new UIStepControl();
                form.Add(Container);
            });
        }

        public void Exception<T>(T pData, IStep<T> pStep, Exception ex)
        {
            string Tstring = JsonConvert.SerializeObject(pData);
            Container.SetValueException(Tstring, ex.Message);
        }

        public void Finish<T>(T pData, IStep<T> pStep, IResult res)
        {
            string Tstring = JsonConvert.SerializeObject(pData);
            Container.SetValueFinish(Tstring, res);
        }

        public void Start<T>(T pData, IStep<T> pStep)
        {
            string Tstring = JsonConvert.SerializeObject(pData);
            Container.SetValueStart(Tstring, pStep.Description());
        }
    }
}
