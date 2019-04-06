using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CulinaireTaxi.App_Data.DataObjects
{
    public class TaxiReservation
    {
        public int Id { get; private set; }
        public int TaxiCompanyId { get; private set; }
        public int UserInfoId { get; private set; }
        public string Date { get; private set; }

        public TaxiReservation(int Id, int TaxiCompanyId, int UserInfoId, string Date)
        {
            this.Id = Id;
            this.TaxiCompanyId = TaxiCompanyId;
            this.UserInfoId = UserInfoId;
            this.Date = Date;
        }
    }
}
