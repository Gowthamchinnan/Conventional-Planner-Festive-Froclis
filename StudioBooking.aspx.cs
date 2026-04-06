using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class StudioBooking : System.Web.UI.Page
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
            Menu m4 = (Menu)Master.FindControl("Menu4");
            m4.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
            {
                if (Session["UName"] != null && Request.QueryString.Get("BID") != null)
                {
                    TextBox1.Text = Request.QueryString.Get("BID");
                    TextBox2.Text = Session["UName"].ToString();
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
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridView1.Visible = false;
            if (DropDownList1.SelectedIndex == 0)
            {
                Label1.Text = "Select Studio Name.....";
                return;
            }

            adp = new SqlDataAdapter("select * from packagetable where studioid=@studioid", con);
            adp.SelectCommand.Parameters.AddWithValue("studioid", DropDownList1.SelectedItem.Value );
            dt = new DataTable();
            adp.Fill(dt);
            GridView1.Visible = true;
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
            HiddenField1.Value = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            if (e.CommandName == "ss")
            {
                int rindex = int.Parse(e.CommandArgument.ToString());
                HiddenField1.Value =GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString();
                TextBox3.Text = GridView1.Rows[rindex].Cells[0].Text;
               
               
                TextBox4.Text = GridView1.Rows[rindex].Cells[1].Text;
                TextBox5.Text = GridView1.Rows[rindex].Cells[2].Text;
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

            cmd = new SqlCommand("insert into sbtable values(@bid,@studioid,@studioname,@packid,@packname,@packdesc,@amount)", con);
            cmd.Parameters.AddWithValue("bid", TextBox1.Text);
            cmd.Parameters .AddWithValue ("studioid",DropDownList1 .SelectedItem .Value );
            cmd.Parameters .AddWithValue ("studioname",DropDownList1 .SelectedItem .Text );
            cmd.Parameters .AddWithValue ("packid",HiddenField1 .Value );
            cmd.Parameters .AddWithValue ("packname",TextBox3 .Text );
            cmd.Parameters .AddWithValue ("packdesc",TextBox4 .Text );
            cmd.Parameters .AddWithValue ("amount",TextBox5 .Text );
            cmd.ExecuteNonQuery();
            cmd.Dispose();


            cmd = new SqlCommand("update hbtable1 set samount=@samount where bid=@bid", con);
            cmd.Parameters.AddWithValue("samount", TextBox5 .Text );
            cmd.Parameters.AddWithValue("bid", TextBox1.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "Booking Details Inserted.....";      
            if (checkmoisoftbooking())
            {
                LinkButton2.Text = "Moisoft Booking";
            }
            else
            {
                LinkButton2.Text = "Amount Payment";
            }



        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }


    }
   

    bool checkmoisoftbooking()
    {
        bool b = false;
        cmd = new SqlCommand("select moption from hbtable where bid=@bid", con);
        cmd.Parameters.AddWithValue("bid", TextBox1.Text);
        rs = cmd.ExecuteReader();
        string moption = "";
        if (rs.Read())
        {
            moption = rs["moption"].ToString();
            rs.Close();
            cmd.Dispose();
        }
        else
        {
            rs.Close();
            cmd.Dispose();
            b = false;

        }
        if (moption.ToLower().Equals("yes"))
            b = true;
        else
            b = false;

        return b;

    }



    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        try
        {
          

            if (LinkButton2.Text.Equals("Amount Payment"))
            {
                Response.Redirect("AmountPayment.aspx");
            }
            else if (LinkButton2.Text.Equals("Moisoft Booking"))
            {
                Response.Redirect("MoisoftBooking.aspx?BID=" + TextBox1.Text);

            }


        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}