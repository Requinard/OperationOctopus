using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;

namespace ICT4EVENT
{
    public static class UserManager
    {
        private static RNGCryptoServiceProvider crypto;

        public static UserModel CreateUser(string username, string password)
        {
            UserModel user = new UserModel(null);

            user.Username = username;
            user.Password = password;

            user.Create();

            return user;
        }
    }
}