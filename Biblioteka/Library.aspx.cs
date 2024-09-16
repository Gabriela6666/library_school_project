using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using MySql.Data.MySqlClient;
using System.Text;
using System.Drawing;


namespace Biblioteka
{
    public partial class Library : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private MySqlConnection connect()
        {
            lInfo.Text = "Connecting 1...";
            lInfo.ForeColor = Color.Red;
            string ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=szkola";

            MySqlConnection connection = new MySqlConnection(ConnectionString);

            try 
            {
                lInfo.Text = "Connecting 2...";
                lInfo.ForeColor = Color.Red;
                connection.Open();
                lInfo.Text = "Connected";
                lInfo.ForeColor = Color.Red;
                return connection;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                lInfo.Text = "ERROR: " + ex.Message;
                lInfo.ForeColor = Color.Red;
            }
            return null;
        }

        string text;

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (lSwitch.Text == "ON")
            {
                lInfo.Text = "The process has already started!";
                lInfo.ForeColor = Color.Red;
                return;
            }

            lSwitch.Text = "ON";
            lSwitch.ForeColor = Color.LimeGreen;

            MySqlConnection conn = connect();
            if (conn == null)
            {
                lInfo.Text = "ERROR";
                lInfo.ForeColor = Color.Red;
                return;
            }

            text = "SELECT * FROM books";
            MySqlCommand command = new MySqlCommand(text, conn);
            //command.CommandTimeout = 60;

