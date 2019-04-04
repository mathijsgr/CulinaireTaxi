using CulinaireTaxi.App_Data.DataObjects;
using WebMatrix.Data;

    public class UserInfoQuerys : DatabaseInfo
    {
        public void AddUserInfo(string UserId, string FirstName, string Prefix, string LastName, string PostalCode, int HouseNumber, string HouseNumberPrefix, string City, int Role)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "INSERT INTO UserInfo (UserId, FirstName, Prefix, LastName, PostalCode, HouseNumber, HouseNumberPrefix, City, Role) "
                + "VALUES(@0,@1,@2,@3,@4,@5,@6,@7,@8)";
            db.QuerySingle(insertCommand, UserId, FirstName, Prefix, LastName, PostalCode, HouseNumber, HouseNumberPrefix, City, Role);
            db.Close();
        }

        public UserInfo GetUserInfo (string Id)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM UserInfo WHERE UserId = @0";
            var row = db.QuerySingle(insertCommand, Id);
            db.Close();

            UserInfo newUserInfo = new UserInfo(row.Id, row.UserId, row.FirstName, row.Prefix, row.LastName, row.PostalCode, row.HouseNumber, row.HouseNumberPrefix, row.City, row.Role);
            return newUserInfo;
        }

        public UserInfo EditUserInfo(UserInfo userInfo)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "UPDATE UserInfo SET FirstName = @1,Prefix = @2, LastName = @3, PostalCode = @4, HouseNumber = @5, HouseNumberPrefix = @6, City = @7 WHERE UserId = @0";
            var row = db.QuerySingle(dbCommand, userInfo.UserId, userInfo.FirstName, userInfo.Prefix, userInfo.LastName, userInfo.PostalCode, userInfo.HouseNumber, userInfo.HouseNumberPrefix, userInfo.City, userInfo.Role);
            db.Close();
            return userInfo;
        }

        public static int GetUserRole(int UserId)
        {
            Database db = Database.Open(DatabaseName);
            string dbCommand = "SELECT * FROM UserInfo WHERE UserId = @0";
            var row = db.QuerySingle(dbCommand, UserId);
            db.Close();
            return row.Role;
        }

        public void DeleteUserInfo(string Id)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "DELETE FROM UserInfo WHERE Id = @0";
            var row = db.QuerySingle(dbCommand, Id);
            db.Close();
        }
    }
