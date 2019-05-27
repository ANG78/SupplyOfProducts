using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SupplyOfProducts.BusinessLogic.Services
{

    public class ProductSupplyService : GenericService<IProductSupply>, IProductSupplyService
    {

        readonly IProductSupplyRepository _productSupplyRepository;

        public ProductSupplyService(IProductSupplyRepository productSupplyRepository):base(productSupplyRepository)
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

        public IEnumerable<IProductSupply> GetAll(string sCodeWorker)
        {
            return _productSupplyRepository.GetProductSuppliedToWorker(sCodeWorker);
        }

        public IList<IProductSupplied> GetProductSuppliedToWorker(string sProduct, string sCodeWorker, string sCodWorkPlace, DateTime date)
        {
            return _productSupplyRepository.GetProductSuppliedToWorkerOnThisPeriod(sProduct, sCodeWorker, sCodWorkPlace, date);
        }

       
        protected override IProductSupply Check(IProductSupply prodSupply)
        {
            if (prodSupply.Id == 0)
            {
                return _productSupplyRepository.Get(prodSupply.WorkerInWorkPlaceId,
                                                    prodSupply.ProductId,
                                                    prodSupply.PeriodDate);

            }

            return _productSupplyRepository.Get(prodSupply.Id); ;
        }

        protected override string GetString(IProductSupply item)
        {
            return item?.WorkerInWorkPlace?.Worker?.Code;
        }
    }


}
