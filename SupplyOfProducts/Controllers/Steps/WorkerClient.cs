using AutoMapper;
using SupplyOfProducts.Api.Controllers.ViewModels;
using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SupplyOfProducts.Api.Controllers.Steps
{
    //https://docs.microsoft.com/es-es/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client
    public class WorkerClient : StepTemplateGeneric<IRequestMustBeCompleted>
    {
        IMapper _mapper { get; set; }
        public WorkerClient(IMapper mapper) {
            _mapper = mapper;
        }

        HttpClient client = new HttpClient();

        public async Task<WorkerViewModel> GetAsync(string sCode)
        {
            client.BaseAddress = new Uri("https://localhost:44385/");
            string path="api/worker/" + sCode;
            WorkerViewModel worker = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                worker = await response.Content.ReadAsAsync<WorkerViewModel>();
            }
            return worker;
        }
        

        public override string Description()
        {
            return "Check and complete the Worker Code by Services";
        }

        protected override IResult ExecuteTemplate(IRequestMustBeCompleted obj)
        {
            var objToProces = obj.HelperCast<IContainWorkerProperty>(obj);

            if (objToProces != null)
            {
                Task.Run(async () =>
                {
                    var resultVM = await GetAsync(objToProces.Worker.Code);
                    objToProces.Worker = _mapper.Map<Worker>(resultVM);
                    objToProces.Worker.Id = objToProces.Worker.Id;
                });

            }
            else
            {
                var objToProces2 = obj.HelperCast<IContainWorkerInWorkPlaceProperty>(obj);
                if (objToProces2 != null)
                {
                    Task.Run(async () =>
                    {
                        var resultVM = await GetAsync(objToProces2.WorkerInWorkPlace.Worker.Code);
                        objToProces2.WorkerInWorkPlace.Worker = _mapper.Map<Worker>(resultVM);
                        objToProces2.WorkerInWorkPlace.WorkerId = objToProces2.WorkerInWorkPlace.Worker.Id;
                    });
                }
            }
            

            return Result.Ok;
        }
      
    }
}
