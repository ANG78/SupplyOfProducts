﻿using AutoMapper;
using SupplyOfProducts.Api.Controllers.ViewModels;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.BusinessLogic.Mappers
{
    public class WorkPlaceProfile : Profile
    {
        public WorkPlaceProfile()
        {
            CreateMap<IWorkPlace, WorkPlaceViewModel>();


            CreateMap<WorkPlaceViewModel, IWorkPlace>().As<WorkPlace>();


            CreateMap<WorkPlaceViewModel, WorkPlace>();

        }
    }
}
