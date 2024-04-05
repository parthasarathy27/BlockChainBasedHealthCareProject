using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class CompanyViewMedicalInsuranceScheme : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    SqlDataAdapter adp;
    DataTable dt;

    void bindgrid()
    {
        adp = new SqlDataAdapter("select * from mstable where iid=@iid", con);
        adp.SelectCommand.Parameters.AddWithValue("iid", TextBox1.Text);
        dt = new DataTable();
        adp.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
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
                        return;

                    }

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