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
    public class ArtistManagerRes
    {
        public static List<ArtistManager> GetAll()
        {
            object[] value = { };
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Singer_GetAll", value);
            
            List<ArtistManager> lstResult = new List<ArtistManager>();
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                foreach (DataRow dr in result.Rows)
                {
                    ArtistManager artist = new ArtistManager();

                    artist.ID = string.IsNullOrEmpty(dr["ID"].ToString()) ? 0 : int.Parse(dr["ID"].ToString());
                    artist.Name = dr["Name"].ToString();
                    artist.Biography = dr["Biography"].ToString();
                    artist.CreatedDate = string.IsNullOrEmpty(dr["CreatedDate"].ToString()) ? default : DateTime.Parse(dr["CreatedDate"].ToString());

                    lstResult.Add(artist);
                }
            }

            return lstResult;
        }
         
        public static bool Insert(ArtistManager artist)
        {
            object[] value =
            {
                artist.Name, artist.Biography, artist.AvatarImageURI, DateTime.Now
            };

            Console.WriteLine("value");
            Console.WriteLine(value);

            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Singer_Insert ", value); 
            if (connection.errorCode == 0 && connection.errorMessage == "")
                return true;
            return false;
        }

        public static ArtistManager Detail(int id)
        {
            object[] value =
            {
                id
            };

            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Singer_Detail ", value);
            ArtistManager artist = new ArtistManager();

            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                var dr = result.Rows[0];
                artist.ID = string.IsNullOrEmpty(dr["ID"].ToString()) ? 0 : int.Parse(dr["ID"].ToString());
                artist.Name = dr["Name"].ToString();
                artist.Biography = dr["Biography"].ToString();
                artist.AvatarImageURI = dr["AvatarImageURI"].ToString();
                artist.CreatedDate = string.IsNullOrEmpty(dr["CreatedDate"].ToString()) ? default : DateTime.Parse(dr["CreatedDate"].ToString());
            }

            return artist;
        }

        public static bool Edit(ArtistManager artist)
        {
            object[] value =
            {
                artist.ID, artist.Name, artist.Biography, artist.AvatarImageURI, DateTime.Now
            };

            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Singer_Update ", value);
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
            DataTable result = connection.Select("Singer_Delete ", value);
            if (connection.errorCode == 0 && connection.errorMessage == "")
                return true;
            return false;
        }
    }
}
