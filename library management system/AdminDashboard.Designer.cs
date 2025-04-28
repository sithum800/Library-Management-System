namespace library_management_system
{
    partial class AdminDashboard
    {
        /// <summary>
        
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlAdmin = new System.Windows.Forms.TabControl();
            this.tabPageUserManagement = new System.Windows.Forms.TabPage();
            this.tabPageBookManagement = new System.Windows.Forms.TabPage();
            this.tabPageBorrowManagement = new System.Windows.Forms.TabPage();
            this.lblWelcomeAdmin = new System.Windows.Forms.Label();
            
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.btnCreateUser = new System.Windows.Forms.Button();
            
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.btnAddBook = new System.Windows.Forms.Button();
            
            this.btnBorrowBook = new System.Windows.Forms.Button();
            this.btnReturnBook = new System.Windows.Forms.Button();
            this.tabControlAdmin.SuspendLayout();
            this.tabPageUserManagement.SuspendLayout();
            this.tabPageBookManagement.SuspendLayout();
            this.tabPageBorrowManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.grpBorrow = new System.Windows.Forms.GroupBox();
            this.lblBorrowBookID = new System.Windows.Forms.Label();
            this.txtBorrowBookID = new System.Windows.Forms.TextBox();
            this.lblBorrowUserID = new System.Windows.Forms.Label();
            this.txtBorrowUserID = new System.Windows.Forms.TextBox();
            this.grpReturn = new System.Windows.Forms.GroupBox();
            this.dgvBorrowedBooks = new System.Windows.Forms.DataGridView();
            this.btnLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowedBooks)).BeginInit();
            this.grpBorrow.SuspendLayout();
            this.grpReturn.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcomeAdmin
            // 
            this.lblWelcomeAdmin.AutoSize = true;
            this.lblWelcomeAdmin.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblWelcomeAdmin.Location = new System.Drawing.Point(12, 9);
            this.lblWelcomeAdmin.Name = "lblWelcomeAdmin";
            this.lblWelcomeAdmin.Size = new System.Drawing.Size(190, 22);
            this.lblWelcomeAdmin.TabIndex = 0;
            this.lblWelcomeAdmin.Text = "Welcome, Admin!";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(697, 9);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // tabControlAdmin
            // 
            this.tabControlAdmin.Controls.Add(this.tabPageUserManagement);
            this.tabControlAdmin.Controls.Add(this.tabPageBookManagement);
            this.tabControlAdmin.Controls.Add(this.tabPageBorrowManagement);
            this.tabControlAdmin.Location = new System.Drawing.Point(12, 34);
            this.tabControlAdmin.Name = "tabControlAdmin";
            this.tabControlAdmin.SelectedIndex = 0;
            this.tabControlAdmin.Size = new System.Drawing.Size(760, 404);
            this.tabControlAdmin.TabIndex = 1;
            // 
            // tabPageUserManagement
            // 
            this.tabPageUserManagement.Controls.Add(this.btnCreateUser);
            this.tabPageUserManagement.Controls.Add(this.dgvUsers);
            this.tabPageUserManagement.Location = new System.Drawing.Point(4, 22);
            this.tabPageUserManagement.Name = "tabPageUserManagement";
            this.tabPageUserManagement.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUserManagement.Size = new System.Drawing.Size(752, 378);
            this.tabPageUserManagement.TabIndex = 0;
            this.tabPageUserManagement.Text = "User Management";
            this.tabPageUserManagement.UseVisualStyleBackColor = true;
            // 
            // btnCreateUser
            // 
            this.btnCreateUser.Location = new System.Drawing.Point(6, 6);
            this.btnCreateUser.Name = "btnCreateUser";
            this.btnCreateUser.Size = new System.Drawing.Size(150, 23);
            this.btnCreateUser.TabIndex = 1;
            this.btnCreateUser.Text = "Create New User";
            this.btnCreateUser.UseVisualStyleBackColor = true;
            this.btnCreateUser.Click += new System.EventHandler(this.btnCreateUser_Click);
            // 
            // dgvUsers
            // 
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(6, 35);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.Size = new System.Drawing.Size(740, 337);
            this.dgvUsers.TabIndex = 0;
            // 
            // tabPageBookManagement
            // 
            this.tabPageBookManagement.Controls.Add(this.btnAddBook);
            this.tabPageBookManagement.Controls.Add(this.dgvBooks);
            this.tabPageBookManagement.Location = new System.Drawing.Point(4, 22);
            this.tabPageBookManagement.Name = "tabPageBookManagement";
            this.tabPageBookManagement.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBookManagement.Size = new System.Drawing.Size(752, 378);
            this.tabPageBookManagement.TabIndex = 1;
            this.tabPageBookManagement.Text = "Book Management";
            this.tabPageBookManagement.UseVisualStyleBackColor = true;
            // 
            // btnAddBook
            // 
            this.btnAddBook.Location = new System.Drawing.Point(6, 6);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(150, 23);
            this.btnAddBook.TabIndex = 1;
            this.btnAddBook.Text = "Add New Book";
            this.btnAddBook.UseVisualStyleBackColor = true;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // dgvBooks
            // 
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooks.Location = new System.Drawing.Point(6, 35);
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.Size = new System.Drawing.Size(740, 337);
            this.dgvBooks.TabIndex = 0;
            // 
            // tabPageBorrowManagement
            // 
            this.tabPageBorrowManagement.Controls.Add(this.grpReturn);
            this.tabPageBorrowManagement.Controls.Add(this.grpBorrow);
            this.tabPageBorrowManagement.Location = new System.Drawing.Point(4, 22);
            this.tabPageBorrowManagement.Name = "tabPageBorrowManagement";
            this.tabPageBorrowManagement.Size = new System.Drawing.Size(752, 378);
            this.tabPageBorrowManagement.TabIndex = 2;
            this.tabPageBorrowManagement.Text = "Borrow Management";
            this.tabPageBorrowManagement.UseVisualStyleBackColor = true;
            // 
            // grpBorrow
            // 
            this.grpBorrow.Controls.Add(this.txtBorrowUserID);
            this.grpBorrow.Controls.Add(this.lblBorrowUserID);
            this.grpBorrow.Controls.Add(this.txtBorrowBookID);
            this.grpBorrow.Controls.Add(this.lblBorrowBookID);
            this.grpBorrow.Controls.Add(this.btnBorrowBook);
            this.grpBorrow.Location = new System.Drawing.Point(15, 15);
            this.grpBorrow.Name = "grpBorrow";
            this.grpBorrow.Size = new System.Drawing.Size(350, 120);
            this.grpBorrow.TabIndex = 2;
            this.grpBorrow.TabStop = false;
            this.grpBorrow.Text = "Borrow a Book";
            // 
            // lblBorrowUserID
            // 
            this.lblBorrowUserID.AutoSize = true;
            this.lblBorrowUserID.Location = new System.Drawing.Point(10, 25);
            this.lblBorrowUserID.Name = "lblBorrowUserID";
            this.lblBorrowUserID.Size = new System.Drawing.Size(46, 13);
            this.lblBorrowUserID.TabIndex = 1;
            this.lblBorrowUserID.Text = "User ID:";
            // 
            // txtBorrowUserID
            // 
            this.txtBorrowUserID.Location = new System.Drawing.Point(70, 22);
            this.txtBorrowUserID.Name = "txtBorrowUserID";
            this.txtBorrowUserID.Size = new System.Drawing.Size(100, 20);
            this.txtBorrowUserID.TabIndex = 2;
            // 
            // lblBorrowBookID
            // 
            this.lblBorrowBookID.AutoSize = true;
            this.lblBorrowBookID.Location = new System.Drawing.Point(10, 55);
            this.lblBorrowBookID.Name = "lblBorrowBookID";
            this.lblBorrowBookID.Size = new System.Drawing.Size(49, 13);
            this.lblBorrowBookID.TabIndex = 3;
            this.lblBorrowBookID.Text = "Book ID:";
            // 
            // txtBorrowBookID
            // 
            this.txtBorrowBookID.Location = new System.Drawing.Point(70, 52);
            this.txtBorrowBookID.Name = "txtBorrowBookID";
            this.txtBorrowBookID.Size = new System.Drawing.Size(100, 20);
            this.txtBorrowBookID.TabIndex = 4;
            // 
            // btnBorrowBook
            // 
            this.btnBorrowBook.Location = new System.Drawing.Point(70, 85);
            this.btnBorrowBook.Name = "btnBorrowBook";
            this.btnBorrowBook.Size = new System.Drawing.Size(100, 23);
            this.btnBorrowBook.TabIndex = 0;
            this.btnBorrowBook.Text = "Borrow Book";
            this.btnBorrowBook.UseVisualStyleBackColor = true;
            this.btnBorrowBook.Click += new System.EventHandler(this.btnBorrowBook_Click);
            // 
            // grpReturn
            // 
            this.grpReturn.Controls.Add(this.dgvBorrowedBooks);
            this.grpReturn.Controls.Add(this.btnReturnBook);
            this.grpReturn.Location = new System.Drawing.Point(15, 145);
            this.grpReturn.Name = "grpReturn";
            this.grpReturn.Size = new System.Drawing.Size(720, 220);
            this.grpReturn.TabIndex = 3;
            this.grpReturn.TabStop = false;
            this.grpReturn.Text = "Return a Book (Select from grid and click Return)";
            // 
            // dgvBorrowedBooks
            // 
            this.dgvBorrowedBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBorrowedBooks.Location = new System.Drawing.Point(10, 25);
            this.dgvBorrowedBooks.Name = "dgvBorrowedBooks";
            this.dgvBorrowedBooks.Size = new System.Drawing.Size(700, 150);
            this.dgvBorrowedBooks.TabIndex = 2;
            // 
            // btnReturnBook
            // 
            this.btnReturnBook.Location = new System.Drawing.Point(10, 185);
            this.btnReturnBook.Name = "btnReturnBook";
            this.btnReturnBook.Size = new System.Drawing.Size(150, 23);
            this.btnReturnBook.TabIndex = 1;
            this.btnReturnBook.Text = "Return Selected Book";
            this.btnReturnBook.UseVisualStyleBackColor = true;
            this.btnReturnBook.Click += new System.EventHandler(this.btnReturnBook_Click);
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 450);
            this.Controls.Add(this.tabControlAdmin);
            this.Controls.Add(this.lblWelcomeAdmin);
            this.Controls.Add(this.btnLogout);
            this.Name = "AdminDashboard";
            this.Text = "Admin Dashboard";
            this.tabControlAdmin.ResumeLayout(false);
            this.tabPageUserManagement.ResumeLayout(false);
            this.tabPageBookManagement.ResumeLayout(false);
            this.tabPageBorrowManagement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowedBooks)).EndInit();
            this.grpBorrow.ResumeLayout(false);
            this.grpBorrow.PerformLayout();
            this.grpReturn.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcomeAdmin;
        private System.Windows.Forms.TabControl tabControlAdmin;
        private System.Windows.Forms.TabPage tabPageUserManagement;
        private System.Windows.Forms.TabPage tabPageBookManagement;
        private System.Windows.Forms.TabPage tabPageBorrowManagement;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Button btnCreateUser;
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Button btnReturnBook;
        private System.Windows.Forms.Button btnBorrowBook;
        private System.Windows.Forms.GroupBox grpBorrow;
        private System.Windows.Forms.TextBox txtBorrowUserID;
        private System.Windows.Forms.Label lblBorrowUserID;
        private System.Windows.Forms.TextBox txtBorrowBookID;
        private System.Windows.Forms.Label lblBorrowBookID;
        private System.Windows.Forms.GroupBox grpReturn;
        private System.Windows.Forms.DataGridView dgvBorrowedBooks;
        private System.Windows.Forms.Button btnLogout;
    }
} 