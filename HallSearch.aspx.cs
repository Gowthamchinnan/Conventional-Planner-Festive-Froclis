using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class HallSearch : System.Web.UI.Page
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
                TextBox2.Text = DateTime.Now.ToString("dd-MMM-yyyy");
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
        Calendar1.Visible = true;
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        try
        {
            DateTime cdate = DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy"));
            DateTime sdate =DateTime .Parse ( Calendar1.SelectedDate.ToString("dd-MMM-yyyy"));
            TimeSpan ts = cdate.Subtract(sdate);
            int diff = ts.Days;
            if (diff > 0)
            {
                Label1.Text = "Selected Date Must Be > " + cdate.ToString("dd-MMM-yyyy");
                return;
            }
            Calendar1.Visible = false;
            TextBox2.Text = sdate.ToString("dd-MMM-yyyy");

        }
         
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        try 
        {
           
            adp = new  SqlDataAdapter("select * from htable where hid not in (select hid from hbtable where  bdate=@bdate)", con);
            adp.SelectCommand.Parameters.AddWithValue("bdate", TextBox2.Text);
            dt = new DataTable();
            adp.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "hb")
            {

                int hid = int.Parse(GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Values[0].ToString());
                string hname =GridView1 .DataKeys [int.Parse (e.CommandArgument .ToString ())].Values [1].ToString ();

                Response.Redirect("HallBooking.aspx?HallID=" + hid + "&HallName=" + hname +"&BookingDate="+TextBox2 .Text );

            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}