            try
            {
                MySqlDataReader myReader = command.ExecuteReader();

                if(myReader.HasRows)
                {
                    lInfo.Text = "Books";
                    lInfo.ForeColor = Color.Blue;

                    while (myReader.Read())
                    {
                        lbBooks.Items.Add(myReader.GetString(0) + " | " + myReader.GetString(1) + " " +  '"' + myReader.GetString(2) + '"');
                    }
                }
                else
                {
                    lInfo.Text = "Query seccessfully executed";
                    lInfo.ForeColor = Color.Blue;
                }
            }
            catch (Exception ex)
            {
                lInfo.Text = "QUERY ERROR: " + ex.Message;
                lInfo.ForeColor = Color.Red;
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            string napis = lbBooks.Text;

            if(napis == "")
            {
                lInfo.Text = "Click on a book!";
                lInfo.ForeColor = Color.Red;

                return;
            }

            string autor = "", tytul = "", liczba = "";
            int iter = 0;
            while (napis[iter] != ' ')
            {
                liczba += napis[iter];
                iter++;
            }
            lId.Text = liczba;
            lId.ForeColor = Color.Black;

            iter += 3;
            while (napis[iter] != '"')
            {
                autor += napis[iter];
                iter++;
            }
            string Autor = "";
            for(int i = 0; i < autor.Length - 1; i++)
            {
                Autor += autor[i];
            }
            txtAuthor.Text = Autor;
            iter++;
            while (iter < napis.Length - 1)
            {
                tytul += napis[iter];
                iter++;
            }
            txtTitle.Text = tytul;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            lbBooks.Items.Clear();
            txtAuthor.Text = "";
            txtTitle.Text = "";
            lInfo.Text = "...";
            lInfo.ForeColor = Color.Red;
            lId.Text = "NULL";
            lId.ForeColor = Color.White;
            lSwitch.Text = "OFF";
            lSwitch.ForeColor = Color.Red;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string author = txtAuthor.Text;
            string title = txtTitle.Text;

            if ((author == "")&&(title == ""))
            {
                lInfo.Text = "Please insert some data";
                lInfo.ForeColor = Color.Red;
                return;
            }

            MySqlConnection conn = connect();
            if (conn == null)
            {
                lInfo.Text = "ERROR";
                lInfo.ForeColor = Color.Red;
                return;
            }

            if(title == "")
            {
                text = "SELECT * FROM books WHERE Authors=";
                text += '"';
                text += author;
                text += '"';
                MySqlCommand command_1 = new MySqlCommand(text, conn);

                try
                {
                    lbBooks.Items.Clear();
                    lId.Text = "NULL";
                    lId.ForeColor = Color.White;
                    MySqlDataReader myReader = command_1.ExecuteReader();

                    if (myReader.HasRows)
                    {
                        lInfo.Text = "Books written by: " + author;
                        lInfo.ForeColor = Color.Blue;

                        while (myReader.Read())
                        {
                            lbBooks.Items.Add(myReader.GetString(1) + " " + '"' + myReader.GetString(2) + '"');
                        }
                    }
                    else
                    {
                        lInfo.Text = "Not in the database";
                        lInfo.ForeColor = Color.Blue;
                    }
                }
                catch (Exception ex)
                {
                    lInfo.Text = "QUERY ERROR: " + ex.Message;
                    lInfo.ForeColor = Color.Red;
                }

                return;
            }
            
            if(author == "")
            {
                text = "SELECT * FROM books WHERE Title=";
                text += '"';
                text += title;
                text += '"';
                MySqlCommand command_2 = new MySqlCommand(text, conn);

                try
                {
                    lbBooks.Items.Clear();
                    lId.Text = "NULL";
                    lId.ForeColor = Color.White;
                    MySqlDataReader myReader = command_2.ExecuteReader();

                    if (myReader.HasRows)
                    {
                        lInfo.Text = "Books titled: " + '"' + title + '"';
                        lInfo.ForeColor = Color.Blue;

                        while (myReader.Read())
                        {
                            lbBooks.Items.Add(myReader.GetString(1) + " " + '"' + myReader.GetString(2) + '"');
                        }
                    }
                    else
                    {
                        lInfo.Text = "Not in the database";
                        lInfo.ForeColor = Color.Blue;
                    }
                }
                catch (Exception ex)
                {
                    lInfo.Text = "QUERY ERROR: " + ex.Message;
                    lInfo.ForeColor = Color.Red;
                }

                return;
            }

            text = "SELECT * FROM books WHERE Authors=";
            text += '"';
            text += author;
            text += '"';
            text += " AND Title=";
            text += '"';
            text += title;
            text += '"';
            

            MySqlCommand command = new MySqlCommand(text, conn);

            try
            {
                lbBooks.Items.Clear();
                lId.Text = "NULL";
                lId.ForeColor = Color.White;
                MySqlDataReader myReader = command.ExecuteReader();

                if (myReader.HasRows)
                {
                    lInfo.Text = "Books titled " + '"' + title + '"' + " written by: " + author;
                    lInfo.ForeColor = Color.Blue;

                    while (myReader.Read())
                    {
                        lbBooks.Items.Add(myReader.GetString(1) + " " + '"' + myReader.GetString(2) + '"');
                    }
                }
                else
                {
                    lInfo.Text = "Not in the database";
                    lInfo.ForeColor = Color.Blue;
                }
            }
            catch (Exception ex)
            {
                lInfo.Text = "QUERY ERROR: " + ex.Message;
                lInfo.ForeColor = Color.Red;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string author = txtAuthor.Text;
            string title = txtTitle.Text;

            if (author == "")
            {
                lInfo.Text = "Please insert the author";
                lInfo.ForeColor = Color.Red;
                return;
            }
            if (title == "")
            {
                lInfo.Text = "Please insert the title";
                lInfo.ForeColor = Color.Red;
                return;
            }

            MySqlConnection conn = connect();
            if (conn == null)
            {
                lInfo.Text = "ERROR";
                lInfo.ForeColor = Color.Red;
                return;
            }

            text = "INSERT INTO books VALUES (NULL, ";
            text += '"';
            text += author;
            text += '"';
            text += ", ";
            text += '"';
            text += title;
            text += '"';
            text += ", DEFAULT, DEFAULT, DEFAULT, DEFAULT, DEFAULT)";

            MySqlCommand command = new MySqlCommand(text, conn);

            try
            {
                command.ExecuteNonQuery();

                lInfo.Text = "Query seccessfully executed";
                lInfo.ForeColor = Color.Blue;

                txtAuthor.Text = "";
                txtTitle.Text = "";
                lId.Text = "NULL";
                lId.ForeColor = Color.White;
            }
            catch (Exception ex)
            {
                lInfo.Text = "QUERY ERROR: " + ex.Message;
                lInfo.ForeColor = Color.Red;
            }

            text = "SELECT * FROM books";
            lbBooks.Items.Clear();
            MySqlCommand command_1 = new MySqlCommand(text, conn);

            try
            {
                MySqlDataReader myReader = command_1.ExecuteReader();

                if (myReader.HasRows)
                {
                    lInfo.Text = "Books";
                    lInfo.ForeColor = Color.Blue;

                    while (myReader.Read())
                    {
                        lbBooks.Items.Add(myReader.GetString(0) + " | " + myReader.GetString(1) + " " + '"' + myReader.GetString(2) + '"');
                    }
                }
                else
                {
                    lInfo.Text = "Query seccessfully executed";
                    lInfo.ForeColor = Color.Blue;
                }
            }
            catch (Exception ex)
            {
                lInfo.Text = "QUERY ERROR: " + ex.Message;
                lInfo.ForeColor = Color.Red;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string id = lId.Text;

            if (id == "NULL")
            {
                lInfo.Text = "No book was selected!";
                lInfo.ForeColor = Color.Red;
                return;
            }

            MySqlConnection conn = connect();
            if (conn == null)
            {
                lInfo.Text = "ERROR";
                lInfo.ForeColor = Color.Red;
                return;
            }

            text = "DELETE FROM books WHERE Id=" + id;

            MySqlCommand command = new MySqlCommand(text, conn);

            try
            {
                command.ExecuteNonQuery();

                lInfo.Text = "Query seccessfully executed";
                lInfo.ForeColor = Color.Blue;

                txtAuthor.Text = "";
                txtTitle.Text = "";
                lId.Text = "NULL";
                lId.ForeColor = Color.White;
            }
            catch (Exception ex)
            {
                lInfo.Text = "QUERY ERROR: " + ex.Message;
                lInfo.ForeColor = Color.Red;
            }

            text = "SELECT * FROM books";
            lbBooks.Items.Clear();
            MySqlCommand command_1 = new MySqlCommand(text, conn);

            try
            {
                MySqlDataReader myReader = command_1.ExecuteReader();

                if (myReader.HasRows)
                {
                    lInfo.Text = "Books";
                    lInfo.ForeColor = Color.Blue;

                    while (myReader.Read())
                    {
                        lbBooks.Items.Add(myReader.GetString(0) + " | " + myReader.GetString(1) + " " + '"' + myReader.GetString(2) + '"');
                    }
                }
                else
                {
                    lInfo.Text = "Query seccessfully executed";
                    lInfo.ForeColor = Color.Blue;
                }
            }
            catch (Exception ex)
            {
                lInfo.Text = "QUERY ERROR: " + ex.Message;
                lInfo.ForeColor = Color.Red;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string author = txtAuthor.Text;
            string title = txtTitle.Text;

            if (author == "")
            {
                lInfo.Text = "Please insert the author";
                lInfo.ForeColor = Color.Red;
                return;
            }
            if (title == "")
            {
                lInfo.Text = "Please insert the title";
                lInfo.ForeColor = Color.Red;
                return;
            }

            MySqlConnection conn = connect();
            if (conn == null)
            {
                lInfo.Text = "ERROR";
                lInfo.ForeColor = Color.Red;
                return;
            }

            text = "UPDATE books SET Authors=";
            text += '"';
            text += author;
            text += '"';
            text += ", Title=";
            text += '"';
            text += title;
            text += '"';
            text += " WHERE Id=";
            text += lId.Text;

            MySqlCommand command = new MySqlCommand(text, conn);

            try
            {
                command.ExecuteNonQuery();

                lInfo.Text = "Query seccessfully executed";
                lInfo.ForeColor = Color.Blue;

                txtAuthor.Text = "";
                txtTitle.Text = "";
                lId.Text = "NULL";
                lId.ForeColor = Color.White;
            }
            catch (Exception ex)
            {
                lInfo.Text = "QUERY ERROR: " + ex.Message;
                lInfo.ForeColor = Color.Red;
            }

            text = "SELECT * FROM books";
            lbBooks.Items.Clear();
            MySqlCommand command_1 = new MySqlCommand(text, conn);

            try
            {
                MySqlDataReader myReader = command_1.ExecuteReader();

                if (myReader.HasRows)
                {
                    lInfo.Text = "Books";
                    lInfo.ForeColor = Color.Blue;

                    while (myReader.Read())
                    {
                        lbBooks.Items.Add(myReader.GetString(0) + " | " + myReader.GetString(1) + " " + '"' + myReader.GetString(2) + '"');
                    }
                }
                else
                {
                    lInfo.Text = "Query seccessfully executed";
                    lInfo.ForeColor = Color.Blue;
                }
            }
            catch (Exception ex)
            {
                lInfo.Text = "QUERY ERROR: " + ex.Message;
                lInfo.ForeColor = Color.Red;
            }
        }
    }
}