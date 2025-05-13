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
    public class User 
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsAdmin { get; set; }
        public string? Password { get; set; }
        public int Bonus { get; set; }

        public User()
        {
        }

        public User(string? name, string? password)
        {
            Name = name;
            Password = password;
            Bonus = 0;
            IsAdmin = false;
        }

        public User(int id, string? name, string? password, bool isAdmin)
        {
            Id = id;
            Name = name;
            IsAdmin = false;
            Password = password;
            Bonus = 0;
        }
    }
}
