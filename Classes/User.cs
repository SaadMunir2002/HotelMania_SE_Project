using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalsProject.Classes
{
    public class User
    {
        private string usertype;
        protected string password;
        protected string firstname;
        protected string lastname;
        protected string email;
        protected string gender;

        public User(string password, string firstname, string lastname, string usertype, string email, string gender)
        {
            this.usertype = usertype;
            this.password = password;
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;
            this.gender = gender;
        }

        public User(string password, string firstname, string lastname, string email)
        {
            this.password = password;
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;
        }

        public string Password { get => password; set => password = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Email { get => email; set => email = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Usertype { get => usertype; set => usertype = value; }
    }
}
