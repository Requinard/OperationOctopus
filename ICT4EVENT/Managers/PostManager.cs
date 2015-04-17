using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

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

            return post;
        }

        public static List<PostModel> FindPost(string test)
        {
            List<PostModel> posts = new List<PostModel>();
            string query =
                String.Format(
                    "SELECT * FROM POST where eventid ='{0}' AND postcontent LIKE '%{1}%'",
                    Settings.ActiveEvent.Id,
                    test);

            OracleDataReader reader = DBManager.QueryDB(query);

            if (reader == null || !reader.HasRows) return null;

            while (reader.Read())
            {
                PostModel post = new PostModel();

                post.ReadFromReader(reader);

                posts.Add(post);
            }

            return posts;
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

        public static List<PostReportModel> GetPostReports(PostModel post)
        {
            string query = String.Format("SELECT * FROM Report WHERE postid = '{0}'", post.Id);
            List<PostReportModel> reports = new List<PostReportModel>();

            OracleDataReader reader = DBManager.QueryDB(query);

            if (reader == null || !reader.HasRows) return null;

            while (reader.Read())
            {
                PostReportModel report = new PostReportModel();

                report.ReadFromReader(reader);

                reports.Add(report);
            }

            return reports;
        }

        public static List<PostReportModel> GetAllReports()
        {
            string query = String.Format("SELECT * FROM Report");
            List<PostReportModel> reports = new List<PostReportModel>();

            OracleDataReader reader = DBManager.QueryDB(query);

            if(reader == null || !reader.HasRows)
            while (reader.Read())
            {
                PostReportModel report = new PostReportModel();

                report.ReadFromReader(reader);

                reports.Add(report);
            }

            return reports;
        }

        public static PostModel RetrievePostFile(PostModel post)
        {
            FTPManager.DownloadFile(post.PathToFile);

            return post;
        }

        public static List<PostModel> GetPostsByPage(PostModel startpost = null, int page = 0, int itemsPerPage = 10)
        {
            List<PostModel> posts = new List<PostModel>();
            OracleDataReader reader = null;

            //Get the data reader
            if (startpost == null)
            {
                string query = String.Format("SELECT * FROM post WHERE eventid = '{0}' ORDER BY ident desc", Settings.ActiveEvent.Id);

                reader = DBManager.QueryDB(query);
            }
            else
            {
                string query = String.Format("SELECT * FROM POST WHERE ident <= '{0}' AND WHERE eventid = '{0}' ORDER BY ident desc",
                    startpost.Id, Settings.ActiveEvent.Id);

                reader = DBManager.QueryDB(query);
            }

            if (reader == null || !reader.HasRows)
                return null;

            //Read the datareader x amount of rows, where x = page*itemsPerPage
            for (int i = 0; i < page*itemsPerPage; i++)
            {
                reader.Read();
            }

            // Now read itemsPerPage rows
            for (int i = 0; i < itemsPerPage; i++)
            {
                if (!reader.Read()) break;

                PostModel post = new PostModel();

                post.ReadFromReader(reader);

                posts.Add(post);
            }

            return posts;

        }
    }
}