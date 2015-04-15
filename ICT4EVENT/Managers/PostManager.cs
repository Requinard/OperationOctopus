using System;
using System.IO;

namespace ICT4EVENT
{
    using System.Windows.Forms.VisualStyles;

    public static class PostManager
    {
        public static PostModel CreateNewPost(string body, string filepath = "")
        {
            PostModel post = new PostModel(Settings.ActiveUser, Settings.ActiveEvent);

            // Set up post details
            post.Content = body;
            DateTime datePosted = DateTime.Now;
            post.DatePosted = datePosted;

            //Upload file to FTP

            // First we copy it to a local directory
            //Extract filename
            if (filepath != "")
            {
                string fileName = Path.GetFileName(filepath);
                string localDirectory = string.Format(
                    "{0}/{1}/{2}/{3}/{4}/{5}/{6}/{7}",
                    "test",
                    datePosted.Year,
                    datePosted.Month,
                    datePosted.Day,
                    datePosted.Hour,
                    datePosted.Minute,
                    datePosted.Second,
                    fileName);

                Directory.CreateDirectory(localDirectory.Replace(fileName, ""));
                File.Copy(filepath, localDirectory);

                FTPManager.UploadFile(localDirectory);

                post.PathToFile = localDirectory;
            }
            else
            {
                post.PathToFile = "";
            }

            post.Create();

            post.Read();

            return post;
        }

        public static LikeModel CreateNewLike(PostModel post)
        {
            LikeModel like = new LikeModel();

            like.User = Settings.ActiveUser;
            like.Post = post;

            like.Create();

            return like;
        }

        public static PostReportModel ReportPost(PostModel post, string reason)
        {
            PostReportModel model = new PostReportModel(post, Settings.ActiveUser);

            model.Reason = reason;
            model.Date = DateTime.Now;
            model.Status = "Reported";

            model.Create();

            return model;
        }

        public static PostReportModel GetPostReports(PostModel post)
        {
            throw new NotImplementedException();
        }

        public static PostModel RetrievePostFile(PostModel post)
        {
            FTPManager.DownloadFile(post.PathToFile);

            return post;
        }
    }
}