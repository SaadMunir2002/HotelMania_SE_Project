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
    public class DeliveryDetailsDL
    {
        static public List<int> retrivedeliveryids()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT o.delivery_id  FROM [Order] o LEFT JOIN AssignedTask at ON o.delivery_id = at.delivery_id WHERE at.delivery_id IS NULL and o.delivery_id is not null", con);
            List<int> l = new List<int>();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    l.Add(reader.GetInt32(0));
                }
            }
            reader.Close();
            return l;


        }

        static public List<int> selectdeliveryids(int id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select id from DeliveryDetails d where d.customer_id = "+id+"", con);
            List<int> l = new List<int>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                l.Add(reader.GetInt32(0));
            }
            reader.Close();
            return l;


        }

        static public void insertdeliverydetails(DeliveryDetails d)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into DeliveryDetails values(@delivery_address,@postal_code,@city,@customer_id)", con);
            cmd.Parameters.AddWithValue("@delivery_address", d.Delivery_address);
            cmd.Parameters.AddWithValue("@postal_code", d.Postelcode);
            cmd.Parameters.AddWithValue("@city", d.City);
            cmd.Parameters.AddWithValue("@customer_id", d.Customerid);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
        }

        static public DataTable viewdeliverydetails()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select id,delivery_address,postal_code,city from DeliveryDetails", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        static public void updatedeliverydetails(int cid,int id,DeliveryDetails d)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("update DeliveryDetails set delivery_address = @delivery_address ,postal_code = @postal_code , city =@city , customer_id = @customer_id where id = " + id + "", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@delivery_address", d.Delivery_address);
            cmd.Parameters.AddWithValue("@postal_code", d.Postelcode);
            cmd.Parameters.AddWithValue("@city", d.City);
            cmd.Parameters.AddWithValue("@customer_id",cid);
            cmd.ExecuteNonQuery();
        }

        static public void deletedeliverydetails(int id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("delete from DeliveryDetails where id = " + id + "", con);
            cmd.ExecuteNonQuery();
        }
    }
}
