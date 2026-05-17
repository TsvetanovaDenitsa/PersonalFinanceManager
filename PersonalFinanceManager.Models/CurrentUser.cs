using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManager.Models
{
    public static class CurrentUser
    {
        public static int Id { get; set; }

        public static string Username { get; set; }
            = string.Empty;

        public static string Email { get; set; }
            = string.Empty;

        public static bool IsLoggedIn
        {
            get
            {
                return Id > 0;
            }
        }

        public static void Logout()
        {
            Id = 0;

            Username = string.Empty;

            Email = string.Empty;
        }
    }
}