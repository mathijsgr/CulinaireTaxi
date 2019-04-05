namespace DataObjects
{
    /// <summary>
    /// restaurant table class
    /// </summary>
    public class RestaurantTable
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// restaurant id
        /// </summary>
        public int RestaurantId { get; private set; }

        /// <summary>
        /// available or not
        /// </summary>
        public int Available { get; private set; }

        /// <summary>
        /// table number
        /// </summary>
        public int TableNumber { get; private set; }

        /// <summary>
        /// number of chairs
        /// </summary>
        public int NumberOfChairs { get; private set; }

        /// <summary>
        /// constructor for restaurantTable
        /// </summary>
        /// <param name="Id">id</param>
        /// <param name="RestaurantId">restaurant id</param>
        /// <param name="Available">available or not (1 - 0)</param>
        /// <param name="TableNumber">table number</param>
        /// <param name="NumberOfChairs">number of chairs</param>
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
