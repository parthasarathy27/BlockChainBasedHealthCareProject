using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class DoctorRegistration : System.Web.UI.Page
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
        cmd = new SqlCommand("select isnull(max(did), 100)+1 from dtable", con);
        TextBox1.Text = cmd.ExecuteScalar().ToString();
        cmd.Dispose();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            if (RadioButtonList1.SelectedIndex == -1)
            {
                Label1.Text = "Select Gender......";
                return;
            }

            cmd = new SqlCommand("select did from dtable where did=@did", con);
            cmd.Parameters.AddWithValue("did", TextBox1.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "DoctorID Already Found.....";
                return;
            }
          

            cmd = new SqlCommand("insert into dtable values(@did,@dname,@gender,@age,@address,@mno,@emailid,@qualification,@certificateno,@experience,@specialist,@uname,@pword,@status)", con);
            cmd.Parameters .AddWithValue ("did",TextBox1 .Text );
            cmd.Parameters .AddWithValue ("dname",TextBox2 .Text );
            cmd.Parameters .AddWithValue ("gender",RadioButtonList1 .SelectedItem .Text );
            cmd.Parameters .AddWithValue ("age",TextBox3 .Text );
            cmd.Parameters .AddWithValue ("address",TextBox4 .Text );
            cmd.Parameters .AddWithValue ("mno",TextBox5 .Text );
            cmd.Parameters .AddWithValue ("emailid",TextBox6 .Text );
            cmd.Parameters .AddWithValue ("qualification",TextBox7 .Text );
            cmd.Parameters .AddWithValue ("certificateno",TextBox8 .Text );
            cmd.Parameters .AddWithValue ("experience",TextBox9 .Text );
            cmd.Parameters .AddWithValue ("specialist",TextBox10 .Text );
            cmd.Parameters .AddWithValue ("uname",TextBox11 .Text );
            cmd.Parameters .AddWithValue ("pword",TextBox12 .Text );
            cmd.Parameters .AddWithValue ("status","Register");
            
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "Register New Doctor Details......";
    

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
        RadioButtonList1.SelectedIndex = -1;
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox9.Text = "";
        TextBox10.Text = "";
        TextBox11.Text = "";
        TextBox12.Text = "";
        autonumber();
        TextBox2.Focus();
    }
}