using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class InsertPackageDetails : System.Web.UI.Page
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
                cmd = new SqlCommand("select studioid,studioname from studiotable", con);
                rs = cmd.ExecuteReader();
                DropDownList1.DataSource = rs;
                DropDownList1.DataValueField = "studioid";
                DropDownList1.DataTextField = "studioname";
                DropDownList1.DataBind();
                rs.Close();
                cmd.Dispose();
                DropDownList1.Items.Insert(0, "Select");
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    void bindgrid()
    {

        adp = new SqlDataAdapter("select * from packagetable where studioid=@studioid", con);
        adp.SelectCommand.Parameters.AddWithValue("studioid", DropDownList1.SelectedItem.Value );
     
        dt = new DataTable();
        adp.Fill(dt);
        GridView1.Visible = true;
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridView1.Visible = false;
           
            if (DropDownList1.SelectedIndex == 0)
            {
                Label1.Text = "Select StudioName....";
                return;
            }
         
            bindgrid();



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
            if (DropDownList1.SelectedIndex == -1)
            {
                Label1.Text = "Select Studio ID.....";
                return;
            }
            cmd = new SqlCommand("select isnull(max(packid), 100)+1 from packagetable", con);
            int packid = int.Parse(cmd.ExecuteScalar().ToString());
            cmd.Dispose();

            cmd = new SqlCommand("insert into packagetable values(@studioid,@studioname,@packid,@packname,@packdesc,@amount)", con);
            cmd.Parameters .AddWithValue ("studioid",DropDownList1 .SelectedItem .Value );
            cmd.Parameters .AddWithValue ("studioname",DropDownList1 .SelectedItem .Text );
            cmd.Parameters .AddWithValue ("packid",packid );
            cmd.Parameters .AddWithValue ("packname",TextBox1 .Text );
            cmd.Parameters .AddWithValue ("packdesc",TextBox2 .Text );
            cmd.Parameters .AddWithValue ("amount",TextBox3 .Text );
            cmd.ExecuteNonQuery ();
            cmd.Dispose ();
            Label1.Text = "Package Details Successfully Inserted.....";
            bindgrid();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox1.Focus();

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}