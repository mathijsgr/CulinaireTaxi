using DataObjects;
using WebMatrix.Data;


namespace Querys
{
    /// <summary>
    /// querys of userInfo
    /// </summary>
    public class UserInfoQuerys : DatabaseInfo
    {
        /// <summary>
        /// Adds a user info to the database 
        /// </summary>
        /// <param name="UserId">user id</param>
        /// <param name="FirstName">first name</param>
        /// <param name="Prefix">prefix</param>
        /// <param name="LastName">last name</param>
        /// <param name="PostalCode">postalcode</param>
        /// <param name="HouseNumber">house number</param>
        /// <param name="HouseNumberPrefix">house number prefix</param>
        /// <param name="City">city</param>
        /// <param name="Role">role</param>
        public void AddUserInfo(string UserId, string FirstName, string Prefix, string LastName, string PostalCode,
            int HouseNumber, string HouseNumberPrefix, string City, int Role)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand =
                "INSERT INTO UserInfo (UserId, FirstName, Prefix, LastName, PostalCode, HouseNumber, HouseNumberPrefix, City, Role) "
                + "VALUES(@0,@1,@2,@3,@4,@5,@6,@7,@8)";
            db.QuerySingle(insertCommand, UserId, FirstName, Prefix, LastName, PostalCode, HouseNumber,
                HouseNumberPrefix, City, Role);
            db.Close();
        }

        /// <summary>
        /// Get user info based on the id given
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>a user info object</returns>
        public UserInfo GetUserInfo(string Id)
        {
            Database db = Database.Open(DatabaseName);
            string insertCommand = "SELECT * FROM UserInfo WHERE UserId = @0";
            var row = db.QuerySingle(insertCommand, Id);
            db.Close();

            UserInfo newUserInfo = new UserInfo(row.Id, row.UserId, row.FirstName, row.Prefix, row.LastName,
                row.PostalCode, row.HouseNumber, row.HouseNumberPrefix, row.City, row.Role);
            return newUserInfo;
        }

        /// <summary>
        /// edit a user info
        /// </summary>
        /// <param name="userInfo">object of user info</param>
        /// <returns>user info</returns>
        public UserInfo EditUserInfo(UserInfo userInfo)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand =
                "UPDATE UserInfo SET FirstName = @1,Prefix = @2, LastName = @3, PostalCode = @4, HouseNumber = @5, HouseNumberPrefix = @6, City = @7 WHERE UserId = @0";
            db.QuerySingle(dbCommand, userInfo.UserId, userInfo.FirstName, userInfo.Prefix, userInfo.LastName,
                userInfo.PostalCode, userInfo.HouseNumber, userInfo.HouseNumberPrefix, userInfo.City, userInfo.Role);
            db.Close();
            return userInfo;
        }

        /// <summary>
        /// gets the role of a user
        /// </summary>
        /// <param name="UserId">user id</param>
        /// <returns>ruser role</returns>
        public int GetUserRole(int UserId)
        {
            Database db = Database.Open(DatabaseName);
            string dbCommand = "SELECT * FROM UserInfo WHERE UserId = @0";
            var row = db.QuerySingle(dbCommand, UserId);
            db.Close();
            return row.Role;
        }

        /// <summary>
        /// delete the user info
        /// </summary>
        /// <param name="Id">user id</param>
        public void DeleteUserInfo(string Id)
        {
            Database db = Database.Open(DatabaseName);
            var dbCommand = "DELETE FROM UserInfo WHERE Id = @0";
            db.QuerySingle(dbCommand, Id);
            db.Close();
        }
    }
}
