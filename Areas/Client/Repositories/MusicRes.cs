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
                    music.MediaImageCoverURI = dr["MediaImageCoverURI"].ToString();
                    music.MediaContentURI = dr["MediaContentURI"].ToString();
                    music.CreatedDate = string.IsNullOrEmpty(dr["CreatedDate"].ToString()) ? default : DateTime.Parse(dr["CreatedDate"].ToString());

                    lstResult.Add(music);
                }
            }

            return lstResult;
        }
         
        public static Music Detail(int id)
        {
            object[] value =
            {
                id
            };

            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Music_Detail ", value);
            Music music = new Music();

            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                var dr = result.Rows[0];
                music.ID = string.IsNullOrEmpty(dr["ID"].ToString()) ? 0 : int.Parse(dr["ID"].ToString());
                music.Name = dr["Name"].ToString();
                music.Author = dr["Author"].ToString();
                music.Singers = dr["Singers"].ToString();
                music.Lyric = dr["Lyric"].ToString();
                music.MediaImageCoverURI = dr["MediaImageCoverURI"].ToString();
                music.MediaContentURI = dr["MediaContentURI"].ToString();
                music.CreatedDate = string.IsNullOrEmpty(dr["CreatedDate"].ToString()) ? default : DateTime.Parse(dr["CreatedDate"].ToString());
            }

            return music;
        }

    }
}
