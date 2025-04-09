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
    public class Order : INotifyPropertyChanged
    {
        private int Id;
        private User? User;
        private List<Item> Items;
        private bool ActiveBonus;
        private int Price;
        public int id
        {
            get
            {
                return Id;
            }
            set
            {
                Id = value;
                OnPropertyChanged("id");
            }
        }
        public User? user
        {
            get
            {
                return User;
            }
            set
            {
                User = value;
                OnPropertyChanged("user");
            }
        }

        public bool activeBonus
        {
            get
            {
                return ActiveBonus;
            }
            set
            {
                ActiveBonus = value;
                OnPropertyChanged("activeBonus");
            }
        }

        public int price
        {
            get
            {
                return Price;
            }
            set
            {
                Price = value;
                OnPropertyChanged("price");
            }
        }

        public Order(int Id, User? User, List<Item> Items, bool ActiveBonus, int Price)
        {
            this.Id = Id;
            this.User = User;
            this.Items = Items;
            this.ActiveBonus = ActiveBonus;
            this.Price = Price;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
