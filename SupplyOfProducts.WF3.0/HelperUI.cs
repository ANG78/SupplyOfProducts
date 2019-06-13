using System.Windows.Forms;

namespace SupplyOfProducts.WF3._0
{
    public static class HelperUI
    {
        public delegate void MethodSetDelegate(Control control, MethodAux v);
        public delegate T MethodGetDelegate<T>(Control control, MethodGetAux<T> v);
        public delegate void MethodAux();
        public delegate T MethodGetAux<T>();

        public static void ModifyMethod(Control control, MethodAux v)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new MethodSetDelegate(ModifyMethod), control, v);
                return;
            }

            v.Invoke();
        }

        public static T GetMethod<T>(Control control, HelperUI.MethodGetAux<T> v)
        {
            if (control.InvokeRequired)
            {
                return (T)control.Invoke(new HelperUI.MethodGetDelegate<T>(GetMethod<T>), control, v);
            }
            return v.Invoke();
        }


    }
}
