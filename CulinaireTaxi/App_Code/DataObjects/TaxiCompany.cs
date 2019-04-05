namespace DataObjects
{
    /// <summary>
    /// taxi company class
    /// </summary>
    public class TaxiCompany
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
        /// company name
        /// </summary>
        public string CompanyName { get; private set; }

        /// <summary>
        /// company location
        /// </summary>
        public string CompanyLocation { get; private set; }

        /// <summary>
        /// description (max 255)
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// has been validated or not (1 - 0)
        /// </summary>
        public int HasBeenValidated { get; private set; }

        /// <summary>
        /// taxi company constructor
        /// </summary>
        /// <param name="Id">id</param>
        /// <param name="OwnerId">owner id</param>
        /// <param name="CompanyName">company name</param>
        /// <param name="CompanyLocation">company location</param>
        /// <param name="Description">description</param>
        /// <param name="HasBeenValidated">has been validated or not (1 - 0)</param>
        public TaxiCompany(int Id, int OwnerId, string CompanyName, string CompanyLocation, string Description,
            int HasBeenValidated)
        {
            this.Id = Id;
            this.OwnerId = OwnerId;
            this.CompanyName = CompanyName;
            this.CompanyLocation = CompanyLocation;
            this.Description = Description;
            this.HasBeenValidated = HasBeenValidated;
        }
    }
}
