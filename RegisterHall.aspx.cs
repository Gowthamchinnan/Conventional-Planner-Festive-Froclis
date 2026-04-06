using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class RegisterHall : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
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
                    autonumber();
                }
            }

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }

    void autonumber()
    {
        cmd = new SqlCommand("select isnull(max(hid),0)+1 from htable ", con);
        TextBox2.Text = cmd.ExecuteScalar().ToString();
        cmd.Dispose();
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
                    FileUpload1.SaveAs(Server.MapPath("HImage\\" + fname1));
                    Image1.ImageUrl = ("HImage\\" + fname1);
                    ViewState.Add("HallImage", fname1);
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
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        try 
        {
            if (ViewState["HallImage"] != null)
            {
                if (DropDownList1.SelectedIndex == 0)
                {
                    Label1.Text = "Select Hall Type.....";
                    return;
                }

                cmd = new SqlCommand("select hid from htable where hid=@hid", con);
                cmd.Parameters.AddWithValue("hid", TextBox2.Text);
                rs = cmd.ExecuteReader();
                bool b = rs.Read();
                rs.Close();
                cmd.Dispose();
                if (b)
                {
                    Label1.Text = "HallID Already Found.....";
                    return;
                }

                cmd = new SqlCommand("insert into htable values(@uname,@hid,@hname,@htype,@hcapacity,@haddress,@hcity,@rent,@aamount,@himage)", con);
                cmd.Parameters .AddWithValue ("uname",TextBox1 .Text );
                cmd.Parameters .AddWithValue ("hid",TextBox2 .Text );
                cmd.Parameters .AddWithValue ("hname",TextBox3 .Text );
                cmd.Parameters .AddWithValue ("htype",DropDownList1 .SelectedItem .Text );
                cmd.Parameters .AddWithValue ("hcapacity",TextBox4 .Text );
                cmd.Parameters .AddWithValue ("haddress",TextBox5 .Text );
                cmd.Parameters .AddWithValue ("hcity",TextBox6 .Text );
                cmd.Parameters .AddWithValue ("rent",TextBox7 .Text );
                cmd.Parameters .AddWithValue ("aamount",TextBox8 .Text );
                cmd.Parameters .AddWithValue ("himage",ViewState ["HallImage"].ToString ());
                cmd.ExecuteNonQuery ();
                cmd.Dispose ();
                Label1.Text = "Hall Registration Details Inserted.....";


            }

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        TextBox2.Text = "";
        TextBox3.Text = "";
        DropDownList1.SelectedIndex = 0;
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox8.Text = "";
        ViewState["HallImage"] = null;
        Image1.ImageUrl = "";

        autonumber();
    }
}