using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CulinaireTaxi.App_Data.DataObjects
{
    public class RestaurantReservation
    {
        public int Id { get; private set; }
        public int RestaurantId { get; private set; }
        public int UserInfoId { get; private set; }
        public int AmountOfPersons { get; private set; }
        public string Date { get; private set; }

        public RestaurantReservation(int Id, int RestaurantId,int UserInfoId, int AmountOfPersons, string Date)
        {
            this.Id = Id;
            this.RestaurantId = RestaurantId;
            this.UserInfoId = UserInfoId;
            this.AmountOfPersons = AmountOfPersons;
            this.Date = Date;
        }
    }
}
