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
    public class ArtistRes
    {
        public static List<Artist> GetAll()
        {
            object[] value = { };
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Singer_GetAll", value);
            
            List<Artist> lstResult = new List<Artist>();
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                foreach (DataRow dr in result.Rows)
                {
                    Artist artist = new Artist();

                    artist.ID = string.IsNullOrEmpty(dr["ID"].ToString()) ? 0 : int.Parse(dr["ID"].ToString());
                    artist.Name = dr["Name"].ToString();
                    artist.Biography = dr["Biography"].ToString();
                    artist.AvatarImageURI = dr["AvatarImageURI"].ToString();
                    artist.CreatedDate = string.IsNullOrEmpty(dr["CreatedDate"].ToString()) ? default : DateTime.Parse(dr["CreatedDate"].ToString());

                    lstResult.Add(artist);
                }
            }
            return lstResult;
        }
         
       
        public static Artist Detail(int id)
        {
            object[] value =
            {
                id
            };

            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Singer_Detail ", value);
            Artist artist = new Artist();

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

    }
}
