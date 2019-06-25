using Newtonsoft.Json;
using SupplyOfProducts.Api.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using System;

namespace SupplyOfProducts.WF3._0
{
    

    public class StepControlObserver : IObserverEvent
    {
        UIStepControl Container;
        public StepControlObserver(UIStepGenerator form)
        {
            HelperUI.ModifyMethod(form, () =>
            {
                Container = new UIStepControl();
                form.Add(Container);
            });
        }

        public void Exception<T>(T pData, IStep<T> pStep, Exception ex)
        {
            Container.SetValueException(SerializeString(pData), ex.Message);
        }

        public void Finish<T>(T pData, IStep<T> pStep, IResult res)
        {
            Container.SetValueFinish(SerializeString(pData), res.ComputeResult().IsOk(),res.ComputeResult().IsWarning(), res.Message());
        }

        public void Start<T>(T pData, IStep<T> pStep)
        {
            Container.SetValueStart(SerializeString(pData));
        }

        public void Initial(string desc)
        {
            Container.SetValueInitial( desc);
        }

        private string SerializeString<TData>(TData pData)
        {
            JsonSerializerSettings opt = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            return JsonConvert.SerializeObject(pData, opt);
        }
    }
}
