using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalsProject.Classes
{
    public class Customer : User
    {
        private int id;
        private string phone;
        private string address;

        public Customer(int id,string password, string firstname, string lastname,string usertype, string email, string gender, string phone, string address) : base(password, firstname, lastname,usertype, email, gender)
        {
            this.id = id;
            this.phone = phone;
            this.address = address;
        }
        public Customer(int id, string password, string firstname, string lastname, string email, string phone, string address) : base(password, firstname, lastname, email)
        {
            this.id = id;
            this.phone = phone;
            this.address = address;
        }



        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public int Id { get => id; set => id = value; }
    }
}
