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
    public enum Size
    {
        S = 0,
        M = 1,
        L = 2,
        XL = 3,
        XXL = 4
    }
    public enum Color
    {
        White = 0,
        Green = 1,
        Blue = 2,
        Red = 3,
        Gray = 4,
        Pink = 5
    }
    public class Item : INotifyPropertyChanged
    {
        private int Id;
        private string? Name;
        private int Price;
        private Size Size;
        private Color Color;
        private SortedSet<string> Description;
        private double Rating;
        private SortedSet<Comment> Comments;

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

        public Color color
        {
            get
            {
                return Color;
            }
            set
            {
                Color = value;
                OnPropertyChanged("color");
            }
        }

        public string? name
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
                OnPropertyChanged("name");
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

        public Size size
        {
            get
            {
                return Size;
            }
            set
            {
                Size = value;
                OnPropertyChanged("size");
            }
        }

        public double rating
        {
            get
            {
                return Rating;
            }
            set
            {
                Rating = value;
                OnPropertyChanged("rating");
            }
        }

        public Item(int Id, string? Name, int Price, Size Size, Color Color, SortedSet<string> Description, double Rating, SortedSet<Comment> Comments)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
            this.Size = Size;
            this.Description = Description;
            this.Rating = Rating;
            this.Comments = Comments;
            this.Color = Color;
        }

        public Item(int Id, string? Name, int Price, Size Size, Color Color, SortedSet<string> Description)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
            this.Size = Size;
            this.Description = Description;
            this.Color = Color;
            Comments = new SortedSet<Comment>();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
