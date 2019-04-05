using CulinaireTaxi.App_Data.DataObjects;
using System.Collections.Generic;
using WebMatrix.Data;

    public class TaxiCompanyQuerys : DatabaseInfo
    {
        public void AddTaxiCompany(int OwnerId, string CompanyName, string CompanyLocation)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "INSERT INTO TaxiCompany (OwnerId,CompanyName,CompanyLocation) "
                + "VALUES(@0,@1,@2)";
            db.QuerySingle(insertCommand, OwnerId, CompanyName, CompanyLocation);
            db.Close();
        }

        public TaxiCompany GetTaxiCompany(int Id)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM TaxiCompany WHERE Id = @0";
            var row = db.QuerySingle(insertCommand, Id);
            db.Close();
            if (row == null) return null;
            var company = new TaxiCompany(row.Id,row.OwnerId, row.CompanyName, row.CompanyLocation);
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
                var company = new TaxiCompany(row.Id, row.OwnerId, row.CompanyName, row.CompanyLocation);
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
                var company = new TaxiCompany(row.Id,row.OwnerId, row.CompanyName, row.CompanyLocation);
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
                var company = new TaxiCompany(row.Id,row.OwnerId, row.CompanyName, row.CompanyLocation);
                companies.Add(company);
            }
            return companies;
        }

        public TaxiCompany EditTaxiCompany(TaxiCompany taxiCompany)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "UPDATE TaxiCompany SET CompanyName = @1,CompanyLocation = @2 WHERE Id = @0";
            db.QuerySingle(dbCommand, taxiCompany.Id, taxiCompany.CompanyName, taxiCompany.CompanyLocation);
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
