using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class AmountPayment : System.Web.UI.Page
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
                if (Session["UName"] != null)
                {
                    TextBox1.Text = Session["UName"].ToString();
                    TextBox3.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                }
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        try 
        {

            cmd = new SqlCommand("select * from ptable where uname=@uname and bid=@bid", con);
            cmd.Parameters.AddWithValue("uname", TextBox1.Text);
            cmd.Parameters.AddWithValue("bid", TextBox2.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "Amount Already Paid.....";
                return;
            }
            cmd = new SqlCommand("select * from hbtable where uname=@uname and bid=@bid ", con);
            cmd.Parameters.AddWithValue("uname", TextBox1.Text);
            cmd.Parameters.AddWithValue("bid", TextBox2.Text);
            rs = cmd.ExecuteReader();
            string pstatus = "";
            if (rs.Read())
            {
                pstatus = rs["pstatus"].ToString();
                rs.Close();
                cmd.Dispose();
            }
            else
            {
                rs.Close();
                cmd.Dispose();
                Label1.Text = "Invalid Booking ID......";
                return;
            }

            if (pstatus.ToLower().Equals("paid"))
            {
                Label1.Text = "Amount Already Paid.....";
                return;
            }

            cmd = new SqlCommand("select * from hbtable1 where bid=@bid", con);
            cmd.Parameters.AddWithValue("bid", TextBox2.Text);
            rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                TextBox4.Text = rs["hrent"].ToString();
                TextBox5.Text = rs["camount"].ToString();
                TextBox6.Text = rs["damount"].ToString();
                TextBox10.Text = rs["samount"].ToString();
                TextBox11.Text = rs["mamount"].ToString();
                float totamount = float.Parse(TextBox4.Text) + float.Parse(TextBox5.Text) + float.Parse(TextBox6.Text) + float.Parse(TextBox10.Text) + float.Parse(TextBox11.Text);
                TextBox7.Text = totamount.ToString();
                rs.Close();
                cmd.Dispose();
            }
            else
            {
                rs.Close();
                cmd.Dispose();
                Label1.Text = "Invalid Booking Number......";
                return;
            }          


        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {

            cmd = new SqlCommand("select * from btable where uname=@uname and accno=@accno and ifsccode=@ifsccode", con);
            cmd.Parameters.AddWithValue("uname", TextBox1.Text);
            cmd.Parameters.AddWithValue("accno", TextBox8.Text);
            cmd.Parameters.AddWithValue("ifsccode", TextBox9.Text);
            rs = cmd.ExecuteReader();
            float amount = 0;
            if (rs.Read())
            {
                amount = float.Parse(rs["amount"].ToString());
                rs.Close();
                cmd.Dispose();
            }
            else
            {
                rs.Close();
                cmd.Dispose();
                Label1.Text = "Invalid Account Number / IFSC Code....";
                return;
            }

            float pamount = float.Parse(TextBox7.Text);
            if (pamount > amount)
            {
                Label1.Text = "InSufficient Balance.First Update Your Balance.....";
                return;
            }

            cmd = new SqlCommand("insert into ptable values(@bid,@uname,@pdate,@totalamount,@accno,@ifsccode)", con);
            cmd.Parameters.AddWithValue("bid", TextBox2.Text);
            cmd.Parameters.AddWithValue("uname", TextBox1.Text);
            cmd.Parameters.AddWithValue("pdate", TextBox3.Text);
            cmd.Parameters.AddWithValue("totalamount", TextBox7.Text);
            cmd.Parameters.AddWithValue("accno", TextBox8.Text);
            cmd.Parameters.AddWithValue("ifsccode", TextBox9.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("update hbtable set pstatus='Paid' where bid=@bid", con);
            cmd.Parameters.AddWithValue("bid", TextBox2.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("update btable set amount=amount-@amount where uname=@uname and accno=@accno and ifsccode=@ifsccode", con);
            cmd.Parameters.AddWithValue("amount", TextBox7.Text);
            cmd.Parameters.AddWithValue("uname", TextBox1.Text);
            cmd.Parameters.AddWithValue("accno", TextBox8.Text);
            cmd.Parameters.AddWithValue("ifsccode", TextBox9.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            Label1.Text = "Amount Payment Details Inserted.....";





        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}