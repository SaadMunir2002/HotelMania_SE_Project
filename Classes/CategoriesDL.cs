using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace finalsProject.Classes
{
    public class CategoriesDL
    {
        static public void insertcategory(Categories c)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Menu_Category values (@cname,@description)", con);
            cmd.Parameters.AddWithValue("@cname", c.Cname);
            cmd.Parameters.AddWithValue("@description", c.Description);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
        }

        static public bool checkcategory(string name)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select count(*) from Menu_Category where cname = @value1", con);
            cmd.Parameters.AddWithValue("@value1", name);
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
        static public List<string> retrivecategory()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select cname from Menu_Category", con);
            List<string> l = new List<string>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                l.Add(reader.GetString(0));
            }
            reader.Close();
            return l;


        }

        static public DataTable viewfoodcategory()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select * from Menu_Category", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        static public void updatefoodcategory(int id,Categories c)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("update Menu_Category set cname = @cname , description = @description where id = " + id + "", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@cname", c.Cname);
            cmd.Parameters.AddWithValue("@description", c.Description);
            cmd.ExecuteNonQuery();
        }

        static public void deletefoodcategory(int id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("delete from Menu_Category where id = " + id + "", con);
            cmd.ExecuteNonQuery();
        }
    }

}
