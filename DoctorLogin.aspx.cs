using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class DoctorLogin : System.Web.UI.Page
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

            cmd = new SqlCommand("select * from dtable where  uname=@uname and pword=@pword", con);
           
            cmd.Parameters.AddWithValue("uname", TextBox1.Text);
            cmd.Parameters.AddWithValue("pword", TextBox2.Text);
            rs = cmd.ExecuteReader();
            string status = "";
            int did = 0;
            if (rs.Read())
            {
                did = int.Parse(rs["did"].ToString());
                status = rs["status"].ToString();
                rs.Close();
                cmd.Dispose();
            }
            else
            {
                rs.Close();
                cmd.Dispose();
                Label1.Text = "Invalid UserID Or Password.....";
                return;
            }

            if (status.Equals("Register"))
            {
                Label1.Text = "Your Status is Register.Process is Going on.Please Wait.....";
                return;
            }
            else if (status.Equals("Rejected"))
            {
                Label1.Text = "Your Status is Rejected.You are not Login.....";
                return;
            }

            else if (status.Equals("Accepted"))
            {

                Session.Add("DID", did );
                Response.Redirect("DoctorViewProfile.aspx");
            }


        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}