using System.Collections.Generic;
using DataObjects;
using WebMatrix.Data;

namespace Querys
{
    /// <summary>
    /// restaurant reservations querys
    /// </summary>
    public class RestaurantReservationQuerys : DatabaseInfo
    {
        /// <summary>
        /// add a reservation
        /// </summary>
        /// <param name="RestaurantId">restaurant id</param>
        /// <param name="UserInfoId">user info id</param>
        /// <param name="AmountOfPersons">number of persons</param>
        /// <param name="Time">time</param>
        public void AddReservation(int RestaurantId, int UserInfoId, int AmountOfPersons, string Time)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "INSERT INTO RestaurantReservation (RestaurantId,UserInfoId,AmountOfPersons,Time) "
                                   + "VALUES(@0,@1,@2)";
            db.QuerySingle(insertCommand, RestaurantId, UserInfoId, AmountOfPersons, Time);
            db.Close();
        }

        /// <summary>
        /// get a reservation
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>reservation object</returns>
        public RestaurantReservation GetReservation(int Id)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM RestaurantReservation WHERE Id = @0";
            var row = db.QuerySingle(insertCommand, Id);
            db.Close();
            var reservering =
                new RestaurantReservation(row.Id, row.RestaurantId, row.UserInfoId, row.AmountOfPerons, row.Date);
            return reservering;
        }

        /// <summary>
        /// get all reservations from a user
        /// </summary>
        /// <param name="UserInfoId">user info id</param>
        /// <returns>list of reservations</returns>
        public List<RestaurantReservation> GetAllReservationsFromUser(int UserInfoId)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM RestaurantReservation WHERE UserInfoId = @0";
            var rows = db.Query(insertCommand, UserInfoId);
            db.Close();
            List<RestaurantReservation> reserveringen = new List<RestaurantReservation>();
            foreach (var row in rows)
            {
                var reservering = new RestaurantReservation(row.Id, row.RestaurantId, row.UserInfoId,
                    row.AmountOfPersons, row.Date);
                reserveringen.Add(reservering);
            }

            return reserveringen;
        }

        /// <summary>
        /// get all reservations from a restaurant
        /// </summary>
        /// <param name="RestaurantId">id</param>
        /// <returns>list of reservations</returns>
        public List<RestaurantReservation> GetAllReservationsFromRestaurant(int RestaurantId)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM RestaurantReservation WHERE RestaurantId = @0";
            var rows = db.Query(insertCommand, RestaurantId);
            db.Close();
            List<RestaurantReservation> reserveringen = new List<RestaurantReservation>();
            foreach (var row in rows)
            {
                var reservering = new RestaurantReservation(row.Id, row.RestaurantId, row.UserInfoId,
                    row.AmountOfPersons, row.Date);
                reserveringen.Add(reservering);
            }

            return reserveringen;
        }

        /// <summary>
        /// edit a reservation
        /// </summary>
        /// <param name="restaurantReservation">object of restaurant reservation</param>
        /// <returns>restaurant reservation object</returns>
        public RestaurantReservation EditReservation(RestaurantReservation restaurantReservation)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "UPDATE RestaurantReservation SET (AmountOfPersons = @1, Date = @2) WHERE Id = @0";
            var row = db.QuerySingle(dbCommand, restaurantReservation.Id, restaurantReservation.AmountOfPersons,
                restaurantReservation.Date);
            db.Close();
            return restaurantReservation;
        }

        /// <summary>
        /// delete a reservation
        /// </summary>
        /// <param name="Id">id</param>
        public void DeleteReservation(int Id)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "DELETE FROM RestaurantReservation WHERE Id = @0";
            db.QuerySingle(dbCommand, Id);
            db.Close();
        }
    }
}
