using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

/// <summary>
/// Summary description for List
/// </summary>
public class ListProvider
{
    public static bool CheckIfListValid(string listId, string uniqueToken)
    {
        Database db = Database.Open("Database");
        var dbCommand = "SELECT * FROM PresentLists WHERE ListCode =@0 AND ListId =@1";
        var checkIfValid = db.QuerySingle(dbCommand, uniqueToken, listId);
        return checkIfValid != null ? true : false;
    }

    public static string GetListByToken(string uniqueToken)
    {
        Database db = Database.Open("Database");
        var dbCommand = "SELECT * FROM PresentLists WHERE ListCode =@0";
        var checkIfValid = db.QuerySingle(dbCommand, uniqueToken);
        if (checkIfValid != null) {
            return Convert.ToString(checkIfValid.ListId);
        }   else
        {
            return "error";
        }
    }

    public static List<GiftList> GetListByOwnerId(int Id)
    {
        List<GiftList> result = new List<GiftList>();
        Database db = Database.Open("Database");
        var dbCommand = "SELECT * FROM PresentLists WHERE OwnerId=@0";
        var rows = db.Query(dbCommand, Id);
        foreach (var row in rows)
        {
            result.Add(new GiftList()
            {
                ListId = row.ListId,
                OwnerId = row.OwnerId,
                ListCode = row.ListCode,
                ListName = row.ListName,
                LastEdited = row.LastEdited,
            });
        }
        db.Close();
        return result;
    }

    public static bool CheckIfOwner(string listId, string uniqueToken, int currentUserId)
    {
        Database db = Database.Open("Database");
        var dbCommand = "SELECT * FROM PresentLists WHERE ListCode =@0 AND ListId =@1 AND OwnerId =@2";
        var checkIfValid = db.QuerySingle(dbCommand, uniqueToken, listId, currentUserId);
        return checkIfValid != null ? true : false;
    }

    public static void deleteListById(string Id)
    {
        Database db = Database.Open("Database");
        var deleteCommand = "DELETE FROM PresentLists WHERE ListId = @0";
        db.Execute(deleteCommand, Id);

    }

    public static void addNewList(int userId, string name)
    {
        string createdAt = Convert.ToString(DateTime.Now);
        string uniqueToken = Guid.NewGuid().ToString("N");
        Database db = Database.Open("Database");
        var insertCommand = "INSERT INTO PresentLists (OwnerId, ListCode, ListName, LastEdited) VALUES(@0, @1, @2, @3)";
        db.Execute(insertCommand, userId, uniqueToken, name, createdAt);
    }
}