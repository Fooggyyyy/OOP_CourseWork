using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CourseWork.Model
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }

        public Contact(int id, string name, string description, string email)
        {
            Id = id;
            Name = name;
            Description = description;
            Email = email;
        }

        public Contact()
        {
        }
    }
}
