using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace myjobprotal.AdminModule
{
    public partial class ManageStates : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["aaa"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                BindCountry();
            }
        }
        public void BindGrid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_States ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "show");
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gvstates.DataSource = dt;
            gvstates.DataBind();
        }

        public void BindCountry()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_countries ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "show");
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlcountry.DataTextField = "cname";
            ddlcountry.DataValueField = "cid";
            ddlcountry.DataSource = dt;
            ddlcountry.DataBind();
            ddlcountry.Items.Insert(0,new ListItem("---Select---",""));
        }  
        public void clear()
        {
            txtsname.Text = "";
            //ddlcountry.SelectedValue = "0";
            btnsave.Text = "Save";
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "Save")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_States", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "insert");
                cmd.Parameters.AddWithValue("@sname", txtsname.Text);
                cmd.Parameters.AddWithValue("@cid", ddlcountry.SelectedValue);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
                clear();
            }
            else if (btnsave.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_States", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "update");
                cmd.Parameters.AddWithValue("@sid", ViewState["ID"]);
                cmd.Parameters.AddWithValue("@sname", txtsname.Text);
                cmd.Parameters.AddWithValue("@cid",ddlcountry.SelectedValue);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
                clear();
            }

    }



        protected void gvstates_RowCommand1(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "A")
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("Proc_States", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "delete");
                cmd.Parameters.AddWithValue("@sid", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
            }

            else if (e.CommandName == "B")
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("Proc_States", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "edit");
                cmd.Parameters.AddWithValue("@sid", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                txtsname.Text = dt.Rows[0]["sname"].ToString();
                ddlcountry.SelectedValue = dt.Rows[0]["cid"].ToString();
                btnsave.Text = "Update";
                ViewState["ID"] = e.CommandArgument;

            }
            
        }
    }
}