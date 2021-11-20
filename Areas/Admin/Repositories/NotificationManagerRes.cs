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
    public class NotificationManagerRes
    {
        public static List<NotificationManager> GetAll()
        {
            object[] value = { };
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Notification_GetAll", value);
            
            List<NotificationManager> lstResult = new List<NotificationManager>();
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                foreach (DataRow dr in result.Rows)
                {
                    NotificationManager NotificationManager = new NotificationManager();

                    NotificationManager.ID = string.IsNullOrEmpty(dr["ID"].ToString()) ? 0 : int.Parse(dr["ID"].ToString());
                    NotificationManager.Title = dr["Title"].ToString();
                    NotificationManager.Content = dr["Content"].ToString();
                    NotificationManager.CreatedBy = dr["CreatedBy"].ToString();
                    NotificationManager.CreatedDate = string.IsNullOrEmpty(dr["CreatedDate"].ToString()) ? default : DateTime.Parse(dr["CreatedDate"].ToString());

                    lstResult.Add(NotificationManager);
                }
            }

            return lstResult;
        }
         
        public static bool Insert(NotificationManager NotificationManager)
        {
            object[] value =
            {
                NotificationManager.Title, NotificationManager.Content, NotificationManager.CreatedBy, NotificationManager.NotificationImage,DateTime.Now
            };

            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Notification_Insert ", value);
            if (connection.errorCode == 0 && connection.errorMessage == "")
                return true;
            return false;
        }

        public static NotificationManager Detail(int id)
        {
            object[] value =
            {
                id
            };

            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Notification_Detail ", value);
            NotificationManager NotificationManager = new NotificationManager();

            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                var dr = result.Rows[0];
                NotificationManager.ID = string.IsNullOrEmpty(dr["ID"].ToString()) ? 0 : int.Parse(dr["ID"].ToString());
                NotificationManager.Title = dr["Title"].ToString();
                NotificationManager.Content = dr["Content"].ToString();
                NotificationManager.CreatedBy = dr["CreatedBy"].ToString();
                NotificationManager.NotificationImage = dr["NotificationImage"].ToString();
                NotificationManager.CreatedDate = string.IsNullOrEmpty(dr["CreatedDate"].ToString()) ? default : DateTime.Parse(dr["CreatedDate"].ToString());
            }

            return NotificationManager;
        }

        public static bool Edit(NotificationManager NotificationManager)
        {
            object[] value =
            {
                NotificationManager.ID,NotificationManager.Title, NotificationManager.Content, NotificationManager.CreatedBy, NotificationManager.NotificationImage,DateTime.Now

            };

            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Notification_Update ", value);
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
            DataTable result = connection.Select("Notification_Delete ", value);
            if (connection.errorCode == 0 && connection.errorMessage == "")
                return true;
            return false;
        }
    }
}