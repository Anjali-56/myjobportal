using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace myjobprotal.AdminModule
{
    public partial class ManageCities : System.Web.UI.Page
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
            SqlCommand cmd = new SqlCommand("Proc_Cities ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "show");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gvcities.DataSource = dt;
            gvcities.DataBind();
        }
        public void BindCountry()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_countries", con);
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
            ddlcountry.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        public void BindState()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_States ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "GetstateByCountry");
            cmd.Parameters.AddWithValue("@cid",ddlcountry.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlstate.DataTextField = "sname";
            ddlstate.DataValueField = "sid";
            ddlstate.DataSource = dt;
            ddlstate.DataBind();
            ddlstate.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        public void clear()
        {
            txtcityname.Text = "";
            ddlcountry.SelectedValue = "0";
            ddlstate.SelectedValue = "0";
            btnsave.Text = "Save";
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "Save")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_Cities", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "insert");
                cmd.Parameters.AddWithValue("@cid", ddlcountry.SelectedValue);
                cmd.Parameters.AddWithValue("@cityname",txtcityname.Text );
                cmd.Parameters.AddWithValue("@sid", ddlstate.SelectedValue);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
                clear();
            }
            else if (btnsave.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_Cities", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "update");
                cmd.Parameters.AddWithValue("@cid", ddlcountry.SelectedValue);
                cmd.Parameters.AddWithValue("@cityid", ViewState["ID"]);
                cmd.Parameters.AddWithValue("@cityname", txtcityname.Text);
                cmd.Parameters.AddWithValue("@sid", ddlstate.SelectedValue);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
                clear();
            }
        }

        protected void gvcities_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "A")
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("Proc_Cities", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "delete");
                cmd.Parameters.AddWithValue("@cityid", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
            }

            else if (e.CommandName == "B")
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("Proc_Cities", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "edit");
                cmd.Parameters.AddWithValue("@cityid", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                txtcityname.Text = dt.Rows[0]["cityname"].ToString();
                ddlcountry.SelectedValue = dt.Rows[0]["cid"].ToString();
                BindState();
                ddlstate.SelectedValue = dt.Rows[0]["sid"].ToString();
                btnsave.Text = "Update";
                ViewState["ID"] = e.CommandArgument;

            }
        }

        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindState();
        }
    }
}