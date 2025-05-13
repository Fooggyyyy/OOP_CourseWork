using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CourseWork.Model
{
    public class LastView
    {
        public int Id { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
        public DateTime TimeView { get; set; }

        public LastView(int id, User? user, int userId, Item item, int itemId, DateTime timeView)
        {
            Id = id;
            User = user;
            UserId = userId;
            Item = item;
            ItemId = itemId;
            TimeView = timeView;
        }

        public LastView(int id, int userId, int itemId, DateTime timeView)
        {
            Id = id;
            UserId = userId;
            ItemId = itemId;
            TimeView = timeView;
        }

        public LastView()
        {
        }
    }
}
