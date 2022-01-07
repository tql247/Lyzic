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
    public class MusicManagerRes
    {
        public static List<MusicManager> GetAll()
        {
            object[] value = { };
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Music_GetAll", value);
            
            List<MusicManager> lstResult = new List<MusicManager>();
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                foreach (DataRow dr in result.Rows)
                {
                    MusicManager MusicManager = new MusicManager();

                    MusicManager.ID = string.IsNullOrEmpty(dr["ID"].ToString()) ? 0 : int.Parse(dr["ID"].ToString());
                    MusicManager.Name = dr["Name"].ToString();
                    MusicManager.Author = dr["Author"].ToString();
                    MusicManager.Singers = dr["Singers"].ToString();
                    MusicManager.CreatedDate = string.IsNullOrEmpty(dr["CreatedDate"].ToString()) ? default : DateTime.Parse(dr["CreatedDate"].ToString());

                    lstResult.Add(MusicManager);
                }
            }

            return lstResult;
        }
         
        public static bool Insert(MusicManager MusicManager)
        {
            object[] value =
            {
                MusicManager.Name, MusicManager.Author, MusicManager.Singers,MusicManager.Genres, MusicManager.Lyric, MusicManager.MediaImageCoverURI, MusicManager.MediaContentURI, DateTime.Now
            };

            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Music_Insert ", value);
            if (connection.errorCode == 0 && connection.errorMessage == "")
                return true;
            return false;
        }

        public static MusicManager Detail(int id)
        {
            object[] value =
            {
                id
            };

            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Music_Detail ", value);
            MusicManager MusicManager = new MusicManager();

            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                var dr = result.Rows[0];
                MusicManager.ID = string.IsNullOrEmpty(dr["ID"].ToString()) ? 0 : int.Parse(dr["ID"].ToString());
                MusicManager.Name = dr["Name"].ToString();
                MusicManager.Author = dr["Author"].ToString();
                MusicManager.Singers = dr["Singers"].ToString();
                MusicManager.Genres = dr["Genres"].ToString();
                MusicManager.Lyric = dr["Lyric"].ToString();
                MusicManager.MediaImageCoverURI = dr["MediaImageCoverURI"].ToString();
                MusicManager.MediaContentURI = dr["MediaContentURI"].ToString();
                MusicManager.CreatedDate = string.IsNullOrEmpty(dr["CreatedDate"].ToString()) ? default : DateTime.Parse(dr["CreatedDate"].ToString());
            }

            return MusicManager;
        }

        public static bool Edit(MusicManager MusicManager)
        {
            object[] value =
            {
                MusicManager.ID, MusicManager.Name, MusicManager.Author, MusicManager.Singers,MusicManager.Genres, MusicManager.Lyric, MusicManager.MediaImageCoverURI, MusicManager.MediaContentURI, DateTime.Now
            };

            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Music_Update ", value);
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
            DataTable result = connection.Select("Music_Delete ", value);
            if (connection.errorCode == 0 && connection.errorMessage == "") {
                return true;
            }
            Console.WriteLine(connection.errorMessage);
            return false;
        }
    }
}
