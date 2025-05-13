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
        Pink = 5,
        Black = 6
    }
    public enum TypeWear
    {
        Jeens = 0,
        Tshirt = 1,
        Hoodie = 2,
        Jacket = 3,
        Shirt = 4,
        Pants = 5,
        Acces = 6
    }
    public class Item 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Size Size { get; set; }
        public Color Color { get; set; }
        public TypeWear Type { get; set; }
        public string Description  { get; set; }
        public double Rating { get; set; }
        public string PhotoPath { get; set; }
        public Item(int id, string name, int price, Size size, Color color, string description, double rating, Comment comment, int commentId, TypeWear Type, string photoPath)
        {
            Id = id;
            Name = name;
            Price = price;
            Size = size;
            Color = color;
            Description = description;
            Rating = rating;
            this.Type = Type;
            PhotoPath = photoPath;
        }

        public Item(int id, string name, int price, Size size, Color color, string description, double rating, TypeWear Type, string PhotoPath)
        {
            Id = id;
            Name = name;
            Price = price;
            Size = size;
            Color = color;
            Description = description;
            Rating = rating;
            this.Type = Type;
            this.PhotoPath = PhotoPath;
        }

        public Item()
        {
        }
    }
}
