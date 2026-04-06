using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class ViewAccountDetails : System.Web.UI.Page
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
                    adp = new SqlDataAdapter("select * from btable where uname=@uname", con);
                    adp.SelectCommand.Parameters.AddWithValue("uname", Session["UName"].ToString());
                    dt = new DataTable();
                    adp.Fill(dt);
                    DetailsView1.DataSource = dt;
                    DetailsView1.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}