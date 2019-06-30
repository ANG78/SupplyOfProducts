using SupplyOfProducts.Api.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SupplyOfProducts.WF3._0
{
    public delegate void RegisterListener(StepContainerObserver stepParam, object request);

    public class StepContainerObserver : IObserverEvent
    {
        UIStepGenerator Container;
        FrmMainObserver FrmMainObserver;
        Dictionary<object, StepControlObserver> Observers = new Dictionary<object, StepControlObserver>();
        static object LockerCreation = new object();


        public StepContainerObserver(FrmMain form, FrmMainObserver obs)
        {
            HelperUI.ModifyMethod(form, () =>
            {
                FrmMainObserver = obs;
                Container = new UIStepGenerator();
                Container.StepObserver = this;
                form.panelSteps.Controls.Add(Container);
            });
        }


        public void RegisterSteps<T>(IStep<T> stepParam, T pData)
        {
            var step = stepParam;
            while (step != null)
            {
                Observers[step] = GetContainer(step);

                if (step is IDecoratorStep<T>)
                {
                    if (((IDecoratorStep<T>)step).DecoratedStep is ICompositorSteps<IRequestMustBeCompleted>)
                    {
                        var reqStep = ((ICompositorSteps<IRequestMustBeCompleted>)((IDecoratorStep<T>)step).DecoratedStep).Steps;
                        while (reqStep != null)
                        {
                            Observers[reqStep] = GetContainer(reqStep);
                            reqStep = reqStep.Next;
                        }
                    }


                }


                step = step.Next;
            }

            FrmMainObserver.RegisterContainer(this, pData);
        }


        private StepControlObserver GetContainer<T>(IStep<T> step)
        {
            if (!Observers.ContainsKey(step))
            {
                lock (LockerCreation)
                {
                    if (!Observers.ContainsKey(step))
                    {
                        var aux = new StepControlObserver(Container);
                        aux.Initial(step.Description());
                        Observers[step] = aux;
                    }
                }
            }

            return Observers[step];

        }

        public void Start<T>(T pData, IStep<T> pStep)
        {
            GetContainer(pStep)?.Start(pData, pStep);
        }
        public void Finish<T>(T pData, IStep<T> pStep, IResult res)
        {
            GetContainer(pStep)?.Finish(pData, pStep, res);
        }

        public void Exception<T>(T pData, IStep<T> pStep, Exception ex)
        {
            GetContainer(pStep)?.Exception(pData, pStep, ex);
        }

        public void ResizeToJustIcon()
        {

            lock (LockerCreation)
            {

                foreach (var cpm in Observers.Values)
                {

                    cpm.ResizeToJustIcon();
                    
                }
            }
        }

    }



}
