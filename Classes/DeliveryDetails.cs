using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalsProject.Classes
{
    public class DeliveryDetails
    {
        private int deliveryid;
        private int customerid;
        private string postelcode;
        private string delivery_address;
        private string city;


        public DeliveryDetails(int customerid, string postelcode, string delivery_address, string city)
        {
            this.customerid = customerid;
            this.postelcode = postelcode;
            this.delivery_address = delivery_address;
            this.city = city;
        }

        public int Deliveryid { get => deliveryid; set => deliveryid = value; }
        public int Customerid { get => customerid; set => customerid = value; }
        public string Delivery_address { get => delivery_address; set => delivery_address = value; }
        public string City { get => city; set => city = value; }
        public string Postelcode { get => postelcode; set => postelcode = value; }
    }
}
