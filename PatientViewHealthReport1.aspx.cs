using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class PatientViewHealthReport1 : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
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
            cmd = new SqlCommand("select * from ptable where pid=@pid and pkey=@pkey", con);
            cmd.Parameters.AddWithValue("pid", TextBox1.Text);
            cmd.Parameters.AddWithValue("pkey", TextBox2.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b==false )
            {
                Label1.Text = "Your Secret Key is Invalid......";
                return;
            }

            Response.Redirect("PatientViewHealthReport2.aspx");


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
                Label1.Text = "Record Not Found.check PTable....";
                return;
            }
            Label1.Text = "Your Private Key is :" + pkey;

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }


    }
}