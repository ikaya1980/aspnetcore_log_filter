using aspnetcore_log_filter.Data;
using aspnetcore_log_filter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcore_log_filter.Infrastructure
{
    public class LogActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            var appUser = new AppUser
            {
                UserName = context.HttpContext.User.Identity.Name,
                LoginDate = DateTime.Now,
                Path = context.HttpContext.Request.Path,
                Method = context.HttpContext.Request.Method,
                QueryString = context.HttpContext.Request.QueryString.ToString()
            };


            // check if the Request is a POST call 
            // since we need to read from the body
            if (context.HttpContext.Request.Method == "POST")
            {
                context.HttpContext.Request.EnableBuffering();
                string body = new StreamReader(context.HttpContext.Request.Body)
                                                    .ReadToEnd();
                context.HttpContext.Request.Body.Position = 0;
                appUser.Payload = body;
            }

            appUser.RequestedOn = DateTime.Now;

            LoggerDbContext logger = new LoggerDbContext();
            logger.AppUsers.Add(appUser);
            logger.SaveChanges();


        }


    }
}
