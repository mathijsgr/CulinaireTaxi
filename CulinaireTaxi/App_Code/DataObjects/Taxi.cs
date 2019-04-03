using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CulinaireTaxi.App_Data.DataObjects
{
    public class Taxi
    {
        public int Id { get; private set; }
        public int TaxiCompanyId { get; private set; }
        public int Available { get; private set; }

        public Taxi(int Id, int TaxiCompanyId, int Available)
        {
            this.Id = Id;
            this.TaxiCompanyId = TaxiCompanyId;
            this.Available = Available;
        }
    }
}
