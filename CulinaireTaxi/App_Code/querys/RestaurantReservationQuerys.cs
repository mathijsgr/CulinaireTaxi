using CulinaireTaxi.App_Data.DataObjects;
using System.Collections.Generic;
using WebMatrix.Data;

    public class RestaurantReservationQuerys : DatabaseInfo
    {
        public void AddReservation(int RestaurantId, int UserInfoId,int AmountOfPerons, string Time)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "INSERT INTO RestaurantReservation (RestaurantId,UserInfoId,AmountOfPerons,Time) "
                + "VALUES(@0,@1,@2)";
            db.QuerySingle(insertCommand, RestaurantId, UserInfoId, AmountOfPerons, Time);
            db.Close();
        }

        public RestaurantReservation GetReservation(int Id)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM RestaurantReservation WHERE Id = @0)";
            var row = db.QuerySingle(insertCommand, Id);
            db.Close();
            var reservering = new RestaurantReservation(row.Id, row.RestaurantId, row.UserInfoId, row.AmountOfPerons, row.Date);
            return reservering;
        }

        public List<RestaurantReservation> GetAllReservationsFromUser(int UserInfoId)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM RestaurantReservation WHERE UserInfoId = @0";
            var rows = db.Query(insertCommand, UserInfoId);
            db.Close();
            List<RestaurantReservation> reserveringen = new List<RestaurantReservation>();
            foreach (var row in rows)
            {
                var reservering = new RestaurantReservation(row.Id, row.RestaurantId, row.UserInfoId, row.AmountOfPersons, row.Date);
                reserveringen.Add(reservering);
            }
            return reserveringen;
        }

        public List<RestaurantReservation> GetAllReservationsFromRestaurant(int RestaurantId)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM RestaurantReservation WHERE RestaurantId = @0";
            var rows = db.Query(insertCommand, RestaurantId);
            db.Close();
            List<RestaurantReservation> reserveringen = new List<RestaurantReservation>();
            foreach (var row in rows)
            {
                var reservering = new RestaurantReservation(row.Id, row.RestaurantId, row.UserInfoId, row.AmountOfPersons, row.Date);
                reserveringen.Add(reservering);
            }
            return reserveringen;
        }

        public RestaurantReservation EditReservation(RestaurantReservation restaurantReservation)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "UPDATE RestaurantReservation SET (AmountOfPersons = @1, Date = @2) WHERE Id = @0";
            var row = db.QuerySingle(dbCommand, restaurantReservation.Id, restaurantReservation.AmountOfPersons, restaurantReservation.Date);
            db.Close();
            return restaurantReservation;
        }

        public void DeleteReservation(int Id)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "DELETE FROM RestaurantReservation WHERE Id = @0";
            var row = db.QuerySingle(dbCommand, Id);
            db.Close();
        }
    }
