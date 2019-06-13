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
        public FrmMainObserver(FrmMain form)
        {
            Form = form;
        }

        Dictionary<object, IObserverEvent> Containers = new Dictionary<object, IObserverEvent>();

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
                        Containers[pData] = new StepContainerObserver(Form.panelSteps);
                    }
                }
            }
            return Containers[pData];
        }


        public async void Start<T>(T pData, IStep<T> pStep)
        {
            try
            {
                if (HelperUI.GetMethod<bool>(Form, () => { return Form.IsDisposed; }))
                {
                    return;
                }


                GetContainer(pData).Start(pData, pStep);

            }
            catch (Exception ex)
            {
                //FrmMain.SynchronizationContext.Post((state) =>
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                //, null);
            }
        }

        public async  void Finish<T>(T pData, IStep<T> pStep, IResult res)
        {
            try
            {
                if (HelperUI.GetMethod<bool>(Form, () => { return Form.IsDisposed; }))
                {
                    return;
                }

                GetContainer(pData).Finish(pData, pStep, res);

            }
            catch (Exception ex)
            {
                //FrmMain.SynchronizationContext.Post((state) =>
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                //, null);
            }
        }

        public async void Exception<T>(T pData, IStep<T> pStep, Exception ex)
        {
            try
            {
                if (HelperUI.GetMethod<bool>(Form, () => { return Form.IsDisposed; }))
                {
                    return;
                }

                GetContainer(pData).Exception(pData, pStep, ex);

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
