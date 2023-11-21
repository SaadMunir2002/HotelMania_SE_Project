using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalsProject.Classes
{
    public class Order :OrderItems
    {
        private int staffid;
        private int tableid;
        private int customerid;
        private int orderid;
        private string comments;
        private int delivery_id;

        public Order(int staffid, int tableid)
        {
            this.staffid = staffid;
            this.tableid = tableid;
        }

        /*public Order(int customerid, int delivery_id)
        {
            this.customerid = customerid;
            this.delivery_id = delivery_id;
        }*/

        public Order(int orderid,int menuid,int price,int quantity ) :base(price,quantity,menuid)
        {
            this.orderid = orderid;
        }
        public Order(int orderid,int customerid,int menuid, int price, int quantity) : base(price, quantity, menuid)
        {
            this.customerid = customerid;
            this.orderid = orderid;
        }

        public int Staffid { get => staffid; set => staffid = value; }
        public int Tableid { get => tableid; set => tableid = value; }
        public int Customerid { get => customerid; set => customerid = value; }
        public int Orderid { get => orderid; set => orderid = value; }
        public string Comments { get => comments; set => comments = value; }
        public int Delivery_id { get => delivery_id; set => delivery_id = value; }
    }
}
