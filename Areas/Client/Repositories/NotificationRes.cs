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
    public class NotificationRes
    {
        public static List<Notification> GetAll()
        {
            object[] value = { };
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Notification_GetAll", value);
            
            List<Notification> lstResult = new List<Notification>();
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                foreach (DataRow dr in result.Rows)
                {
                    Notification Notification = new Notification();

                    Notification.ID = string.IsNullOrEmpty(dr["ID"].ToString()) ? 0 : int.Parse(dr["ID"].ToString());
                    Notification.Title = dr["Title"].ToString();
                    Notification.Content = dr["Content"].ToString();
                    Notification.NotificationImage = dr["NotificationImage"].ToString();
                    Notification.CreatedBy = dr["CreatedBy"].ToString();
                    Notification.CreatedDate = string.IsNullOrEmpty(dr["CreatedDate"].ToString()) ? default : DateTime.Parse(dr["CreatedDate"].ToString());

                    lstResult.Add(Notification);
                }
            }

            return lstResult;
        }
        public static Notification Detail(int id)
        {
            object[] value =
            {
                id
            };

            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Notification_Detail ", value);
            Notification Notification = new Notification();

            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                var dr = result.Rows[0];
                Notification.ID = string.IsNullOrEmpty(dr["ID"].ToString()) ? 0 : int.Parse(dr["ID"].ToString());
                Notification.Title = dr["Title"].ToString();
                Notification.Content = dr["Content"].ToString();
                Notification.CreatedBy = dr["CreatedBy"].ToString();
                Notification.NotificationImage = dr["NotificationImage"].ToString();
                Notification.CreatedDate = string.IsNullOrEmpty(dr["CreatedDate"].ToString()) ? default : DateTime.Parse(dr["CreatedDate"].ToString());
            }

            return Notification;
        }

        
    }
}