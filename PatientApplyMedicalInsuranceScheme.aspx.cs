using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class PatientApplyMedicalInsuranceScheme : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    SqlDataAdapter adp;
    DataTable dt;
    void autonumber()
    {
        cmd = new SqlCommand("select isnull(max(policyno), 10000)+1 from msatable", con);
        TextBox2.Text = cmd.ExecuteScalar().ToString();
        cmd.Dispose();
    }
    void bindview1()
    {
        adp = new SqlDataAdapter("select * from ptable where pid=@pid", con);
        adp.SelectCommand.Parameters.AddWithValue("pid", Session["PID"].ToString());
        dt = new DataTable();
        adp.Fill(dt);
        DetailsView1.DataSource = dt;
        DetailsView1.DataBind();

    }
    void bindview2()
    {
        adp = new SqlDataAdapter("select * from mstable where rid=@rid", con);
        adp.SelectCommand.Parameters.AddWithValue("rid", Request.QueryString.Get("RID"));
        dt = new DataTable();
        adp.Fill(dt);
        DetailsView2.DataSource = dt;
        DetailsView2.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //RID
            Label1.Text = "";
            Menu m5 = (Menu)Master.FindControl("Menu5");
            m5.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
            {
                if (Session["PID"] != null)
                {
                    TextBox1.Text = Session["PID"].ToString();
                    autonumber();
                    TextBox3.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                    bindview1();
                    bindview2();
                }
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

            //cmd = new SqlCommand("Select * from msatable where cid=@cid", con);
            //cmd.Parameters.AddWithValue("cid", TextBox1.Text);
            //rs = cmd.ExecuteReader();
            //bool b = rs.Read();
            //rs.Close();
            //cmd.Dispose();
            //if (b)
            //{
            //    Label1.Text = "Medical Insurance Scheme Already Applied......";
            //    return;                
            //}

            cmd = new SqlCommand("select rid from msatable where rid =@rid and cid=@cid", con);
            cmd.Parameters.AddWithValue("rid", Request .QueryString .Get ("RID"));
            cmd.Parameters.AddWithValue("cid", TextBox1.Text);
            rs = cmd.ExecuteReader();
           bool  b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "Patient Already Apply this Medical Scheme......";
                return;
            }

            cmd = new SqlCommand("select policyno from msatable where policyno=@policyno", con);
            cmd.Parameters.AddWithValue("policyno", TextBox2.Text);
            rs = cmd.ExecuteReader();
            b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "Policy Number Already Found......";
                return;
            }
            cmd = new SqlCommand("insert into msatable values(@policyno,@cid,@cusname,@rid,@iid,@cname,@padate)", con);
            cmd.Parameters.AddWithValue("policyno", TextBox2.Text);
            cmd.Parameters.AddWithValue("cid", TextBox1.Text);
            cmd.Parameters.AddWithValue("cusname", DetailsView1.Rows[0].Cells[1].Text);
            cmd.Parameters.AddWithValue("rid", Request.QueryString.Get("RID"));
            cmd.Parameters.AddWithValue("iid", DetailsView2.Rows[0].Cells[1].Text);
            cmd.Parameters.AddWithValue("cname", DetailsView2.Rows[1].Cells[1].Text);
            cmd.Parameters.AddWithValue("padate", TextBox3.Text);
            int no=  cmd.ExecuteNonQuery();
            cmd.Dispose();
            if (no != 0)
            {
                cmd = new SqlCommand("select * from pirtable where iid=@iid and cid=@cid", con);
                cmd.Parameters.AddWithValue("iid", DetailsView2.Rows[0].Cells[1].Text);
                cmd.Parameters.AddWithValue("cid", TextBox1.Text);
                rs = cmd.ExecuteReader();
                bool bb = rs.Read();
                rs.Close();
                cmd.Dispose();
                if (bb)
                {
                    cmd = new SqlCommand("update pirtable set mcamount=mcamount + @mcamount  where iid=@iid and cid=@cid", con);

                    cmd.Parameters.AddWithValue("mcamount", DetailsView2.Rows[6].Cells[1].Text);
                    cmd.Parameters.AddWithValue("iid", DetailsView2.Rows[0].Cells[1].Text);
                    cmd.Parameters.AddWithValue("cid", TextBox1.Text);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                else
                {
                    cmd = new SqlCommand("insert into pirtable values(@iid,@cid,@mcamount)", con);

                    
                    cmd.Parameters.AddWithValue("iid", DetailsView2.Rows[0].Cells[1].Text);
                    cmd.Parameters.AddWithValue("cid", TextBox1.Text);
                    cmd.Parameters.AddWithValue("mcamount", DetailsView2.Rows[6].Cells[1].Text);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

            }

            Label1.Text = "Medical Insurance Scheme Details Successfully Applied.......";
            LinkButton1.Enabled = false;


        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}