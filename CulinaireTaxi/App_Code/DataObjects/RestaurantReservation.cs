namespace DataObjects
{
    /// <summary>
    /// restaurant reservation class
    /// </summary>
    public class RestaurantReservation
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
        /// user info id
        /// </summary>
        public int UserInfoId { get; private set; }

        /// <summary>
        /// amount of persons
        /// </summary>
        public int AmountOfPersons { get; private set; }

        /// <summary>
        /// time of reservation
        /// </summary>
        public string Date { get; private set; }

        /// <summary>
        /// constructor for restaurant reservation
        /// </summary>
        /// <param name="Id">id</param>
        /// <param name="RestaurantId">restaurant id</param>
        /// <param name="UserInfoId">user info id</param>
        /// <param name="AmountOfPersons">amount of persons</param>
        /// <param name="Time">time</param>
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
