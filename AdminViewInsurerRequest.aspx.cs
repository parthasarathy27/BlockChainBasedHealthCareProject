using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class AdminViewInsurerRequest : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter adp;
    DataTable dt;

    void bindgrid()
    {
        adp = new SqlDataAdapter("select * from crtable where status='Requesting'  ", con);      
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
            Menu m2 = (Menu)Master.FindControl("Menu2");
            m2.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
            {
                
                    bindgrid();
                
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
            int claimid = int.Parse(GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());
            string s = "";
            if (e.CommandName == "aa")
            {
                s = "Accepting";
            }
            else if (e.CommandName == "rr")
            {
                s = "Rejecting";
            }

            cmd = new SqlCommand("update crtable set status=@status where claimid=@claimid", con);
            cmd.Parameters.AddWithValue("status", s);
            cmd.Parameters.AddWithValue("claimid", claimid);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            bindgrid();

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}