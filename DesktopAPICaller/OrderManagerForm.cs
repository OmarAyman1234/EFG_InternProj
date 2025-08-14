using DesktopAPICaller.Forms;
using OrderSharedContent.Context;
namespace DesktopAPICaller
{
    public partial class orderManager : Form
    {
        public orderManager()
        {

            InitializeComponent();
            greetLabel.Text = $"Hello, {Session.Username}";
        }

        private void getAllOrdersButton_Click(object sender, EventArgs e)
        {
            var form = new GetAllOrdersForm();
            form.Show();
        }

        private void getSpecificOrderButton_Click(object sender, EventArgs e)
        {
            var form = new GetSpecificOrderForm();
            form.Show();
        }

        private void newOrderButton_Click(object sender, EventArgs e)
        {
            var form = new NewOrderForm();
            form.Show();
        }
    }
}
