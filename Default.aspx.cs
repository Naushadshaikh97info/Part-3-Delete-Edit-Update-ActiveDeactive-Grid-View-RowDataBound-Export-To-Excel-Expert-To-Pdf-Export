using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    DataClassesDataContext linq_obj = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        fill_data();
        fill_hobby();
    }
    private void fill_hobby()
    {
        var id = (from a in linq_obj.hoby_msts
                  select a).ToList();
        cb_hobby.DataSource = id;
        cb_hobby.DataBind();
    }
    private void fill_data()
    {
        var id = (from a in linq_obj.Naushads
                  select new
                  {
                      code = a.UserId,
                      name = a.Name,
                      surname = a.SurName,
                      username = a.UserName,
                      password = a.Password,
                      gender = a.Gender,
                      country = a.Country,
                      hobby=a.hobby,
                      active = a.Active
                  }).ToList();
        GridView1.DataSource = id;
        GridView1.DataBind();
        fill_data_active();
    }
    private void fill_data_active()
    {
        var id = (from a in linq_obj.Naushads
                  where a.Active == "Active"
                  select new
                  {
                      code = a.UserId,
                      name = a.Name,
                      surname = a.SurName,
                      username = a.UserName,
                      password = a.Password,
                      gender = a.Gender,
                      country = a.Country,
                      hobby=a.hobby,
                  }).ToList();
        GridView2.DataSource = id;
        GridView2.DataBind();
    }
    private void Clear()
    {
        txt_name.Text = "";
        txt_surname.Text = "";
        txt_username.Text = "";
        txt_password.Text = "";
        rb_gender.SelectedIndex = -1;
        ddl_country.SelectedIndex = 0;
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        string a = "";
        for (int i = 0; i < cb_hobby.Items.Count; i++)
        {
            if (cb_hobby.Items[i].Selected)
            {
                if (a == "")
                {
                    a = cb_hobby.Items[i].Value;
                }
                else
                {
                    a += "," + cb_hobby.Items[i].Value;
                }
            }
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fill_data();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int code = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value.ToString());
        ViewState["id"] = code;
        var id = (from a in linq_obj.Naushads
                  where a.UserId == code
                  select a).Single();

        txt_name.Text = id.Name;
        txt_surname.Text = id.SurName;
        txt_username.Text = id.UserName;
        txt_password.Text = id.Password;
        rb_gender.SelectedValue = id.Gender;
        ddl_country.SelectedValue = id.Country;
        string[] abc = id.hobby.Split(',');
        for (int i = 0; i < abc.Length; i++)
        {
            string xyz = abc[i].ToString();
            for (int j = 0; j < cb_hobby.Items.Count; j++)
            {
                if (cb_hobby.Items[j].Value == xyz)
                {
                    cb_hobby.Items[j].Selected = true;
                }
            }
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        linq_obj.Delete_Naushad(Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()));
        linq_obj.SubmitChanges();

        fill_data();

    }
    protected void byn_update_Click(object sender, EventArgs e)
    {
        string a = "";
        for (int i = 0; i < cb_hobby.Items.Count; i++)
        {
            if (cb_hobby.Items[i].Selected)
            {
                if (a == "")
                {
                    a = cb_hobby.Items[i].Value;
                }
                else
                {
                    a += "," + cb_hobby.Items[i].Value;
                }
            }
        }
        linq_obj.Update_Naushad(Convert.ToInt32(ViewState["id"].ToString()), txt_name.Text, txt_surname.Text, txt_username.Text, txt_password.Text, rb_gender.SelectedValue, ddl_country.SelectedValue,a);
        linq_obj.SubmitChanges();

        fill_data();
        Clear();
        Response.Redirect("Default.aspx");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;

        int code = Convert.ToInt32(lnk.CommandArgument.ToString());

        var id = (from a in linq_obj.Naushads
                  where a.UserId == code
                  select a).Single();
        if (id.Active == "Deactive")
        {
            id.Active = "Active";   
            linq_obj.SubmitChanges();
        }
        else
        {
            id.Active = "Deactive";
            linq_obj.SubmitChanges();
        }
        fill_data();
    }

   
    //-------------------- Export To Excel ---------------------//
    //protected void ExportToExcel(object sender, EventArgs e)
    //{
    //    Response.Clear();
    //    Response.Buffer = true;
    //    Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
    //    Response.Charset = "";
    //    Response.ContentType = "application/vnd.ms-excel";
    //    using (StringWriter sw = new StringWriter())
    //    {
    //        HtmlTextWriter hw = new HtmlTextWriter(sw);

    //        //To Export all pages
    //        GridView1.AllowPaging = false;

    //        this.fill_data();

    //        GridView1.HeaderRow.BackColor = Color.White;
    //        foreach (TableCell cell in GridView1.HeaderRow.Cells)
    //        {
    //            cell.BackColor = GridView1.HeaderStyle.BackColor;
    //        }
    //        foreach (GridViewRow row in GridView1.Rows)
    //        {
    //            row.BackColor = Color.White;
    //            foreach (TableCell cell in row.Cells)
    //            {
    //                if (row.RowIndex % 2 == 0)
    //                {
    //                    cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
    //                }
    //                else
    //                {
    //                    cell.BackColor = GridView1.RowStyle.BackColor;
    //                }
    //                cell.CssClass = "textmode";
    //            }
    //        }

    //        GridView1.RenderControl(hw);

    //        //style to format numbers to string
    //        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
    //        Response.Write(style);
    //        Response.Output.Write(sw.ToString());
    //        Response.Flush();
    //        Response.End();
    //    }
    //}

    //public override void VerifyRenderingInServerForm(Control control)
    //{
    //    /* Verifies that the control is rendered */
    //}
    //--------------------------End----------------------------//
    //protected void btn_search_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        fill_data(); var id = (from a in linq_obj.newsletter_msts
    //                               where a.datetime >= Convert.ToDateTime(txt_start_date.Text) && a.datetime <= Convert.ToDateTime(txt_end_date.Text)
    //                               select new
    //                               {
    //                                   code = a.intglcode,
    //                                   email = a.newsletter,
    //                                   datetime1 = a.datetime
    //                               }).ToList();
    //        GridView1.DataSource = id;
    //        GridView1.DataBind();

    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}
    //------------------- Export To Pdf -----------------//
    //protected override void Render(HtmlTextWriter writer)
    //{
    //    MemoryStream mem = new MemoryStream();
    //    StreamWriter twr = new StreamWriter(mem);
    //    HtmlTextWriter myWriter = new HtmlTextWriter(twr);
    //    base.Render(myWriter);
    //    myWriter.Flush();
    //    myWriter.Dispose();
    //    StreamReader strmRdr = new StreamReader(mem);
    //    strmRdr.BaseStream.Position = 0;
    //    string pageContent = strmRdr.ReadToEnd();
    //    strmRdr.Dispose();
    //    mem.Dispose();
    //    writer.Write(pageContent);
    //    CreatePDFDocument(pageContent);


    //}
    //public void CreatePDFDocument(string strHtml)
    //{

    //    string strFileName = HttpContext.Current.Server.MapPath("test.pdf");
    //    // step 1: creation of a document-object
    //    Document document = new Document();
    //    // step 2:
    //    // we create a writer that listens to the document
    //    PdfWriter.GetInstance(document, new FileStream(strFileName, FileMode.Create));
    //    StringReader se = new StringReader(strHtml);
    //    HTMLWorker obj = new HTMLWorker(document);
    //    document.Open();
    //    obj.Parse(se);
    //    document.Close();
    //    ShowPdf(strFileName);
    //}
    //public void ShowPdf(string strFileName)
    //{
    //    Response.ClearContent();
    //    Response.ClearHeaders();
    //    Response.AddHeader("Content-Disposition", "inline;filename=" + strFileName);
    //    Response.ContentType = "application/pdf";
    //    Response.WriteFile(strFileName);
    //    Response.Flush();
    //    Response.Clear();
    //}

    //----------------------- OR ------------------------//
    //Response.ContentType = "application/pdf";

    //Response.AddHeader("content-disposition", "attachment;filename=Export.pdf");
    //Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //StringWriter sw = new StringWriter();
    //HtmlTextWriter hw = new HtmlTextWriter(sw);
    //HtmlForm frm = new HtmlForm();
    //gv.Parent.Controls.Add(frm);
    //frm.Attributes["runat"] = "server";
    //frm.Controls.Add(gv);
    //frm.RenderControl(hw);
    //StringReader sr = new StringReader(sw.ToString());
    //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
    //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
    //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
    //pdfDoc.Open();
    //htmlparser.Parse(sr);
    //pdfDoc.Close();
    //Response.Write(pdfDoc);
    //Response.End();
    //---------------------------------------------------//
    //---------------------- End ------------------------//

    //----------------------Print Invoice------------------//
    //protected void onclick_Print(object sender, ImageClickEventArgs e)
    //{
    //    try
    //    {
    //        Response.Write("<script>");
    //        Response.Write("window.open('invoice.aspx?id=" + order_no + " ','_blank')");
    //        Response.Write("</script>");
    //        // Response.Redirect("invoice.aspx?id=" + order_no);

    //        //  Page.RegisterStartupScript("Window", "window.open('invoice.aspx?id=" + order_no + "','','width=500,height=320,left=200,top=200');");
    //        //   Page.RegisterStartupScript("jwb", " <script language=javascript>function a(){window.open('invoice.aspx?id" + order_no + "','','width=500,height=320,left=200,top=200');}</script> ");
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
    //----------------------End-------------------------------//
}
