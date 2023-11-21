using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalsProject.Classes
{
    public class OrderItemsDL
    {

        public static void insertorderitem(Order o)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("insert into Order_Items values (@order_id,@menu_id,@price,@quantity) ", con);
            cmd.Parameters.AddWithValue("@order_id", o.Orderid);
            cmd.Parameters.AddWithValue("@menu_id", o.Menuid);
            cmd.Parameters.AddWithValue("@price", o.Price);
            cmd.Parameters.AddWithValue("@quantity", o.Quantity);
            cmd.ExecuteNonQuery();
        }

        public static DataTable retriveorderitem(int id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select m.name,o.price,o.quantity from menu m left join Order_Items o on m.id = o.menu_id where o.order_id = "+id+"", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static int generatecustbill(int id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select sum(price*quantity) from Order_Items where order_id = @value", con);
            cmd.Parameters.AddWithValue("@value", id);
            int result = (int)cmd.ExecuteScalar();
            return result;
        }

        static public void deleteorderitemsmenu(int id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("delete from Order_Items where menu_id = " + id + "", con);
            cmd.ExecuteNonQuery();
        }
    }
}
