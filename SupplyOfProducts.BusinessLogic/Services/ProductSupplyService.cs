using SupplyOfProducts.BusinessLogic.Services.Generics;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SupplyOfProducts.BusinessLogic.Services
{

    public class ProductSupplyService : GenericNotCodeService<IProductSupply>, IProductSupplyService
    {

        readonly IProductSupplyRepository _productSupplyRepository;

        public ProductSupplyService(IProductSupplyRepository productSupplyRepository) : base(productSupplyRepository)
        {
            _productSupplyRepository = productSupplyRepository;
        }

        public void Save(IProductSupply prodSupply)
        {
            if (prodSupply.Id == 0)
            {
                _productSupplyRepository.Add(prodSupply);
            }
            else
            {
                _productSupplyRepository.Edit(prodSupply);
            }

        }


        public void Remove(IProductSupply prodSupply)
        {
            if (prodSupply.Id > 0)
            {
                _productSupplyRepository.Remove(prodSupply);
            }

        }

      

        public IEnumerable<IProductSupplied> GetProductSuppliedToWorker(string sProduct, string sCodeWorker, string sCodWorkPlace, DateTime date)
        {
            return _productSupplyRepository.GetProductSuppliedToWorkerOnThisPeriod(sProduct, sCodeWorker, sCodWorkPlace, date);
        }

        public IEnumerable<IProductSupply> GetAll(int WorkerInWorkPlaceId, int ProductId, DateTime date)
        {
            return _productSupplyRepository.GetAll(WorkerInWorkPlaceId, ProductId, date); ;
        }

        protected override IProductSupply Check(IProductSupply prodSupply)
        {
            if (prodSupply.Id == 0)
            {
                var result = _productSupplyRepository.GetAll(prodSupply.WorkerInWorkPlaceId,
                                                          prodSupply.ProductId,
                                                          prodSupply.PeriodDate).ToList();
                if (result.Count == 0)
                {
                    return null;
                }

                return result.OrderByDescending(x => x.Id).FirstOrDefault();
            }

            return _productSupplyRepository.Get(prodSupply.Id); ;
        }

        protected override string GetString(IProductSupply item)
        {
            return item?.WorkerInWorkPlace?.Worker?.Code;
        }

       
    }


}
