namespace OrganizePro
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LoginUsernameInput = new TextBox();
            LoginPasswordInput = new TextBox();
            UsernameLabel = new Label();
            PasswordLabel = new Label();
            LoginBtn = new Button();
            tabControl1 = new TabControl();
            LoginTabPage = new TabPage();
            CreateUserTabPage = new TabPage();
            CreateUsernameLabel = new Label();
            CreateUsernameInput = new TextBox();
            CreateUserBtn = new Button();
            CreatePasswordInput = new TextBox();
            CreatePasswordLabel = new Label();
            tabControl1.SuspendLayout();
            LoginTabPage.SuspendLayout();
            CreateUserTabPage.SuspendLayout();
            SuspendLayout();
            // 
            // LoginUsernameInput
            // 
            LoginUsernameInput.Location = new Point(34, 111);
            LoginUsernameInput.Margin = new Padding(4, 5, 4, 5);
            LoginUsernameInput.Name = "LoginUsernameInput";
            LoginUsernameInput.Size = new Size(218, 31);
            LoginUsernameInput.TabIndex = 0;
            // 
            // LoginPasswordInput
            // 
            LoginPasswordInput.Location = new Point(34, 225);
            LoginPasswordInput.Margin = new Padding(4, 5, 4, 5);
            LoginPasswordInput.Name = "LoginPasswordInput";
            LoginPasswordInput.Size = new Size(218, 31);
            LoginPasswordInput.TabIndex = 1;
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Location = new Point(103, 61);
            UsernameLabel.Margin = new Padding(4, 0, 4, 0);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(91, 25);
            UsernameLabel.TabIndex = 2;
            UsernameLabel.Text = "Username";
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Location = new Point(103, 178);
            PasswordLabel.Margin = new Padding(4, 0, 4, 0);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(87, 25);
            PasswordLabel.TabIndex = 3;
            PasswordLabel.Text = "Password";
            // 
            // LoginBtn
            // 
            LoginBtn.Location = new Point(147, 336);
            LoginBtn.Margin = new Padding(4, 5, 4, 5);
            LoginBtn.Name = "LoginBtn";
            LoginBtn.Size = new Size(107, 38);
            LoginBtn.TabIndex = 4;
            LoginBtn.Text = "Login";
            LoginBtn.UseVisualStyleBackColor = true;
            LoginBtn.Click += Login;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(LoginTabPage);
            tabControl1.Controls.Add(CreateUserTabPage);
            tabControl1.Location = new Point(388, 119);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(300, 439);
            tabControl1.TabIndex = 5;
            // 
            // LoginTabPage
            // 
            LoginTabPage.Controls.Add(UsernameLabel);
            LoginTabPage.Controls.Add(LoginBtn);
            LoginTabPage.Controls.Add(LoginUsernameInput);
            LoginTabPage.Controls.Add(PasswordLabel);
            LoginTabPage.Controls.Add(LoginPasswordInput);
            LoginTabPage.Location = new Point(4, 34);
            LoginTabPage.Name = "LoginTabPage";
            LoginTabPage.Padding = new Padding(3);
            LoginTabPage.Size = new Size(292, 401);
            LoginTabPage.TabIndex = 0;
            LoginTabPage.Text = "Login";
            LoginTabPage.UseVisualStyleBackColor = true;
            // 
            // CreateUserTabPage
            // 
            CreateUserTabPage.Controls.Add(CreateUsernameLabel);
            CreateUserTabPage.Controls.Add(CreateUsernameInput);
            CreateUserTabPage.Controls.Add(CreateUserBtn);
            CreateUserTabPage.Controls.Add(CreatePasswordInput);
            CreateUserTabPage.Controls.Add(CreatePasswordLabel);
            CreateUserTabPage.Location = new Point(4, 34);
            CreateUserTabPage.Name = "CreateUserTabPage";
            CreateUserTabPage.Padding = new Padding(3);
            CreateUserTabPage.Size = new Size(292, 401);
            CreateUserTabPage.TabIndex = 1;
            CreateUserTabPage.Text = "Create New User";
            CreateUserTabPage.UseVisualStyleBackColor = true;
            // 
            // CreateUsernameLabel
            // 
            CreateUsernameLabel.AutoSize = true;
            CreateUsernameLabel.Location = new Point(104, 59);
            CreateUsernameLabel.Margin = new Padding(4, 0, 4, 0);
            CreateUsernameLabel.Name = "CreateUsernameLabel";
            CreateUsernameLabel.Size = new Size(91, 25);
            CreateUsernameLabel.TabIndex = 8;
            CreateUsernameLabel.Text = "Username";
            // 
            // CreateUsernameInput
            // 
            CreateUsernameInput.Location = new Point(35, 109);
            CreateUsernameInput.Margin = new Padding(4, 5, 4, 5);
            CreateUsernameInput.Name = "CreateUsernameInput";
            CreateUsernameInput.Size = new Size(218, 31);
            CreateUsernameInput.TabIndex = 6;
            // 
            // CreateUserBtn
            // 
            CreateUserBtn.Location = new Point(148, 334);
            CreateUserBtn.Margin = new Padding(4, 5, 4, 5);
            CreateUserBtn.Name = "CreateUserBtn";
            CreateUserBtn.Size = new Size(107, 38);
            CreateUserBtn.TabIndex = 10;
            CreateUserBtn.Text = "Create";
            CreateUserBtn.UseVisualStyleBackColor = true;
            CreateUserBtn.Click += CreateUser;
            // 
            // CreatePasswordInput
            // 
            CreatePasswordInput.Location = new Point(35, 223);
            CreatePasswordInput.Margin = new Padding(4, 5, 4, 5);
            CreatePasswordInput.Name = "CreatePasswordInput";
            CreatePasswordInput.Size = new Size(218, 31);
            CreatePasswordInput.TabIndex = 7;
            // 
            // CreatePasswordLabel
            // 
            CreatePasswordLabel.AutoSize = true;
            CreatePasswordLabel.Location = new Point(104, 176);
            CreatePasswordLabel.Margin = new Padding(4, 0, 4, 0);
            CreatePasswordLabel.Name = "CreatePasswordLabel";
            CreatePasswordLabel.Size = new Size(87, 25);
            CreatePasswordLabel.TabIndex = 9;
            CreatePasswordLabel.Text = "Password";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(tabControl1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "LoginForm";
            Text = "Form1";
            Load += LoginForm_Load;
            tabControl1.ResumeLayout(false);
            LoginTabPage.ResumeLayout(false);
            LoginTabPage.PerformLayout();
            CreateUserTabPage.ResumeLayout(false);
            CreateUserTabPage.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox LoginUsernameInput;
        private TextBox LoginPasswordInput;
        private Label UsernameLabel;
        private Label PasswordLabel;
        private Button LoginBtn;
        private TabControl tabControl1;
        private TabPage LoginTabPage;
        private TabPage CreateUserTabPage;
        private Label CreateUsernameLabel;
        private TextBox CreateUsernameInput;
        private Button CreateUserBtn;
        private TextBox CreatePasswordInput;
        private Label CreatePasswordLabel;
    }
}
