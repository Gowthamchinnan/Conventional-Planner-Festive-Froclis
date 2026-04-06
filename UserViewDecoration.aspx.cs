using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class UserViewDecoration : System.Web.UI.Page
{
    SqlConnection con;
  
    SqlDataAdapter adp;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            Menu m4 = (Menu)Master.FindControl("Menu4");
            m4.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
           
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        try
        {
            GridView1.Visible = false;
            if (DropDownList1.SelectedIndex == 0 )
            {
                Label1.Text = "Select Decoration Type......";
                return;
            }

            adp = new SqlDataAdapter("select * from dstable where  dtype=@dtype", con);

            adp.SelectCommand.Parameters.AddWithValue("dtype", DropDownList1.SelectedItem.Text);
            dt = new DataTable();
            adp.Fill(dt);
            GridView1.Visible = true;
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}