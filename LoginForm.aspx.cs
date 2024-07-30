using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace myjobprotal
{
    public partial class LoginForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["aaa"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            if (ddluserType.SelectedValue == "1")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from tblAdmin where adminemail='" + txtemail.Text + "'and adminpassword='" + txtpassword.Text + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count == 0)
                {
                    lblmsg.Text = "login failed....";

                }
                else
                {
                    Session["AID"] = dt.Rows[0]["adminid"];
                    Response.Redirect("~/AdminModule/AdminHome.aspx");

                }
            }
            else if (ddluserType.SelectedValue == "2")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from tblJobseeker_Registration where jsemail='" + txtemail.Text + "'and jspassword='" + txtpassword.Text + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count == 0)
                {
                    lblmsg.Text = "login failed....";

                }
                else
                {
                    Session["JSID"] = dt.Rows[0]["jsid"];
                    Response.Redirect("~/JobSeekersModule/JobSeekerHome.aspx");
                }
            }
            else if (ddluserType.SelectedValue == "3")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from tblRecruiter_Registration where jremail='" + txtemail.Text + "'and jrpassword='" + txtpassword.Text + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count == 0)
                {
                    lblmsg.Text = "login failed....";

                }
                else
                {
                    Session["JRID"] = dt.Rows[0]["jrid"];
                    Response.Redirect("~/JobRecruitersModule/JobRecruiterHome.aspx");
                }

            }
        }
    }
}