using System.Collections.Generic;
using DataObjects;
using WebMatrix.Data;

namespace Querys
{
    /// <summary>
    /// taxi querys class
    /// </summary>
    public class TaxiQuerys : DatabaseInfo
    {
        /// <summary>
        /// add a taxi
        /// </summary>
        /// <param name="TaxiCompanyId">company id</param>
        /// <param name="Available"> bool for available or not</param>
        public void AddTaxi(string TaxiCompanyId, int Available)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "INSERT INTO Taxi (TaxiCompanyId,Available) "
                + "VALUES(@0,@1)";
            db.QuerySingle(insertCommand, TaxiCompanyId, Available);
            db.Close();
        }

        /// <summary>
        /// get a taxi
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>object of taxi</returns>
        public Taxi GetTaxi(int Id)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM Taxi WHERE Id = @0";
            var row = db.QuerySingle(insertCommand, Id);
            db.Close();
            var taxi = new Taxi(row.Id, row.TaxiCompanyId, row.Available);
            return taxi;
        }

        /// <summary>
        /// get all taxi's from a company
        /// </summary>
        /// <param name="TaxiCompanyId">company id</param>
        /// <returns>list of taxi's</returns>
        public List<Taxi> GetAllTaxisFromACompany(int TaxiCompanyId)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM Taxi WHERE TaxiCompanyId = @0";
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

        /// <summary>
        /// edit a taxi
        /// </summary>
        /// <param name="taxi">taxi object</param>
        /// <returns>taxi object</returns>
        public Taxi EditTaxi(Taxi taxi)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "UPDATE Taxi SET Available = @1 WHERE Id = @0";
            db.QuerySingle(dbCommand, taxi.Id, taxi.Available);
            db.Close();
            return taxi;
        }

        /// <summary>
        /// delete a taxi
        /// </summary>
        /// <param name="Id">taxi id</param>
        public void DeleteTaxi(int Id)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "DELETE FROM Taxi WHERE Id = @0 ";
            db.QuerySingle(dbCommand, Id);
            db.Close();
        }
    }
}
