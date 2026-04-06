using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class UserRegistration : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            Menu m1 = (Menu)Master.FindControl("Menu1");
            m1.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
          
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
            cmd = new SqlCommand("select uname from otable where uname=@uname", con);
            cmd.Parameters.AddWithValue("uname", TextBox6.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "UserName Already Found....";
                return;
            }

            cmd = new SqlCommand("insert into utable values(@name,@gender,@address,@city,@cno,@mailid,@uname,@pword)", con);
            cmd.Parameters.AddWithValue("name", TextBox1.Text);
            cmd.Parameters.AddWithValue("gender", RadioButtonList1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("address", TextBox2.Text);
            cmd.Parameters.AddWithValue("city", TextBox3.Text);
            cmd.Parameters.AddWithValue("cno", TextBox4.Text);
            cmd.Parameters.AddWithValue("mailid", TextBox5.Text);
            cmd.Parameters.AddWithValue("uname", TextBox6.Text);
            cmd.Parameters.AddWithValue("pword", TextBox7.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Response.Redirect("UserLogin.aspx");
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}