using OrderSharedContent;
using OrderSharedContent.Context;
using System.Text.Json;
using System.Net.Http.Headers;
namespace DesktopAPICaller.AuthForms
{
    public partial class LoginForm : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public LoginForm()
        {
            InitializeComponent();
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(usernameTextBox.Text) || string.IsNullOrEmpty(passwordTextBox.Text))
            {
                MessageBox.Show("Please fill up all fields!");
                return;
            }

            string username = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();
            LoginRequest newLogin = new LoginRequest { Username = username, Password = password};

            var json = JsonSerializer.Serialize(newLogin);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("http://localhost:7087/Auth/login", content);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var jsonDoc = JsonDocument.Parse(responseBody);

                if (jsonDoc.RootElement.TryGetProperty("accessToken", out JsonElement tokenElement))
                {
                    string token = tokenElement.GetString();

                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    _httpClient.DefaultRequestHeaders.Remove("X-Username");
                    _httpClient.DefaultRequestHeaders.Add("X-Username", username);

                    this.DialogResult = DialogResult.OK;
                    Session.Username = usernameTextBox.Text;
                    Session.Token = token; 
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Login failed: token not found in response.");
                    return;
                }

            }
            else
            {
                string errorMsg = await response.Content.ReadAsStringAsync();
                MessageBox.Show(errorMsg);
            }
        }

        private void registerLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var registerForm = new RegisterForm();
            registerForm.Show();
            //this.Close();
        }
    }
}
