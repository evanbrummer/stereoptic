namespace Montana
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
            
            // my delusions of pseudocode: 
            /*
            * Well we're in main so I'm not sure what I should aim for
            * in terms of cohesion. On startup, stereoptic needs to: 
            * Open the configuration window, there are config options
            * to automatically start the visualizer, but it's not on 
            * always by default. All main needs to do is start the 
            * form, but maybe we have a StartupHandler class that 
            * checks our configs and everything. Could check some 
            * common repos to see if anybody else does something like 
            * that. 
            */

            StartupHandler sh = new StartupHandler() {
                public StartupHandler() {
                    getConfiguration();
                }

                public void startApp() {
                    Application.Run(new ConfigForm());
                    SystrayHandler.start();
                    // configform will be where we set stuff up
                }
            }; 
            // probably don't need to pass anything to it yet
            sh.start();

        }
    }
}