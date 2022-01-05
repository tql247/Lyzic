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
        public static (Notification, List<Comment>) Detail(int id)
        {
            object[] value =
            {
                id
            };

            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Notification_Detail ", value);
            DataTable commentsTable = connection.Select("Load_Comment_Notification ", value);
            Notification Notification = new Notification();
            List<Comment> commentList = new List<Comment>();

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

            if (connection.errorCode == 0 && commentsTable.Rows.Count > 0)
            {
                foreach (DataRow dr in commentsTable.Rows)
                {
                    Comment comment = new Comment();
                    object[] accountID =
                    {
                        dr["AccountID"].ToString()
                    };

                    DataTable getUserName = connection.Select("Account_Detail", accountID);
                    if (connection.errorCode == 0 && getUserName.Rows.Count > 0)
                    {
                        var user = getUserName.Rows[0];
                        comment.UserName = user["UserName"].ToString();
                    }
                    else
                    {
                        comment.UserName = "Incognito";
                    }

                    comment.Content = dr["Content"].ToString();

                    commentList.Add(comment);
                }
            }

            return (Notification, commentList);
        }


    }
}