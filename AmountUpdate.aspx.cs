using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class AmountUpdate : System.Web.UI.Page
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
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

        try 
        {
            cmd = new SqlCommand("select amount from btable where uname=@uname and accno=@accno", con);
            cmd.Parameters.AddWithValue("uname", Session["UName"].ToString());
            cmd.Parameters.AddWithValue("accno", TextBox2.Text);
            rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                TextBox3.Text = rs["amount"].ToString();
                rs.Close();
                cmd.Dispose();
            }
            else
            {
                rs.Close();
                cmd.Dispose();
                Label1.Text = "Invalid Account Number.....";

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
            cmd = new SqlCommand("select amount from btable where uname=@uname and accno=@accno", con);
            cmd.Parameters.AddWithValue("uname", Session["UName"].ToString());
            cmd.Parameters.AddWithValue("accno", TextBox2.Text);
            rs=cmd.ExecuteReader ();
            bool b =rs.Read ();
            rs.Close();
            cmd.Dispose();
            if(b==false )
            {
                Label1.Text = "Invalid Account Number.....";
                return;
            }

            cmd = new SqlCommand("update btable set amount=amount + @amount where uname=@uname and accno=@accno", con);
            cmd.Parameters.AddWithValue("amount", TextBox4.Text);
            cmd.Parameters.AddWithValue("uname", TextBox1.Text);
            cmd.Parameters.AddWithValue("accno", TextBox2.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "Amount Updated......";


            
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}