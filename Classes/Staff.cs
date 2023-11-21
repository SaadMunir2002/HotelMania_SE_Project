using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalsProject.Classes
{
    public class Staff : User
    {
        private int id;
        private string phone;
        private string address;
        private DateTime hiredate;
        private decimal salary;

      
        public Staff(int id, string password, string firstname, string lastname,string usertype, string email, string gender, string phone, string address, DateTime hiredate, decimal salary) : base(password, firstname, lastname,usertype, email, gender)
        {
            this.id = id;
            this.phone = phone;
            this.address = address;
            this.hiredate = hiredate;
            this.salary = salary;
        }

        public Staff(int id, string password, string firstname, string lastname,string email, string phone, string address, DateTime hiredate, decimal salary) : base(password, firstname, lastname, email)
        {
            this.id = id;
            this.phone = phone;
            this.address = address;
            this.hiredate = hiredate;
            this.salary = salary;
        }

        public void Stafff(  string phone, string address, DateTime hiredate, decimal salary) 
        {
            this.phone = phone;
            this.address = address;
            this.hiredate = hiredate;
            this.salary = salary;
        }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public DateTime Hiredate { get => hiredate; set => hiredate = value; }
        public decimal Salary { get => salary; set => salary = value; }
        public int Id { get => id; set => id = value; }
    }
}
