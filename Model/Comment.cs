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
    public class Comment : INotifyPropertyChanged
    {
        private User? User;
        private string? Description;

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

        public string? description
        {
            get
            {
                return Description;
            }
            set
            {
                Description = value;
                OnPropertyChanged("description");
            }
        }

        public Comment(User? User, string? Description)
        {
            this.User = User;
            this.Description = Description;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
