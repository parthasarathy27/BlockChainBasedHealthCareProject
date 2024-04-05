using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class InsuranceCompanyRegistration : System.Web.UI.Page
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
            if (!IsPostBack)
                autonumber();
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }

    void autonumber()
    {
        cmd = new SqlCommand("select isnull(max(iid), 0)+1 from itable", con);
        TextBox1.Text = cmd.ExecuteScalar().ToString();
        cmd.Dispose();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {

            cmd = new SqlCommand("select iid from itable where iid=@iid", con);
            cmd.Parameters.AddWithValue("iid", TextBox1.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "Insurer ID Already Found.....";
                return;
            }

            cmd = new SqlCommand("insert into itable values(@iid,@iname,@cname,@crno,@caddress,@mno,@emailid,@uname,@pword,@status)", con);
            cmd.Parameters .AddWithValue ("iid",TextBox1 .Text );
            cmd.Parameters .AddWithValue ("iname",TextBox2 .Text );
            cmd.Parameters .AddWithValue ("cname",TextBox3 .Text );
            cmd.Parameters .AddWithValue ("crno",TextBox4 .Text );
            cmd.Parameters .AddWithValue ("caddress",TextBox5 .Text );
            cmd.Parameters .AddWithValue ("mno",TextBox6 .Text );
            cmd.Parameters .AddWithValue ("emailid",TextBox7 .Text );
            cmd.Parameters .AddWithValue ("uname",TextBox8 .Text );
            cmd.Parameters .AddWithValue ("pword",TextBox9 .Text );
            cmd.Parameters .AddWithValue ("status","Register");
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "Register New Insurance Company Details......";

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";        
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox9.Text = "";        
        autonumber();
        TextBox2.Focus();
    }
}