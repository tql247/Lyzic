using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Lyzic.ExtendMethods
{
    public static class AppExtends {
        public static void AddStatusCodePages(this IApplicationBuilder app) {
            
            app.UseStatusCodePages(appError => {
                appError.Run(async context => {
                    var response = context.Response;
                    var code = response.StatusCode;
                    
                    
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