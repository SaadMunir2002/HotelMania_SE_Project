using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalsProject.Classes
{
    public class CustomerDL
    {
        static public void insertcustomer( Customer c)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into customer values (@id,@phone,@address)", con);
            cmd.Parameters.AddWithValue("@id", c.Id);
            cmd.Parameters.AddWithValue("@phone", c.Phone);
            cmd.Parameters.AddWithValue("@address", c.Address);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
        }

        static public bool signinvalidcustomer(string email,string password,int usertype)
        {
            var con = Configuration.getInstance().getConnection();
            string query = "Select count(*) from Users where email = @value and password = @value2 and usertype = @value3";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@value", email);
            cmd.Parameters.AddWithValue("@value2", password);
            cmd.Parameters.AddWithValue("@value3", usertype);
            int result = (int)cmd.ExecuteScalar();
            
            if(result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static public Customer customerinfo(string email,int usertype)
        {
            var con = Configuration.getInstance().getConnection();
            string query = "select c.id,u.first_name,u.last_name,u.email,u.password,c.phone,c.address from customer c left join users u on u.id = c.id where u.email = @value and u.usertype = @value1";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@value", email);
            cmd.Parameters.AddWithValue("@value1", usertype);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string fname = reader.GetString(1);
                    string lname = reader.GetString(2);
                    string Email = reader.GetString(3);
                    string password = reader.GetString(4);
                    string phone = reader.GetString(5);
                    string address = reader.GetString(6);
                    Customer c = new Customer(id, password, fname, lname, Email, phone, address);
                    reader.Close();
                    return c;
                }
                else
                {
                    // handle case when no rows are returned
                    return null;
                }
            }
            catch (Exception ex)
            {
                // handle any exceptions that may occur
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
