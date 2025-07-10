using Microsoft.AspNetCore.SignalR.Client;
using OrderSharedContent;
using OrderSharedContent.Context;
using System.ComponentModel;
using System.Net.Http;
using System.Text.Json;

namespace DesktopAPICaller.Forms
{
    public partial class OrdersTrackerForm : Form
    {
        private BindingList<string> messages;
        private HubConnection hubConnection;
        private readonly HttpClient _httpClient = new HttpClient();

        public OrdersTrackerForm()
        {
            InitializeComponent();
            messages = new BindingList<string>();
            trackerDataGrid.DataSource = messages;
            trackerDataGrid.AutoGenerateColumns = true;
            hubConnection = new HubConnectionBuilder()
                 .WithUrl("https://localhost:7209/messagehub")
                 .WithAutomaticReconnect()
                 .Build();

        }
        private async void OrdersTrackerForm_Load(object sender, EventArgs e)
        {

            // CALL GET ALL


            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Session.Token);
            var response = await _httpClient.GetAsync("https://localhost:7089/api/Orders");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var orders = JsonSerializer.Deserialize<List<OrderDto>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            messages.Clear();
            foreach (var order in orders) {
                messages.Add(order.ToString());
            }

            trackerDataGrid.DataSource = messages;

            hubConnection.On<string>("ReceiveMessage", message =>
            {
                Console.WriteLine("Received: " + message);
                Invoke(() => messages.Add(message));
            });

            await hubConnection.StartAsync();
            await hubConnection.InvokeAsync("GetMessageAndSendToAll");

        }
    }

   /* public class MessageItem
    {
        public string Message { get; set; } = "teeeeeeeeeeeeeeeeeest";
    } */
}

