using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalsProject.Classes
{
    public class Categories
    {
        private int id;
        private string cname;
        private string description;

        public Categories(string cname, string description)
        {
            this.cname = cname;
            this.description = description;
        }

        public Categories(string cname)
        {
            this.cname = cname;;
        }

        public Categories()
        {

        }
        public string Description { get => description; set => description = value; }
        public string Cname { get => cname; set => cname = value; }
        public int Id { get => id; set => id = value; }
    }
}
