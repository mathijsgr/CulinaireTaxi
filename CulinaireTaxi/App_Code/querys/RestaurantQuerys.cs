using System.Collections.Generic;
using DataObjects;
using WebMatrix.Data;

namespace Querys
{
    /// <summary>
    /// restaurant querys class
    /// </summary>
    public class RestaurantQuerys : DatabaseInfo
    {
        /// <summary>
        /// add a restaurant
        /// </summary>
        /// <param name="OwnerId">owner id</param>
        /// <param name="RestaurantName">restaurant name</param>
        /// <param name="PostalCode">postal code</param>
        /// <param name="HouseNumber">house number</param>
        /// <param name="HouseNumberPrefix"> house number prefix</param>
        /// <param name="City">city</param>
        /// <param name="Description">description</param>
        public void AddRestaurant(int OwnerId, string RestaurantName, string PostalCode, string HouseNumber,
            string HouseNumberPrefix, string City, string Description, string StreetName)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand =
                "INSERT INTO Restaurant (OwnerId,RestaurantName,PostalCode,HouseNumber,HouseNumberPrefix,City,Description,HasBeenValidated,StreetName) "
                + "VALUES(@0,@1,@2,@3,@4,@5,@6,@7)";
            db.QuerySingle(insertCommand, OwnerId, RestaurantName, PostalCode, HouseNumber, HouseNumberPrefix, City,
                Description, 0, StreetName);
            db.Close();
        }

        /// <summary>
        /// get a restaurant by id
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>restaurant object</returns>
        public Restaurant GetRestaurant(int Id)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM Restaurant WHERE Id = @0";
            var row = db.QuerySingle(insertCommand, Id);
            db.Close();
            var restaurant = new Restaurant(row.Id, row.OwnerId, row.RestaurantName, row.StreetName, row.PostalCode, row.HouseNumber,
                row.HouseNumberPrefix, row.City, row.Description, row.HasBeenValidated);
            return restaurant;
        }

        /// <summary>
        /// get restaurant by owner id
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>restaurant object</returns>
        public Restaurant GetRestaurantByOwnerId(int Id)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM Restaurant WHERE OwnerId = @0";
            var row = db.QuerySingle(insertCommand, Id);
            db.Close();
            if (row == null) return null;
            else
            {
                var restaurant = new Restaurant(row.Id, row.OwnerId, row.RestaurantName, row.StreetName, row.PostalCode,
                    row.HouseNumber, row.HouseNumberPrefix, row.City, row.Description, row.HasBeenValidated);
                return restaurant;
            }
        }

        /// <summary>
        /// check if restaurant exists
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>true or false</returns>
        public bool CheckIfRestaurantExists(int Id)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM Restaurant WHERE OwnerId = @0";
            var row = db.QuerySingle(insertCommand, Id);
            db.Close();
            if (row == null) return false;
            return true;
        }

        /// <summary>
        /// get all restaurants
        /// </summary>
        /// <returns>list of restaurants</returns>
        public List<Restaurant> GetAllRestaurants()
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM Restaurant WHERE HasBeenValidated = 3";
            var rows = db.Query(insertCommand);
            db.Close();
            List<Restaurant> restaurants = new List<Restaurant>();
            foreach (var row in rows)
            {
                var restaurant = new Restaurant(row.Id, row.OwnerId, row.RestaurantName, row.StreetName, row.PostalCode,
                    row.HouseNumber, row.HouseNumberPrefix, row.City, row.Description, row.HasBeenValidated);
                restaurants.Add(restaurant);
            }

            return restaurants;
        }

        /// <summary>
        /// get all not validated restaurants
        /// </summary>
        /// <returns>list of restaurants</returns>
        public List<Restaurant> GetAllNotValidatedRestaurants()
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM Restaurant WHERE NOT HasBeenValidated = 3";
            var rows = db.Query(insertCommand);
            db.Close();
            List<Restaurant> restaurants = new List<Restaurant>();
            foreach (var row in rows)
            {
                var restaurant = new Restaurant(row.Id, row.OwnerId, row.RestaurantName, row.StreetName, row.PostalCode,
                    row.HouseNumber, row.HouseNumberPrefix, row.City, row.Description, row.HasBeenValidated);
                restaurants.Add(restaurant);
            }

            return restaurants;
        }

        /// <summary>
        /// get all restaurants by postal code
        /// </summary>
        /// <returns>list of restaurants</returns>
        public List<Restaurant> GetAllRestaurantsByPostalCode()
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM Restaurant)";
            var rows = db.Query(insertCommand);
            db.Close();
            List<Restaurant> restaurants = new List<Restaurant>();
            foreach (var row in rows)
            {
                var restaurant = new Restaurant(row.Id, row.OwnerId, row.RestaurantName, row.StreetName, row.PostalCode,
                    row.HouseNumber, row.HouseNumberPrefix, row.City, row.Description, row.HasBeenValidated);
                restaurants.Add(restaurant);
            }

            return restaurants;
        }

        /// <summary>
        /// get all restaurants by city
        /// </summary>
        /// <returns>list of restaurants</returns>
        public List<Restaurant> GetAllRestaurantsByCity()
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM Restaurant)";
            var rows = db.Query(insertCommand);
            db.Close();
            List<Restaurant> restaurants = new List<Restaurant>();
            foreach (var row in rows)
            {
                var restaurant = new Restaurant(row.Id, row.OwnerId, row.RestaurantName, row.StreetName, row.PostalCode,
                    row.HouseNumber, row.HouseNumberPrefix, row.City, row.Description, row.HasBeenValidated);
                restaurants.Add(restaurant);
            }

            return restaurants;
        }

        /// <summary>
        /// update restaurant validation
        /// </summary>
        /// <param name="Id">id</param>
        /// <param name="Validation">validation true or false (1 - 0)</param>
        public void UpdateRestaurantValidation(int Id, int Validation)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "UPDATE Restaurant SET HasBeenValidated = @1 WHERE Id = @0";
            db.QuerySingle(dbCommand, Id, Validation);
            db.Close();
        }

        /// <summary>
        /// edit a restaurant
        /// </summary>
        /// <param name="restaurant">restaurant object</param>
        /// <returns>restaurant object</returns>
        public Restaurant EditRestaurant(Restaurant restaurant)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand =
                "UPDATE Restaurant SET RestaurantName = @1, PostalCode = @2, HouseNumber = @3, HouseNumberPrefix = @4, City = @5, StreetName = @6 WHERE Id = @0";
            db.QuerySingle(dbCommand, restaurant.Id, restaurant.RestaurantName, restaurant.PostalCode,
                restaurant.HouseNumber, restaurant.HouseNumberPrefix, restaurant.City, restaurant.StreetName);
            db.Close();
            return restaurant;
        }

        /// <summary>
        /// delete a taxi
        /// </summary>
        /// <param name="Id">taxi id</param>
        public void DeleteTaxi(int Id)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "DELETE FROM Restaurant WHERE Id = @0";
            db.QuerySingle(dbCommand, Id);
            db.Close();
        }
    }
}