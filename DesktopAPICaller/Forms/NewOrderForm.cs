using OrderAPI.Domain;
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

                if (string.IsNullOrWhiteSpace(productsComboBox.Text) ||
                    string.IsNullOrWhiteSpace(priceLabelValue.Text) ||
                    string.IsNullOrWhiteSpace(quantityTextBox.Text) ||
                    string.IsNullOrWhiteSpace(directionComboBox.Text))
                {
                    throw new ArgumentNullException("Please fill in all fields.");
                }

                string product = productsComboBox.Text.Trim();
                decimal price = decimal.Parse(priceLabelValue.Text.Trim());
                int quantity = int.Parse(quantityTextBox.Text.Trim());
                string direction = directionComboBox.Text.Trim();

                CreateOrderRequest newOrder = new CreateOrderRequest(product, price, quantity, direction);

                var json = JsonSerializer.Serialize(newOrder);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                _httpClient.DefaultRequestHeaders.Add("X-Username", Session.Username);

                var response = await _httpClient.PostAsync("https://localhost:7089/api/Orders", content);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var createdOrder = JsonSerializer.Deserialize<OrderDto>(responseBody);
                MessageBox.Show($"Order Created!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in creating an order: {ex.Message}");
            }
        }

        private async void NewOrderForm_Load(object sender, EventArgs e)
        {
            productsComboBox.Text = "Loading Products...";

            var response = await _httpClient.GetAsync("https://localhost:7089/api/Products");

            if (!response.IsSuccessStatusCode)
            {
                string error = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Error in fetching products: {response.StatusCode}\nDetails: {error}");
                return;
            }

            var json = await response.Content.ReadAsStringAsync();
            var products = JsonSerializer.Deserialize<IEnumerable<Product>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            productsComboBox.DataSource = products;
            productsComboBox.DisplayMember = "Name";
            productsComboBox.ValueMember = "Id";

            productsComboBox.SelectedIndex = 0;

            if (productsComboBox.SelectedItem is Product selectedItem)
            {
                int id = selectedItem.Id;
                decimal price = selectedItem.Price;

                priceLabelValue.Text = price.ToString("0.00");
            }
        }

        private void productsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(productsComboBox.SelectedItem is Product selectedItem)
            {
                int id = selectedItem.Id;
                decimal price = selectedItem.Price;

                priceLabelValue.Text = price.ToString("0.00");
            }
        }
    }
}
