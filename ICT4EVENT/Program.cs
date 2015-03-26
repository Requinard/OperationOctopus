using System;
using System.Windows.Forms;

namespace ICT4EVENT
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Logger.Initialize();
            Logger.Success("Initialized Logger");
            Logger.Info("Starting Application");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            Logger.Info("Exiting Application");
            Logger.Destruct();
        }
    }
}