namespace DataObjects
{
    /// <summary>
    /// taxi restaurant contract class
    /// </summary>
    public class TaxiRestaurantContract
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
        /// taxi company id
        /// </summary>
        public int TaxiCompanyId { get; private set; }

        /// <summary>
        /// contract description
        /// </summary>
        public string ContractDescription { get; private set; }

        /// <summary>
        /// taxi restaurant contract constructor
        /// </summary>
        /// <param name="Id">id</param>
        /// <param name="RestaurantId">restaurant id</param>
        /// <param name="TaxiCompanyId">taxi company id</param>
        /// <param name="ContractDescription">contract description</param>
        public TaxiRestaurantContract(int Id, int RestaurantId, int TaxiCompanyId, string ContractDescription)
        {
            this.Id = Id;
            this.RestaurantId = RestaurantId;
            this.TaxiCompanyId = TaxiCompanyId;
            this.ContractDescription = ContractDescription;
        }
    }
}