using System;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Services.Request
{
    public interface IRequestMustBeCompleted
    {
    }


    public static class SSS
    {
        public static void HelperCast<T>( this IRequestMustBeCompleted ob , object value, ref T result)
        {

            if (!(value is IManagementModelRequest))
            {
                return;
            }

            Type t = value.GetType();
            if (t.IsGenericType)
            {
                var ItemValue = t.GetProperty("Item")?.GetValue(value);
                if (ItemValue != null && ItemValue is T)
                {
                    result = (T)ItemValue;
                }
            }
        }
    }


}
