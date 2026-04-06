using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class HallBooking : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            Menu m4 = (Menu)Master.FindControl("Menu4");
            m4.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
            {
                if (Session ["UName"]!=null && Request .QueryString .Get ("HallID")!=null && Request .QueryString .Get ("HallName")!=null && Request.QueryString .Get ("BookingDate")!=null )
                {
                    autonumber();
                    TextBox2.Text = Request.QueryString.Get("BookingDate");
                    TextBox3 .Text =Session ["UName"].ToString ();
                    TextBox4 .Text =Request .QueryString .Get ("HallID");
                    TextBox5 .Text =Request .QueryString .Get ("HallName");

                }
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }

    void autonumber()
    {
        cmd = new SqlCommand("select isnull(max(bid), 1000)+1 from hbtable", con);
        TextBox1.Text = cmd.ExecuteScalar().ToString();
        cmd.Dispose();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try 
        {
            if (RadioButtonList1.SelectedIndex == -1 || RadioButtonList2.SelectedIndex == -1 || RadioButtonList3.SelectedIndex == -1 ||RadioButtonList4.SelectedIndex == -1)
            {
                Label1.Text = "Select All Options.....";
                return;
            }

            cmd = new SqlCommand("select bid from hbtable where bid=@bid", con);
            cmd.Parameters.AddWithValue("bid", TextBox1.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "Booking ID Already Found....";
                return;
            }

            cmd = new SqlCommand("select rent from htable where hid=@hid", con);
            cmd.Parameters.AddWithValue("hid", TextBox4.Text);
            rs = cmd.ExecuteReader();
            float rent = 0;
            if (rs.Read())
            {
                rent =float.Parse ( rs["rent"].ToString());
                rs.Close();
                cmd.Dispose();
            }
            else
            {
                rs.Close();
                cmd.Dispose();
                Label1.Text = "Record Not Found.Check HTable....";
                return ;
            }

            cmd = new SqlCommand("insert into hbtable values(@bid,@bdate,@uname,@hid,@hname,@coption,@doption,@soption,@moption,@pstatus)", con);
            cmd.Parameters .AddWithValue ("bid",TextBox1 .Text );
            cmd.Parameters .AddWithValue ("bdate",TextBox2 .Text );
            cmd.Parameters .AddWithValue ("uname",TextBox3 .Text );
            cmd.Parameters .AddWithValue ("hid",TextBox4 .Text );
            cmd.Parameters .AddWithValue ("hname",TextBox5 .Text );
            cmd.Parameters .AddWithValue ("coption",RadioButtonList1 .SelectedItem .Text );
            cmd.Parameters .AddWithValue ("doption",RadioButtonList2 .SelectedItem .Text );
            cmd.Parameters.AddWithValue("soption", RadioButtonList3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("moption", RadioButtonList4.SelectedItem.Text);
            cmd.Parameters .AddWithValue ("pstatus","Not Paid");
            int no=cmd.ExecuteNonQuery();
            cmd.Dispose();
            if (no != 0)
            {
                cmd = new SqlCommand("insert into hbtable1 values(@bid,@hrent,@camount,@damount,@samount,@mamount)", con);
                cmd.Parameters.AddWithValue("bid", TextBox1.Text);
                cmd.Parameters.AddWithValue("hrent", rent );
                cmd.Parameters.AddWithValue("camount", 0);
                cmd.Parameters.AddWithValue("damount", 0);
                cmd.Parameters.AddWithValue("samount", 0);
                cmd.Parameters.AddWithValue("mamount", 0);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = new SqlCommand("insert into hbtable2 values(@bid,@coption,@doption,@soption,@moption)", con);
                cmd.Parameters.AddWithValue("bid", TextBox1.Text);
                cmd.Parameters.AddWithValue("coption", RadioButtonList1.SelectedItem.Text);
                cmd.Parameters.AddWithValue("doption", RadioButtonList2.SelectedItem.Text);
                cmd.Parameters.AddWithValue("soption", RadioButtonList3.SelectedItem.Text);
                cmd.Parameters.AddWithValue("moption", RadioButtonList4.SelectedItem.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Label1.Text = "Hall Booking Details Inserted.....";

                if (RadioButtonList1.SelectedIndex == 0 )
                {
                    Response.Redirect("CateringBooking.aspx?BID=" + TextBox1.Text );
                }
                else if (RadioButtonList2.SelectedIndex == 0)
                {
                    Response.Redirect("DecorationBooking.aspx?BID=" + TextBox1.Text );
                }
                else if (RadioButtonList3.SelectedIndex == 0)
                {
                 
                    Response.Redirect("StudioBooking.aspx?BID=" + TextBox1.Text );
                }
                else if (RadioButtonList4.SelectedIndex == 0)
                {

                    Response.Redirect("MoisoftBooking.aspx?BID=" + TextBox1.Text);
                }
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}