using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class InsurerViewClaimRequestStatus : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    SqlDataAdapter adp;
    DataTable dt;

    void bindgrid()
    {
        adp = new SqlDataAdapter("select i1.claimid, i1.pid,i1.pname, i1.did,i1.dname,i1.ttype,i1.tamount,i1.tdate,c1.status from icrtable i1 , crtable c1 where i1.claimid in (select claimid from crtable where iid=@iid and (status='Accepting' or status='Rejecting'))and i1.status='Claiming'   ", con);
        adp.SelectCommand.Parameters.AddWithValue("iid", Session["IID"].ToString());
     
        dt = new DataTable();
        adp.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string status = dt.Rows[i]["status"].ToString().ToLower();
            if (status .Equals ("accepting"))
                GridView1 .Rows [i].Cells[9].Enabled =true  ;
            else
                GridView1.Rows[i].Cells[9].Enabled = false;
        }

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
            if (e.CommandName == "ap")
            {
                int claimid = int.Parse(GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());

                int pid = int.Parse(GridView1.Rows[int.Parse(e.CommandArgument.ToString())].Cells[1].Text);

                int did = int.Parse(GridView1.Rows[int.Parse(e.CommandArgument.ToString())].Cells[3].Text);

               float amount = float.Parse(GridView1.Rows[int.Parse(e.CommandArgument.ToString())].Cells[6].Text);

              /* cmd = new SqlCommand("select mcamount from mstable where iid=(select iid from msatable where cid=@cid)", con);
               cmd.Parameters.AddWithValue("cid", pid);
               rs = cmd.ExecuteReader();
               float mcamount = 0;
               if (rs.Read())
               {
                   mcamount = float.Parse(rs["mcamount"].ToString());
                   rs.Close();
                   cmd.Dispose();
               }
               else
               {
                   rs.Close();
                   cmd.Dispose();
                   Label1.Text = "Record Not Found.Check MSTable.....";
                   return;
               }*/


               cmd = new SqlCommand("select mcamount from pirtable where iid=@iid and cid=@cid", con);
              cmd.Parameters.AddWithValue("iid", Session["IID"].ToString());
              cmd.Parameters.AddWithValue("cid", pid);
              rs = cmd.ExecuteReader();
              float mcamount = 0;
              if (rs.Read())
              {
                  mcamount = float.Parse(rs["mcamount"].ToString());
                  rs.Close();
                  cmd.Dispose();
              }
              else
              {
                  rs.Close();
                  cmd.Dispose();
                  Label1.Text = "Record Not Found.Check MSTable.....";
                  return;
              }
                
               if (amount > mcamount)
               {
                   Label1.Text = "Maximum Claim Amount is Low.So , Claim Details Not Approved......";
                   return;
               }


                cmd = new SqlCommand("update icrtable set status=@status where claimid=@claimid", con);
                cmd.Parameters.AddWithValue("status", "Approved");
                cmd.Parameters.AddWithValue("claimid", claimid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = new SqlCommand("update paytable set status=@status  where pid=@pid and did=@did", con);
                cmd.Parameters.AddWithValue("status", "Paid");
                cmd.Parameters.AddWithValue("pid", pid);
                cmd.Parameters.AddWithValue("did", did);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = new SqlCommand("update pirtable set mcamount=mcamount-@mcamount where iid=@iid and cid=@cid", con);
                cmd.Parameters.AddWithValue("mcamount", amount);
                cmd.Parameters.AddWithValue("iid", Session["IID"].ToString());
                cmd.Parameters.AddWithValue("cid", pid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                bindgrid();

            }

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}