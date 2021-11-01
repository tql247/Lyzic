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
    public class MusicRes
    {
        public static List<Music> GetAll()
        {
            object[] value = { };
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Music_GetAll", value);
            
            List<Music> lstResult = new List<Music>();
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                foreach (DataRow dr in result.Rows)
                {
                    Music music = new Music();

                    music.ID = string.IsNullOrEmpty(dr["ID"].ToString()) ? 0 : int.Parse(dr["ID"].ToString());
                    music.Name = dr["Name"].ToString();
                    music.Author = dr["Author"].ToString();
                    music.Singers = dr["Singers"].ToString();
                    music.CreatedDate = string.IsNullOrEmpty(dr["CreatedDate"].ToString()) ? default : DateTime.Parse(dr["CreatedDate"].ToString());

                    lstResult.Add(music);
                }
            }

            return lstResult;
        }
        // /*
         
        //  */
        public static bool Insert(Music music)
        {
            Console.WriteLine(music);
            // object[] value =
            // {
            //     music.ID, music.Name, music.Price, music.RAM, music.CPU, music.Storage
            // };

            // SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            // DataTable result = connection.Select("Music_Insert ", value);
            // if (connection.errorCode == 0 && connection.errorMessage == "")
            //     return true;
            // return false;
            return false;
        }

        // public static Music Detail(string id)
        // {
        //     object[] value =
        //     {
        //         id
        //     };

        //     SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
        //     DataTable result = connection.Select("Music_Detail ", value);
        //     Music music = new Music();

        //     if (connection.errorCode == 0 && result.Rows.Count > 0)
        //     {
        //         var dr = result.Rows[0];
        //         music.ID = dr["ID"].ToString();
        //         music.Name = dr["Name"].ToString();
        //         music.Price = string.IsNullOrEmpty(dr["Price"].ToString()) ? 0 : int.Parse(dr["Price"].ToString());
        //         music.RAM = string.IsNullOrEmpty(dr["RAM"].ToString()) ? 0 : int.Parse(dr["RAM"].ToString());
        //         music.Storage = string.IsNullOrEmpty(dr["Storage"].ToString()) ? 0 : int.Parse(dr["Storage"].ToString());
        //         music.CPU = dr["CPU"].ToString();
        //     }

        //     return music;
        // }

        // public static bool Update(Music music)
        // {
        //     object[] value =
        //     {
        //         music.ID, music.Name, music.Price, music.RAM, music.CPU, music.Storage
        //     };

        //     SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
        //     DataTable result = connection.Select("Music_Update ", value);
        //     if (connection.errorCode == 0 && connection.errorMessage == "")
        //         return true;
        //     return false;
        // }

        // public static bool Delete(Music music)
        // {
        //     object[] value =
        //     {
        //         music.ID
        //     };

        //     SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
        //     DataTable result = connection.Select("Music_Delete ", value);
        //     if (connection.errorCode == 0 && connection.errorMessage == "")
        //         return true;
        //     return false;
        // }
    }
}
