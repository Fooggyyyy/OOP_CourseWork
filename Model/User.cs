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
    public class User : INotifyPropertyChanged
    {
        private int Id;
        private string? Name;
        private bool IsAdmin;
        private string? Password;
        private int Bonus;

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

        public bool isadmin
        {
            get
            {
                return IsAdmin;
            }
            set
            {
                IsAdmin = value;
                OnPropertyChanged("isadmin");
            }
        }

        public string? password
        {
            get
            {
                return Password;
            }
            set
            {
                Password = value;
                OnPropertyChanged("password");
            }
        }

        public int bonus
        {
            get
            {
                return Bonus;
            }
            set
            {
                Bonus = value;
                OnPropertyChanged("bonus");
            }
        }

        public User(int Id, string? Name, bool IsAdmin, string? Password, int Bonus)
        {
            this.Id = Id;
            this.Name = Name;
            this.IsAdmin = IsAdmin;
            this.Password = Password;
            this.Bonus = Bonus;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
