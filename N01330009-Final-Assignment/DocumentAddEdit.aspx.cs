using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace N01330009_Final_Assignment
{
    public partial class DocumentAddEdit : Page
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
                    pageType.InnerText = "Edit ";
                    Document document_record = database.FindDocument(Int32.Parse(document_id));
                    pageTitle.Text = document_record.GetDocumentTitle();
                    pageContent.Text = document_record.GetDocumentBody();
                }
                else
                {
                    pageType.InnerText = "Add ";
                }
            }
        }

        protected void Add_Edit_Document(object sender, EventArgs e)
        {
            DOCSDB database = new DOCSDB();

            Document new_document = new Document();
            Debug.WriteLine(pageTitle.Text);
            new_document.SetDocumentTitle(pageTitle.Text);
            new_document.SetDocumentContent(pageContent.Text);
            //new_document.SetDocumentCreated(DateTime.Now);
            string document_id = Request.QueryString["document_id"];
            bool valid = true;
            if (String.IsNullOrEmpty(document_id)) valid = false;
            if (valid)
            {
                Debug.WriteLine("if");
                database.AddEditDocument(new_document, Int32.Parse(document_id));
            }
            else
            {
                Debug.WriteLine("else");
                database.AddEditDocument(new_document, 0);
            }

            Response.Redirect("DocumentList.aspx");
        }
    }
}