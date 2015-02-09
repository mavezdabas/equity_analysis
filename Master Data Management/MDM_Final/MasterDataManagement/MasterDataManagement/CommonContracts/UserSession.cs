using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonContracts
{
    public static class UserSession
    {
        public static int UserId { get; set; }
        public static String LoginId { get; set; }
        public static UserRole Role { get; set; }
        public static String Name { get; set; }
    }
}
