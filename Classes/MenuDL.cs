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
    public class MenuDL
    {
        static public void insertmenuitem(menumenu m)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Menu values (@category_id,@name,@description,@price)", con);
            int id = convertcategory(m.Cname); 
            cmd.Parameters.AddWithValue("@category_id", id);
            cmd.Parameters.AddWithValue("@name", m.Name);
            cmd.Parameters.AddWithValue("@description", m.Description);
            cmd.Parameters.AddWithValue("@price", m.Price);
            cmd.ExecuteNonQuery(); 
            MessageBox.Show("Successfully saved");
        }

        static public bool checkmenuitem(string name, string category)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select count(*) from Menu where name = @value1 and category_id = @value2",con);
            int id = convertcategory(category);
            cmd.Parameters.AddWithValue("@value2", id);
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

        static public List<menumenu> retrivemenuitems()
        {
            List<menumenu> l = new List<menumenu>();
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select m.id, c.cname,m.name,m.price from Menu m left join Menu_Category c on c.id = m.category_id", con);
            try
            {
                //DataTable dataTable = new DataTable();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string category = reader.GetString(1);
                    string name = reader.GetString(2);
                    decimal price = reader.GetDecimal(3);
                    menumenu m = new menumenu(id,category, name, price);
                    l.Add(m);
                }
                //dataTable.Load(reader);
                reader.Close();
                return l;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                Console.WriteLine(ex.Message);
                return new List<menumenu>();
            }
        }

        static int convertcategory(string category)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmdd = new SqlCommand("select id from Menu_Category where cname = @value",con);
            cmdd.Parameters.AddWithValue("@value", category);
            int id = (int)cmdd.ExecuteScalar();
            return id;
        }

        static public void updatemenu(int id, menumenu m)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("update Menu set category_id = @category_id, name = @name , description = @description,price = @price where id = " + id + "", con);
            int cid = convertcategory(m.Cname);
            cmd.Parameters.AddWithValue("@category_id", cid);
            cmd.Parameters.AddWithValue("@name", m.Name);
            cmd.Parameters.AddWithValue("@description", m.Description);
            cmd.Parameters.AddWithValue("@price", m.Price);
            cmd.ExecuteNonQuery();
        }

        static public void deletemenu(int id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("delete from Menu where id = " + id + "", con);
            cmd.ExecuteNonQuery();
        }

        static public void deletecategorymenu(int id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("delete from Menu where category_id = " + id + "", con);
            cmd.ExecuteNonQuery();
        }

        static public DataTable viewmenu()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select m.id, m.name,c.cname,m.description,m.price from Menu m left join Menu_Category c on m.category_id = c.id", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
