using aspnetcore_log_filter.Data;
using aspnetcore_log_filter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.CodeAnalysis.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace aspnetcore_log_filter.Infrastructure
{
    public class ClaimRequirementAttribute : TypeFilterAttribute
    {
        public ClaimRequirementAttribute(string claimType, string claimValue) : base(typeof(LogUserAuthorizeAttribute))
        {
            Arguments = new object[] { new Claim(claimType, claimValue) };
        }
    }

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class LogUserAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public LogUserAuthorizeAttribute()
        {

        }
        

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            AppUser appUser= new Models.AppUser()
            {
                UserName = context.HttpContext.User.Identity.Name,
                LoginDate = DateTime.Now,
               

            };
           
            LoggerDbContext logger = new LoggerDbContext();
            logger.AppUsers.Add(appUser);
            logger.SaveChanges();

       
        }
    }

}
