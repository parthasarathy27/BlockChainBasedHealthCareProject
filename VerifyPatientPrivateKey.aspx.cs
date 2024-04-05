using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class VerifyPatientPrivateKey : System.Web.UI.Page
{
    //pid,pname, sugar, bp, health status, xray,scan,ecg,surgery, medicine details ,prescribed doctor, treatmentplace, treatment date, treatment type treatment amount

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
                if (Session["DID"] != null && Request .QueryString .Get ("ReqID")!=null && Request.QueryString.Get ("PID")!=null )
                {
                    TextBox1.Text = Session["DID"].ToString();
                    TextBox2.Text = Request.QueryString.Get("ReqID");
                    TextBox3.Text = Request.QueryString.Get("PID");
                    
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
            cmd = new SqlCommand("select * from reqtable where reqid=@reqid and pid=@pid and pkey=@pkey", con);
            cmd.Parameters.AddWithValue("reqid", TextBox2.Text);
            cmd.Parameters.AddWithValue("pid", TextBox3.Text);
            cmd.Parameters.AddWithValue("pkey", TextBox4.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b == false)
            {
                Label1.Text = "Patient Secret Key is Invalid.....";
                return;
            }
            Response.Redirect("ViewPatientHealthReport.aspx?ReqID=" + TextBox2.Text + "&PID=" + TextBox3.Text);

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}