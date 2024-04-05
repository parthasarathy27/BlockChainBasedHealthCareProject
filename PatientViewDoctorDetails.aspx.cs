using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class PatientViewDoctorDetails : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    SqlDataAdapter adp;
    DataTable dt;

    void bindgrid()
    {
        adp = new SqlDataAdapter("select * from dtable where status='Accepted' ", con);

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
            Menu m5 = (Menu)Master.FindControl("Menu5");
            m5.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
            {
                if (Session["PID"] != null)
                {
                    TextBox1.Text = Session["PID"].ToString();
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
            if (e.CommandName == "rd")
            {
                 int did = int.Parse(GridView1.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text);
                string dname = GridView1.Rows[int.Parse(e.CommandArgument.ToString())].Cells[1].Text;

                cmd = new SqlCommand("select * from reqtable where pid=@pid and did=@did", con);
                cmd.Parameters.AddWithValue("pid", TextBox1.Text);
                cmd.Parameters.AddWithValue("did", did);
                rs = cmd.ExecuteReader();
                bool b = rs.Read();
                rs.Close();
                cmd.Dispose();
                if (b)
                {
                    Label1.Text = "Already Request Send to Doctor ID :" + did;
                    return;
                }

                cmd = new SqlCommand("select pname ,pkey from ptable where pid=@pid", con);
                cmd.Parameters.AddWithValue("pid", TextBox1.Text);
                rs = cmd.ExecuteReader();
                string pname = "", pkey = "";
                if (rs.Read())
                {
                    pname = rs["pname"].ToString();
                    pkey = rs["pkey"].ToString();
                    rs.Close();
                    cmd.Dispose();

                }
                else
                {
                    rs.Close();
                    cmd.Dispose();
                    Label1.Text = "Record Not Found.Check PTable....";
                    return;
                }

            

                cmd = new SqlCommand("select isnull(max(reqid), 100)+1 from reqtable", con);
                int reqid = int.Parse(cmd.ExecuteScalar().ToString());
                cmd.Dispose();

                cmd = new SqlCommand("insert into reqtable values(@reqid,@did,@dname,@pid,@pname,@pkey,@reqdate)", con);
                cmd.Parameters .AddWithValue ("reqid",reqid );
                cmd.Parameters .AddWithValue ("did",did );
                cmd.Parameters .AddWithValue ("dname",dname);
                cmd.Parameters .AddWithValue ("pid",TextBox1 .Text );
                cmd.Parameters .AddWithValue ("pname",pname );
                cmd.Parameters .AddWithValue ("pkey",pkey );
                cmd.Parameters .AddWithValue ("reqdate",DateTime .Now .ToString ("dd-MMM-yyyy"));
                cmd.ExecuteNonQuery ();
                cmd.Dispose ();

                Label1.Text = "Request Details Successfully Inserted....";

               
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}