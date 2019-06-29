using Newtonsoft.Json;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using System;

namespace SupplyOfProducts.WF3._0
{
    public enum EType
    {
        WorkerViewModel,
        ConfigSupplyViewModel,
        ProductViewModel,
        ProductComplexViewModel
    }

    public static class ETypeExtesion
    {
        public static string GetTemplateString(this EType e)
        {

            string metaInfo = "SupplyOfProducts.Api.Controllers.ViewModels.";
            metaInfo += e.ToString();

            var aux = Activator.CreateInstance("SupplyOfProducts.Api.Common", metaInfo);

            JsonSerializerSettings s = new JsonSerializerSettings();
            s.NullValueHandling = NullValueHandling.Include;
            s.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            s.MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead;
            return JsonConvert.SerializeObject(aux.Unwrap(), Formatting.Indented, s);

        }
    }


}
