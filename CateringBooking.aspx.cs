using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class CateringBooking : System.Web.UI.Page
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
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            GridView1.Visible = false;
            if (RadioButtonList1.SelectedIndex == -1 || DropDownList1.SelectedIndex == 0)
            {
                Label1.Text = "Select All Option.....";
                return;
            }

            adp = new SqlDataAdapter("select * from cstable where ftype=@ftype and fcategory=@fcategory", con);
            adp.SelectCommand.Parameters.AddWithValue("ftype", RadioButtonList1.SelectedItem.Text);
            adp.SelectCommand.Parameters.AddWithValue("fcategory", DropDownList1.SelectedItem.Text);
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
                int rindex =int.Parse (e.CommandArgument .ToString ());
                TextBox3 .Text = GridView1.Rows[rindex].Cells[0].Text;
                TextBox4 .Text = GridView1.Rows[rindex].Cells[1].Text;
                TextBox5 .Text = GridView1.Rows[rindex].Cells[2].Text;


            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void TextBox6_TextChanged(object sender, EventArgs e)
    {
        try 
        {
            float spcost = float.Parse(TextBox5.Text);
            int tperson = int.Parse(TextBox6.Text);
            float totalamount = spcost * tperson;
            TextBox7.Text = totalamount.ToString();
        }

        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }


    }

    bool checkdecorationbooking()
    {
        bool b = false;
        cmd = new SqlCommand("select doption from hbtable where bid=@bid", con);
        cmd.Parameters.AddWithValue("bid", TextBox1.Text);
        rs = cmd.ExecuteReader();
        string doption = "";
        if (rs.Read())
        {
            doption = rs["doption"].ToString();
            rs.Close();
            cmd.Dispose();
        }
        else
        {
            rs.Close();
            cmd.Dispose();
            b = false;

        }
        if (doption.ToLower().Equals("yes"))
            b = true;
        else
            b = false;
        return b;

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
            if (RadioButtonList1.SelectedIndex == -1 || DropDownList1.SelectedIndex == 0)
            {
                Label1.Text = "Select All Options.....";
                return;
            }

            cmd = new SqlCommand("insert into cbtable values(@bid,@csname,@ftype,@fcategory,@fitems,@cost,@noperson,@totalamount)", con);
            cmd.Parameters .AddWithValue ("bid",TextBox1 .Text );
            cmd.Parameters .AddWithValue ("csname",TextBox3 .Text );
            cmd.Parameters .AddWithValue ("ftype",RadioButtonList1 .SelectedItem .Text );
            cmd.Parameters .AddWithValue ("fcategory",DropDownList1 .SelectedItem .Text );
            cmd.Parameters .AddWithValue ("fitems",TextBox4 .Text );
            cmd.Parameters .AddWithValue ("cost",TextBox5 .Text );
            cmd.Parameters .AddWithValue ("noperson",TextBox6 .Text);
            cmd.Parameters .AddWithValue ("totalamount",TextBox7 .Text );
            cmd.ExecuteNonQuery ();
            cmd.Dispose ();

            adp = new SqlDataAdapter("select * from cbtable where bid=@bid", con);
            adp.SelectCommand.Parameters.AddWithValue("bid", TextBox1.Text);
            dt = new DataTable();
            adp.Fill(dt);
            GridView2.DataSource = dt;
            GridView2.DataBind();

            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";


            if (checkdecorationbooking() )
            {
                LinkButton3.Text  = "Decoration Booking";
            }
            else if (checkstudiobooking()) 
            {
                LinkButton3.Text = "Studio Booking";
            }

            else if (checkmoisoftbooking())
            {
                LinkButton3.Text = "Moisoft Booking";
            }
            else
            {
                LinkButton3.Text = "Amount Payment";
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        try 
        {

            cmd = new SqlCommand("select isnull(sum(totalamount), 0) from cbtable where bid=@bid", con);
            cmd.Parameters.AddWithValue("bid", TextBox1.Text);
            float totamount = float.Parse(cmd.ExecuteScalar().ToString());
            cmd.Dispose();

            cmd = new SqlCommand("update hbtable1 set camount=@camount where bid=@bid", con);
            cmd.Parameters.AddWithValue("camount", totamount);
            cmd.Parameters.AddWithValue("bid", TextBox1.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "Booking Details Inserted.....";
            if (LinkButton3.Text.Equals("Amount Payment"))
            {
                
                Response.Redirect("AmountPayment.aspx");
            }
            else if (LinkButton3 .Text .Equals ("Decoration Booking"))
            {
                Response.Redirect("DecorationBooking.aspx?BID=" + TextBox1.Text);

            }
            else if (LinkButton3.Text.Equals("Studio Booking"))
            {
                Response.Redirect("StudioBooking.aspx?BID=" + TextBox1.Text);

            }

            else if (LinkButton3.Text.Equals("Moisoft Booking"))
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