using CAIT.SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Lyzic.Const;
using Lyzic.Models;

namespace T3_51703124.Repository
{
    public class LaptopRes
    {
        // public static List<Laptop> GetAll()
        // {
        //     object[] value = { };
        //     SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
        //     DataTable result = connection.Select("Laptop_GetAll", value);
            
        //     List<Laptop> lstResult = new List<Laptop>();
        //     if (connection.errorCode == 0 && result.Rows.Count > 0)
        //     {
        //         foreach (DataRow dr in result.Rows)
        //         {
        //             Laptop lap = new Laptop();
        //             lap.ID = dr["ID"].ToString();
        //             lap.Name = dr["Name"].ToString();
        //             lap.Price = string.IsNullOrEmpty(dr["Price"].ToString()) ? 0 : int.Parse(dr["Price"].ToString());
        //             lap.RAM = string.IsNullOrEmpty(dr["RAM"].ToString()) ? 0 : int.Parse(dr["RAM"].ToString());
        //             lap.Storage = string.IsNullOrEmpty(dr["Storage"].ToString()) ? 0 : int.Parse(dr["Storage"].ToString());
        //             lap.CPU = dr["CPU"].ToString();

        //             lstResult.Add(lap);
        //         }
        //     }

        //     return lstResult;
        // }
        // /*
         
        //  */
        // public static bool Insert(Laptop lap)
        // {
        //     object[] value =
        //     {
        //         lap.ID, lap.Name, lap.Price, lap.RAM, lap.CPU, lap.Storage
        //     };

        //     SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
        //     DataTable result = connection.Select("Laptop_Insert ", value);
        //     if (connection.errorCode == 0 && connection.errorMessage == "")
        //         return true;
        //     return false;
        // }

        // public static Laptop Detail(string id)
        // {
        //     object[] value =
        //     {
        //         id
        //     };

        //     SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
        //     DataTable result = connection.Select("Laptop_Detail ", value);
        //     Laptop lap = new Laptop();

        //     if (connection.errorCode == 0 && result.Rows.Count > 0)
        //     {
        //         var dr = result.Rows[0];
        //         lap.ID = dr["ID"].ToString();
        //         lap.Name = dr["Name"].ToString();
        //         lap.Price = string.IsNullOrEmpty(dr["Price"].ToString()) ? 0 : int.Parse(dr["Price"].ToString());
        //         lap.RAM = string.IsNullOrEmpty(dr["RAM"].ToString()) ? 0 : int.Parse(dr["RAM"].ToString());
        //         lap.Storage = string.IsNullOrEmpty(dr["Storage"].ToString()) ? 0 : int.Parse(dr["Storage"].ToString());
        //         lap.CPU = dr["CPU"].ToString();
        //     }

        //     return lap;
        // }

        // public static bool Update(Laptop lap)
        // {
        //     object[] value =
        //     {
        //         lap.ID, lap.Name, lap.Price, lap.RAM, lap.CPU, lap.Storage
        //     };

        //     SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
        //     DataTable result = connection.Select("Laptop_Update ", value);
        //     if (connection.errorCode == 0 && connection.errorMessage == "")
        //         return true;
        //     return false;
        // }

        // public static bool Delete(Laptop lap)
        // {
        //     object[] value =
        //     {
        //         lap.ID
        //     };

        //     SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
        //     DataTable result = connection.Select("Laptop_Delete ", value);
        //     if (connection.errorCode == 0 && connection.errorMessage == "")
        //         return true;
        //     return false;
        // }
    }
}
