using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class NewCatering : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            Menu m2 = (Menu)Master.FindControl("Menu2");
            m2.Visible = true;
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
            cmd = new SqlCommand("select csname from ctable where csname=@csname", con);
            cmd.Parameters.AddWithValue("csname", TextBox1.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "Service Name Already Found.....";
                return;
            }

            cmd = new SqlCommand("insert into ctable values (@csname,@name,@address,@city,@cno,@mailid)", con);
            cmd.Parameters.AddWithValue("csname", TextBox1.Text);
            cmd.Parameters.AddWithValue("name", TextBox2.Text);
            cmd.Parameters.AddWithValue("address", TextBox3.Text);
            cmd.Parameters.AddWithValue("city", TextBox4.Text);
            cmd.Parameters.AddWithValue("cno", TextBox5.Text);
            cmd.Parameters.AddWithValue("mailid", TextBox6.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "New Catering Details Inserted.....";


        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox1.Focus();
    }
}