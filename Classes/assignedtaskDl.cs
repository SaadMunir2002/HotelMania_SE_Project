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
    public class assignedtaskDl
    {
        static public void assigntask(AssignedTask a)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into AssignedTask values (@table_id,@staff_id,@delivery_id)", con);
            cmd.Parameters.AddWithValue("@staff_id", a.Staffid);
            cmd.Parameters.AddWithValue("@table_id", a.Taskid);
            cmd.Parameters.AddWithValue("@delivery_id", DBNull.Value);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
        }

        static public void updatetask(int id, AssignedTask a)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("update AssignedTask set table_id = @table_id, staff_id = @staff_id, delivery_id = @delivery_id where id = " + id + "", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@staff_id", a.Staffid);
            cmd.Parameters.AddWithValue("@table_id", a.Taskid);
            cmd.Parameters.AddWithValue("@delivery_id", DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        static public void updatedeliverytask(int id, AssignedTask a)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("update AssignedTask set table_id = @table_id, staff_id = @staff_id, delivery_id = @delivery_id where id = " + id + "", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@staff_id", a.Staffid);
            cmd.Parameters.AddWithValue("@table_id", DBNull.Value);
            cmd.Parameters.AddWithValue("@delivery_id", a.Taskid);
            cmd.ExecuteNonQuery();
        }

        static public void deletetask(int id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("delete from AssignedTask where id = " + id + "", con);
            cmd.ExecuteNonQuery();
        }

        static public void deletetabletask(int id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("delete from AssignedTask where table_id = " + id + "", con);
            cmd.ExecuteNonQuery();
        }

        static public void deletestafftask(int id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("delete from AssignedTask where staff_id = " + id + "", con);
            cmd.ExecuteNonQuery();
        }

        static public DataTable viewstafftask()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select id,table_id,staff_id from AssignedTask where delivery_id is null", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        static public DataTable viewdeliverytask()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select id,delivery_id,staff_id from AssignedTask where table_id is null", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        static public void assigndeliverytask(AssignedTask a)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into AssignedTask values (@table_id,@staff_id,@delivery_id)", con);
            cmd.Parameters.AddWithValue("@staff_id", a.Staffid);
            cmd.Parameters.AddWithValue("@table_id", DBNull.Value);
            cmd.Parameters.AddWithValue("@delivery_id", a.Taskid);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
        }

        static public bool checkwaitertask(int task)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select count(*) from AssignedTask where table_id = @value", con);
            cmd.Parameters.AddWithValue("@value", task);
            int result = (int)cmd.ExecuteScalar();
            if (result == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        static public bool checkdeliverymantask(int task)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select count(*) from AssignedTask where delivery_id = @value", con);
            cmd.Parameters.AddWithValue("@value", task);
            int result = (int)cmd.ExecuteScalar();
            if (result == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
