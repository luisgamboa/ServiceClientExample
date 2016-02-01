using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    BookReviewServiceReference1.AuthorBookServiceClient db 
        = new BookReviewServiceReference1.AuthorBookServiceClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDropDown();
        }
    
    }
    protected void DropDownListAuthor_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();

    }

    protected void LoadDropDown()
    {
        string[] authors = db.GetAuthors();
        DropDownListAuthor.DataSource = authors;
        DropDownListAuthor.DataBind();
        DropDownListAuthor.Items.Add("Choose an Author");
        DropDownListAuthor.Items.Insert(0, "Choose an Author");
    }

    protected void FillGrid()
    { 
        string author = DropDownListAuthor.SelectedItem.Text;
        BookReviewServiceReference1.BookLite[] books = db.GetBooks(author);
        GridViewBooks.DataSource = books;
        GridViewBooks.DataBind();

    }
}