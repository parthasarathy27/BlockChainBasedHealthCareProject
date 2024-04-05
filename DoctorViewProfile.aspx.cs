using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class DoctorViewProfile : System.Web.UI.Page
{
    SqlConnection con;
    SqlDataAdapter adp;
    DataTable dt;

    void bindview()
    {
        adp = new SqlDataAdapter("select * from dtable where did=@did", con);
        adp.SelectCommand.Parameters.AddWithValue("did", Session["DID"].ToString());
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
            Menu m3 = (Menu)Master.FindControl("Menu3");
            m3.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
            {
                if (Session["DID"] != null)
                    bindview();
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}