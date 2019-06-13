using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupplyOfProducts.WF3._0
{
    /// <summary>
    /// Helper Injection
    /// </summary>
    public class HI 
    {
        private static HI Instance = null;
        private static ServiceProvider ProviderDB;
        private static object LockerInstance = new object();

        private HI(ServiceProvider sr)
        {
            ProviderDB = sr;
        }
        
        public static HI GetInst(ServiceProvider sr = null)
        {
            if (Instance == null)
            {
                lock (LockerInstance)
                {
                    Instance = new HI(sr);
                }

            }

            return Instance;
        }

        public T Get<T>()
        {
            return ProviderDB.GetService<T>();
        }
    }

}
