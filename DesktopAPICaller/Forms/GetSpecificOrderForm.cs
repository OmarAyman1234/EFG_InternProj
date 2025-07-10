using Microsoft.IdentityModel.Tokens;
using OrderSharedContent;
using OrderSharedContent.Context;
using System.Text.Json;

namespace DesktopAPICaller.Forms
{
    public partial class GetSpecificOrderForm : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private OrderDto _currentOrder;
        public GetSpecificOrderForm()
        {
            InitializeComponent();

            editOrderButton.Hide();
            deleteOrderButton.Hide();
        }

        private async void getOrderButton_Click(object sender, EventArgs e)
        {
            string enteredId = enterIdTextBox.Text;
            try
            {
                if (enteredId.Trim().IsNullOrEmpty())
                    throw new ArgumentNullException("ID cannot be empty!");

                _httpClient.DefaultRequestHeaders.Remove("X-Username");
                _httpClient.DefaultRequestHeaders.Add("X-Username", Session.Username);

                var response = await _httpClient.GetAsync($"https://localhost:7089/api/Orders/{enteredId}");

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var order = JsonSerializer.Deserialize<OrderDto>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                orderDataGridView.DataSource = new List<OrderDto> { order };
                _currentOrder = order;
                editOrderButton.Show();
                deleteOrderButton.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in fetching a order #{enteredId}: {ex.Message}");
            }
        }

        private void editOrderButton_Click(object sender, EventArgs e)
        {
            var editOrderForm = new EditOrderForm(_currentOrder);
            editOrderForm.Show();
        }

        private async void deleteOrderButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentOrder == null)
                {
                    MessageBox.Show("No order loaded to delete.");
                    return;
                }

                int orderToDeleteId = _currentOrder.Id;
                _httpClient.DefaultRequestHeaders.Remove("X-Username");
                _httpClient.DefaultRequestHeaders.Add("X-Username", Session.Username);

                var response = await _httpClient.DeleteAsync($"https://localhost:7089/api/Orders/{orderToDeleteId}");
                response.EnsureSuccessStatusCode();

                MessageBox.Show($"Order {_currentOrder.Id} deleted!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}");
            }
        }

    }
}
