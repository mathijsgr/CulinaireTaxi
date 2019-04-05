using CulinaireTaxi.App_Data.DataObjects;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebMatrix.Data;



    public class RestaurantQuerys : DatabaseInfo
    {
        public void AddRestaurant(int OwnerId, string RestaurantName,string PostalCode,int HouseNumber,string HouseNumberPrefix,string City, string Description)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "INSERT INTO Restaurant (OwnerId,RestaurantName,PostalCode,HouseNumber,HouseNumberPrefix,City,Description,HasBeenValidated) "
                + "VALUES(@0,@1,@2,@3,@4,@5,@6,@7)";
            db.QuerySingle(insertCommand, OwnerId, RestaurantName, PostalCode, HouseNumber, HouseNumberPrefix, City, Description, 0);
            db.Close();
        }

        public Restaurant GetRestaurant(int Id)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM Restaurant WHERE Id = @0";
            var row = db.QuerySingle(insertCommand, Id);
            db.Close();
            var restaurant = new Restaurant(row.Id, row.OwnerId, row.RestaurantName,row.PostalCode,row.HouseNumber,row.HouseNumberPrefix,row.City, row.Description, row.HasBeenValidated);
            return restaurant;
        }

        public Restaurant GetRestaurantByOwnerId(int Id)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM Restaurant WHERE OwnerId = @0";
            var row = db.QuerySingle(insertCommand, Id);
            db.Close();
            if (row == null) return null;
            else
            {
            var restaurant = new Restaurant(row.Id, row.OwnerId, row.RestaurantName, row.PostalCode, row.HouseNumber, row.HouseNumberPrefix, row.City, row.Description, row.HasBeenValidated);
            return restaurant;
            }   
        }

        public static bool CheckIfRestaurantExists(int Id)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM Restaurant WHERE OwnerId = @0";
            var row = db.QuerySingle(insertCommand, Id);
            db.Close();
            if (row == null) return false;
            return true;
        }

        public List<Restaurant> GetAllRestaurants()
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM Restaurant";
            var rows = db.Query(insertCommand);
            db.Close();
            List<Restaurant> restaurants = new List<Restaurant>();
            foreach (var row in rows)
            {
                var restaurant = new Restaurant(row.Id, row.OwnerId, row.RestaurantName, row.PostalCode, row.HouseNumber, row.HouseNumberPrefix, row.City, row.Description, row.HasBeenValidated);
                restaurants.Add(restaurant);
            }
            return restaurants;
        }

        public List<Restaurant> GetAllNotValidatedRestaurants()
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM Restaurant WHERE NOT HasBeenValidated = 3";
            var rows = db.Query(insertCommand);
            db.Close();
            List<Restaurant> restaurants = new List<Restaurant>();
            foreach (var row in rows)
            {
                var restaurant = new Restaurant(row.Id, row.OwnerId, row.RestaurantName, row.PostalCode, row.HouseNumber, row.HouseNumberPrefix, row.City, row.Description, row.HasBeenValidated);
                restaurants.Add(restaurant);
            }
            return restaurants;
        }

        public List<Restaurant> GetAllRestaurantsByPostalCode()
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM Restaurant)";
            var rows = db.Query(insertCommand);
            db.Close();
            List<Restaurant> restaurants = new List<Restaurant>();
            foreach (var row in rows)
            {
                var restaurant = new Restaurant(row.Id, row.OwnerId, row.RestaurantName, row.PostalCode, row.HouseNumber, row.HouseNumberPrefix, row.City, row.Description, row.HasBeenValidated);
                restaurants.Add(restaurant);
            }
            return restaurants;
        }

        public List<Restaurant> GetAllRestaurantsByCity()
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM Restaurant)";
            var rows = db.Query(insertCommand);
            db.Close();
            List<Restaurant> restaurants = new List<Restaurant>();
            foreach (var row in rows)
            {
                var restaurant = new Restaurant(row.Id, row.OwnerId, row.RestaurantName, row.PostalCode, row.HouseNumber, row.HouseNumberPrefix, row.City, row.Description, row.HasBeenValidated);
                restaurants.Add(restaurant);
            }
            return restaurants;
        }

        public void UpdateRestaurantValidation(int Id, int Validation)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "UPDATE Restaurant SET HasBeenValidated = @1 WHERE Id = @0";
            db.QuerySingle(dbCommand, Id, Validation);
            db.Close();
        }

        public Restaurant EditRestaurant(Restaurant restaurant)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "UPDATE Restaurant SET RestaurantName = @1, PostalCode = @2, HouseNumber = @3, HouseNumberPrefix = @4, City = @5 WHERE Id = @0";
            var row = db.QuerySingle(dbCommand, restaurant.Id,restaurant.RestaurantName, restaurant.PostalCode,restaurant.HouseNumber,restaurant.HouseNumberPrefix,restaurant.City);
            db.Close();
            return restaurant;
        }

        public void DeleteTaxi(int Id)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "DELETE FROM Restaurant WHERE Id = @0";
            var row = db.QuerySingle(dbCommand, Id);
            db.Close();
        }
    }

