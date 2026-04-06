using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class NewStudio : System.Web.UI.Page
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
            cmd = new SqlCommand("select isnull(max(studioid), 0)+1 from studiotable", con);
            int studioid = int.Parse(cmd.ExecuteScalar().ToString());
            cmd.Dispose();

            cmd = new SqlCommand("insert into studiotable values (@studioid,@studioname,@address,@emailid,@mno)", con);
            cmd.Parameters .AddWithValue ("studioid", studioid );
            cmd.Parameters .AddWithValue ("studioname",TextBox1 .Text );
            cmd.Parameters .AddWithValue ("address",TextBox2 .Text );
            cmd.Parameters .AddWithValue ("emailid",TextBox3 .Text );
            cmd.Parameters .AddWithValue ("mno",TextBox4 .Text );
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "New Studio Details Inserted.....";


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
    
        TextBox1.Focus();
    }
}