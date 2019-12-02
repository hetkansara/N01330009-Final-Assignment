using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace N01330009_Final_Assignment
{
    public class Document
    {
        private string DocumentTitle;
        private string DocumentBody;
        private string DocumentCreated;

        public string GetDocumentTitle()
        {
            return DocumentTitle;
        }
        public string GetDocumentBody()
        {
            return DocumentBody;
        }
        public string GetDocumentCreated()
        {
            return DocumentCreated;
        }

        public void SetDocumentTitle(string value)
        {
            DocumentTitle = value;
        }
        public void SetDocumentContent(string value)
        {
            DocumentBody = value;
        }
        public void SetDocumentCreated(string value)
        {
            DocumentCreated = value;
        }

    }
}