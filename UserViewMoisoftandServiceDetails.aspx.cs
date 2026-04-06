using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class UserViewMoisoftandServiceDetails : System.Web.UI.Page
{
    SqlConnection con;
    SqlDataAdapter adp;
    DataTable dt;
    void bindgrid1()
    {
        adp = new SqlDataAdapter("select * from moitable", con);
        dt = new DataTable();
        adp.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
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
                bindgrid1();
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }

    void bindgrid2(int mid)
    {
        adp = new SqlDataAdapter("select * from mstable where mid=@mid", con);
        adp.SelectCommand.Parameters.AddWithValue("mid", mid);
        dt = new DataTable();
        adp.Fill(dt);
        GridView2.Visible = true;
        GridView2.DataSource = dt;
        GridView2.DataBind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridView2.Visible = false;
            if (e.CommandName == "vs")
            {
                int mid = int.Parse(GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());
                bindgrid2(mid);
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}