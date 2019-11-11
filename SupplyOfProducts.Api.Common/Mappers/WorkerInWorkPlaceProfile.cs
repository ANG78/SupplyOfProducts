using SupplyOfProducts.Api.Controllers.ViewModels;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.BusinessLogic.Mappers
{
    public class WorkerInWorkPlaceProfile : ProfileHelper
    {
        public WorkerInWorkPlaceProfile()
        {

            CreateMap<IWorkerInWorkPlace, WorkerInWorkPlaceViewModel>()
                .ForMember(wiwp => wiwp.WorkerCode, opt => opt.MapFrom(s => s.Worker.Code))
                .ForMember(wiwp => wiwp.WorkPlaceCode, opt => opt.MapFrom(s => s.WorkPlace.Code))
                ;

            CreateMap<WorkerInWorkPlaceViewModel, IWorkerInWorkPlace>().As<WorkerInWorkPlace>();

            CreateMap<WorkerInWorkPlaceViewModel, WorkerInWorkPlace>()
                 .ForMember(wiwp => wiwp.Worker, opt => opt.MapFrom(s => Create<Worker>(s.WorkerCode)))
                 .ForMember(wiwp => wiwp.WorkPlace, opt => opt.MapFrom(s => Create<WorkPlace>(s.WorkPlaceCode)))
                ;
        }

    }

}


