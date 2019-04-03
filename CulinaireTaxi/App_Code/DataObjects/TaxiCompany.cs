using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CulinaireTaxi.App_Data.DataObjects
{
    public class TaxiCompany
    {
        public int Id { get; private set; }
        public string OwnerId { get; private set; }
        public string CompanyName { get; private set; }
        public string CompanyLocation { get; private set; }

        public TaxiCompany(int Id, string OwnerId, string CompanyName, string CompanyLocation)
        {
            this.Id = Id;
            this.OwnerId = OwnerId;
            this.CompanyName = CompanyName;
            this.CompanyLocation = CompanyLocation;
        }
    }
}
