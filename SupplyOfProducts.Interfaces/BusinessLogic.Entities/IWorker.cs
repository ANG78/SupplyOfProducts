using System;
using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Entities
{

    public interface IAddress
    {
        string Country { get; set; }
        string City { get; set; }
        string Street { get; set; }
    }

    public class NotesWork //: INotesWork
    {
        public int Id { get; set; }
        public string comments { get; set; }
        public DateTime DateTime { get; set; }
    }
    /*public interface INotesWork
    {
        string comments { get; set; }
        DateTime DateTime { get; set; }
    }*/

    public interface IDetailWork
    {
        IList<NotesWork> Notes { get; set; }
        DateTime? Birthday { get; set; }
        IAddress Address { get; set; }
    }

    public interface IWorker : ICode, IId
    {

        IDetailWork Detail { get; set; }
        string Name { get; set; }
    }


}
