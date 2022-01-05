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
    public class CommentMusicManagerRes
    {
        public static List<CommentMusicManager> GetAll()
        {
            object[] value = { };
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("CommentMusic_GetAll", value);
            
            List<CommentMusicManager> lstResult = new List<CommentMusicManager>();
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                foreach (DataRow dr in result.Rows)
                {
                    CommentMusicManager CommentMusicManager = new CommentMusicManager();

                    CommentMusicManager.ID = string.IsNullOrEmpty(dr["ID"].ToString()) ? 0 : int.Parse(dr["ID"].ToString());
                    CommentMusicManager.AccountID = string.IsNullOrEmpty(dr["AccountID"].ToString()) ? 0 : int.Parse(dr["AccountID"].ToString());
                    CommentMusicManager.MusicID = string.IsNullOrEmpty(dr["MusicID"].ToString()) ? 0 : int.Parse(dr["MusicID"].ToString());
                    CommentMusicManager.MusicName = dr["Name"].ToString();
                    CommentMusicManager.Singers = dr["Singers"].ToString();
                    CommentMusicManager.UserName = dr["UserName"].ToString();
                    CommentMusicManager.Content = dr["Content"].ToString();
                    CommentMusicManager.CreatedDate = string.IsNullOrEmpty(dr["CreatedDate"].ToString()) ? default : DateTime.Parse(dr["CreatedDate"].ToString());

                    lstResult.Add(CommentMusicManager);
                }
            }

            return lstResult;
        }

        public static bool Delete(int id)
        {
            object[] value =
            {
                id
            };

            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Notification_Delete ", value);
            if (connection.errorCode == 0 && connection.errorMessage == "")
                return true;
            return false;
        }
    }
}