using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class OwnerViewEditHallDetails : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    SqlDataAdapter adp;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            Menu m3 = (Menu)Master.FindControl("Menu3");
            m3.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
            {
                if (Session["OName"] != null)
                {
                    TextBox1.Text = Session["OName"].ToString();
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
        adp = new SqlDataAdapter("select * from htable where uname=@uname", con);
        adp.SelectCommand.Parameters.AddWithValue("uname", TextBox1.Text);
        dt = new DataTable();
        adp.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        bindgrid();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            int hid = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
            TextBox hname = (TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0];
            TextBox htype = (TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0];
            TextBox hcapacity = (TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0];
            TextBox haddress = (TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0];
            TextBox hcity = (TextBox)GridView1.Rows[e.RowIndex].Cells[5].Controls[0];
            TextBox rent = (TextBox)GridView1.Rows[e.RowIndex].Cells[6].Controls[0];
            TextBox aamount = (TextBox)GridView1.Rows[e.RowIndex].Cells[7].Controls[0];

            if (htype .Text .ToUpper().Equals ("AC")==false  &&  htype .Text .ToUpper().Equals ("NON AC") ==false )
            {
                Label1.Text = "Hall Type is AC/ Non AC .....";
                return;
            }

            cmd = new SqlCommand("update htable set hname=@hname ,htype=@htype, hcapacity=@hcapacity, haddress=@haddress,hcity=@hcity,rent=@rent , aamount=@aamount where hid=@hid", con);
            cmd.Parameters.AddWithValue("hname", hname.Text);
            cmd.Parameters.AddWithValue("htype", htype.Text);
            cmd.Parameters.AddWithValue("hcapacity", hcapacity.Text);
            cmd.Parameters.AddWithValue("haddress", haddress.Text);
            cmd.Parameters.AddWithValue("hcity", hcity.Text);
            cmd.Parameters.AddWithValue("rent", rent.Text);
            cmd.Parameters.AddWithValue("aamount", aamount.Text);
            cmd.Parameters.AddWithValue("hid", hid);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            GridView1.EditIndex = -1;
            bindgrid();


           
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        bindgrid();
    }
}