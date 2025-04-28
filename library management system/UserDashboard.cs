using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace library_management_system
{
    public partial class UserDashboard : Form
    {
        private DatabaseConnection dbConnection;
        private int currentUserID;
        private string currentUsername;
        private LoginForm loginFormInstance; 

        public UserDashboard(int userId, string username, LoginForm loginForm)
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();

            currentUserID = userId;
            currentUsername = username;
            loginFormInstance = loginForm;

            // Display user info
            lblWelcomeUser.Text = $"Welcome, {currentUsername} (ID: {currentUserID})";

            ConfigureSearchResultsGrid();
            if (cmbSearchBy.Items.Count > 0)
            {
                cmbSearchBy.SelectedIndex = 0; 
            }
            this.StartPosition = FormStartPosition.CenterScreen;

            
            this.FormClosed += UserDashboard_FormClosed;
        }

        private void ConfigureSearchResultsGrid()
        {
            dgvSearchResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSearchResults.ReadOnly = true;
            dgvSearchResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearchTerm.Text.Trim();
            string searchBy = cmbSearchBy.SelectedItem.ToString(); // Name, Author, Category, ISBN

            if (string.IsNullOrWhiteSpace(searchBy))
            {
                 MessageBox.Show("Please select a search criteria (Name, Author, etc.).", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 return;
            }

             
            dgvSearchResults.DataSource = null;

            if (dbConnection.OpenConnection())
            {
                
                string query = $"SELECT Name, Author, Category, ISBN, Availability FROM Books WHERE {searchBy} LIKE @SearchTerm";
                
                MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%"); 

                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        dgvSearchResults.DataSource = dataTable;
                        
                    }
                    else
                    {
                        MessageBox.Show("No books found matching your criteria.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error performing search: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnLogout_Click(object sender, EventArgs e)
        {
           
            this.Hide(); 
            loginFormInstance.Show(); 
            this.Close();
        }

       
        private void UserDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            if (!loginFormInstance.Visible)
            {
                 loginFormInstance.Show();
            }
            
        }
    }
} 