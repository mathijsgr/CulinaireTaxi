using CulinaireTaxi.App_Data.DataObjects;
using System.Collections.Generic;
using WebMatrix.Data;

namespace CulinaireTaxi.App_Data.querys
{
    public class TaxiQuerys : DatabaseInfo
    {
        public void AddTaxi(string TaxiCompanyId, int Available)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "INSERT INTO Taxi (TaxiCompanyId,Available) "
                + "VALUES(@0,@1)";
            db.QuerySingle(insertCommand, TaxiCompanyId, Available);
            db.Close();
        }

        public Taxi GetTaxi(int Id)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM Taxi WHERE Id = @0)";
            var row = db.QuerySingle(insertCommand, Id);
            db.Close();
            var taxi = new Taxi(row.Id, row.TaxiCompanyId, row.Available);
            return taxi;
        }

        public List<Taxi> GetAllTaxisFromACompany(int TaxiCompanyId)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM Taxi WHERE TaxiCompanyId = @0)";
            var rows = db.Query(insertCommand, TaxiCompanyId);
            db.Close();
            List<Taxi> taxis = new List<Taxi>();
            foreach (var row in rows)
            {
                var taxi = new Taxi(row.Id, row.TaxiCompanyId, row.Available);
                taxis.Add(taxi);
            }
            return taxis;
        }

        public Taxi EditTaxi(Taxi taxi)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "UPDATE Taxi SET Available = @1 WHERE Id = @0";
            var row = db.QuerySingle(dbCommand, taxi.Id, taxi.Available);
            db.Close();
            return taxi;
        }

        public void DeleteTaxi(int Id)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "DELETE FROM Taxi WHERE Id = @0 ";
            var row = db.QuerySingle(dbCommand, Id);
            db.Close();
        }
    }
}
