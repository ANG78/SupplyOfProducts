using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System;
using System.Collections.Generic;

namespace SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration
{
    public partial class Worker : IWorker
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public IDetailWork Detail { get; set; } = new DetailWork();

        public Worker()
        { }

        public Worker( IWorker worker)
        {
            Id = worker.Id;
            Code = worker.Code;
            Name = worker.Name;
        }
    }

    public class DetailWork : IDetailWork
    {
        public DateTime? Birthday { get; set; }
        public IAddress Address { get; set; } = new AddressWork();
        public IList<NotesWork> Notes { get; set; }
    }
    /*
    public class NotesWork //: INotesWork
    {
        public string comments { get; set; }
        public DateTime DateTime { get; set; }
    }*/



    public class AddressWork : IAddress
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}
