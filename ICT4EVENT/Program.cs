using System;
using System.Windows.Forms;
using ApplicationLogger;

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
            try
            {
                Logger.Initialize(Settings.LOGFILENAME);
            }
            catch (Exception)
            {
                Logger.Initialize();
            }
            Logger.Success("Initialized Logger");
            Logger.Info("Starting Application");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            Logger.Info("Exiting Application");
            Logger.Destruct(Settings.LOGFILENAME);
        }
    }
}