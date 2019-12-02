﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace N01330009_Final_Assignment
{
    public class DOCSDB
    {
        // Reference file: https://github.com/christinebittle/crud_essentials (SCHOOLDB.cs)
        // Date Taken: 28th November. 2019

        private static string User { get { return "root"; } }
        private static string Password { get { return ""; } }
        private static string Database { get { return "page_db"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return ""; } }

        //ConnectionString is something that we use to connect to a database
        private static string ConnectionString {
            get {
                return "server = "+Server
                    +"; user = "+User
                    +"; database = "+Database
                    +"; port = "+Port
                    +"; password = "+Password;
            }
        }

        // This function is as it was in the SCHOOLDB.cs (No Changes) - Het Kansara
        //returns a result set
        //is a list dictionaries
        //a dictionary is like a list but with Key:Value pairs
        //they are also known as "associative arrays"
        public List<Dictionary<String,String>> List_Query(string query)
        {
            MySqlConnection Connect = new MySqlConnection(ConnectionString);

            // INPUT -> (string) SELECT QUERY 
            // e.g. "select * from students";
            // OUTPUT -> (List<Dictionary<String,String>>) RESULT SET 
            // e.g. 
            //[
            //  {"STUDENTFNAME":"SARAH","STUDENTLNAME":"Valdez","STUDENTNUMBER":"N1678","ENROLMENTDATE":"2018-06-18"},
            //  {"STUDENTFNAME":"Jennifer","STUDENTLNAME":"FAULKNER","STUDENTNUMBER":"N1679","ENROLMENTDATE":"2018-08-02"},
            //  {"STUDENTFNAME":"Austin","STUDENTLNAME":"Simon","STUDENTNUMBER":"N1682","ENROLMENTDATE":"2018-06-14"},
            //  ...
            //] 
            List<Dictionary<String, String>> ResultSet = new List<Dictionary<String, String>>();

            // try{} catch{} will attempt to do everything inside try{}
            // if an error happens inside try{}, then catch{} will execute instead.
            // very useful for debugging without the whole program crashing!
            // this can be easily abused and should be used sparingly.
            try
            {
                Debug.WriteLine("Connection Initialized...");
                Debug.WriteLine("Attempting to execute query "+query);
                //open the db connection
                Connect.Open();
                //give the connection a query
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                //grab the result set
                MySqlDataReader resultset = cmd.ExecuteReader();

                
                //for every row in the result set
                while (resultset.Read())
                {
                    Dictionary<String,String> Row = new Dictionary<String, String>();
                    //for every column in the row
                    for(int i = 0; i < resultset.FieldCount; i++)
                    {
                        Row.Add(resultset.GetName(i), resultset.GetString(i));
                        
                    }
                    
                    ResultSet.Add(Row);
                }//end row
                resultset.Close();

                
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the List_Query method!");
                Debug.WriteLine(ex.ToString());
               
            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return ResultSet;
        }

        public Document FindDocument(int id)
        {
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            Document result_document = new Document();

            try
            {
                string query = "SELECT page_id, page_title, page_body, DATE_FORMAT(created_on, '%m/%d/%Y %h:%i %p') AS created_on FROM pages where page_id=" + id;
                Console.WriteLine(query);
                Debug.WriteLine("Connection Initialized...");
                Connect.Open();
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                MySqlDataReader resultset = cmd.ExecuteReader();
                
                List<Document> documents = new List<Document>();

                while (resultset.Read())
                {
                    Document currentDocument = new Document();
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        string key = resultset.GetName(i);
                        string value = resultset.GetString(i);
                        Debug.WriteLine("Attempting to transfer " + key + " data of " + value);
                        Console.WriteLine(value);
                        switch (key)
                        {
                            case "page_title":
                                currentDocument.SetDocumentTitle(value);
                                break;
                            case "page_body":
                                currentDocument.SetDocumentContent(value);
                                break;
                            case "created_on":
                                currentDocument.SetDocumentCreated(value);
                                break;
                        }

                    }
                    documents.Add(currentDocument);
                }

                result_document = documents[0]; //get the first student

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the find Document method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return result_document;
        }



        // add page into database
        public void AddEditDocument(Document new_document, int documentID)
        {
            Console.WriteLine("AScas");
            string query;
            if (documentID == 0)
            {
                query = "INSERT INTO pages(page_id, page_title, page_body) VALUES (NULL,'{0}','{1}')";
                query = String.Format(query, new_document.GetDocumentTitle(), new_document.GetDocumentBody());
            } 
            else
            {
                query = "update pages set page_title='{0}', page_body='{1}' where page_id={2}";
                query = String.Format(query, new_document.GetDocumentTitle(), new_document.GetDocumentBody(), documentID);
            }

            Debug.WriteLine(query);

            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                Connect.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the AddEditDocument Method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
        }


        public void DeleteDocument(int document_id)
        {
            //DELETING ON THE PRIMARY KEY OF STUDENTS
            string query = "delete from pages where page_id = {0}";
            query = String.Format(query, document_id);

            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            //This command removes the particular student from the table
            MySqlCommand cmd_removedocument = new MySqlCommand(query, Connect);
            try
            {
                //try to execute both commands!
                Connect.Open();
                //then delete the main record
                cmd_removedocument.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + cmd_removedocument);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the delete Document Method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
        }

    }
}