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
    public class CommentNotificationManagerRes
    {
        public static List<CommentNotificationManager> GetAll()
        {
            object[] value = { };
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("CommentNotification_GetAll", value);
            
            List<CommentNotificationManager> lstResult = new List<CommentNotificationManager>();
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                foreach (DataRow dr in result.Rows)
                {
                    CommentNotificationManager CommentNotificationManager = new CommentNotificationManager();

                    CommentNotificationManager.ID = string.IsNullOrEmpty(dr["ID"].ToString()) ? 0 : int.Parse(dr["ID"].ToString());
                    CommentNotificationManager.AccountID = string.IsNullOrEmpty(dr["AccountID"].ToString()) ? 0 : int.Parse(dr["AccountID"].ToString());
                    CommentNotificationManager.NotificationID = string.IsNullOrEmpty(dr["NotificationID"].ToString()) ? 0 : int.Parse(dr["NotificationID"].ToString());
                    CommentNotificationManager.NotificationTitle = dr["Title"].ToString();
                    CommentNotificationManager.UserName = dr["UserName"].ToString();
                    CommentNotificationManager.Content = dr["Content"].ToString();
                    CommentNotificationManager.CreatedDate = string.IsNullOrEmpty(dr["CreatedDate"].ToString()) ? default : DateTime.Parse(dr["CreatedDate"].ToString());

                    lstResult.Add(CommentNotificationManager);
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