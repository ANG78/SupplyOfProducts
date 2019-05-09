using SupplyOfProducts.Api.Controllers.ViewModels;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupplyOfProducts.Api.Controllers.Examples
{
    public class ExampleRequestConfigSupplyViewModel : IExamplesProvider<RequestConfigSupplyViewModel>
    {
        public RequestConfigSupplyViewModel GetExamples()
        {
            return new RequestConfigSupplyViewModel
            {
                CodeProduct = "EPI1",
                CodeWorker = "W01",
                CodeWorkPlace = "WP01",
                Date = new DateTime(2010, 04, 10),
                Amount = 1,
            };
        }
    }

    public class ExampleRequestSupplyViewModel : IExamplesProvider<RequestSupplyViewModel>
    {
        public RequestSupplyViewModel GetExamples()
        {
            return new RequestSupplyViewModel
            {
                CodeProduct = "EPI1",
                CodeWorker = "W01",
                CodeWorkPlace = "WP01",
                Date = new DateTime(2010, 04, 12),
            };
        }
    }
    
}
