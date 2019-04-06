namespace DataObjects
{
    /// <summary>
    /// taxi reservation class
    /// </summary>
    public class TaxiReservation
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
        /// user info id
        /// </summary>
        public int UserInfoId { get; private set; }

        /// <summary>
        /// time
        /// </summary>
        public string Date { get; private set; }


        /// <summary>
        /// constructor for taxi reservation
        /// </summary>
        /// <param name="Id">id</param>
        /// <param name="TaxiCompanyId">taxi company id</param>
        /// <param name="UserInfoId">user info id</param>
        /// <param name="Date">Date</param>
        public TaxiReservation(int Id, int TaxiCompanyId, int UserInfoId, string Date)
        {
            this.Id = Id;
            this.TaxiCompanyId = TaxiCompanyId;
            this.UserInfoId = UserInfoId;
            this.Date = Date;
        }
    }
}
