using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace library_management_system
{
    public partial class AddBookForm : Form
    {
        private DatabaseConnection dbConnection;
        private AdminDashboard parentDashboard;  

        public AddBookForm(AdminDashboard dashboard)
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            parentDashboard = dashboard;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string author = txtAuthor.Text.Trim();
            string category = txtCategory.Text.Trim();
            string isbn = txtISBN.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(author) || 
                string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(isbn))
            {
                MessageBox.Show("All fields (Name, Author, Category, ISBN) are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Optional: Add check if ISBN already exists

            if (dbConnection.OpenConnection())
            {
                // Availability defaults to 'Available'
                string query = "INSERT INTO Books (Name, Author, Category, ISBN) VALUES (@Name, @Author, @Category, @ISBN)";
                MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Author", author);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@ISBN", isbn);

                try
                {
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Book added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        parentDashboard.LoadBooks();  
                        this.Close(); 
                    }
                    else
                    {
                        MessageBox.Show("Failed to add book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (MySqlException ex)
                {
                    // duplicate ISBN
                    if (ex.Number == 1062) // Error code - duplicate entry
                    {
                        MessageBox.Show("A book with this ISBN already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                         MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            else
            {
                MessageBox.Show("Database connection failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
} 