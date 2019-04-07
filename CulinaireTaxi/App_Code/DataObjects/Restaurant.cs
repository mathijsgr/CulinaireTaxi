namespace DataObjects
{
    /// <summary>
    /// restaurant class
    /// </summary>
    public class Restaurant
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// owner id
        /// </summary>
        public int OwnerId { get; private set; }

        /// <summary>
        /// restaurant name
        /// </summary>
        public string RestaurantName { get; private set; }

        /// <summary>
        /// postal code
        /// </summary>
        public string StreetName { get; private set; }

        /// <summary>
        /// postal code
        /// </summary>
        public string PostalCode { get; private set; }

        /// <summary>
        /// house number
        /// </summary>
        public string HouseNumber { get; private set; }

        /// <summary>
        /// house number prefix
        /// </summary>
        public string HouseNumberPrefix { get; private set; }

        /// <summary>
        /// city
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// description
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// has been validated
        /// </summary>
        public int HasBeenValidated { get; private set; }

        /// <summary>
        /// constructor for restaurant
        /// </summary>
        /// <param name="Id">id</param>
        /// <param name="OwnerId">owner id</param>
        /// <param name="RestaurantName">restaurant name</param>
        /// <param name="PostalCode">postal code</param>
        /// <param name="HouseNumber">house number</param>
        /// <param name="HouseNumberPrefix">house number prefix</param>
        /// <param name="City">city</param>
        /// <param name="Description">description</param>
        /// <param name="HasBeenValidated">has been validated</param>
        public Restaurant(int Id, int OwnerId, string RestaurantName, string StreetName, string PostalCode, string HouseNumber,
            string HouseNumberPrefix, string City, string Description, int HasBeenValidated)
        {
            this.Id = Id;
            this.OwnerId = OwnerId;
            this.RestaurantName = RestaurantName;
            this.StreetName = StreetName;
            this.PostalCode = PostalCode;
            this.HouseNumber = HouseNumber;
            this.HouseNumberPrefix = HouseNumberPrefix;
            this.City = City;
            this.Description = Description;
            this.HasBeenValidated = HasBeenValidated;
        }
    }
}
