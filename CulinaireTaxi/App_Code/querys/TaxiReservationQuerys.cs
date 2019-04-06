using System.Collections.Generic;
using DataObjects;
using WebMatrix.Data;

namespace Querys
{
    /// <summary>
    /// taxi reservation querys
    /// </summary>
    public class TaxiReservationQuerys : DatabaseInfo
    {
        /// <summary>
        /// add a taxi reservation
        /// </summary>
        /// <param name="TaxiCompanyId">taxi company id</param>
        /// <param name="UserInfoId">user info id</param>
        /// <param name="Date">time</param>
        public void AddReservation(int TaxiCompanyId, int UserInfoId, string Date)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "INSERT INTO TaxiReservation (TaxiCompanyId,UserInfoId,Date) "
                + "VALUES(@0,@1,@2)";
            db.QuerySingle(insertCommand, TaxiCompanyId, UserInfoId, Date);
            db.Close();
        }
        
        /// <summary>
        /// gets a reservation by id
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>reservation</returns>
        public TaxiReservation GetReservation(int Id)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM TaxiReservation WHERE Id = @0";
            var row = db.QuerySingle(insertCommand, Id);
            db.Close();
            var reservering = new TaxiReservation(row.Id,row.TaxiCompanyId, row.UserInfoId, row.Date);
            return reservering;
        }

        /// <summary>
        /// gets all reservations from a user
        /// </summary>
        /// <param name="UserInfoId">user info id</param>
        /// <returns>list of reservations</returns>
        public List<TaxiReservation> GetAllReservationsFromUser(int UserInfoId)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM TaxiReservation WHERE UserInfoId = @0";
            var rows = db.Query(insertCommand, UserInfoId);
            db.Close();
            List<TaxiReservation> reserveringen = new List<TaxiReservation>();
            foreach (var row in rows)
            {
                var reservering = new TaxiReservation(row.Id,row.TaxiCompanyId, row.UserInfoId, row.Date);
                reserveringen.Add(reservering);
            }
            return reserveringen;
        }

        /// <summary>
        /// gets all reservations from a taxi company
        /// </summary>
        /// <param name="TaxiCompanyId">taxi comapny id</param>
        /// <returns>list of reservations</returns>
        public List<TaxiReservation> GetAllReservationsFromTaxiCompany(int TaxiCompanyId)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM TaxiReservation WHERE TaxiCompanyId = @0";
            var rows = db.Query(insertCommand, TaxiCompanyId);
            db.Close();
            List<TaxiReservation> reserveringen = new List<TaxiReservation>();
            foreach (var row in rows)
            {
                var reservering = new TaxiReservation(row.Id, row.TaxiCompanyId, row.UserInfoId, row.Date);
                reserveringen.Add(reservering);
            }
            return reserveringen;
        }

        /// <summary>
        /// edit a reservation
        /// </summary>
        /// <param name="taxiReservation">taxiReservation object</param>
        /// <returns>taxi reservation</returns>
        public TaxiReservation EditReservation(TaxiReservation taxiReservation)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "UPDATE TaxiReservation SET (Date = @1) WHERE Id = @0";
            var row = db.QuerySingle(dbCommand, taxiReservation.Id, taxiReservation.Date);
            db.Close();
            return taxiReservation;
        }

        /// <summary>
        /// delete a reservation
        /// </summary>
        /// <param name="Id">id</param>
        public void DeleteReservation(int Id)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "DELETE FROM TaxiReservation WHERE Id = @0";
            db.QuerySingle(dbCommand, Id);
            db.Close();
        }
    }
