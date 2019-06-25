using SupplyOfProducts.Api.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using System;
using System.Collections.Generic;

namespace SupplyOfProducts.WF3._0
{


    public class FrmMainObserver : IObserverEvent
    {
        FrmMain Form;
        static object LockerCreation = new object();

        Dictionary<object, IObserverEvent> Containers = new Dictionary<object, IObserverEvent>();

        public FrmMainObserver(FrmMain form)
        {
            Form = form;
            Form.CreateNewHandler += CreateContainer;
        }

        public void CreateContainer()
        {
            var aux = new StepContainerObserver(Form, this);
        }

        public void RegisterContainer<T>( StepContainerObserver obs, T pData)
        {
            Containers[pData] = obs;
        }
       

        /*public void Clear(IRequest<SettlementSchedule> rq)
        {
            try
            {
                Helper.SynchronizationContext.Post((state) =>
                {
                    if (!Form.IsDisposed)
                    {
                        if (containers.ContainsKey(rq))
                        {
                            var cont = containers[rq];
                            Form.panelSteps.Controls.Remove(cont);
                        }
                    }

                }, null);

            }
            catch (Exception ex)
            {
               // FrmMain.SynchronizationContext.Post((state) =>
               //     System.Windows.MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
               //     , null);
            }

        }*/

        private IObserverEvent GetContainer<T>(T pData, IStep<T> pStep = null)
        {
            if (!Containers.ContainsKey(pData))
            {
                lock (LockerCreation)
                {
                    if (!Containers.ContainsKey(pData))
                    {
                        Containers[pData] = null;// Form.Get(pData);
                    }
                }
            }
            return Containers[pData];
        }


        public  void Start<T>(T pData, IStep<T> pStep)
        {
            try
            {
                if (HelperUI.GetMethod<bool>(Form, () => { return Form.IsDisposed; }))
                {
                    return;
                }


                GetContainer(pData)?.Start(pData, pStep);

            }
            catch (Exception ex)
            {
                //FrmMain.SynchronizationContext.Post((state) =>
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                //, null);
            }
        }

        public   void Finish<T>(T pData, IStep<T> pStep, IResult res)
        {
            try
            {
                if (HelperUI.GetMethod<bool>(Form, () => { return Form.IsDisposed; }))
                {
                    return;
                }

                GetContainer(pData)?.Finish(pData, pStep, res);

            }
            catch (Exception ex)
            {
                //FrmMain.SynchronizationContext.Post((state) =>
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                //, null);
            }
        }

        public  void Exception<T>(T pData, IStep<T> pStep, Exception ex)
        {
            try
            {
                if (HelperUI.GetMethod<bool>(Form, () => { return Form.IsDisposed; }))
                {
                    return;
                }

                GetContainer(pData)?.Exception(pData, pStep, ex);

            }
            catch (Exception ex1)
            {
                //FrmMain.SynchronizationContext.Post((state) =>
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                //, null);
            }

        }
    }
}
