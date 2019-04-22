using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;

namespace SupplyOfProducts.BusinessLogic.Steps.WorkerInfo
{
    public class GenerateWorkerReport : StepDecoratorTemplateGeneric<IWorkerInfo>
    {
        readonly IWorkerService _workerService;
        readonly IProductSupplyService _productSuppliedService;
        
        public GenerateWorkerReport(IWorkerService supplyBusinessLogic, IProductSupplyService productSuppliedService)
        {
            _workerService = supplyBusinessLogic;
            _productSuppliedService = productSuppliedService;
            
        }

        public override string Description()
        {
            return "Generate the report of products supplied to the worker passed as parameter";
        }

        protected override IResult ExecuteTemplate(IWorkerInfo obj)
        {
            obj.ProductSupplies = _productSuppliedService.GetProductSuppliedToWorker(obj.Worker.Code);
            obj.WorkPlaces = _workerService.GetWorkPlaceWhereWorkedTheWorker(obj.Worker.Code,null);          
            return Result.Ok;
        }
    }
}
