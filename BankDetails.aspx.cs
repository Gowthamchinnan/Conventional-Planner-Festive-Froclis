using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class BankDetails : System.Web.UI.Page
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
                }
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
            cmd = new SqlCommand("select  * from btable where accno=@accno", con);
            cmd.Parameters.AddWithValue("accno", TextBox4.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "Account Number Already Found.....";
                return;
            }
            cmd = new SqlCommand("select  * from btable where ifsccode=@ifsccode", con);
            cmd.Parameters.AddWithValue("accno", TextBox4.Text);
            cmd.Parameters.AddWithValue("ifsccode", TextBox5.Text);
            rs = cmd.ExecuteReader();
            b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "IFSC Code Already Found.....";
                return;
            }
            cmd = new SqlCommand("insert into btable values(@uname,@bname,@baddress,@accno,@ifsccode,@amount)", con);
            cmd.Parameters .AddWithValue ("uname",TextBox1 .Text );
            cmd.Parameters .AddWithValue ("bname",TextBox2 .Text );
            cmd.Parameters .AddWithValue ("baddress",TextBox3 .Text );
            cmd.Parameters .AddWithValue ("accno",TextBox4 .Text );
            cmd.Parameters .AddWithValue ("ifsccode",TextBox5 .Text );
            cmd.Parameters .AddWithValue ("amount",TextBox6 .Text );
            cmd.ExecuteNonQuery ();
            cmd.Dispose ();
            Label1.Text = "Account Details Inserted....";

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}