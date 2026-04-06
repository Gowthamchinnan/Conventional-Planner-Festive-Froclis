using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class InsertDecorationStyle : System.Web.UI.Page
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
            if (!IsPostBack )
            {
                cmd=new SqlCommand ("select dsname from dtable", con );
                rs=cmd.ExecuteReader ();
                DropDownList1 .DataSource =rs ;
                DropDownList1 .DataTextField ="dsname";
                DropDownList1 .DataBind ();
                rs.Close ();
                cmd.Dispose ();
                DropDownList1 .Items .Insert (0,"Select");
            }
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
            Image1.ImageUrl = "";
            if (FileUpload1.HasFile)
            {
                string fname = FileUpload1.FileName;
                string ext = fname.Substring(fname.LastIndexOf(".")).ToLower();
                if (ext.Equals(".jpg") || ext.Equals(".png") || ext.Equals(".gif") || ext.Equals(".jpeg"))
                {
                    string fname1 = DateTime.Now.Ticks + "_" + fname;
                    FileUpload1.SaveAs(Server.MapPath("DImage\\" + fname1));
                    Image1.ImageUrl = ("DImage\\" + fname1);
                    ViewState.Add("DImage", fname1);
                }
                else
                    Label1.Text = "Select Only .jpg Or .png Or .gif Files.....";

            }
            else
                Label1.Text = "Select File Name....";

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }

    void bindgrid()
    {

        adp = new SqlDataAdapter("select * from dstable where dsname=@dsname and dtype=@dtype", con);
        adp.SelectCommand.Parameters.AddWithValue("dsname", DropDownList1.SelectedItem.Text);
        adp.SelectCommand.Parameters.AddWithValue("dtype", DropDownList2.SelectedItem.Text);
        dt = new DataTable();
        adp.Fill(dt);
        GridView1.Visible = true;
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
  
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try 
        {
            GridView1.Visible = false;
            if (DropDownList1.SelectedIndex == 0 || DropDownList2.SelectedIndex == 0)
            {
                Label1.Text = "Select All Options....";
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
            if (ViewState["DImage"] != null)
            {
                if (DropDownList1.SelectedIndex == 0 || DropDownList2.SelectedIndex == 0)
                {
                    Label1.Text = "Select All Options....";
                    return;
                }

                cmd = new SqlCommand("insert into dstable values(@dsname,@dtype,@dimage,@dcost)", con);
                cmd.Parameters.AddWithValue("dsname", DropDownList1.SelectedItem.Text);
                cmd.Parameters.AddWithValue("dtype", DropDownList2.SelectedItem.Text);
                cmd.Parameters.AddWithValue("dimage", ViewState["DImage"].ToString());
                cmd.Parameters.AddWithValue("dcost", TextBox1.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                bindgrid();
                Label1.Text = "Record Inserted....";
                Image1.ImageUrl = "";
                TextBox1.Text = "";
                ViewState["DImage"] = null;
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}