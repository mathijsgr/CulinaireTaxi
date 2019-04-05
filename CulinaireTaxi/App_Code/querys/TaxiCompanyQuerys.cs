using CulinaireTaxi.App_Data.DataObjects;
using System.Collections.Generic;
using WebMatrix.Data;

    public class TaxiCompanyQuerys : DatabaseInfo
    {
        public void AddTaxiCompany(int OwnerId, string CompanyName, string CompanyLocation, string Description)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "INSERT INTO TaxiCompany (OwnerId,CompanyName,CompanyLocation, Description, HasBeenValidated) "
                + "VALUES(@0,@1,@2,@3,@4)";
            db.QuerySingle(insertCommand, OwnerId, CompanyName, CompanyLocation, Description, 0);
            db.Close();
        }

        public TaxiCompany GetTaxiCompany(int Id)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM TaxiCompany WHERE Id = @0";
            var row = db.QuerySingle(insertCommand, Id);
            db.Close();
            if (row == null) return null;
            var company = new TaxiCompany(row.Id,row.OwnerId, row.CompanyName, row.CompanyLocation, row.Description, row.HasBeenValidated);
            return company;
        }

        public TaxiCompany GetTaxiCompanyByOwnerId(int Id)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM TaxiCompany WHERE OwnerId = @0";
            var row = db.QuerySingle(insertCommand, Id);
            db.Close();
            if (row == null) return null;
            else
            {
                var company = new TaxiCompany(row.Id, row.OwnerId, row.CompanyName, row.CompanyLocation, row.Description, row.HasBeenValidated);
                return company;
            }
        }

        public List<TaxiCompany> GetAllCompanies()
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM TaxiCompany";
            var rows = db.Query(insertCommand);
            db.Close();
            List<TaxiCompany> companies = new List<TaxiCompany>();
            foreach (var row in rows)
            {
                var company = new TaxiCompany(row.Id,row.OwnerId, row.CompanyName, row.CompanyLocation, row.Description, row.HasBeenValidated);
                companies.Add(company);
            }
            return companies;
        }

        public List<TaxiCompany> GetAllNotValidatedCompanies()
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM TaxiCompany WHERE NOT HasBeenValidated = 3";
            var rows = db.Query(insertCommand);
            db.Close();
            List<TaxiCompany> companies = new List<TaxiCompany>();
            foreach (var row in rows)
            {
                var company = new TaxiCompany(row.Id, row.OwnerId, row.CompanyName, row.CompanyLocation, row.Description, row.HasBeenValidated);
                companies.Add(company);
            }
            return companies;
        }

        public List<TaxiCompany> GetAllCompaniesByLocation(string CompanyLocation)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM TaxiCompany WHERE CompanyLocation = @0)";
            var rows = db.Query(insertCommand, CompanyLocation);
            db.Close();
            List<TaxiCompany> companies = new List<TaxiCompany>();
            foreach (var row in rows)
            {
                var company = new TaxiCompany(row.Id,row.OwnerId, row.CompanyName, row.CompanyLocation, row.Description, row.HasBeenValidated);
                companies.Add(company);
            }
            return companies;
        }

        public void UpdateTaxiCompanyValidation(int Id, int Validation)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "UPDATE TaxiCompany SET HasBeenValidated = @1 WHERE Id = @0";
            db.QuerySingle(dbCommand, Id, Validation);
            db.Close();
        }

        public TaxiCompany EditTaxiCompany(TaxiCompany taxiCompany)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "UPDATE TaxiCompany SET CompanyName = @1,CompanyLocation = @2, Description = @3 WHERE Id = @0";
            db.QuerySingle(dbCommand, taxiCompany.Id, taxiCompany.CompanyName, taxiCompany.CompanyLocation, taxiCompany.Description);
            db.Close();
            return taxiCompany;
        }

        public void DeleteReservation(int Id)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "DELETE FROM TaxiCompany WHERE Id = @0 ";
            db.QuerySingle(dbCommand, Id);
            db.Close();
        }
    }
