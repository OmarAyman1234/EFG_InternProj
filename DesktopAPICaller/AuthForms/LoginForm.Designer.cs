namespace DesktopAPICaller.AuthForms
{
    partial class LoginForm
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
            usernameLabel = new Label();
            usernameTextBox = new TextBox();
            label2 = new Label();
            passwordTextBox = new TextBox();
            passwordLabel = new Label();
            loginButton = new Button();
            registerLinkLabel = new LinkLabel();
            label1 = new Label();
            SuspendLayout();
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(261, 114);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(95, 25);
            usernameLabel.TabIndex = 0;
            usernameLabel.Text = "Username:";
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(362, 111);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(164, 31);
            usernameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(347, 31);
            label2.Name = "label2";
            label2.Size = new Size(108, 48);
            label2.TabIndex = 2;
            label2.Text = "Login";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(362, 148);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(164, 31);
            passwordTextBox.TabIndex = 4;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.ForeColor = Color.Black;
            passwordLabel.Location = new Point(261, 151);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(91, 25);
            passwordLabel.TabIndex = 3;
            passwordLabel.Text = "Password:";
            // 
            // loginButton
            // 
            loginButton.Location = new Point(347, 225);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(112, 34);
            loginButton.TabIndex = 5;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // registerLinkLabel
            // 
            registerLinkLabel.AutoSize = true;
            registerLinkLabel.Location = new Point(436, 285);
            registerLinkLabel.Name = "registerLinkLabel";
            registerLinkLabel.Size = new Size(75, 25);
            registerLinkLabel.TabIndex = 6;
            registerLinkLabel.TabStop = true;
            registerLinkLabel.Text = "Register";
            registerLinkLabel.LinkClicked += registerLinkLabel_LinkClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(233, 285);
            label1.Name = "label1";
            label1.Size = new Size(197, 25);
            label1.TabIndex = 7;
            label1.Text = "Don't have an account?";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(registerLinkLabel);
            Controls.Add(loginButton);
            Controls.Add(passwordTextBox);
            Controls.Add(passwordLabel);
            Controls.Add(label2);
            Controls.Add(usernameTextBox);
            Controls.Add(usernameLabel);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label usernameLabel;
        private TextBox usernameTextBox;
        private Label label2;
        private TextBox passwordTextBox;
        private Label passwordLabel;
        private Button loginButton;
        private LinkLabel registerLinkLabel;
        private Label label1;
    }
}