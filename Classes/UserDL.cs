using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace finalsProject.Classes
{
    public class UserDL
    {
        static public void insertUser(User u)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Users values (@password,@usertype,@first_name,@last_name,@email,@gender)", con);
            cmd.Parameters.AddWithValue("@password", u.Password);
            string query = "select Id from Lookup  where Value = @value";
            SqlCommand cmdd = new SqlCommand(query, con);
            cmdd.Parameters.AddWithValue("@value", u.Usertype);
            int result = (int)cmdd.ExecuteScalar();
            cmd.Parameters.AddWithValue("@usertype", result);
            cmd.Parameters.AddWithValue("@first_name", u.Firstname);
            cmd.Parameters.AddWithValue("@last_name", u.Lastname);
            cmd.Parameters.AddWithValue("@email", u.Email);
            string query1 = "select Id from Lookup  where Value = @value";
            SqlCommand cmddd = new SqlCommand(query1, con);
            cmddd.Parameters.AddWithValue("@value", u.Gender);
            int result1 = (int)cmddd.ExecuteScalar();
            cmd.Parameters.AddWithValue("@gender", result1);
            cmd.ExecuteNonQuery();

        }
        static public int getuserid(string email)
        {
            var con = Configuration.getInstance().getConnection();
            string query = "Select id from Users where email = @value";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@value", email);
            int result = (int)cmd.ExecuteScalar();
            return result;

        }

        static public bool checkemail(string email)
        {
            var con = Configuration.getInstance().getConnection();
            string query = "Select count(*) from Users where email = @value";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@value", email);
            int result = (int)cmd.ExecuteScalar();
            if(result == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }

        static public void updateuser(int id , User u)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("update Users set password = @password , usertype = @usertype ,first_name = @first_name , last_name = @last_name , email = @email , gender = @gender  where id = " + id + "", con);
            cmd.Parameters.AddWithValue("@password", u.Password);
            string query = "select Id from Lookup  where Value = @value";
            SqlCommand cmdd = new SqlCommand(query, con);
            cmdd.Parameters.AddWithValue("@value", u.Usertype);
            int result = (int)cmdd.ExecuteScalar();
            cmd.Parameters.AddWithValue("@usertype", result);
            cmd.Parameters.AddWithValue("@first_name", u.Firstname);
            cmd.Parameters.AddWithValue("@last_name", u.Lastname);
            cmd.Parameters.AddWithValue("@email", u.Email);
            string query1 = "select Id from Lookup  where Value = @value";
            SqlCommand cmddd = new SqlCommand(query1, con);
            cmddd.Parameters.AddWithValue("@value", u.Gender);
            int result1 = (int)cmddd.ExecuteScalar();
            cmd.Parameters.AddWithValue("@gender", result1);
            cmd.ExecuteNonQuery();
        }

        static public void deleteuser(int id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("delete from Users where id = " + id + "", con);
            cmd.ExecuteNonQuery();
        }
    }
}
