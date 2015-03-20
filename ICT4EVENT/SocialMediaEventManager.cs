using System.Collections.Generic;

namespace ICT4EVENT
{
    internal class SocialMediaEventManager
    {
        private DBManager dbManager;
        private List<EventModel> events;
        private List<UserModel> users;

        public SocialMediaEventManager()
        {
            dbManager = new DBManager();
            events = new List<EventModel>();
            users = new List<UserModel>();
        }

        ~SocialMediaEventManager()
        {
            dbManager = null;
        }
    }
}