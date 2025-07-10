namespace DesktopAPICaller.AuthForms
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            registerButton = new Button();
            label2 = new Label();
            usernameTextBox = new TextBox();
            usernameLabel = new Label();
            emailTextBox = new TextBox();
            emailLabel = new Label();
            passwordTextBox = new TextBox();
            passwordLabel = new Label();
            confirmPasswordTextBox = new TextBox();
            confirmPasswordLabel = new Label();
            label1 = new Label();
            loginLinkLabel = new LinkLabel();
            SuspendLayout();
            // 
            // registerButton
            // 
            registerButton.Location = new Point(354, 281);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(112, 34);
            registerButton.TabIndex = 5;
            registerButton.Text = "Register";
            registerButton.UseVisualStyleBackColor = true;
            registerButton.Click += registerButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(354, 38);
            label2.Name = "label2";
            label2.Size = new Size(149, 48);
            label2.TabIndex = 8;
            label2.Text = "Register";
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(369, 118);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(204, 31);
            usernameTextBox.TabIndex = 1;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(268, 121);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(95, 25);
            usernameLabel.TabIndex = 6;
            usernameLabel.Text = "Username:";
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(369, 155);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(204, 31);
            emailTextBox.TabIndex = 2;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(305, 158);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(58, 25);
            emailLabel.TabIndex = 12;
            emailLabel.Text = "Email:";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(369, 192);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(204, 31);
            passwordTextBox.TabIndex = 3;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(272, 192);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(91, 25);
            passwordLabel.TabIndex = 14;
            passwordLabel.Text = "Password:";
            // 
            // confirmPasswordTextBox
            // 
            confirmPasswordTextBox.Location = new Point(369, 229);
            confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            confirmPasswordTextBox.PasswordChar = '*';
            confirmPasswordTextBox.Size = new Size(204, 31);
            confirmPasswordTextBox.TabIndex = 4;
            // 
            // confirmPasswordLabel
            // 
            confirmPasswordLabel.AutoSize = true;
            confirmPasswordLabel.Location = new Point(203, 229);
            confirmPasswordLabel.Name = "confirmPasswordLabel";
            confirmPasswordLabel.Size = new Size(160, 25);
            confirmPasswordLabel.TabIndex = 16;
            confirmPasswordLabel.Text = "Confirm Password:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(252, 336);
            label1.Name = "label1";
            label1.Size = new Size(213, 25);
            label1.TabIndex = 19;
            label1.Text = "Already have an account?";
            // 
            // loginLinkLabel
            // 
            loginLinkLabel.AutoSize = true;
            loginLinkLabel.Location = new Point(471, 336);
            loginLinkLabel.Name = "loginLinkLabel";
            loginLinkLabel.Size = new Size(56, 25);
            loginLinkLabel.TabIndex = 6;
            loginLinkLabel.TabStop = true;
            loginLinkLabel.Text = "Login";
            loginLinkLabel.LinkClicked += registerLinkLabel_LinkClicked;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(loginLinkLabel);
            Controls.Add(confirmPasswordTextBox);
            Controls.Add(confirmPasswordLabel);
            Controls.Add(passwordTextBox);
            Controls.Add(passwordLabel);
            Controls.Add(emailTextBox);
            Controls.Add(emailLabel);
            Controls.Add(registerButton);
            Controls.Add(label2);
            Controls.Add(usernameTextBox);
            Controls.Add(usernameLabel);
            Name = "RegisterForm";
            Text = "RegisterForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button registerButton;
        private Label label2;
        private TextBox usernameTextBox;
        private Label usernameLabel;
        private TextBox emailTextBox;
        private Label emailLabel;
        private TextBox passwordTextBox;
        private Label passwordLabel;
        private TextBox confirmPasswordTextBox;
        private Label confirmPasswordLabel;
        private Label label1;
        private LinkLabel loginLinkLabel;
    }
}