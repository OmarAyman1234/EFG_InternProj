using OrderSharedContent;
using OrderSharedContent.Context;
using System.Text.Json;

namespace DesktopAPICaller.Forms
{
    public partial class NewOrderForm : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public NewOrderForm()
        {
            InitializeComponent();
        }

        private async void addOrderButton_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(productTextBox.Text) ||
                    string.IsNullOrWhiteSpace(priceTextBox.Text) ||
                    string.IsNullOrWhiteSpace(quantityTextBox.Text) ||
                    string.IsNullOrWhiteSpace(directionComboBox.Text))
                {
                    throw new ArgumentNullException("Please fill in all fields.");
                }

                string product = productTextBox.Text.Trim();
                decimal price = decimal.Parse(priceTextBox.Text.Trim());
                int quantity = int.Parse(quantityTextBox.Text.Trim());
                string direction = directionComboBox.Text.Trim();

                CreateOrderRequest newOrder = new CreateOrderRequest(product, price, quantity, direction);

                var json = JsonSerializer.Serialize(newOrder);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                _httpClient.DefaultRequestHeaders.Remove("X-Username");
                _httpClient.DefaultRequestHeaders.Add("X-Username", Session.Username);

                var response = await _httpClient.PostAsync("https://localhost:7089/api/Orders", content);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var createdOrder = JsonSerializer.Deserialize<OrderDto>(responseBody);
                MessageBox.Show($"{createdOrder.Id}: {createdOrder.Product}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in creating an order: {ex.Message}");
            }
        }
    }
}
