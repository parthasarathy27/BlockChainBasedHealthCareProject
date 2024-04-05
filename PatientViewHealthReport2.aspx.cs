using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;

public partial class PatientViewHealthReport2 : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    SqlDataAdapter adp;
    DataTable dt;

    void bindgrid()
    {
        cmd = new SqlCommand("select pkey from ptable where pid=@pid", con);
        cmd.Parameters.AddWithValue("pid", TextBox1.Text);
        rs = cmd.ExecuteReader();
        string pkey = "";
        if (rs.Read())
        {
            pkey = rs["pkey"].ToString();
            rs.Close();
            cmd.Dispose();
        }
        else
        {
            rs.Close();
            cmd.Dispose();
            Label1.Text = "Patient ID Not Found.Check Ptable....";
            return;
        }


        char[] c = pkey.ToCharArray();
        byte b = (byte)c[3];

        DirectoryInfo d1 = new DirectoryInfo(Server.MapPath("Temp"));
        FileInfo[] f1 = d1.GetFiles();
        foreach (FileInfo f2 in f1)
            f2.Delete();

        adp = new SqlDataAdapter("select * from hrtable where pid=@pid order by tdate desc", con);
        adp.SelectCommand.Parameters.AddWithValue("pid", TextBox1.Text);
        dt = new DataTable();
        adp.Fill(dt);
        for (int i = 0; i < dt.Rows.Count; i++)
        {

            string xrayfname = dt.Rows[i]["xrayfname"].ToString();
            byte[] xraycontent = (byte[])dt.Rows[i]["xraycontent"];

            int j = 0;
            for (j = 0; j < xraycontent.Length; j++)
            {
                xraycontent[j] = (byte)(xraycontent[j] - b);
            }

            FileStream fs = new FileStream(Server.MapPath("Temp/") + xrayfname, FileMode.Create, FileAccess.Write);
            fs.Write(xraycontent, 0, xraycontent.Length);
            fs.Close();

            string scanfname = dt.Rows[i]["scanfname"].ToString();
            byte[] scancontent = (byte[])dt.Rows[i]["scancontent"];

            for (j = 0; j < scancontent.Length; j++)
            {
                scancontent[j] = (byte)(scancontent[j] - b);
            }

            fs = new FileStream(Server.MapPath("Temp/") + scanfname, FileMode.Create, FileAccess.Write);
            fs.Write(scancontent, 0, scancontent.Length);
            fs.Close();

            string ecgfname = dt.Rows[i]["ecgfname"].ToString();
            byte[] ecgcontent = (byte[])dt.Rows[i]["ecgcontent"];

            for (j = 0; j < ecgcontent.Length; j++)
            {
                ecgcontent[j] = (byte)(ecgcontent[j] - b);
            }

            fs = new FileStream(Server.MapPath("Temp/") + ecgfname, FileMode.Create, FileAccess.Write);
            fs.Write(ecgcontent, 0, ecgcontent.Length);
            fs.Close();
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            Menu m5 = (Menu)Master.FindControl("Menu5");
            m5.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
            {
                if (Session["PID"] != null)
                {
                    TextBox1.Text = Session["PID"].ToString(); 
                    bindgrid();

                }
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}