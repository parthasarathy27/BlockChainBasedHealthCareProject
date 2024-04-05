using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class PatientRegistration : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;

    void autonumber()
    {
        cmd = new SqlCommand("select isnull(max(pid), 1000)+1 from ptable", con);
        TextBox1.Text = cmd.ExecuteScalar().ToString();
        cmd.Dispose();
    }
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


    private string GenerateKey()//3
    {

        string s = "";
        Random random = new Random();
        int length = 8;
        for (int i = 0; i < length; i++)
        {
            if (i == 3)
            {
                s += random.Next(1, 5);
            }
            if (random.Next(0, 4) == 0)
            {
                s += ((char)random.Next(97, 122)).ToString();
            }
            else if (random.Next(0, 3) == 1) 
            {
                s += random.Next(0, 9);
            }
            else
            {
                s += ((char)random.Next(65, 90)).ToString();
            }

        }
        return s.Trim();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {

            cmd = new SqlCommand("select pid from ptable where pid=@pid", con);
            cmd.Parameters.AddWithValue("pid", TextBox1.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "Patient ID Already Found.....";
                return;
            }

            string pkey = GenerateKey();
            cmd = new SqlCommand("insert into ptable values(@pid,@pname,@gender,@age,@address,@city,@mno,@emailid,@pword,@pkey)", con);
            cmd.Parameters .AddWithValue ("pid",TextBox1 .Text );       
            cmd.Parameters .AddWithValue ("pname",TextBox2 .Text );
            cmd.Parameters .AddWithValue ("gender",RadioButtonList1 .SelectedItem .Text );
            cmd.Parameters .AddWithValue ("age",TextBox3 .Text );
            cmd.Parameters .AddWithValue ("address",TextBox4 .Text );
            cmd.Parameters .AddWithValue ("city",TextBox5 .Text );
            cmd.Parameters .AddWithValue ("mno",TextBox6 .Text );
            cmd.Parameters .AddWithValue ("emailid",TextBox7 .Text );
            cmd.Parameters .AddWithValue ("pword",TextBox8 .Text );
            cmd.Parameters.AddWithValue("pkey", pkey);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "Your Details Successfully Registered.Your Private Key is :" + pkey;

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
        autonumber();
        TextBox2.Focus();
    }
}