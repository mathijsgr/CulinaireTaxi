namespace DataObjects
{
    /// <summary>
    /// user info class
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// user id
        /// </summary>
        public int UserId { get; private set; }

        /// <summary>
        /// first name
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// prefix
        /// </summary>
        public string Prefix { get; private set; }

        /// <summary>
        /// last name
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// postal code
        /// </summary>
        public string PostalCode { get; private set; }

        /// <summary>
        /// house number
        /// </summary>
        public int HouseNumber { get; private set; }

        /// <summary>
        /// house number prefix
        /// </summary>
        public string HouseNumberPrefix { get; private set; }

        /// <summary>
        /// city
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// role
        /// </summary>
        public int Role { get; private set; }


        /// <summary>
        /// constructor for user info
        /// </summary>
        /// <param name="Id">id</param>
        /// <param name="UserId">user id</param>
        /// <param name="FirstName">first name</param>
        /// <param name="Prefix">prefix</param>
        /// <param name="LastName">last name</param>
        /// <param name="PostalCode">postal code</param>
        /// <param name="HouseNumber">house number</param>
        /// <param name="HouseNumberPrefix">house number prefix</param>
        /// <param name="City">city</param>
        /// <param name="Role">role</param>
        public UserInfo(int Id, int UserId, string FirstName, string Prefix, string LastName, string PostalCode,
            int HouseNumber, string HouseNumberPrefix, string City, int Role)
        {
            this.Id = Id;
            this.UserId = UserId;
            this.FirstName = FirstName;
            this.Prefix = Prefix;
            this.LastName = LastName;
            this.PostalCode = PostalCode;
            this.HouseNumber = HouseNumber;
            this.HouseNumberPrefix = HouseNumberPrefix;
            this.City = City;
            this.Role = Role;
        }
    }
}
