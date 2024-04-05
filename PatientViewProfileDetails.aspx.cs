using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class PatientViewProfileDetails : System.Web.UI.Page
{
    SqlConnection con;
    SqlDataAdapter adp;
    DataTable dt;

    void bindview()
    {
        adp = new SqlDataAdapter("select * from ptable where pid=@pid", con);
        adp.SelectCommand.Parameters.AddWithValue("pid", Session["PID"].ToString());
        dt = new DataTable();
        adp.Fill(dt);
       DetailsView1.DataSource = dt;
        DetailsView1.DataBind();

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            Menu m5 = (Menu)Master.FindControl("Menu5");
            m5.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
            {
                if (Session ["PID"]!=null )
                    bindview();
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}