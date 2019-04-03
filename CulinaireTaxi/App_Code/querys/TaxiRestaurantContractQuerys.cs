using CulinaireTaxi.App_Data.DataObjects;
using System.Collections.Generic;
using WebMatrix.Data;

namespace CulinaireTaxi.App_Data.querys
{
    public class TaxiRestaurantContractQuerys : DatabaseInfo
    {
        public void AddContract(int RestaurantId, int TaxiCompanyId, string ContractDescription)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "INSERT INTO TaxiRestaurantContract (RestaurantId,TaxiCompanyId,ContractDescription) "
                + "VALUES(@0,@1,@2)";
            db.QuerySingle(insertCommand, RestaurantId, TaxiCompanyId, ContractDescription);
            db.Close();
        }

        public TaxiRestaurantContract GetContract(int Id)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM TaxiRestaurantContract WHERE Id = @0)";
            var row = db.QuerySingle(insertCommand, Id);
            db.Close();

            TaxiRestaurantContract contract = new TaxiRestaurantContract(row.Id, row.RestaurantId,row.TaxiCompanyId,row.ContractDescription);
            return contract;
        }

        public List <TaxiRestaurantContract> GetContractsFromRestaurant(int RestaurantId)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM TaxiRestaurantContract WHERE RestaurantId = @0)";
            var rows = db.Query(insertCommand, RestaurantId);
            db.Close();

            List<TaxiRestaurantContract> contracten = new List<TaxiRestaurantContract>();
            foreach (var row in rows)
            {
                TaxiRestaurantContract contract = new TaxiRestaurantContract(row.Id,row.RestaurantId, row.TaxiCompanyId, row.ContractDescription);
                contracten.Add(contract);
            }
            return contracten;
        }

        public List<TaxiRestaurantContract> GetContractsFromTaxiCompany(int TaxiCompanyId)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM TaxiRestaurantContract WHERE TaxiCompanyId = @0)";
            var rows = db.Query(insertCommand,TaxiCompanyId);
            db.Close();

            List<TaxiRestaurantContract> contracten = new List<TaxiRestaurantContract>();
            foreach (var row in rows)
            {
                TaxiRestaurantContract contract = new TaxiRestaurantContract(row.Id,row.RestaurantId, row.TaxiCompanyId, row.ContractDescription);
                contracten.Add(contract);
            }
            return contracten;
        }

        public TaxiRestaurantContract EditContract(TaxiRestaurantContract taxiRestaurantContract)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "UPDATE TaxiRestaurantContract SET (ContractDescription = @1) WHERE Id = @0";
            var row = db.QuerySingle(dbCommand, taxiRestaurantContract.Id, taxiRestaurantContract.ContractDescription);
            db.Close();
            return taxiRestaurantContract;
        }

        public void DeleteContract(int Id)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "DELETE FROM TaxiRestaurantContract WHERE Id = @0";
            var row = db.QuerySingle(dbCommand, Id);
            db.Close();
        }
    }
}
