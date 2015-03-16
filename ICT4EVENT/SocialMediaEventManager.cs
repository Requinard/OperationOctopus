using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4EVENT
{
    class SocialMediaEventManager
    {
        private List<EventModel> events;
        private List<UserModel> users;
        private DBManager dbManager;

        public SocialMediaEventManager()
        {
            this.dbManager = new DBManager();
            this.events = new List<EventModel>();
            this.users = new List<UserModel>();
        }
    }
}
