using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace N01330009_Final_Assignment
{
    public partial class DocumentView : Page
    {
        DOCSDB database = new DOCSDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string document_id = Request.QueryString["document_id"];
                bool valid = true;
                if (String.IsNullOrEmpty(document_id)) valid = false;
                if (valid)
                {
                    Document document_record = database.FindDocument(Int32.Parse(document_id));
                    documentTitle.InnerText = document_record.GetDocumentTitle();
                    documentBody.InnerHtml = document_record.GetDocumentBody();
                    createdOn.InnerHtml = "Created on " + document_record.GetDocumentCreated();
                }
                else
                {
                    documentTitle.InnerText = "Document title not found";
                }
            }
        }
    }
}