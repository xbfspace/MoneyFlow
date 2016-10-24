using MoneyFlow.Common.DataAccess;
using MoneyFlow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;

namespace MoneyFlow.DAL
{
    public class EarnDal
    {
        public int Add(Earn model) {
            using (var conn=SqLiteHelper.GetConnection()) {
                var insertSql = "insert into earn(ID,Amount,Content,EarnDate) values (@id,@amount,@content,@earnDate)";
                return conn.Execute(insertSql, new { id="",amount="",content="",earnDate="" });
            }
        }
    }
}