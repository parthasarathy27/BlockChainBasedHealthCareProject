using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class PatientLogin : System.Web.UI.Page
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

            cmd = new SqlCommand("select * from ptable where pid=@pid and pword=@pword", con);

            cmd.Parameters.AddWithValue("pid", TextBox1.Text);
            cmd.Parameters.AddWithValue("pword", TextBox2.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Session.Add("PID", TextBox1.Text);
                Response.Redirect("PatientViewMedicalSchemeDetails.aspx");
            }
            else
            {
                Label1.Text = "Invalid Patient ID or Password.....";
            }
         
            
           
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}