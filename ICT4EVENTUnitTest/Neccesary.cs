using ICT4EVENT;

namespace ICT4EVENTUnitTest
{
    public static class Init
    {
        public static void Initialize()
        {
            DBConfig config = new DBConfig();

            config.user = "PTS08";
            config.database = "xe";
            config.pw = "PTS08";
            config.host = "proftaak.me";
            config.port = "1521";

            Settings.DbConfig = config;

            DBManager.Initalize();
        }
    }
}