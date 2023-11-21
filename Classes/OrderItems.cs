using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalsProject.Classes
{
    public class OrderItems 
    {
        private int price;
        private int quantity;
        private int menuid;


        public OrderItems(int price, int quantity)
        {
            this.price = price;
            this.quantity = quantity;
        }
        public OrderItems()
        {

        }

        public OrderItems(int price, int quantity, int menuid)
        {
            this.price = price;
            this.quantity = quantity;
            this.menuid = menuid;
        }

        public int Price { get => price; set => price = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int Menuid { get => menuid; set => menuid = value; }
    }
}
