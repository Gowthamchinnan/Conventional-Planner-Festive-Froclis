using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class DecorationBooking : System.Web.UI.Page
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
                }
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try 
        {
            GridView1.Visible = false;
            if (DropDownList1.SelectedIndex == 0)
            {
                Label1.Text = "Select Decoration Type.....";
                return;
            }

            adp = new SqlDataAdapter("select * from dstable where dtype=@dtype", con);
            adp.SelectCommand.Parameters.AddWithValue("dtype", DropDownList1.SelectedItem.Text);
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
            if (e.CommandName == "ss")
            {
                int rindex=int.Parse (e.CommandArgument .ToString ());
                TextBox3.Text = GridView1.Rows[rindex].Cells[0].Text;
                string dimage = GridView1.DataKeys[rindex].Value.ToString();
                ViewState["DImage"] = dimage;
                Image1.ImageUrl = "~\\DImage\\" + dimage ;
                TextBox4.Text = GridView1.Rows[rindex].Cells[2].Text;
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
         
            cmd = new SqlCommand("insert into dbtable values(@bid,@dsname,@dtype,@dimage,@dcost)", con);
            cmd.Parameters .AddWithValue ("bid",TextBox1 .Text );
            cmd.Parameters .AddWithValue ("dsname",TextBox3 .Text );
            cmd.Parameters .AddWithValue ("dtype",DropDownList1 .SelectedItem .Text );
            cmd.Parameters .AddWithValue ("dimage",ViewState ["DImage"].ToString () );
            cmd.Parameters .AddWithValue ("dcost",TextBox4 .Text );
            cmd.ExecuteNonQuery ();
            cmd.Dispose ();


            adp = new SqlDataAdapter("select * from dbtable where bid=@bid", con);
            adp.SelectCommand.Parameters.AddWithValue("bid", TextBox1.Text);
            dt = new DataTable();
            adp.Fill(dt);
            GridView2.DataSource = dt;
            GridView2.DataBind();

            TextBox3.Text = "";
            TextBox4.Text = "";
            Image1.ImageUrl = "";

           
             if (checkstudiobooking())
            {
                LinkButton2.Text = "Studio Booking";
            }

            else if (checkmoisoftbooking())
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
    bool checkstudiobooking()
    {
        bool b = false;
        cmd = new SqlCommand("select soption from hbtable where bid=@bid", con);
        cmd.Parameters.AddWithValue("bid", TextBox1.Text);
        rs = cmd.ExecuteReader();
        string soption = "";
        if (rs.Read())
        {
            soption = rs["soption"].ToString();
            rs.Close();
            cmd.Dispose();
        }
        else
        {
            rs.Close();
            cmd.Dispose();
            b = false;

        }
        if (soption.ToLower().Equals("yes"))
            b = true;
        else
            b = false;

        return b;

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
            cmd = new SqlCommand("select isnull(sum(dcost), 0) from dbtable where bid=@bid", con);
            cmd.Parameters.AddWithValue("bid", TextBox1.Text);
            float dcost = float.Parse(cmd.ExecuteScalar().ToString());
            cmd.Dispose();

            cmd = new SqlCommand("update hbtable1 set damount=@damount where bid=@bid", con);
            cmd.Parameters.AddWithValue("damount", dcost);
            cmd.Parameters.AddWithValue("bid", TextBox1.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "Booking Details Inserted.....";
           // Response.Redirect("AmountPayment.aspx");

            if (LinkButton2.Text.Equals("Amount Payment"))
            {
                Response.Redirect("AmountPayment.aspx");
            }
           
            else if (LinkButton2.Text.Equals("Studio Booking"))
            {
                Response.Redirect("StudioBooking.aspx?BID=" + TextBox1.Text);

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