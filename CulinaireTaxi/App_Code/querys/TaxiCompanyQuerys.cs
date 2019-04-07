using System.Collections.Generic;
using DataObjects;
using WebMatrix.Data;

namespace Querys
{
    /// <summary>
    /// taxi company querys
    /// </summary>
    public class TaxiCompanyQuerys : DatabaseInfo
    {
        /// <summary>
        /// add a taxi company
        /// </summary>
        /// <param name="OwnerId">owner id</param>
        /// <param name="CompanyName">company name</param>
        /// <param name="CompanyLocation">location</param>
        /// <param name="Description">description</param>
        public void AddTaxiCompany(int OwnerId, string CompanyName, string CompanyLocation, string Description)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand =
                "INSERT INTO TaxiCompany (OwnerId,CompanyName,CompanyLocation, Description, HasBeenValidated) "
                + "VALUES(@0,@1,@2,@3,@4)";
            db.QuerySingle(insertCommand, OwnerId, CompanyName, CompanyLocation, Description, 0);
            db.Close();
        }

        /// <summary>
        /// get a taxi company by id
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>object of company</returns>
        public TaxiCompany GetTaxiCompany(int Id)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM TaxiCompany WHERE Id = @0";
            var row = db.QuerySingle(insertCommand, Id);
            db.Close();
            if (row == null) return null;
            var company = new TaxiCompany(row.Id, row.OwnerId, row.CompanyName, row.CompanyLocation, row.Description,
                row.HasBeenValidated);
            return company;
        }

        /// <summary>
        /// get taxi company by owner id
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>null or company object</returns>
        public TaxiCompany GetTaxiCompanyByOwnerId(int Id)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM TaxiCompany WHERE OwnerId = @0";
            var row = db.QuerySingle(insertCommand, Id);
            db.Close();
            if (row == null) return null;
            else
            {
                var company = new TaxiCompany(row.Id, row.OwnerId, row.CompanyName, row.CompanyLocation,
                    row.Description, row.HasBeenValidated);
                return company;
            }
        }

        /// <summary>
        /// get all companies
        /// </summary>
        /// <returns>list of all companies</returns>
        public List<TaxiCompany> GetAllCompanies()
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM TaxiCompany WHERE HasBeenValidated = 3";
            var rows = db.Query(insertCommand);
            db.Close();
            List<TaxiCompany> companies = new List<TaxiCompany>();
            foreach (var row in rows)
            {
                if (row.CompanyName == null)
                {

                }
                else
                {
                    var company = new TaxiCompany(row.Id, row.OwnerId, row.CompanyName, row.CompanyLocation,
                        row.Description, row.HasBeenValidated);
                    companies.Add(company);
                }
            }

            return companies;
        }

        /// <summary>
        /// get all not valid companies
        /// </summary>
        /// <returns>list of all not valid companies</returns>
        public List<TaxiCompany> GetAllNotValidatedCompanies()
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM TaxiCompany WHERE NOT HasBeenValidated = 3";
            var rows = db.Query(insertCommand);
            db.Close();
            List<TaxiCompany> companies = new List<TaxiCompany>();
            foreach (var row in rows)
            {
                var company = new TaxiCompany(row.Id, row.OwnerId, row.CompanyName, row.CompanyLocation,
                    row.Description, row.HasBeenValidated);
                companies.Add(company);
            }

            return companies;
        }

        /// <summary>
        /// get all companies by location
        /// </summary>
        /// <param name="CompanyLocation">location</param>
        /// <returns>list of companies</returns>
        public List<TaxiCompany> GetAllCompaniesByLocation(string CompanyLocation)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM TaxiCompany WHERE CompanyLocation = @0)";
            var rows = db.Query(insertCommand, CompanyLocation);
            db.Close();
            List<TaxiCompany> companies = new List<TaxiCompany>();
            foreach (var row in rows)
            {
                var company = new TaxiCompany(row.Id, row.OwnerId, row.CompanyName, row.CompanyLocation,
                    row.Description, row.HasBeenValidated);
                companies.Add(company);
            }

            return companies;
        }

        /// <summary>
        /// update a taxi company validation
        /// </summary>
        /// <param name="Id">id</param>
        /// <param name="Validation">validation</param>
        public void UpdateTaxiCompanyValidation(int Id, int Validation)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "UPDATE TaxiCompany SET HasBeenValidated = @1 WHERE Id = @0";
            db.QuerySingle(dbCommand, Id, Validation);
            db.Close();
        }

        /// <summary>
        /// edit a taxi company
        /// </summary>
        /// <param name="taxiCompany">taxi company object</param>
        /// <returns>taxi company object</returns>
        public TaxiCompany EditTaxiCompany(TaxiCompany taxiCompany)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand =
                "UPDATE TaxiCompany SET CompanyName = @1,CompanyLocation = @2, Description = @3 WHERE Id = @0";
            db.QuerySingle(dbCommand, taxiCompany.Id, taxiCompany.CompanyName, taxiCompany.CompanyLocation,
                taxiCompany.Description);
            db.Close();
            return taxiCompany;
        }

        /// <summary>
        /// delete a taxi company
        /// </summary>
        /// <param name="Id">id</param>
        public void DeleteTaxiCompany(int Id)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "DELETE FROM TaxiCompany WHERE Id = @0 ";
            db.QuerySingle(dbCommand, Id);
            db.Close();
        }
    }
}
