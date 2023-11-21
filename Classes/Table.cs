using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalsProject.Classes
{
    public class Table
    {
        private int tableid;
        private  int tableno;
        private int floor;


        public Table(int tableno,int floor)
        {
            this.tableno = tableno;
            this.floor = floor;
        }

        public Table(int tableid, int tableno, int floor)
        {
            this.tableid = tableid;
            this.tableno = tableno;
            this.floor = floor;
        }

        public int Tableno { get => tableno; set => tableno = value; }
        public int Floor { get => floor; set => floor = value; }
        public int Tableid { get => tableid; set => tableid = value; }
    }
}
