using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            Menu m1 = (Menu)Master.FindControl("Menu1");
            m1.Visible = true;
            
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
            if (TextBox1.Text.Equals("Admin") && TextBox2.Text.Equals("Admin"))
                Response.Redirect("ViewDoctorDetails.aspx");
            else
                Label1.Text = "Invalid UserName or Password.....";


        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}