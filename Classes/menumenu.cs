using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalsProject.Classes
{
    public class menumenu : Categories
    {
        private int id;
        private string name;
        private string description;
        private decimal price;

        public menumenu(int id,string cname, string name, decimal price) : base(cname)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }

        public menumenu(string cname, string name, decimal price) : base(cname)
        {
            this.name = name;
            this.price = price;
        }

        public menumenu( string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }

        public menumenu(string cname, string name, string description, decimal price) : base(cname)
        {
            this.name = name;
            this.description = description;
            this.price = price;
        }

        public string Name { get => name; set => name = value; }
        
        public decimal Price { get => price; set => price = value; }
        public string Description { get => description; set => description = value; }
        public int Id { get => id; set => id = value; }
    }
}
