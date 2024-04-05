using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class PatientViewMedicalSchemeApplyDetails : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    SqlDataAdapter adp;
    DataTable dt;

    void bindview()
    {
        adp = new SqlDataAdapter("select m1.policyno, m1.padate,m2.iid, m2.cname,m2.mischeme,m2.ipamount, m2.vperiod,m2.idisease, m2 .mcamount from msatable m1, mstable m2 where m1.cid=@cid and m1.rid=m2.rid", con);
        adp.SelectCommand.Parameters.AddWithValue("cid", TextBox1.Text);
        dt = new DataTable();
        adp.Fill(dt);
        DetailsView1.DataSource = dt;
        DetailsView1.DataBind();
        
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1 .Text ="";
            Menu m5 = (Menu)Master.FindControl("Menu5");
            m5.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
            {
                if (Session["PID"] != null)
                {
                    TextBox1.Text = Session["PID"].ToString();
                    bindview();
                }
            }

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {
        DetailsView1.PageIndex = e.NewPageIndex;
        bindview();
    }
}