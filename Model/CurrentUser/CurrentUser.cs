using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOP_CourseWork.Model.CurrentUser.CurrentUser;

namespace OOP_CourseWork.Model.CurrentUser
{
    public class CurrentUser
    {
        public static int UserId { get; set; }

        public static void SetUser(int userId)
        {
            UserId = userId;
        }

        public static void Clear()
        {
            UserId = 0;
        }

        public static bool IsLoggedIn => UserId != 0;
    }
}
