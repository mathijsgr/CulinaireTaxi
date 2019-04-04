
    public class UserInfo
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public string FirstName { get; private set; }
        public string Prefix { get; private set; }
        public string LastName { get; private set; }
        public string PostalCode { get; private set; }
        public int HouseNumber { get; private set; }
        public string HouseNumberPrefix { get; private set; }
        public string City { get; private set; }
        public int Role { get; private set; }

        public UserInfo (int Id, int UserId,string FirstName, string Prefix, string LastName, string PostalCode, int HouseNumber, string HouseNumberPrefix, string City, int Role)
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
