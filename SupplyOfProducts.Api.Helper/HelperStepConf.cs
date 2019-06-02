using SupplyOfProducts.Interfaces.BusinessLogic;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace SupplyOfProducts.Api.Common
{
    public class HelperStepConf
    {
        readonly IServiceProvider _service;
        public HelperStepConf(IServiceProvider service)
        {
            _service = service;
        }

        public IStep<T> Get<T>(IList<IStep<T>> list)
        {
            var result = list.First();
            list = list.Reverse().ToList();
            var current = list.FirstOrDefault();
            for (int i = 1; i < list.Count; i++)
            {
                list[i].Next = current;
                current = list[i];
            }
            return result;
        }

        public T GetService<T>()
        {
            return _service.GetRequiredService<T>();
        }
    }
}
