using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CourseWork.Model
{
    public class History
    {
        public int Id { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }

        public History(int id, User? user, int userId, Item item, int itemId)
        {
            Id = id;
            User = user;
            UserId = userId;
            Item = item;
            ItemId = itemId;
        }

        public History(int id, int userId, int itemId)
        {
            Id = id;
            UserId = userId;
            ItemId = itemId;
        }

        public History()
        {
        }
    }
}
