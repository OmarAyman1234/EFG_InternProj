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