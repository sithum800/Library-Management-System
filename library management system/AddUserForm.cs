using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace library_management_system
{
    public partial class AddUserForm : Form
    {
        private DatabaseConnection dbConnection;
        private AdminDashboard parentDashboard; 

        public AddUserForm(AdminDashboard dashboard)
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            parentDashboard = dashboard;
            cmbUserType.Items.AddRange(new object[] { "Admin", "Basic" });
            cmbUserType.SelectedIndex = 1; // Default to Basic
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text; // NO HASHING
            string userType = cmbUserType.SelectedItem.ToString();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and Password cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // if username already exists

            if (dbConnection.OpenConnection())
            {
                string query = "INSERT INTO Users (Username, Password, UserType) VALUES (@Username, @Password, @UserType)";
                MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@UserType", userType);

                try
                {
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("User created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        parentDashboard.LoadUsers(); 
                        this.Close(); 
                    }
                    else
                    {
                        MessageBox.Show("Failed to create user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (MySqlException ex)
                {
                    // duplicate username
                    if (ex.Number == 1062) // Error code - duplicate entry
                    {
                        MessageBox.Show("Username already exists. Please choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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