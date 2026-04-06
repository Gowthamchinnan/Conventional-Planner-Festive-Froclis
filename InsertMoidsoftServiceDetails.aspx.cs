using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class InsertMoidsoftServiceDetails : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    SqlDataAdapter adp;
    DataTable dt;
    void bindgrid1()
    {
        adp = new SqlDataAdapter("select * from moitable ", con);          dt = new DataTable();
        adp.Fill(dt);
        GridView1.Visible = true;
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
            HiddenField1.Value = "";
            int mid = int.Parse(GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());
            HiddenField1.Value = mid.ToString();
            bindgrid2(mid);



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
          
            cmd = new SqlCommand("select isnull(max(msid), 1000)+1 from mstable", con);
            int msid = int.Parse(cmd.ExecuteScalar().ToString());
            cmd.Dispose();

            cmd = new SqlCommand("insert into mstable values(@mid,@msid,@icount,@scost,@scount)", con);
            cmd.Parameters.AddWithValue("mid", HiddenField1.Value);
            cmd.Parameters.AddWithValue("msid", msid);
            cmd.Parameters.AddWithValue("icount", TextBox1.Text);
            cmd.Parameters.AddWithValue("scost", TextBox2.Text);
            cmd.Parameters.AddWithValue("scount", TextBox3.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "Moi Service Details Successfully Inserted.....";
            bindgrid2(int.Parse (HiddenField1 .Value ));

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
   
}