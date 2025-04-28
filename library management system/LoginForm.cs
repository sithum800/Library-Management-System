using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace library_management_system
{
    public partial class LoginForm : Form
    {
        private DatabaseConnection dbConnection;

        public LoginForm()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            // Center form on screen
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                lblMessage.Text = "Please enter both username and password.";
                return;
            }

            if (dbConnection.OpenConnection())
            {
                // UserID, UserType, and Username
                string query = "SELECT UserID, UserType, Username FROM Users WHERE Username = @Username AND Password = @Password";
                MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                try
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // If a user is found
                        {
                            int userId = reader.GetInt32("UserID");
                            string userType = reader.GetString("UserType");
                            string fetchedUsername = reader.GetString("Username");  

                            lblMessage.Text = "Login successful!";
                            
                            
                            reader.Close(); 

                           
                            if (userType == "Admin")
                            { 
                                AdminDashboard adminDashboard = new AdminDashboard(this); 
                                adminDashboard.Show();
                                this.Hide();  
                            }
                            else // Basic User
                            {
                                
                                UserDashboard userDashboard = new UserDashboard(userId, fetchedUsername, this);
                                userDashboard.Show();
                                this.Hide();  
                            }
                        }
                        else
                        {
                            // No user found
                            reader.Close();  
                            lblMessage.Text = "Invalid username or password.";
                        }
                    } 
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Database error during login: " + ex.Message;
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            else
            {
                lblMessage.Text = "Failed to connect to the database.";
            }
        }
    }
} 