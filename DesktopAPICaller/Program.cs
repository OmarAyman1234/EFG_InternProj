using Azure.Identity;
using DesktopAPICaller.AuthForms;

namespace DesktopAPICaller
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Auth warm up
            Task.Run(async () =>
            {
                using var client = new HttpClient();
                try
                {
                    await client.PostAsync("http://localhost:7087/Auth/refresh", null);
                }
                catch
                {
                    // Ignore warm-up errors
                }
            });

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            using (var loginForm = new LoginForm())
            {
                var result = loginForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // Authenticated successfully
                    Application.Run(new orderManager());
                }
                else
                {
                    // Login failed or cancelled
                    Application.Exit();
                }
            }
        }
    }
}