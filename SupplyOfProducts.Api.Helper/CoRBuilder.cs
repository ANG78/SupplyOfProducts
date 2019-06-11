using SupplyOfProducts.Interfaces.BusinessLogic;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace SupplyOfProducts.Api.Common
{


    public class CoRBuilder
    {
        public static bool IsCreateListener { get; set; } = true;

        readonly IServiceProvider _service;
        public CoRBuilder(IServiceProvider service)
        {
            _service = service;
        }

        public IStep<T> Get<T>(params IStep<T>[] parameters)
        {
            IList<IStep<T>> listToProcess = parameters.ToList();

            if (IsCreateListener)
            {
                listToProcess = listToProcess.Select(x => (IStep<T>)new DecoratorStep<T>(x)).ToList();
            }

            var result = listToProcess.First();
            listToProcess = listToProcess.Reverse().ToList();
            var current = listToProcess.FirstOrDefault();
            for (int i = 1; i < listToProcess.Count; i++)
            {
                listToProcess[i].Next = current;
                current = listToProcess[i];
            }
            return result;
        }

        public T GetService<T>()
        {
            return _service.GetRequiredService<T>();
        }
    }
}
