using System.Collections.Generic;
using DataObjects;
using WebMatrix.Data;

namespace Querys
{

    /// <summary>
    /// query class for taxi - restaurant contracts
    /// </summary>
    public class TaxiRestaurantContractQuerys : DatabaseInfo
    {
        /// <summary>
        /// add a restaurant - taxi contract
        /// </summary>
        /// <param name="RestaurantId">restaurant id</param>
        /// <param name="TaxiCompanyId">taxi company id</param>
        /// <param name="ContractDescription"></param>
        public void AddContract(int RestaurantId, int TaxiCompanyId, string ContractDescription)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand =
                "INSERT INTO TaxiRestaurantContract (RestaurantId, TaxiCompanyId, ContractDescription) "
                + "VALUES(@0,@1,@2)";
            db.QuerySingle(insertCommand, RestaurantId, TaxiCompanyId, ContractDescription);
            db.Close();
        }

        /// <summary>
        /// gets a contract by id
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>contract</returns>
        public TaxiRestaurantContract GetContract(int Id)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM TaxiRestaurantContract WHERE Id = @0";
            var row = db.QuerySingle(insertCommand, Id);
            db.Close();
            if (row == null) return null;
            TaxiRestaurantContract contract = new TaxiRestaurantContract(row.Id, row.RestaurantId,row.TaxiCompanyId,row.ContractDescription);
            return contract;
        }

        /// <summary>
        /// gets all contracts from a restaurant
        /// </summary>
        /// <param name="RestaurantId">id</param>
        /// <returns>list of contracts</returns>
        public List<TaxiRestaurantContract> GetContractsFromRestaurant(int RestaurantId)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM TaxiRestaurantContract WHERE RestaurantId = @0";
            var rows = db.Query(insertCommand, RestaurantId);
            db.Close();

            List<TaxiRestaurantContract> contracten = new List<TaxiRestaurantContract>();
            foreach (var row in rows)
            {
                TaxiRestaurantContract contract = new TaxiRestaurantContract(row.Id, row.RestaurantId,
                    row.TaxiCompanyId, row.ContractDescription);
                contracten.Add(contract);
            }

            return contracten;
        }

        /// <summary>
        /// gets all contracts from a taxi company
        /// </summary>
        /// <param name="TaxiCompanyId">id</param>
        /// <returns>list of contracts</returns>
        public List<TaxiRestaurantContract> GetContractsFromTaxiCompany(int TaxiCompanyId)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM TaxiRestaurantContract WHERE TaxiCompanyId = @0";
            var rows = db.Query(insertCommand, TaxiCompanyId);
            db.Close();

            List<TaxiRestaurantContract> contracten = new List<TaxiRestaurantContract>();
            foreach (var row in rows)
            {
                TaxiRestaurantContract contract = new TaxiRestaurantContract(row.Id, row.RestaurantId,
                    row.TaxiCompanyId, row.ContractDescription);
                contracten.Add(contract);
            }

            return contracten;
        }

        /// <summary>
        /// edit a contract
        /// </summary>
        /// <param name="taxiRestaurantContract">object of taxiRestaurantContract</param>
        /// <returns>object of taxiRestaurantContract</returns>
        public TaxiRestaurantContract EditContract(TaxiRestaurantContract taxiRestaurantContract)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "UPDATE TaxiRestaurantContract SET (ContractDescription = @1) WHERE Id = @0";
            db.QuerySingle(dbCommand, taxiRestaurantContract.Id, taxiRestaurantContract.ContractDescription);
            db.Close();
            return taxiRestaurantContract;
        }

        /// <summary>
        /// delete a contract
        /// </summary>
        /// <param name="Id">id</param>
        public void DeleteContract(int Id)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "DELETE FROM TaxiRestaurantContract WHERE Id = @0";
            db.QuerySingle(dbCommand, Id);
            db.Close();
        }
    }
}