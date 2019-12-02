using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace N01330009_Final_Assignment
{
    public partial class DocumentDelete : Page
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
                }
                else
                {
                    documentTitle.InnerText = "[Document title not found]";
                }
            }
        }

        protected void Delete_Document(object sender, EventArgs e)
        {
            bool valid = true;
            string documentID = Request.QueryString["document_id"];
            if (String.IsNullOrEmpty(documentID)) valid = false;
            if (valid)
            {
                database.DeleteDocument(Int32.Parse(documentID));
                Response.Redirect(Request.QueryString["parent"] + ".aspx");
            }
        }

        protected void Go_Back(object sender, EventArgs e)
        {
            Response.Redirect(Request.QueryString["parent"] + ".aspx");
        }
    }
}