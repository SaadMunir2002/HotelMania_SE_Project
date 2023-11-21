using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalsProject.Classes
{
    public class OrderDL
    {

        public static void StaffChooseTable(Order o)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into [Order] values (@customer_id,@table_id,@staff_id,@comments,@delivery_id)", con);
            cmd.Parameters.AddWithValue("@table_id", o.Tableid);
            cmd.Parameters.AddWithValue("@staff_id", o.Staffid);
            cmd.Parameters.AddWithValue("@customer_id", DBNull.Value);
            cmd.Parameters.AddWithValue("@comments", DBNull.Value);
            cmd.Parameters.AddWithValue("@delivery_id", DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        public static void customerorder(Order o)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into [Order] values (@customer_id,@table_id,@staff_id,@comments,@delivery_id)", con);
            cmd.Parameters.AddWithValue("@table_id", DBNull.Value);
            cmd.Parameters.AddWithValue("@staff_id", DBNull.Value);
            cmd.Parameters.AddWithValue("@customer_id", o.Staffid);
            cmd.Parameters.AddWithValue("@comments", DBNull.Value);
            cmd.Parameters.AddWithValue("@delivery_id", o.Tableid);
            cmd.ExecuteNonQuery();
        }
        static public List<int> retriveorderids()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select distinct o.id from [Order] o left join Order_Items oi on o.id = oi.order_id left join Menu m on m.id = oi.menu_id  where o.customer_id is null  and m.id = oi.menu_id ", con);
            List<int> l = new List<int>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                l.Add(reader.GetInt32(0));
            }
            reader.Close();
            return l;


        }

        static public DataTable managervieworders()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select * from [Order] ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static int getorderid()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 id FROM [Order] ORDER BY ID DESC", con);
            int result = (int)cmd.ExecuteScalar();
            return result;
        }

        static public void deletestafffromorders(int id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("delete from [Order] where id = " + id + "", con);
            cmd.ExecuteNonQuery();
        }

        
    }
}
