using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.Repository;
using System;
using System.Collections.Generic;

namespace SupplyOfProducts.BusinessLogic.Services
{

    public class ProductSupplyService : IProductSupplyService
    {

        readonly IProductSupplyRepository _productSupplyRepository;

        public ProductSupplyService(IProductSupplyRepository productSupplyRepository)
        {
            _productSupplyRepository = productSupplyRepository;
        }

        public IProductSupply Get(IProductSupply prodSupply)
        {
            if (prodSupply.Id == 0)
            {
                return _productSupplyRepository.Get(prodSupply.IdWorkerInWorkPlace, 
                                                    prodSupply.IdProduct, 
                                                    prodSupply.PeriodDate);

            }

            return _productSupplyRepository.Get(prodSupply.Id);
        }

        public void Save(IProductSupply prodSupply)
        {
            _productSupplyRepository.Save(prodSupply);
        }


        public void Remove(IProductSupply prodSupply)
        {
            _productSupplyRepository.Remove(prodSupply);
        }

        public IList<IProductSupply> GetProductSuppliedToWorker(string sCodeWorker)
        {
            return _productSupplyRepository.GetProductSuppliedToWorker(sCodeWorker);
        }

        public IList<IProductSupplied> GetProductSuppliedToWorker(string sProduct, string sCodeWorker, string sCodWorkPlace, DateTime date)
        {
            return _productSupplyRepository.GetProductSuppliedToWorker(sProduct, sCodeWorker, sCodWorkPlace, date);
        }

       
    }


}
