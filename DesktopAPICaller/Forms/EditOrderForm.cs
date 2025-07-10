using OrderSharedContent;
using OrderSharedContent.Context;
using System.Text.Json;

namespace DesktopAPICaller.Forms
{
    public partial class EditOrderForm : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public EditOrderForm(OrderDto o)
        {
            InitializeComponent();

            idTextBox.Text = o.Id.ToString();
            clientIdTextBox.Text = o.ClientId.ToString();
            productTextBox.Text = o.Product;
            priceTextBox.Text = o.Price.ToString();
            quantityTextBox.Text = o.Quantity.ToString();
            directionComboBox.SelectedItem = o.Direction;
        }

        private async void saveButton_Click(object sender, EventArgs e)
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

                EditOrderRequest editedOrder = new EditOrderRequest(product, price, quantity, direction);

                var json = JsonSerializer.Serialize(editedOrder);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                _httpClient.DefaultRequestHeaders.Remove("X-Username");
                _httpClient.DefaultRequestHeaders.Add("X-Username", Session.Username);

                var response = await _httpClient.PutAsync($"https://localhost:7089/api/Orders/{idTextBox.Text}", content);
                response.EnsureSuccessStatusCode();

                MessageBox.Show("Order edited!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in editing an order: {ex.Message}");
            }
        }
    }
}
