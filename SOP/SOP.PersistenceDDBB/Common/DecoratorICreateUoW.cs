﻿using SupplyOfProducts.Interfaces.BusinessLogic;

namespace SupplyOfProducts.PersistenceDDBB
{

   
        public class DecoratorICreateUoW : ICreateUoW
        {
            protected readonly IGenericContext _context;
            public DecoratorICreateUoW(IGenericContext context)
            {
                _context = context;
            }

            public IUnitOfWork CreateUoW()
            {
                return _context.CreateUoW();
            }
        }

    
}
