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
        // public static List<Account> GetAll()
        // {
        //     object[] value = { };
        //     SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
        //     DataTable result = connection.Select("Account_GetAll", value);
            
        //     List<Account> lstResult = new List<Account>();
        //     if (connection.errorCode == 0 && result.Rows.Count > 0)
        //     {
        //         foreach (DataRow dr in result.Rows)
        //         {
        //             Account Account = new Account();

        //             Account.ID = string.IsNullOrEmpty(dr["ID"].ToString()) ? 0 : int.Parse(dr["ID"].ToString());
        //             Account.FullName = dr["FullName"].ToString();
        //             Account.UserName = dr["UserName"].ToString();
        //             Account.PassWord = dr["PassWord"].ToString();
        //             Account.RoleName = dr["RoleName"].ToString();
        //             Account.CreatedDate = string.IsNullOrEmpty(dr["CreatedDate"].ToString()) ? default : DateTime.Parse(dr["CreatedDate"].ToString());

        //             lstResult.Add(Account);
        //         }
        //     }

        //     return lstResult;
        // }
         
        // public static bool Insert(Account Account)
        // {
        //     object[] value =
        //     {
        //         Account.FullName, 
        //         Account.UserName, 
        //         Account.PassWord, 
        //         Account.RoleName,  
        //         DateTime.Now
        //     };

        //     SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
        //     DataTable result = connection.Select("Account_Insert ", value);
        //     if (connection.errorCode == 0 && connection.errorMessage == "")
        //         return true;
        //     return false;
        // }

        // public static Account Detail(int id)
        // {
        //     object[] value =
        //     {
        //         id
        //     };

        //     SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
        //     DataTable result = connection.Select("Account_Detail ", value);
        //     Account Account = new Account();

        //     if (connection.errorCode == 0 && result.Rows.Count > 0)
        //     {
        //         var dr = result.Rows[0];
        //         Account.ID = string.IsNullOrEmpty(dr["ID"].ToString()) ? 0 : int.Parse(dr["ID"].ToString());
        //         Account.FullName = dr["FullName"].ToString();
        //         Account.UserName = dr["UserName"].ToString();
        //         Account.PassWord = dr["PassWord"].ToString();
        //         Account.RoleName = dr["RoleName"].ToString();
        //         Account.CreatedDate = string.IsNullOrEmpty(dr["CreatedDate"].ToString()) ? default : DateTime.Parse(dr["CreatedDate"].ToString());

        //     }
        //     return Account;
        // }
    }
}
