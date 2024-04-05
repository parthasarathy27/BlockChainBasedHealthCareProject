using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class InsuranceCompanyViewPatientAppliedPolicy : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    SqlDataAdapter adp;
    DataTable dt;

    void bindgrid()
    {
        adp = new SqlDataAdapter("select m1.policyno,m1.padate,p1.gender, p1.age, p1.address,p1.city, p1.mno, p1.emailid, m2.mischeme, m2.ipamount, m2.vperiod,m2.idisease, m2.mcamount from msatable m1, ptable p1, mstable m2 where m1.iid=@iid and m1.iid=m2.iid and m1.cid=p1.pid", con);
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