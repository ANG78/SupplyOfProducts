using SupplyOfProducts.Api.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SupplyOfProducts.WF3._0
{
    public class StepContainerObserver : IObserverEvent
    {
        UIStepContainer Container;
        FlowLayoutPanel PanelSteps;
        Dictionary<object, IObserverEvent> Observers = new Dictionary<object, IObserverEvent>();
        static object LockerCreation = new object();

        public StepContainerObserver(FlowLayoutPanel panelSteps)
        {
            HelperUI.ModifyMethod(panelSteps, () =>
            {
                Container = new UIStepContainer();
                panelSteps.Controls.Add(Container);
                PanelSteps = panelSteps;
            });
        }



        private IObserverEvent GetContainer<T>(IStep<T> step)
        {
            if (!Observers.ContainsKey(step))
            {
                lock (LockerCreation)
                {
                    if (!Observers.ContainsKey(step))
                    {
                        Observers[step] = new StepControlObserver(Container);
                    }
                }
            }

            return Observers[step];

        }

        public void Create<T>(IStep<T> step)
        {
            HelperUI.ModifyMethod(Container, () =>
            {
                var current = step;
                while (current != null)
                {
                    Observers[step] = GetContainer(step);
                    current = current.Next;
                }

            });
        }

        public void Start<T>(T pData, IStep<T> pStep)
        {
            GetContainer(pStep).Start(pData, pStep);
        }
        public void Finish<T>(T pData, IStep<T> pStep, IResult res)
        {
            GetContainer(pStep).Finish(pData, pStep, res);
        }

        public void Exception<T>(T pData, IStep<T> pStep, Exception ex)
        {
            GetContainer(pStep).Exception(pData, pStep, ex);
        }

    }



}
