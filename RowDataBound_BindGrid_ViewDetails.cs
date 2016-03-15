using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class CS : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            BoundField bfield = new BoundField();
            bfield.HeaderText = "Name";
            bfield.DataField = "Name";
            GridView1.Columns.Add(bfield);

            TemplateField tfield = new TemplateField();
            tfield.HeaderText = "Country";
            GridView1.Columns.Add(tfield);

            tfield = new TemplateField();
            tfield.HeaderText = "View";
            GridView1.Columns.Add(tfield);
        }
        this.BindGrid();
    }

    private void BindGrid()
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id", typeof(int)),
                        new DataColumn("Name", typeof(string)),
                        new DataColumn("Country",typeof(string)) });
        dt.Rows.Add(1, "John Hammond", "United States");
        dt.Rows.Add(2, "Mudassar Khan", "India");
        dt.Rows.Add(3, "Suzanne Mathews", "France");
        dt.Rows.Add(4, "Robert Schidner", "Russia");
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txtCountry = new TextBox();
            txtCountry.ID = "txtCountry";
            txtCountry.Text = (e.Row.DataItem as DataRowView).Row["Country"].ToString();
            e.Row.Cells[1].Controls.Add(txtCountry);

            LinkButton lnkView = new LinkButton();
            lnkView.ID = "lnkView";
            lnkView.Text = "View";
            lnkView.Click += ViewDetails;
            lnkView.CommandArgument = (e.Row.DataItem as DataRowView).Row["Id"].ToString();
            e.Row.Cells[2].Controls.Add(lnkView);
        }
    }

    protected void ViewDetails(object sender, EventArgs e)
    {
        LinkButton lnkView = (sender as LinkButton);
        GridViewRow row = (lnkView.NamingContainer as GridViewRow);
        string id = lnkView.CommandArgument;
        string name = row.Cells[0].Text;
        string country = (row.FindControl("txtCountry") as TextBox).Text;
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Id: " + id + " Name: " + name + " Country: " + country + "')", true);
    }
}


