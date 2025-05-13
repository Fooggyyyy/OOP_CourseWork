using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CourseWork.Model.CurrentUser
{
    internal class CurrentItem
    {
        public static int ItemId { get; set; }

        public static void SetUser(int userId)
        {
            ItemId = userId;
        }

        public static void Clear()
        {
            ItemId = 0;
        }

        public static bool IsLoggedIn => ItemId != 0;
    }
}
