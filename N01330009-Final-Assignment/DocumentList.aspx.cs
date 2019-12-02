using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace N01330009_Final_Assignment
{
    public partial class DocumentList : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            document_list.InnerHtml = "";
            NoResultMsg.InnerHtml = "";
            NoResultMsg.Style.Add("display", "none");

            string searchkey = "";
            if (Page.IsPostBack)
            {
                searchkey = searchText.Text;
            }

            string query = "select * from pages";

            if (searchkey != "")
            {
                query += " WHERE page_title like '%" + searchkey + "%' ";
            }
            
            query += " order by created_on DESC";
            var database = new DOCSDB();
            List<Dictionary<String, String>> rs = database.List_Query(query);
            if (rs.Count == 0)
            {
                NoResultMsg.InnerHtml = "No Documents found with name <b>"+ searchkey + "</b>...";
                NoResultMsg.Style.Add("display", "block");

            }
            foreach (Dictionary<String, String> row in rs)
            {
                document_list.InnerHtml += "<div class=\"col-md-2\">";
                document_list.InnerHtml += "<div class=\"icons page-icons-container\">";
                document_list.InnerHtml += "<a href = \"DocumentAddEdit.aspx?document_id=" + row["page_id"] + "\" title=\"Edit Document\"><i class=\"fas fa-edit page-edit-icon\"></i></a>";
                document_list.InnerHtml += "<a href = \"DocumentDelete.aspx?parent=DocumentList&document_id=" + row["page_id"] + "\" title=\"Delete Document\"><i class=\"fas fa-trash page-delete-icon\"></i></a></div>";
                document_list.InnerHtml += "<a href = \"DocumentView.aspx?document_id=" + row["page_id"] + "\" class=\"view-link\" title=\"View Document\"><div class=\"page-content document-container view-btn\"><div class=\"output-html\"><h1>" + row["page_body"] + "</h1></div></div></a>";
                document_list.InnerHtml += "<div class=\"page-title-text\"><p class=\"page-title\">" + row["page_title"] + "</p><p class=\"page-date-created\">" + row["created_on"] + "</p></div></div>";
            }


        }

        protected void Add_Document(object sender, EventArgs e)
        {
            Response.Redirect("DocumentAddEdit.aspx");
        }
    }
}