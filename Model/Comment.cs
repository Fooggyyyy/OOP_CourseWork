using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

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
        [Range(1, 5)]
        public int Rating { get; set; }

        public Comment(int id, User user, int userId, Item item, int itemId, string description, int Rating)
        {
            Id = id;
            User = user;
            UserId = userId;
            Item = item;
            ItemId = itemId;
            Description = description;
            this.Rating = Rating;
        }

        public Comment(int id, int userId, int itemId, string description, int Rating)
        {
            Id = id;
            UserId = userId;
            ItemId = itemId;
            Description = description;
            this.Rating = Rating;
        }

        public Comment()
        {
        }
    }
}
