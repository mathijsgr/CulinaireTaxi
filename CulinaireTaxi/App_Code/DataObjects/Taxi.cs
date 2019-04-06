namespace DataObjects
{
    /// <summary>
    /// taxi class
    /// </summary>
    public class Taxi
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// taxi company id
        /// </summary>
        public int TaxiCompanyId { get; private set; }

        /// <summary>
        /// available or not (1 - 0)
        /// </summary>
        public int Available { get; private set; }

        /// <summary>
        /// constructor for taxi
        /// </summary>
        /// <param name="Id">id</param>
        /// <param name="TaxiCompanyId">taxi company id</param>
        /// <param name="Available">available or not (1 - 0)</param>
        public Taxi(int Id, int TaxiCompanyId, int Available)
        {
            this.Id = Id;
            this.TaxiCompanyId = TaxiCompanyId;
            this.Available = Available;
        }
    }
}
