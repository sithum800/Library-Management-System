using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace library_management_system
{
    public partial class AdminDashboard : Form
    {
        private DatabaseConnection dbConnection;
        private LoginForm loginFormInstance; 

        public AdminDashboard(LoginForm loginForm) 
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            loginFormInstance = loginForm;
            LoadUsers();
            LoadBooks();
            LoadBorrowedBooks();
            ConfigureUserGrid();
            ConfigureBookGrid();
            ConfigureBorrowedBooksGrid();


            this.FormClosed += AdminDashboard_FormClosed;
        }

        // --- User Management --- 
        private void ConfigureUserGrid()
        {
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.ReadOnly = true;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public void LoadUsers()
        {
            if (dbConnection.OpenConnection())
            {
                string query = "SELECT UserID, Username, UserType, CreatedDate FROM Users";
                MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvUsers.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading users: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            AddUserForm addUserForm = new AddUserForm(this); 
            addUserForm.ShowDialog(); 
        }

        // --- Book Management --- 
        private void ConfigureBookGrid()
        {
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.ReadOnly = true;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public void LoadBooks()
        {
             if (dbConnection.OpenConnection())
            {

                string query = "SELECT BookID, Name, Author, Category, ISBN, Availability FROM Books";
                MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvBooks.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading books: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        

        private void btnAddBook_Click(object sender, EventArgs e)
        {

            AddBookForm addBookForm = new AddBookForm(this);
            addBookForm.ShowDialog();
        }

        // --- Borrow Management --- 
        private void ConfigureBorrowedBooksGrid()
        {
            dgvBorrowedBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBorrowedBooks.ReadOnly = true;
            dgvBorrowedBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        public void LoadBorrowedBooks()
        {
            if (dbConnection.OpenConnection())
            {

                string query = @"SELECT 
                                    bb.BorrowID, 
                                    u.Username, 
                                    b.Name AS BookName, 
                                    bb.BorrowDate, 
                                    bb.UserID, 
                                    bb.BookID 
                                FROM BorrowedBooks bb
                                JOIN Users u ON bb.UserID = u.UserID
                                JOIN Books b ON bb.BookID = b.BookID
                                WHERE bb.Status = 'Active'";
                MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvBorrowedBooks.DataSource = dataTable;


                    if (dgvBorrowedBooks.Columns.Contains("UserID"))
                        dgvBorrowedBooks.Columns["UserID"].Visible = false;
                    if (dgvBorrowedBooks.Columns.Contains("BookID"))
                         dgvBorrowedBooks.Columns["BookID"].Visible = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading borrowed books: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnBorrowBook_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtBorrowUserID.Text, out int userId) || !int.TryParse(txtBorrowBookID.Text, out int bookId))
            {
                MessageBox.Show("Please enter valid numeric User ID and Book ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!dbConnection.OpenConnection())
            {
                MessageBox.Show("Database connection failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MySqlTransaction transaction = null;
            try
            {

                transaction = dbConnection.GetConnection().BeginTransaction();


                string userCheckQuery = "SELECT COUNT(*) FROM Users WHERE UserID = @UserID";
                MySqlCommand userCheckCmd = new MySqlCommand(userCheckQuery, dbConnection.GetConnection(), transaction);
                userCheckCmd.Parameters.AddWithValue("@UserID", userId);
                if (Convert.ToInt32(userCheckCmd.ExecuteScalar()) == 0)
                {
                    MessageBox.Show($"User with ID {userId} does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    transaction.Rollback();
                    return;
                }


                string bookCheckQuery = "SELECT Availability FROM Books WHERE BookID = @BookID";
                MySqlCommand bookCheckCmd = new MySqlCommand(bookCheckQuery, dbConnection.GetConnection(), transaction);
                bookCheckCmd.Parameters.AddWithValue("@BookID", bookId);
                object availabilityResult = bookCheckCmd.ExecuteScalar();

                if (availabilityResult == null)
                {
                    MessageBox.Show($"Book with ID {bookId} does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    transaction.Rollback();
                    return;
                }
                if (availabilityResult.ToString() != "Available")
                {
                     MessageBox.Show($"Book with ID {bookId} is currently not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    transaction.Rollback();
                    return;
                }


                string insertBorrowQuery = "INSERT INTO BorrowedBooks (UserID, BookID, Status) VALUES (@UserID, @BookID, 'Active')";
                MySqlCommand insertCmd = new MySqlCommand(insertBorrowQuery, dbConnection.GetConnection(), transaction);
                insertCmd.Parameters.AddWithValue("@UserID", userId);
                insertCmd.Parameters.AddWithValue("@BookID", bookId);
                insertCmd.ExecuteNonQuery();


                string updateBookQuery = "UPDATE Books SET Availability = 'Borrowed' WHERE BookID = @BookID";
                MySqlCommand updateCmd = new MySqlCommand(updateBookQuery, dbConnection.GetConnection(), transaction);
                updateCmd.Parameters.AddWithValue("@BookID", bookId);
                updateCmd.ExecuteNonQuery();


                transaction.Commit();
                MessageBox.Show("Book borrowed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                txtBorrowUserID.Clear();
                txtBorrowBookID.Clear();


                LoadBooks();
                LoadBorrowedBooks();
            }
            catch (Exception ex)
            {

                try { transaction?.Rollback(); } catch { /* Ignore rollback errors */ }
                MessageBox.Show("Error borrowing book: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            if (dgvBorrowedBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a borrowed book record from the grid to return.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            int borrowId = Convert.ToInt32(dgvBorrowedBooks.SelectedRows[0].Cells["BorrowID"].Value);
            int bookId = Convert.ToInt32(dgvBorrowedBooks.SelectedRows[0].Cells["BookID"].Value); 

            if (!dbConnection.OpenConnection())
            {
                MessageBox.Show("Database connection failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MySqlTransaction transaction = null;
            try
            {
                transaction = dbConnection.GetConnection().BeginTransaction();


                string updateBorrowQuery = "UPDATE BorrowedBooks SET Status = 'Returned', ReturnDate = NOW() WHERE BorrowID = @BorrowID";
                MySqlCommand updateBorrowCmd = new MySqlCommand(updateBorrowQuery, dbConnection.GetConnection(), transaction);
                updateBorrowCmd.Parameters.AddWithValue("@BorrowID", borrowId);
                updateBorrowCmd.ExecuteNonQuery();


                string updateBookQuery = "UPDATE Books SET Availability = 'Available' WHERE BookID = @BookID";
                MySqlCommand updateBookCmd = new MySqlCommand(updateBookQuery, dbConnection.GetConnection(), transaction);
                updateBookCmd.Parameters.AddWithValue("@BookID", bookId);
                 updateBookCmd.ExecuteNonQuery();


                transaction.Commit();
                MessageBox.Show("Book returned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                LoadBooks();
                LoadBorrowedBooks();

            }
            catch (Exception ex)
            {
                try { transaction?.Rollback(); } catch { /* Ignore rollback errors */ }
                MessageBox.Show("Error returning book: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        // --- Logout & Form Close --- 
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginFormInstance.Show();
            this.Close();
        }

        private void AdminDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (loginFormInstance != null && !loginFormInstance.Visible)
            {
                loginFormInstance.Show();
            }


        }
    }
} 