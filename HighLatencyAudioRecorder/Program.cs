namespace stereoptic
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
            Application.Run(new Form());

            AudioProcessor ap = new AudioProcessor();

            System.Diagnostics.Debug.WriteLine("Starting...");
            ap.Start();
            Thread.Sleep(5000);
            ap.Stop();

            Thread.Sleep(10000);
        }
    }
}