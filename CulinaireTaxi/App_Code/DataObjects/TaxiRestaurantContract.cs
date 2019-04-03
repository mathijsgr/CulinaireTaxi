using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CulinaireTaxi.App_Data.DataObjects
{
    public class TaxiRestaurantContract
    {
        public int Id { get; private set; }
        public int RestaurantId { get; private set; }
        public int TaxiCompanyId { get; private set; }
        public string ContractDescription { get; private set; }

        public TaxiRestaurantContract (int Id,int RestaurantId, int TaxiCompanyId, string ContractDescription)
        {
            this.Id = Id;
            this.RestaurantId = RestaurantId;
            this.TaxiCompanyId = TaxiCompanyId;
            this.ContractDescription = ContractDescription;
        }
    }
}
