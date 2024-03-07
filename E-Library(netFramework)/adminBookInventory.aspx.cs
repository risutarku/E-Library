using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace E_Library_netFramework_
{
    public partial class adminBookInventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_books;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillAuthorPublisherValues();
                fillPublisherValues();
            }
            GridView1.DataBind();
        }

        // go button 
        protected void Button4_Click(object sender, EventArgs e)
        {
            getBookByID();
        }

        // add button 
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfBookExist())
            {
                Response.Write("<script>alert('Book Already Exists, try some other Book ID')</script>");
            }
            else
            {
                addNewBook();
            }

        }

        // update button 
        protected void Button1_Click(object sender, EventArgs e)
        {
            updateBookByID();
        }

        // delete button 
        protected void Button3_Click(object sender, EventArgs e)
        {
            deleteBookByID();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        // user defined functions
        void deleteBookByID()
        {
            if (checkIfBookExist())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE FROM book_master_tbl WHERE book_id='" + TextBox3.Text.Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@author_name", TextBox4.Text.Trim());

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Book Deleted successfully');</script>");
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid member ID');</script>");

            }
        }
        void updateBookByID()
        {
            if (checkIfBookExist())
            {
                try
                {
                    int actual_stock = Convert.ToInt32(TextBox2.Text.Trim());
                    int current_stock = Convert.ToInt32(TextBox6.Text.Trim());

                    if (global_actual_stock == actual_stock)
                    {

                    }
                    else
                    {
                        if (actual_stock < global_issued_books)
                        {
                            Response.Write("<script>alert('Actual Stock value cannot" +
                                " be less than the Issued books ');</script>");
                        }
                        else
                        {
                            current_stock = actual_stock - global_issued_books;
                            TextBox6.Text = "" + current_stock;
                        }
                    }

                    string genres = "";
                    foreach (int i in ListBox1.GetSelectedIndices())
                    {
                        genres += ListBox1.Items[i] + ",";
                    }
                    genres = genres.Remove(genres.Length - 1);

                    string filepath = "~book_invcentory/books1.png";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (filename == "" || filename == null)
                    {
                        filepath = global_filepath;
                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("book_invcentory/" + filename));
                        filepath = "~book_invcentory/" + filename;
                    }


                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    
                    SqlCommand cmd = new SqlCommand("UPDATE book_master_tbl SET " +
                        "book_name=@book_name, genre=@genre, author_name=@author_name," +
                        "publisher_name=@publisher_name, publisher_date=@publisher_date," +
                        "language=@language, edition=@edition, book_cost=@book_cost," +
                        "no_of_pages=@no_of_pages, book_description=@book_description," +
                        "actual_stock=@actual_stock, current_stock=@current_stock," +
                        "book_img_link=@book_img_link WHERE book_id='" + TextBox3.Text.Trim() + "'", con);


                    cmd.Parameters.AddWithValue("@book_name", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre", genres);
                    cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_date", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@edition", TextBox9.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_cost", TextBox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@no_of_pages", TextBox11.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_description", TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", actual_stock.ToString());
                    cmd.Parameters.AddWithValue("@current_stock", current_stock.ToString());
                    cmd.Parameters.AddWithValue("@book_img_link", filepath);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Book updated successfully');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");

                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID');</script>");
            }
        }
        void getBookByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from book_master_tbl WHERE book_id=" +
                    "'"+TextBox3.Text.Trim()+"';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    TextBox4.Text = dt.Rows[0]["book_name"].ToString();
                    TextBox1.Text = dt.Rows[0]["publisher_date"].ToString();
                    TextBox9.Text = dt.Rows[0]["edition"].ToString();
                    TextBox10.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                    TextBox11.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                    TextBox2.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    TextBox6.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    TextBox7.Text = ""+ (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));
                    TextBox5.Text = dt.Rows[0]["book_description"].ToString();
                    DropDownList1.SelectedValue = dt.Rows[0]["language"].ToString().Trim();
                    DropDownList2.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();
                    DropDownList3.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();

                    ListBox1.ClearSelection();
                    string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');
                    for(int i = 0; i < genre.Length; i++)
                    {
                        for (int j = 0; j < ListBox1.Items.Count; j++)
                        {
                            if (ListBox1.Items[j].ToString() == genre[i])
                            {
                                ListBox1.Items[j].Selected = true;
                            }
                        }
                    }

                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                    global_issued_books = global_actual_stock - global_current_stock;
                    global_filepath = dt.Rows[0]["book_img_link"].ToString();

                }
                else
                {
                    Response.Write("<script>alert('Invalid Book ID');</script>");
                }

            }
            catch (Exception ex)
            {

            }
        }
        void fillAuthorPublisherValues()
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT author_name from author_master_tbl;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataValueField = "author_name";
                DropDownList3.DataBind();

                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
            }
        }
        void fillPublisherValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT publisher_name from publisher_master_tbl;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "publisher_name";
                DropDownList2.DataBind();

                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
            }
        }
        bool checkIfBookExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id='"+
                    TextBox3.Text.Trim() + "' OR book_name='"+TextBox4.Text.Trim()+"';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
        void addNewBook()
        {
            try
            {
                string genres = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i] + ",";
                }
                genres = genres.Remove(genres.Length - 1);

                string filePath = "~/book_inventory/books1.png";
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("book_inventory/" + fileName));
                filePath = "~/book_inventory/" + fileName;

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tbl" +
                    "(book_id,book_name,genre,author_name,publisher_name,publisher_date,language,edition,book_cost,no_of_pages,book_description," +
                    "actual_stock,current_stock,book_img_link) values" +
                    "(@book_id,@book_name,@genre,@author_name,@publisher_name,@publisher_date,@language,@edition,@book_cost,@no_of_pages,@book_description," +
                    "@actual_stock,@current_stock,@book_img_link)", con);

                cmd.Parameters.AddWithValue("@book_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_date", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", TextBox11.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@book_img_link", filePath);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book added successfully')</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('"+ex.Message+"')</script>");
            }
        }

    }
}