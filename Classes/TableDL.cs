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
    public class TableDL
    {
        static public void inserttable(Table t)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Seating_Table values (@table_no,@floor)", con);
            cmd.Parameters.AddWithValue("@table_no", t.Tableno);
            cmd.Parameters.AddWithValue("@floor", t.Floor);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
        }

        static public bool checktable(int tableno,int floor)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select count(*) from Seating_Table where floor = @value2 and table_no = @value1",con);
            cmd.Parameters.AddWithValue("@value1",tableno);
            cmd.Parameters.AddWithValue("@value2",floor);
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

        static public List<int> retrivetableids()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT s.id FROM Seating_Table s LEFT JOIN AssignedTask a ON s.id = a.table_id WHERE a.table_id IS NULL", con);
            List<int> l = new List<int>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                l.Add(reader.GetInt32(0));
            }
            reader.Close();
            return l;


        }
        static public void updatetable(int id,Table t)
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("update Seating_Table set table_no = @table_no , floor = @floor where id = " + id + "", con);
            cmd.Parameters.AddWithValue("@table_no", t.Tableno);
            cmd.Parameters.AddWithValue("@floor", t.Floor);
            cmd.ExecuteNonQuery();
        }

        static public void deletetable(int id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("delete from Seating_Table where id = " + id + "", con);
            cmd.ExecuteNonQuery();
        }

        static public DataTable viewtable()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select * from Seating_Table", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


    }
}
