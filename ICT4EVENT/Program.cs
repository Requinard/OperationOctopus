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
            RunTest();
            Application.Run(new LoginForm());
            Logger.Info("Exiting Application");
            Logger.Destruct(Settings.LOGFILENAME);
        }

        private static void RunTest()
        {
            //PostModel post = PostManager.CreateNewPost("test", "test2", @"C:\Users\Davi\Pictures\hallo.gif");
            //PostManager.RetrievePostFile(post);
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
            EquipmentManager.Initialize();
            Logger.Info("Starting Application");
        }
    }
}