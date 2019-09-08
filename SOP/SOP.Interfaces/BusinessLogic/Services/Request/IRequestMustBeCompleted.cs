using System;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Services.Request
{
    public interface IRequestMustBeCompleted
    {
    }


    public static class IRequestMustBeCompletedExtension
    {
        //public static void HelperCast<T>( this IRequestMustBeCompleted ob , object value, ref T result)
        //{

        //    if (!(value is IManagementModelRequest))
        //    {
        //        return;
        //    }

        //    Type t = value.GetType();
        //    if (t.IsGenericType)
        //    {
        //        var ItemValue = t.GetProperty("Item")?.GetValue(value);
        //        if (ItemValue != null && ItemValue is T)
        //        {
        //            result = (T)ItemValue;
        //        }
        //    }
        //}

        public static T HelperCast<T>(this IRequestMustBeCompleted ob, object value) where T :class
        {

            if (!(value is IManagementModelRequest))
            {
                return null;
            }

            Type t = value.GetType();
            if (t.IsGenericType)
            {
                var ItemValue = t.GetProperty("Item")?.GetValue(value);
                if (ItemValue != null && ItemValue is T)
                {
                    return ItemValue as T;
                }
            }

            return null;
        }
    }


}
