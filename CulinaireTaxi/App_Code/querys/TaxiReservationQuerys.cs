using CulinaireTaxi.App_Data.DataObjects;
using System.Collections.Generic;
using WebMatrix.Data;

    public class TaxiReservationQuerys : DatabaseInfo
    {
        public void AddReservation(int TaxiCompanyId, int UserInfoId, string Time)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "INSERT INTO TaxiReservation (TaxiCompanyId,UserInfoId,Time) "
                + "VALUES(@0,@1,@2)";
            db.QuerySingle(insertCommand, TaxiCompanyId, UserInfoId, Time);
            db.Close();
        }
        
        public TaxiReservation GetReservation(int Id)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM TaxiReservation WHERE Id = @0 )";
            var row = db.QuerySingle(insertCommand, Id);
            db.Close();
            var reservering = new TaxiReservation(row.Id,row.TaxiCompanyId, row.UserInfoId, row.Time);
            return reservering;
        }

        public List<TaxiReservation> GetAllReservationsFromUser(int UserInfoId)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM TaxiReservation WHERE UserInfoId = @0";
            var rows = db.Query(insertCommand, UserInfoId);
            db.Close();
            List<TaxiReservation> reserveringen = new List<TaxiReservation>();
            foreach (var row in rows)
            {
                var reservering = new TaxiReservation(row.Id,row.TaxiCompanyId, row.UserInfoId, row.Date);
                reserveringen.Add(reservering);
            }
            return reserveringen;
        }

        public List<TaxiReservation> GetAllReservationsFromTaxiCompany(int TaxiCompanyId)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM TaxiReservation WHERE TaxiCompanyId = @0";
            var rows = db.Query(insertCommand, TaxiCompanyId);
            db.Close();
            List<TaxiReservation> reserveringen = new List<TaxiReservation>();
            foreach (var row in rows)
            {
                var reservering = new TaxiReservation(row.Id, row.TaxiCompanyId, row.UserInfoId, row.Date);
                reserveringen.Add(reservering);
            }
            return reserveringen;
        }

        public TaxiReservation EditReservation(TaxiReservation taxiReservation)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "UPDATE TaxiReservation SET (Time = @1) WHERE Id = @0";
            var row = db.QuerySingle(dbCommand, taxiReservation.Id, taxiReservation.Time);
            db.Close();
            return taxiReservation;
        }

        public void DeleteReservation(int Id)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "DELETE FROM TaxiReservation WHERE Id = @0";
            var row = db.QuerySingle(dbCommand, Id);
            db.Close();
        }
    }
