using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class AddPatientHealthDetails : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;

    
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
                if (Session["DID"] != null && Request.QueryString.Get("ReqID") != null && Request.QueryString.Get("PID") != null)
                {
                TextBox1.Text = Request.QueryString.Get("PID");
                cmd = new SqlCommand("select pname from ptable where pid=@pid", con);
                cmd.Parameters.AddWithValue("pid", TextBox1.Text);
                rs = cmd.ExecuteReader();
                if (rs.Read())
                {
                    TextBox2.Text = rs["pname"].ToString();
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


                cmd = new SqlCommand("select dname from dtable where did=@did", con);
                cmd.Parameters.AddWithValue("did", Session ["DID"].ToString ());
                rs = cmd.ExecuteReader();
                if (rs.Read())
                {
                    TextBox8.Text = rs["dname"].ToString();
                    rs.Close();
                    cmd.Dispose();
                }
                else
                {
                    rs.Close();
                    cmd.Dispose();
                    Label1.Text = "Record Not Found.Check DTable....";
                    return;
                }

                TextBox10.Text = DateTime.Now.ToString("dd-MMM-yyyy");



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
            if (FileUpload1.HasFile == false || FileUpload2.HasFile == false || FileUpload3.HasFile == false)
            {
                Label1.Text = "Select All Files.....";
                return;
            }

            DirectoryInfo d1 = new DirectoryInfo(Server.MapPath("Temp"));
            FileInfo[] f1 = d1.GetFiles();
            foreach (FileInfo f2 in f1)
                f2.Delete();

            string xrayfname = FileUpload1.FileName;
             string ext = xrayfname.Substring(xrayfname.LastIndexOf(".") + 1).ToLower();           
            if (ext.Equals("jpg") == false && ext.Equals("jpeg") == false && ext.Equals("gif") == false && ext.Equals("png") == false && ext.Equals("bmp") == false)
            {
                Label1.Text = "XRay File Select Image Type File Only......";
                return;
            }


            string scanfname = FileUpload2.FileName;
           ext = scanfname.Substring(scanfname.LastIndexOf(".") + 1).ToLower();
            if (ext.Equals("jpg") == false && ext.Equals("jpeg") == false && ext.Equals("gif") == false && ext.Equals("png") == false && ext.Equals("bmp") == false)
            {
                Label1.Text = "Scan File Select Image Type File Only......";
                return;
            }
            string ecgfname = FileUpload3.FileName;
            ext = ecgfname.Substring(ecgfname.LastIndexOf(".") + 1).ToLower();
            if (ext.Equals("jpg") == false && ext.Equals("jpeg") == false && ext.Equals("gif") == false && ext.Equals("png") == false && ext.Equals("bmp") == false)
            {
                Label1.Text = "ECG File Select Image Type File Only......";
                return;
            }

            xrayfname = "X_" + DateTime.Now.Ticks + "_" + xrayfname;
            FileUpload1.PostedFile.SaveAs(Server.MapPath("Temp/") + xrayfname);

            scanfname = "S_" + DateTime.Now.Ticks + "_" + scanfname;
            FileUpload2.PostedFile.SaveAs(Server.MapPath("Temp/") + scanfname);
            ecgfname = "E_" + DateTime.Now.Ticks + "_" + ecgfname;
            FileUpload3.PostedFile.SaveAs(Server.MapPath("Temp/") + ecgfname);

            FileStream fs = new FileStream(Server.MapPath("Temp/" + xrayfname), FileMode.Open, FileAccess.Read);
            byte[] xraycontent = new byte[fs.Length];
            fs.Read(xraycontent, 0, xraycontent.Length);
            fs.Close();

             fs = new FileStream(Server.MapPath("Temp/" + scanfname), FileMode.Open, FileAccess.Read);
            byte[] scancontent = new byte[fs.Length];
            fs.Read(scancontent, 0, scancontent.Length);
            fs.Close();

            fs = new FileStream(Server.MapPath("Temp/" + ecgfname), FileMode.Open, FileAccess.Read);
            byte[] ecgcontent = new byte[fs.Length];
            fs.Read(ecgcontent, 0, ecgcontent.Length);
            fs.Close();


            cmd = new SqlCommand("select pkey from ptable where pid=@pid", con);
            cmd.Parameters.AddWithValue("pid", TextBox1.Text);
            rs = cmd.ExecuteReader();
            string pkey = "";
            if (rs.Read())
            {
                pkey = rs["pkey"].ToString();
                rs.Close();
                cmd.Dispose();
            }
            else
            {
                rs.Close();
                cmd.Dispose();
                Label1.Text = "Patient ID Not Found.Check Ptable....";
                return;
            }


            char[] c = pkey.ToCharArray();
            byte b = (byte)c[3];



            int i = 0;
            for (i = 0; i < xraycontent.Length;i++)
            {
                xraycontent[i] = (byte)(xraycontent[i] + b);
            }

            for (i = 0; i < scancontent.Length; i++)
            {
                scancontent[i] = (byte)(scancontent[i] + b);
            }

            for (i = 0; i < ecgcontent.Length; i++)
            {
                ecgcontent[i] = (byte)(ecgcontent[i] + b);
            }
            cmd = new SqlCommand("insert into hrtable values(@did,@pid,@rid,@pname,@slevel,@bplevel,@hstatus,@xrayfname,@xraycontent,@scanfname,@scancontent,@ecgfname,@ecgcontent,@surgerydetails,@medicinedetails,@dname,@tplace,@tdate,@ttype,@tamount)", con);
            cmd.Parameters .AddWithValue ("did",Session ["DID"].ToString ());
            cmd.Parameters .AddWithValue ("pid",TextBox1 .Text );
            cmd.Parameters.AddWithValue("rid", Request.QueryString.Get("ReqID"));
            cmd.Parameters .AddWithValue ("pname",TextBox2 .Text );
            cmd.Parameters .AddWithValue ("slevel",TextBox3 .Text );
            cmd.Parameters .AddWithValue ("bplevel",TextBox4 .Text );
            cmd.Parameters .AddWithValue ("hstatus",TextBox5 .Text );
            cmd.Parameters .AddWithValue ("xrayfname",xrayfname );
            cmd.Parameters .AddWithValue ("xraycontent",xraycontent );
            cmd.Parameters .AddWithValue ("scanfname",scanfname );
            cmd.Parameters .AddWithValue ("scancontent",scancontent );
            cmd.Parameters .AddWithValue ("ecgfname",ecgfname );
            cmd.Parameters .AddWithValue ("ecgcontent",ecgcontent );
            cmd.Parameters .AddWithValue ("surgerydetails",TextBox6 .Text );
            cmd.Parameters .AddWithValue ("medicinedetails",TextBox7 .Text );
            cmd.Parameters .AddWithValue ("dname",TextBox8 .Text );
            cmd.Parameters .AddWithValue ("tplace",TextBox9 .Text );
            cmd.Parameters .AddWithValue ("tdate",TextBox10 .Text );
            cmd.Parameters .AddWithValue ("ttype",TextBox11 .Text );
            cmd.Parameters .AddWithValue ("tamount",TextBox12 .Text );
            int no =cmd.ExecuteNonQuery ();
            cmd.Dispose ();
            if (no != 0)
            {

                cmd=new SqlCommand ("select dname from dtable where did=@did", con );
                cmd.Parameters .AddWithValue ("did", Session ["DID"].ToString ());
                rs=cmd.ExecuteReader ();
                string dname="";
                if (rs.Read ())
                {
                    dname =rs ["dname"].ToString ();
                    rs.Close ();
                    cmd.Dispose ();
                }
                else 
                {
                    rs.Close ();
                    cmd.Dispose ();
                    Label1 .Text ="Record Not Found.Check DTable....";
                    return ;
                }
                cmd = new SqlCommand("insert into paytable values(@pid,@pname,@did,@dname,@rid,@ttype,@tamount,@tdate,@status)", con);
                cmd.Parameters .AddWithValue ("pid",TextBox1 .Text );
                cmd.Parameters .AddWithValue ("pname",TextBox2 .Text );
                cmd.Parameters .AddWithValue ("did",Session ["DID"].ToString ());
                cmd.Parameters .AddWithValue ("dname",dname );
                cmd.Parameters.AddWithValue("rid", Request.QueryString.Get("ReqID"));
                cmd.Parameters .AddWithValue ("ttype",TextBox11 .Text );
                cmd.Parameters .AddWithValue ("tamount",TextBox12 .Text );
                cmd.Parameters .AddWithValue ("tdate",TextBox10 .Text );
                cmd.Parameters .AddWithValue ("status","Pending");
                cmd.ExecuteNonQuery ();
                cmd.Dispose ();

                cmd = new SqlCommand("select isnull(max(claimid), 100)+1 from icrtable", con);
                int claimid = int.Parse(cmd.ExecuteScalar().ToString());
                cmd.Dispose();

                cmd = new SqlCommand("insert into icrtable values(@claimid,@pid,@pname,@did,@dname,@rid,@ttype,@tamount,@tdate,@status)", con);
                cmd.Parameters.AddWithValue("claimid", claimid);
                cmd.Parameters.AddWithValue("pid", TextBox1.Text);
                cmd.Parameters.AddWithValue("pname", TextBox2.Text);
                cmd.Parameters.AddWithValue("did", Session["DID"].ToString());
                cmd.Parameters.AddWithValue("dname", dname);
                cmd.Parameters.AddWithValue("rid", Request.QueryString.Get("ReqID"));
                cmd.Parameters.AddWithValue("ttype", TextBox11.Text);
                cmd.Parameters.AddWithValue("tamount", TextBox12.Text);
                cmd.Parameters.AddWithValue("tdate", TextBox10.Text);
                cmd.Parameters.AddWithValue("status", "Claiming");
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                Label1.Text = "Patient Health Report Successfully Inserted.....";
             
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}