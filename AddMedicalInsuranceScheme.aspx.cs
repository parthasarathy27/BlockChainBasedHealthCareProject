using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class AddMedicalInsuranceScheme : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            Menu m4 = (Menu)Master.FindControl("Menu4");
            m4.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
            {
                if (Session["IID"] != null)
                {
                    TextBox1.Text = Session["IID"].ToString();
                    TextBox7.Text = DateTime.Now.ToString("dd-MMM-yyyy");

                    cmd = new SqlCommand("select cname from itable where iid=@iid", con);
                    cmd.Parameters.AddWithValue("iid", TextBox1.Text);
                    rs = cmd.ExecuteReader();
                    if (rs.Read())
                    {
                        TextBox2.Text = rs["cname"].ToString();
                        rs.Close();
                        cmd.Dispose();
                    }
                    else
                    {
                        rs.Close();
                        cmd.Dispose();
                        Label1.Text = "Record Not Found.Check ITable.....";

                    }
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
            if (DropDownList1.SelectedIndex == 0)
            {
                Label1.Text = "Select Disease to be Insured Option.....";
                return;
            }

            cmd = new SqlCommand("select isnull(max(rid), 0) + 1 from mstable", con);
            int rid = int.Parse(cmd.ExecuteScalar().ToString());
            cmd.Dispose();

            cmd = new SqlCommand("insert into mstable values(@iid,@cname,@mischeme,@ipamount,@vperiod,@idisease,@mcamount,@cdate,@rid)", con);
            cmd.Parameters .AddWithValue ("iid",TextBox1 .Text );
            cmd.Parameters .AddWithValue ("cname",TextBox2 .Text );
            cmd.Parameters .AddWithValue ("mischeme",TextBox3 .Text );
            cmd.Parameters .AddWithValue ("ipamount",TextBox4 .Text );
            cmd.Parameters .AddWithValue ("vperiod",TextBox5 .Text );
            cmd.Parameters .AddWithValue ("idisease",DropDownList1 .SelectedItem .Text );
            cmd.Parameters .AddWithValue ("mcamount",TextBox6 .Text );
            cmd.Parameters .AddWithValue ("cdate",TextBox7 .Text );
            cmd.Parameters .AddWithValue ("rid",rid);
            cmd.ExecuteNonQuery ();
            cmd.Dispose ();

            Label1.Text = "Medical Insurance Scheme Details Successfully Inserted......";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox3.Focus();



        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox3.Focus();

    }
}