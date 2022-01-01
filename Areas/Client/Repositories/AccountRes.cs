using CAIT.SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Lyzic.Const;
using Lyzic.Models;

namespace Lyzic.Repositories
{
    public class AccountRes
    {
        public static bool Insert(Account Account)
        {
            object[] value =
            {
                Account.FullName, 
                Account.UserName, 
                Account.PassWord, 
                "user",  
                DateTime.Now
            };

            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Account_Insert ", value);
            if (connection.errorCode == 0 && connection.errorMessage == "")
                return true;
            return false;
        }

        public static Account Profile(int id)
        {
            object[] value =
            {
                id
            };

            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Account_Detail ", value);
            Account Account = new Account();

            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                var dr = result.Rows[0];
                Account.ID = string.IsNullOrEmpty(dr["ID"].ToString()) ? 0 : int.Parse(dr["ID"].ToString());
                Account.FullName = dr["FullName"].ToString();
                Account.UserName = dr["UserName"].ToString();
                Account.PassWord = dr["PassWord"].ToString();
                Account.RoleName = dr["RoleName"].ToString();
                Account.CreatedDate = string.IsNullOrEmpty(dr["CreatedDate"].ToString()) ? default : DateTime.Parse(dr["CreatedDate"].ToString());

            }
            return Account;
        }
    }
}
