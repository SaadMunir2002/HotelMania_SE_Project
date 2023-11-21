using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace finalsProject.Classes
{
    public class ReservationDL
    {
        static public void insertTable(Reservation R)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Reservation_Table values (@Tid,@Cid,@Rdate,@Status)", con);
            cmd.Parameters.AddWithValue("@Tid", R.Tableid);
            cmd.Parameters.AddWithValue("@Cid", R.Custid);
            cmd.Parameters.AddWithValue("@Rdate", R.Reservationdate);
            cmd.Parameters.AddWithValue("@Status", R.Status);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
        }

    }
}
