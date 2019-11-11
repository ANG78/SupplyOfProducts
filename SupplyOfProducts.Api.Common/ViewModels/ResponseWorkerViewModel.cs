using System;
using System.Collections.Generic;

namespace SupplyOfProducts.Api.Controllers.ViewModels
{

    public class ResponseWorkerViewModel : IResponseViewModel
    {
        public ResponseViewModel Status { get; set; } =  new ResponseViewModel();
        public string CodeWorker { get; set; }
        public string Name { get; set; }
        public IList<ResponseSupplyByWorkPlaceViewModel> ProductSuppliedByWorkPlaces { get; set; } = new List<ResponseSupplyByWorkPlaceViewModel>();
    }
}
