using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace MoneyFlow.Common.DataAccess
{
    public class SqLiteHelper
    {
        private static readonly string DbFilePath= Environment.CurrentDirectory + "\\App_Data\\MoneyFlow.db"; 
        public static SQLiteConnection GetConnection() {
            var connection = new SQLiteConnection("Data Source=" + DbFilePath);
            connection.Open();
            return connection;
        }
    }
}