using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;

namespace Lyzic.ExtendMethods
{
    public static class AppExtends {
        public static void AddStatusCodePages(this IApplicationBuilder app) {
            
            app.UseStatusCodePages(appError => {
                appError.Run(async context => {
                    var response = context.Response;
                    var request = context.Response;
                    var code = response.StatusCode;

                    if (code == 401) {
                        var area = context.GetRouteData().Values["area"].ToString();
                        if (area == "Admin") {
                            response.Redirect("/admin/AccountManager/login");
                        } else {
                            response.Redirect("/Account/login" + area);
                        }
                    }
                    
                    var content = @$"
                        <html><head></head>
                        <body>
                            {code} - {(HttpStatusCode) code}
                        </body>
                        </html>
                    ";

                    await response.WriteAsync(content);
                });
            });

        }
    }
}