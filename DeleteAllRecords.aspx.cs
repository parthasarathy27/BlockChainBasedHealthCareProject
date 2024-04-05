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
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            Menu m1 = (Menu)Master.FindControl("Menu1");
            m1.Visible = true;
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

            DirectoryInfo d1 = new DirectoryInfo(Server.MapPath("Temp"));
            FileInfo[] f1 = d1.GetFiles();
            foreach (FileInfo f2 in f1)
                f2.Delete();

            cmd = new SqlCommand("delete from crtable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from dtable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from hrtable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from icrtable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from itable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from msatable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from mstable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from paytable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from ptable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from reqtable", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            Label1.Text = "All Table Records are Deleted.....";

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}