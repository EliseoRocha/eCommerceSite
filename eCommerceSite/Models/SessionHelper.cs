using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceSite.Models
{
    /// <summary>
    /// Helper class to provide easy access 
    /// to the current HttpContext (Sessions and cookies)
    /// </summary>
    public static class SessionHelper
    {
        private const string MemberIdKey = "Id";

        /// <summary>
        /// Create session for the user and store their MemberId
        /// </summary>
        public static void LogUserIn(IHttpContextAccessor context, int memberId)
        {
            context.HttpContext.Session.SetInt32(MemberIdKey, memberId);
        }

        /// <summary>
        /// Returns true if the user has a session created
        /// </summary>
        public static bool IsUserLoggedIn(IHttpContextAccessor context)
        {
            if (context.HttpContext.Session.GetInt32(MemberIdKey).HasValue)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the number of items in the users shopping cart
        /// </summary>
        /// <returns></returns>
        public static int GetCartTotal(IHttpContextAccessor accessor)
        {
            //Read cookie data
            string data = accessor.HttpContext.Request.Cookies["Cart"];

            //If there are no cart cookie
            if (string.IsNullOrEmpty(data))
            {
                return 0;
            }

            //Turn string into List<Product>
            List<Product> prods = JsonConvert.DeserializeObject<List<Product>>(data);

            //Return the count
            return prods.Count();
        }
    }
}
