using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupplyOfProducts.WF3._0
{
    public abstract class HelperRun
    {
        public abstract IResult Run();

    }

    public class HelperRun<TModel> : HelperRun
    {
        public IStep<IManagementModelRequest<TModel>> BusinessLogic { get; set; }
        public IManagementModelRequest<TModel> Request { get; set; }



        public override IResult Run()
        {
            return BusinessLogic.Execute(Request);
        }
    }
}
