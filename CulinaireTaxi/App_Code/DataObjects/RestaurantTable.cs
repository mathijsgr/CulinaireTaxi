using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CulinaireTaxi.App_Data.DataObjects
{
    public class RestaurantTable
    {
        public int Id { get; private set; }
        public int RestaurantId { get; private set; }
        public int Available { get; private set; }
        public int TableNumber { get; private set; }
        public int NumberOfChairs { get; private set; }

        public RestaurantTable (int Id, int RestaurantId, int Available,int TableNumber,int NumberOfChairs)
        {
            this.Id = Id;
            this.RestaurantId = RestaurantId;
            this.Available = Available;
            this.TableNumber = TableNumber;
            this.NumberOfChairs = NumberOfChairs;
        }
    }
}
