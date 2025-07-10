using OrderSharedContent;
using OrderSharedContent.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopAPICaller.AuthForms
{
    public partial class RegisterForm : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void registerLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private async void registerButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(usernameTextBox.Text) || string.IsNullOrEmpty(passwordTextBox.Text) || string.IsNullOrEmpty(emailTextBox.Text))
                throw new Exception("Please fill up all fields!");

            string username = usernameTextBox.Text.Trim();
            string email = emailTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();
            string confirmPassword = confirmPasswordTextBox.Text.Trim();

            if (password != confirmPassword)
            {
                MessageBox.Show("Password and confirm password don't match!");
                return;
            }

            RegisterRequest rr = new RegisterRequest { Username = username, Email = email, Password = password, ConfirmPassword = confirmPassword };

            var json = JsonSerializer.Serialize(rr);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7089/Auth/register", content);

            if (response.IsSuccessStatusCode)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                MessageBox.Show(errorMessage);
            }
        }
    }
}
