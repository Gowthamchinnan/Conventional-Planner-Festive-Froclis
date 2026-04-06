using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class ViewEditStudio : System.Web.UI.Page
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
            Menu m2 = (Menu)Master.FindControl("Menu2");
            m2.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
            {
                bindgrid();
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }

    void bindgrid()
    {
        adp = new SqlDataAdapter("select * from studiotable ", con);

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
            int studioid= int.Parse (GridView1.DataKeys[e.RowIndex].Value.ToString());
            TextBox studioname = (TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0];
            TextBox address = (TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0];
            TextBox emailid = (TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0];            
            TextBox mno = (TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0];          



            cmd = new SqlCommand("update studiotable set studioname=@studioname,address=@address, emailid=@emailid,mno=@mno where studioid=@studioid", con);
            cmd.Parameters .AddWithValue ("studioname",studioname );
             cmd.Parameters .AddWithValue ("address",address );
             cmd.Parameters .AddWithValue ("emailid",emailid );
             cmd.Parameters .AddWithValue ("mno",mno );
             cmd.Parameters .AddWithValue ("studioid",studioid );          
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