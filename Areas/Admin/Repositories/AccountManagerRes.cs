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
    public class AccountManagerRes
    {
        public static List<AccountManager> GetAll()
        {
            object[] value = { };
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Account_GetAll", value);
            
            List<AccountManager> lstResult = new List<AccountManager>();
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                foreach (DataRow dr in result.Rows)
                {
                    AccountManager AccountManager = new AccountManager();

                    AccountManager.ID = string.IsNullOrEmpty(dr["ID"].ToString()) ? 0 : int.Parse(dr["ID"].ToString());
                    AccountManager.FullName = dr["FullName"].ToString();
                    AccountManager.UserName = dr["UserName"].ToString();
                    AccountManager.PassWord = dr["PassWord"].ToString();
                    AccountManager.RoleName = dr["RoleName"].ToString();
                    AccountManager.CreatedDate = string.IsNullOrEmpty(dr["CreatedDate"].ToString()) ? default : DateTime.Parse(dr["CreatedDate"].ToString());

                    lstResult.Add(AccountManager);
                }
            }

            return lstResult;
        }
         
        public static bool Insert(AccountManager AccountManager)
        {
            object[] value =
            {
                AccountManager.FullName, 
                AccountManager.UserName, 
                AccountManager.PassWord, 
                AccountManager.RoleName,  
                DateTime.Now
            };

            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Account_Insert ", value);
            if (connection.errorCode == 0 && connection.errorMessage == "")
                return true;
            return false;
        }

        public static AccountManager Detail(int id)
        {
            object[] value =
            {
                id
            };

            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Account_Detail ", value);
            AccountManager AccountManager = new AccountManager();

            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                var dr = result.Rows[0];
                AccountManager.ID = string.IsNullOrEmpty(dr["ID"].ToString()) ? 0 : int.Parse(dr["ID"].ToString());
                AccountManager.FullName = dr["FullName"].ToString();
                AccountManager.UserName = dr["UserName"].ToString();
                AccountManager.PassWord = dr["PassWord"].ToString();
                AccountManager.RoleName = dr["RoleName"].ToString();
                AccountManager.CreatedDate = string.IsNullOrEmpty(dr["CreatedDate"].ToString()) ? default : DateTime.Parse(dr["CreatedDate"].ToString());

            }
            return AccountManager;
        }

        public static bool Edit(AccountManager AccountManager)
        {
            Console.WriteLine(AccountManager.FullName);
            object[] value =
            {
                AccountManager.ID, AccountManager.FullName, AccountManager.UserName, AccountManager.PassWord, AccountManager.RoleName
            };

            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Account_Update ", value);
            if (connection.errorCode == 0 && connection.errorMessage == "")
                return true;
            return false;
        }

        public static bool Delete(int id)
        {
            object[] value =
            {
                id
            };

            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Account_Delete ", value);
            if (connection.errorCode == 0 && connection.errorMessage == "")
                return true;
            return false;
        }
    }
}
