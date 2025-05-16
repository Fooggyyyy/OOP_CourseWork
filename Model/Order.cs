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
    public enum Status
    {
        Processing = 0,
        Shipped = 1,
        Delivered = 2
    }

    public class Order 
    {
        public int Id { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
        public bool ActiveBonus { get; set; }
        public Status Status { get; set; }
        public int Price { get; set; }

        public Order(int id, User? user, int userId, Item item, int itemId, bool activeBonus, int price, Status Status)
        {
            Id = id;
            User = user;
            UserId = userId;
            Item = item;
            ItemId = itemId;
            ActiveBonus = activeBonus;
            Price = price;
            this.Status = Status;
        }

        public Order(int id, int userId, int itemId, bool activeBonus, int price)
        {
            Id = id;
            UserId = userId;
            ItemId = itemId;
            ActiveBonus = activeBonus;
            Price = price;
        }

        public Order()
        {
        }
    }
}
