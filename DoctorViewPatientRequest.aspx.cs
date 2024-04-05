using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class DoctorViewPatientRequest : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    SqlDataAdapter adp;
    DataTable dt;

    void bindgrid()
    {
        adp = new SqlDataAdapter("select r1.reqid, r1.reqdate,r1.pid, r1.pname, r1.pkey, p1.pid, p1.pname, p1.gender,p1.age, p1.address, p1.city, p1.mno, p1.emailid from reqtable r1,ptable p1 where r1.pid=p1.pid and r1.did=@did", con);
        adp.SelectCommand.Parameters.AddWithValue("did", TextBox1.Text);
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
            Menu m3 = (Menu)Master.FindControl("Menu3");
            m3.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
            {
                if (Session["DID"] != null)
                {
                    TextBox1.Text = Session["DID"].ToString();
                    bindgrid();
                }
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try 
        {
            if (e.CommandName == "vh")
            {
                int reqid = int.Parse(GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());
                int pid = int.Parse(GridView1.Rows[int.Parse(e.CommandArgument.ToString())].Cells[2].Text);
                Response.Redirect("VerifyPatientPrivateKey.aspx?ReqID=" + reqid + "&PID=" + pid);
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}