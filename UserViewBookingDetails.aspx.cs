using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class UserViewBookingDetails : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                if (Session["UName"] != null)
                {
                    TextBox1.Text = Session["UName"].ToString();
                    bindgrid();
                }
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }

    void bindgrid()
    {
        GridView2.Visible = false;
        GridView3.Visible = false;
        GridView4.Visible = false;
        GridView5.Visible = false;
        DetailsView1.Visible = false;
        Label2.Visible = false;
        Label3.Visible = false;
        Label4.Visible = false;
        Label5.Visible = false;
        Label6.Visible = false;



        adp = new SqlDataAdapter("select * from hbtable where uname=@uname", con);
        adp.SelectCommand.Parameters.AddWithValue("uname", TextBox1.Text);
        dt = new DataTable();
        adp.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();

        for (int i = 0; i < dt.Rows.Count; i++)
        {

            //8,9
            string coption = dt.Rows[i]["coption"].ToString();
            string doption = dt.Rows[i]["doption"].ToString();
            string soption = dt.Rows[i]["soption"].ToString();
            string moption = dt.Rows[i]["moption"].ToString();

            if (coption.ToLower().Equals("yes"))
                GridView1.Rows[i].Cells[10].Enabled = true;
            else
                GridView1.Rows[i].Cells[10].Enabled = false;

            if (doption.ToLower().Equals("yes"))
                GridView1.Rows[i].Cells[11].Enabled = true;
            else
                GridView1.Rows[i].Cells[11].Enabled = false;

            if (doption.ToLower().Equals("yes"))
                GridView1.Rows[i].Cells[12].Enabled = true;
            else
                GridView1.Rows[i].Cells[12].Enabled = false;

            if (doption.ToLower().Equals("yes"))
                GridView1.Rows[i].Cells[13].Enabled = true;
            else
                GridView1.Rows[i].Cells[13].Enabled = false;

        }

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int bid = int.Parse(GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());
            if (e.CommandName == "vc")
            {
                adp = new SqlDataAdapter("select * from cbtable where bid=@bid", con);
                adp.SelectCommand.Parameters.AddWithValue("bid", bid);
                dt = new DataTable();
                adp.Fill(dt);
                GridView2.Visible = true;
                Label2.Visible = true;
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
            else if (e.CommandName == "vd")
            {
                adp = new SqlDataAdapter("select * from dbtable where bid=@bid", con);
                adp.SelectCommand.Parameters.AddWithValue("bid", bid);
                dt = new DataTable();
                adp.Fill(dt);
                GridView3.Visible = true;
                Label3.Visible = true;
                GridView3.DataSource = dt;
                GridView3.DataBind();
            }

            else if (e.CommandName == "vs")
            {
                adp = new SqlDataAdapter("select * from sbtable where bid=@bid", con);
                adp.SelectCommand.Parameters.AddWithValue("bid", bid);
                dt = new DataTable();
                adp.Fill(dt);
                Label5.Visible = true;
                GridView4.Visible = true;
                GridView4.DataSource = dt;
                GridView4.DataBind();
            }

            else if (e.CommandName == "vm")
            {
                adp = new SqlDataAdapter("select * from mbtable where bid=@bid", con);
                adp.SelectCommand.Parameters.AddWithValue("bid", bid);
                dt = new DataTable();
                adp.Fill(dt);
                Label6.Visible = true;
                GridView5.Visible = true;
                GridView5.DataSource = dt;
                GridView5.DataBind();
            }


            adp = new SqlDataAdapter("select * from hbtable1 where bid=@bid", con);
            adp.SelectCommand.Parameters.AddWithValue("bid", bid);
            dt = new DataTable();
            adp.Fill(dt);
            DetailsView1.Visible = true;
            Label4.Visible = true;
            DetailsView1.DataSource = dt;
            DetailsView1.DataBind();



        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}