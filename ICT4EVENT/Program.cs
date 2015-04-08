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
            InitializeApplication();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            Logger.Info("Exiting Application");
            Logger.Destruct(Settings.LOGFILENAME);
        }

        private static void InitializeApplication()
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
            DBManager.Initalize();
            EventManager.Initialize();
            UserManager.Initialize();
            Logger.Info("Starting Application");
        }
    }
}