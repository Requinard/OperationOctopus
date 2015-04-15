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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InitializeApplication();
            Application.Run(new LoginForm());
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
            EquipmentManager.Initialize();
            Logger.Info("Starting Application");
        }
    }
}