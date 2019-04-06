using System.Collections.Generic;
using DataObjects;
using WebMatrix.Data;


namespace Querys
{
    /// <summary>
    /// restaurant table querys
    /// </summary>
    public class RestaurantTableQuerys : DatabaseInfo
    {
        /// <summary>
        /// add a table
        /// </summary>
        /// <param name="RestaurantId">id</param>
        /// <param name="Available">available or not</param>
        /// <param name="TableNumber">table number</param>
        /// <param name="NumberOfChairs">number of chairs</param>
        public void AddTable(string RestaurantId, int Available,int TableNumber, int NumberOfChairs)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "INSERT INTO RestaurantTable (RestaurantId,Available,TableNumber,NumberOfChairs)"
                + "VALUES(@0,@1,@2)";
            db.QuerySingle(insertCommand, RestaurantId, Available);
            db.Close();
        }

        /// <summary>
        /// get a table
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>table object</returns>
        public RestaurantTable GetTable(int Id)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM RestaurantTable WHERE Id = @0";
            var row = db.QuerySingle(insertCommand, Id);
            db.Close();
            var table = new RestaurantTable(row.Id, row.RestaurantId, row.Available, row.TableNumber, row.NumberOfChairs);
            return table;
        }

        /// <summary>
        /// get all tables of a restaurant
        /// </summary>
        /// <param name="RestaurantId">id</param>
        /// <returns>list of tables</returns>
        public List<RestaurantTable> GetAllTables(int RestaurantId)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM RestaurantTable WHERE RestaurantId = @0";
            var rows = db.Query(insertCommand, RestaurantId);
            db.Close();
            List<RestaurantTable> tables = new List<RestaurantTable>();
            foreach (var row in rows)
            {
                var table = new RestaurantTable(row.Id, row.RestaurantId, row.Available, row.TableNumber, row.NumberOfChairs);
                tables.Add(table);
            }
            return tables;
        }

        /// <summary>
        /// edit a table
        /// </summary>
        /// <param name="restaurantTable">object of restaurant table</param>
        /// <returns>restaurant table object</returns>
        public RestaurantTable EditTable(RestaurantTable restaurantTable)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "UPDATE RestaurantTable SET (Available = @1, TableNumber = @2, NumberOfChairs = @3) WHERE Id = @0";
            db.QuerySingle(dbCommand, restaurantTable.Id, restaurantTable.Available, restaurantTable.TableNumber, restaurantTable.NumberOfChairs);
            db.Close();
            return restaurantTable;
        }

        /// <summary>
        /// delete a table
        /// </summary>
        /// <param name="Id">id</param>
        public void DeleteTable(int Id)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "DELETE FROM RestaurantTable WHERE Id = @0 ";
            db.QuerySingle(dbCommand, Id);
            db.Close();
        }
    }
}
