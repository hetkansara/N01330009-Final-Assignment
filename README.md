# HK Docs - N01330009 - Final Assignment - Web Application Development #

**HK-Docs** is an application build with visual studio. It's a CRUD Application of Documents. Users can add/update/view or delete their documents.

## Developed by ##

    Het Kansara - Web Development - Humber College (N01330009)

## How to configure the project? ##

1. Clone Git Repository - Using GIT CLI
    * Open Terminal
    * `git clone https://github.com/hetkansara/N01330009-Final-Assignment.git`
2. Navigate to project directory - `N01330009-Final-Assignment`
3. Open project with [`Visual Studio`](https://visualstudio.microsoft.com/downloads/)
4. Configure your mysql database credentials in `DOCSDB.cs`
    ### DOCSDB ###
    ![DOCSDB.cs](https://i.ibb.co/5jdkLJb/Screenshot-63.png)

## Wireframes ##
   ### Documents Listing
   ![Documents Listing](https://i.ibb.co/Ht3WRvv/Screenshot-64.png)

   ### Add Document
   ![Add Document](https://i.ibb.co/DwFyGF0/Screenshot-65.png)

   ### Edit Document
   ![Edit Document](https://i.ibb.co/7QZpzm1/Screenshot-67.png)

   ### Delete Document
   ![Delete Document](https://i.ibb.co/tZhHyv4/Screenshot-68.png)

   ### View Document
   ![View Document](https://i.ibb.co/j4315n5/Screenshot-69.png)

## Structure of Project(Code Organization) ##

### Dependencies ###
   * Visual Studio 
   * MySQL Server

### Frontend ###
`DocumentList.aspx` is the landing page of the web application containing all the documents listing. Click on any page to render the page or we can direct add/edit pages by using action buttons.

All CSS files are at `Content/` folder and all Scripts are located in `Content/Scripts` folder.

There are many Javascript files which are bundled together with `Webpack`, which combines all of them and outputs a `app.bundle.js` which is included in `index.html`.

### Backend ###
We have a `Pages` database in the backend. The structure of the database is as given below.

### Pages Table ###

| PAGE_ID | PAGE_TITLE | PAGE_BODY | CREATED_ON |
| ------- | ----------- | ----- | ------- |
| 1 | About me | `<h1><font color="#ff0000"><b>Het Kansara</b></font></h1>` | 2019-11-30 20:11:16 |
| 2 | Contact me | `<h1><font color="#ff0000"><b>Contact Number</b></font></h1>` | 2019-12-03 15:18:26 |

Get sample database .sql file from `Database` folder 

## External API(s) & References ##

   1. For database connection: https://github.com/christinebittle/crud_essentials (SCHOOLDB.cs)
   2. Fonts used from: https://fonts.google.com/
   3. Icons used from: https://fontawesome.com/
   4. Text editor plugin for editing document: https://github.com/webfashionist/RichText
   5. Other Libraries: Bootstrap(https://getbootstrap.com/) & Jquery(https://jquery.com/)