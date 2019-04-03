using CulinaireTaxi.App_Data.DataObjects;
using System.Collections.Generic;
using WebMatrix.Data;


namespace CulinaireTaxi.App_Data.querys
{
    public class RestaurantTableQuerys : DatabaseInfo
    {
        public void AddTable(string RestaurantId, int Available,int TableNumber, int NumberOfChairs)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "INSERT INTO RestaurantTable (RestaurantId,Available,TableNumber,NumberOfChairs)"
                + "VALUES(@0,@1,@2)";
            db.QuerySingle(insertCommand, RestaurantId, Available);
            db.Close();
        }

        public RestaurantTable GetTable(int Id)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM RestaurantTable WHERE Id = @0";
            var row = db.QuerySingle(insertCommand, Id);
            db.Close();
            var table = new RestaurantTable(row.Id, row.RestaurantId, row.Available, row.TableNumber, row.NumberOfChairs);
            return table;
        }

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

        public RestaurantTable EditTable(RestaurantTable restaurantTable)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "UPDATE RestaurantTable SET (Available = @1, TableNumber = @2, NumberOfChairs = @3) WHERE Id = @0";
            var row = db.QuerySingle(dbCommand, restaurantTable.Id, restaurantTable.Available, restaurantTable.TableNumber, restaurantTable.NumberOfChairs);
            db.Close();
            return restaurantTable;
        }

        public void DeleteTable(int Id)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "DELETE FROM RestaurantTable WHERE Id = @0 ";
            var row = db.QuerySingle(dbCommand, Id);
            db.Close();
        }
    }
}
