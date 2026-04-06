using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class DeleteAllRecords : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            
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
            cmd = new SqlCommand("delete from btable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from cbtable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from cstable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from ctable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from dbtable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from dstable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from dtable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from hbtable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from hbtable1", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cmd = new SqlCommand("delete from hbtable2", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from htable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from mbtable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from moitable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from mstable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();


            cmd = new SqlCommand("delete from otable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from packagetable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from ptable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from sbtable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from studiotable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from utable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            DirectoryInfo d1 = new DirectoryInfo(Server.MapPath("DImage"));

            FileInfo[] f1 = d1.GetFiles();
            foreach (FileInfo f2 in f1)
                f2.Delete();

            d1 = new DirectoryInfo(Server.MapPath("HImage"));

             f1 = d1.GetFiles();
            foreach (FileInfo f2 in f1)
                f2.Delete();

            Label1.Text = "Table Records are Deleted.....";

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}