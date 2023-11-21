using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace finalsProject.Classes
{
    public class StaffDL
    {
        static public void insertstaff(Staff s)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into staff values (@id,@phone,@address,@hiredate,@salary)", con);
            cmd.Parameters.AddWithValue("@id", s.Id);
            cmd.Parameters.AddWithValue("@phone", s.Phone);
            cmd.Parameters.AddWithValue("@address", s.Address);
            cmd.Parameters.AddWithValue("@hiredate", s.Hiredate);
            cmd.Parameters.AddWithValue("@salary", s.Salary);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
        }

        static public bool signinvalidstaff(string email, string password,int usertype)
        {
            var con = Configuration.getInstance().getConnection();
            string query = "Select count(*) from Users where email = @value and password = @value2 and usertype = @value3";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@value", email);
            cmd.Parameters.AddWithValue("@value2", password);
            cmd.Parameters.AddWithValue("@value3", usertype);
            int result = (int)cmd.ExecuteScalar();

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static public List<int> retrivestaffids(int id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select s.id from staff s left join users u on s.id = u.id join lookup l on u.usertype = l.id where l.id = @value", con);
            cmd.Parameters.AddWithValue("@value", id);
            List<int> l = new List<int>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                l.Add(reader.GetInt32(0));
            }
            reader.Close();
            return l;


        }

        static public Staff staffinfo(string email, int usertype)
        {
           
            var con = Configuration.getInstance().getConnection();
            string query = "select u.id,u.first_name,u.last_name,u.email,u.password,s.phone,s.address,s.salary,s.hiredate from staff s left join users u on u.id = s.id where u.email = @value and u.usertype = @value1";
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
                    decimal salary = reader.GetDecimal(7);
                    DateTime hiredate = reader.GetDateTime(8);
                    Staff s = new Staff(id,password, fname, lname, Email, phone, address,hiredate,salary);
                   reader.Close();
                    return s;
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

        static public List<Table> staffviewassignedtables(int id)
        {
            List<Table> t = new List<Table>();
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select t.id,t.table_no,t.floor from Seating_Table t left join AssignedTask a on t.id = a.table_id left join staff s on a.staff_id = s.id where s.id = @value", con);
            cmd.Parameters.AddWithValue("@value", id);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int table_id = reader.GetInt32(0);
                    int table_no = reader.GetInt32(1);
                    int floor = reader.GetInt32(2);

                    Table ta = new Table(table_id, table_no, floor);
                    t.Add(ta);
                }
                reader.Close();
                return t;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                Console.WriteLine(ex.Message);
                return new List<Table>();
            }
        }


        static public List<int> viewassignedtables(int id)
        {
            List<int> t = new List<int>();
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select t.id from Seating_Table t left join AssignedTask a on t.id = a.table_id left join staff s on a.staff_id = s.id where s.id = @value", con);
            cmd.Parameters.AddWithValue("@value", id);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    t.Add(reader.GetInt32(0));
                }
                reader.Close();
                return t;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                Console.WriteLine(ex.Message);
                return new List<int>();
            }
        }

        static public List<DeliveryDetails> staffviewassignedorders(int id)
        {
            List<DeliveryDetails> dl = new List<DeliveryDetails>();
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select d.customer_id,d.delivery_address,d.postal_code,d.city from  DeliveryDetails d left join AssignedTask a on a.staff_id = "+id+" ", con);
            cmd.Parameters.AddWithValue("@value", id);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int customer_id = reader.GetInt32(0);
                    string delivery_address = reader.GetString(1);
                    string postalCode = reader.GetString(2);
                    string city = reader.GetString(3);
                    DeliveryDetails d = new DeliveryDetails(customer_id,postalCode,delivery_address,city);
                    dl.Add(d);
                }
                reader.Close();
                return dl;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                Console.WriteLine(ex.Message);
                return new List<DeliveryDetails>();
            }
        }

        static public void updatestaff(int id , Staff s)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("update Staff set id = @id, phone = @phone , address = @address ,hiredate = @hiredate , salary = @salary where id = " + id + "", con);
            cmd.Parameters.AddWithValue("@id", s.Id);
            cmd.Parameters.AddWithValue("@phone", s.Phone);
            cmd.Parameters.AddWithValue("@address", s.Address);
            cmd.Parameters.AddWithValue("@hiredate", s.Hiredate);
            cmd.Parameters.AddWithValue("@salary", s.Salary);
            cmd.ExecuteNonQuery();
        }

        static public void deletestaff(int id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("delete from Staff where id = " + id + "", con);
            cmd.ExecuteNonQuery();
        }

        static public DataTable viewstaff()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select u.id,u.password,l.value,u.gender,u.first_name,u.last_name,u.email,s.phone,s.address,s.salary,s.hiredate from staff s left join users u on u.id = s.id join lookup l on l.id = u.usertype", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

    }
}
