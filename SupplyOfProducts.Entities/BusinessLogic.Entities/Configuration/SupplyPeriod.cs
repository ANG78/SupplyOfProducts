﻿using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System;

namespace SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration
{
    public class SupplyPeriod : ISupplyPeriod
    {
        public DateTime DateStart { get; set; }
        public uint NumYearsByPeriod { get; set; }
    }

}
