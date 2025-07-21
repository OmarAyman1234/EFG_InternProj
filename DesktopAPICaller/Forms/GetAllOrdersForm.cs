using System.Text.Json;
using OrderSharedContent;
using OrderSharedContent.Context;
using Microsoft.AspNetCore.SignalR.Client;
using System.ComponentModel;

namespace DesktopAPICaller.Forms
{
    public partial class GetAllOrdersForm : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HubConnection _hubConnection;
        private BindingList<OrderDto> _orders = new BindingList<OrderDto>();

        public GetAllOrdersForm()
        {
            InitializeComponent();
        }

        private async void GetAllOrdersForm_Load(object sender, EventArgs e)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Add("X-Username", Session.Username);
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Session.Token);

                var response = await _httpClient.GetAsync("https://localhost:7089/api/Orders");

                if (!response.IsSuccessStatusCode)
                {
                    // unauthorized:

                    //try refresh
                    var refreshResponse = await _httpClient.PostAsync("http://localhost:7087/Auth/refresh", null);
                    string newAccessToken = await refreshResponse.Content.ReadAsStringAsync();

                    // add the access token after refresh
                    _httpClient.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", newAccessToken);

                    Session.Token = newAccessToken;

                    // retry fetching after refresh
                    response = await _httpClient.GetAsync("https://localhost:7089/api/Orders");

                    if (!response.IsSuccessStatusCode)
                        throw new Exception("You need to login!");
                }

                var json = await response.Content.ReadAsStringAsync();
                var orders = JsonSerializer.Deserialize<List<OrderDto>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                _orders = new BindingList<OrderDto>(orders);
                ordersDataGridView.DataSource = _orders;

                _hubConnection = new HubConnectionBuilder()
                    .WithUrl("https://localhost:7248/hubs/orderstream")
                    .WithAutomaticReconnect()
                    .Build();

                _hubConnection.On<OrderDto>("ReceiveOrderUpdate", (order) =>
                {
                    Invoke(() => Invoke(() => _orders.Add(order)));
                });

                await _hubConnection.StartAsync();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        protected override async void OnFormClosed(FormClosedEventArgs e)
        {
            if (_hubConnection != null)
            {
                await _hubConnection.StopAsync();
                await _hubConnection.DisposeAsync();
            }

            base.OnFormClosed(e);
        }

        private void ordersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}