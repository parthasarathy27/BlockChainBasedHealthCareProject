using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class InsuranceViewClaimRequest : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter adp;
    DataTable dt;

    void bindgrid()
    {
        adp = new SqlDataAdapter("select * from icrtable where pid in (select cid from msatable where iid=@iid) and claimid not in (select claimid from crtable where iid=@iid1) and status='Claiming'  ", con);
        adp.SelectCommand.Parameters.AddWithValue("iid", Session["IID"].ToString());
        adp.SelectCommand.Parameters.AddWithValue("iid1", Session["IID"].ToString());
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
            if (e.CommandName == "ra")
            {
                int claimid = int.Parse(GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());

                int pid = int.Parse(GridView1.Rows[int.Parse(e.CommandArgument.ToString())].Cells[1].Text);

                cmd = new SqlCommand("insert into crtable values(@claimid,@iid,@pid,@status)", con);
                cmd.Parameters .AddWithValue ("claimid",claimid );
                cmd.Parameters .AddWithValue ("iid",Session ["IID"].ToString ());
                cmd.Parameters .AddWithValue ("pid",pid );
                cmd.Parameters .AddWithValue ("status","Requesting");
                cmd.ExecuteNonQuery();                            
                cmd.Dispose ();
                bindgrid();

            }

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}