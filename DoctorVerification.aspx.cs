using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class DoctorVerification : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter adp;
    DataTable dt;

    void bindview()
    {
        adp = new SqlDataAdapter("select * from dtable where did=@did", con);
        adp.SelectCommand.Parameters.AddWithValue("did", Request.QueryString.Get("DID"));
        dt = new DataTable();
        adp.Fill(dt);
        DetailsView1.DataSource = dt;
        DetailsView1.DataBind();
        if (dt.Rows.Count != 0)
        {
            string status = dt.Rows[0]["status"].ToString().ToLower ();
            if (status.Equals("register"))
                RadioButtonList1.Enabled = true;
            else if (status.Equals("rejected"))
            {
                RadioButtonList1.Enabled = true;
                RadioButtonList1.SelectedIndex = 1;
            }
            else if (status.Equals("accepted"))
            {
                RadioButtonList1.Enabled = false;
                RadioButtonList1.SelectedIndex = 0;
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            Menu m2 = (Menu)Master.FindControl("Menu2");
            m2.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
            {
                if (Request .QueryString .Get ("DID")!=null )
                    bindview();
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
            if (RadioButtonList1.SelectedIndex == -1)
            {
                Label1.Text = "Status Not Selected......";
                return;
            }
            string status = "";
                if (RadioButtonList1 .SelectedIndex ==0)
                    status ="Accepted";
                else if (RadioButtonList1 .SelectedIndex ==1 )
                    status ="Rejected";
            cmd = new SqlCommand("update dtable set status=@status where did=@did", con);
            cmd.Parameters.AddWithValue("status", status);
            cmd.Parameters.AddWithValue("did", Request.QueryString.Get("DID"));
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "Verification Process Successfully Updated.....";
            bindview();


        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}