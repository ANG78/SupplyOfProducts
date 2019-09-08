using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using AutoMapper;
using SupplyOfProducts.Api.Controllers.ViewModels;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.BusinessLogic.Mappers
{
    public class WorkerProfile : Profile
    {
        public WorkerProfile()
        {
            CreateMap<IWorker, WorkerViewModel>();

            CreateMap<WorkerViewModel, IWorker>();
        }
    }
}
