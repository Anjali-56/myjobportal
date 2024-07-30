using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myjobprotal.AdminModule
{
    public partial class Managejobprofile : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["aaa"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }

        }
        public void BindGrid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_JobProfile ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "show");
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gvJobProfiles.DataSource = dt;
            gvJobProfiles.DataBind();
        }
        public void clear()
        {
            txtname.Text = "";
            btnsave.Text = "Save";
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "Save")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_JobProfile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "insert");
                cmd.Parameters.AddWithValue("@jpname", txtname.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
                clear();
            }
            else if (btnsave.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_JobProfile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "update");
                cmd.Parameters.AddWithValue("@jpid", ViewState["ID"]);
                cmd.Parameters.AddWithValue("@jpname", txtname.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
                clear();
            }



        }

        protected void gvJobProfiles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName =="A")
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("Proc_JobProfile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "delete");
                cmd.Parameters.AddWithValue("@jpid", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
            }

            else if (e.CommandName=="B")
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("Proc_JobProfile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "edit");
                cmd.Parameters.AddWithValue("@jpid", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                txtname.Text = dt.Rows[0]["jpname"].ToString();
                btnsave.Text = "Update";
                ViewState["ID"] = e.CommandArgument;
                
            }
        }
    }
}