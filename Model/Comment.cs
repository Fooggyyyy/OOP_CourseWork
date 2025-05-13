using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace OOP_CourseWork.Model
{
    public class Comment 
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }  
        public Item Item { get; set; }
        public int ItemId { get; set; }
        public string Description { get; set; }

        public Comment(int id, User user, int userId, Item item, int itemId, string description)
        {
            Id = id;
            User = user;
            UserId = userId;
            Item = item;
            ItemId = itemId;
            Description = description;
        }

        public Comment(int id, int userId, int itemId, string description)
        {
            Id = id;
            UserId = userId;
            ItemId = itemId;
            Description = description;
        }

        public Comment()
        {
        }
    }
}
