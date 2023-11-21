using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalsProject.Classes
{
    public class Reservation
    {
        private int _id;
        private int custid;
        private int tableid;
        private int status;
        private DateTime reservationdate;

        public Reservation(DateTime reservationdate)
        {
            this.Reservationdate = reservationdate;
        }

        public DateTime Reservationdate { get => reservationdate; set => reservationdate = value; }
        public int Id { get => _id; set => _id = value; }
        public int Tableid { get => tableid; set => tableid = value; }
        public int Status { get => status; set => status = value; }
        public int Custid { get => custid; set => custid = value; }
    }
}
