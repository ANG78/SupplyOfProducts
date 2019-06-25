using AutoMapper;
using Newtonsoft.Json;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;

namespace SupplyOfProducts.WF3._0
{
    public class FactoryHelperRun
    {
        public HelperRun<TInterfaceModel> GetExecutor<TInterfaceModel, TViewModel>(EType type, string stextJson, Operation op)
        {
            var _businessLogic = HI.GetInst().Get<IStep<IManagementModelRequest<TInterfaceModel>>>();
            IMapper _mapper = HI.GetInst().Get<IMapper>();

            TViewModel itemViewModel = JsonConvert.DeserializeObject<TViewModel>(stextJson);
            var itemModel = _mapper.Map<TInterfaceModel>(itemViewModel);

            var request = new ManagementModelRequest<TInterfaceModel>
            {
                Item = itemModel,
                Type = op
            };


            HelperRun<TInterfaceModel> pExecutor = new HelperRun<TInterfaceModel>
            {
                BusinessLogic = _businessLogic,
                Request = request
            };


            return pExecutor;
        }
    }
}
