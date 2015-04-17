namespace ICT4EVENT
{
using System;
using System.Collections.Generic;
using System.IO;

using Oracle.DataAccess.Client;

namespace ICT4EVENT
{
    using System.Windows.Forms.VisualStyles;

    public static class PostManager
    {
        public static PostModel CreateNewPost(string body, string filepath = "")
        {
            var post = new PostModel(Settings.ActiveUser, Settings.ActiveEvent);

            // Set up post details
            post.Content = body;
            var datePosted = DateTime.Now;
            post.DatePosted = datePosted;

            //Upload file to FTP

            // First we copy it to a local directory
            //Extract filename
            if (filepath != "")
            {
                var fileName = Path.GetFileName(filepath);
                var localDirectory = string.Format(
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

             var reg = new Regex(@"/([#]\w+)/");

            foreach (Match match in reg.Matches(post.Content))
            {
                TagPost(post, match.ToString());
            }
            return post;
        }
        private static void TagPost(PostModel post, string tag)
        {
            TagModel tagModel = null;
            // We check if the tag already exists

            var select_tagname = string.Format("SELECT * FROM TAG WHERE name = '{0}'", tag);

            var reader = DBManager.QueryDB(select_tagname);

            if (reader == null)
            {
                tagModel = new TagModel();

                tagModel.Name = tag;

                if (tagModel.Create() == false)
                {
                    return;
                }

                //requery the db
                reader = DBManager.QueryDB(select_tagname);
            }

            tagModel = new TagModel();

            reader.Read();

            tagModel.ReadFromReader(reader);

            // We now have the tag. time to create an M2M query
            var insert_query = string.Format(
                "INSERT INTO TAGPOST (tagid, postid) VALUES ('{0}', '{1}')",
                tagModel.Id,
                post.Id);

            reader = DBManager.QueryDB(insert_query);
        }
        private static List<PostModel> GetPostByTags(string tag)
        {
            var posts = new List<PostModel>();

            var query = string.Format(
                "SELECT * FROM TagPost, Tag wHERE tag.name = '{0}' AND tag.ident = tagpost.tagid",
                tag);

            var reader = DBManager.QueryDB(query);

            if (reader == null)
            {
                return null;
            }

            while (reader.Read())
            {
                var post = new PostModel(Int32.Parse(reader["postid"].ToString()));

                posts.Add(post);
            }

            IEnumerable<PostModel> s = from post in posts where post.EventItem.Id == Settings.ActiveEvent.Id select post;

            return s.ToList();
        }

        public static List<LikeModel> GetPostLikes(PostModel post)
        {
            var likes = new List<LikeModel>();

            var query = string.Format("SELECT * FROM Like WHERE postid = '{0}'", post.Id);

            var reader = DBManager.QueryDB(query);

            if (reader == null)
            {
                return null;
            }

            while (reader.Read())
            {
                var like = new LikeModel();

                like.ReadFromReader(reader);

                likes.Add(like);
            }

            return likes;
        }
 
        public static List<PostModel> FindPost(string test)
        {
            var posts = new List<PostModel>();
            var query = string.Format(
                    "SELECT * FROM POST where eventid ='{0}' AND postcontent LIKE '%{1}%'",
                    Settings.ActiveEvent.Id,
                    test);

            var reader = DBManager.QueryDB(query);

            if (reader == null || !reader.HasRows)
            {
                return null;
            }

            while (reader.Read())
            {
                var post = new PostModel();

                post.ReadFromReader(reader);

                posts.Add(post);
            }

            return posts;
        }

        public static LikeModel CreateNewLike(PostModel post)
        {
            var like = new LikeModel();

            like.User = Settings.ActiveUser;
            like.Post = post;

            like.Create();

            return like;
        }

        public static PostReportModel ReportPost(PostModel post, string reason)
        {
            var model = new PostReportModel(post, Settings.ActiveUser);

            model.Reason = reason;
            model.Date = DateTime.Now;
            model.Status = "Reported";

            model.Create();

            return model;
        }

        public static List<PostReportModel> GetPostReports(PostModel post)
        {
            var query = string.Format("SELECT * FROM Report WHERE postid = '{0}'", post.Id);
            var reports = new List<PostReportModel>();

            var reader = DBManager.QueryDB(query);

            if (reader == null || !reader.HasRows)
            {
                return null;
            }

            while (reader.Read())
            {
                var report = new PostReportModel();

                report.ReadFromReader(reader);

                reports.Add(report);
            }

            return reports;
        }

                 public static List<TagModel> GetAllTags()
         {
             List<TagModel> tags = new List<TagModel>();
             string query = "SELECT * FROM TAG";
 
             OracleDataReader reader = DBManager.QueryDB(query);
 
             if (reader == null) return null;
 
             while (reader.Read())
             {
                 TagModel tag = new TagModel();
 
                 tag.ReadFromReader(reader);
 
                 tags.Add(tag);
             }
 
             return tags;
  }
        public static List<PostReportModel> GetAllReports()
        {
            var query = "SELECT * FROM Report";
            var reports = new List<PostReportModel>();

            var reader = DBManager.QueryDB(query);

            if (reader == null || !reader.HasRows)
            {
            while (reader.Read())
            {
                    var report = new PostReportModel();

                report.ReadFromReader(reader);

                reports.Add(report);
            }
            }

            return reports;
        }

        public static PostModel RetrievePostFile(PostModel post)
        {
            FTPManager.DownloadFile(post.PathToFile);

            return post;
        }

    <<<<<<<

        private HEAD 

    =======

        public static List<PostModel> RetrieveUserPosts(UserModel user)
        {
            var posts = new List<PostModel>();
            var query = string.Format(
                "SELECT * FROM POST WHERE userid = '{0}' AND eventid = '{1}'",
                user.Id,
                Settings.ActiveEvent.Id);

            var reader = DBManager.QueryDB(query);

            if (reader == null || !reader.HasRows)
            {
                return null;
            }

            while (reader.Read())
            {
                var post = new PostModel();

                post.ReadFromReader(reader);

                posts.Add(post);
            }

            return posts;
        }

        public static List<TagModel> GetAllTags()
        {
            List<TagModel> tags = new List<TagModel>();
            var query = "SELECT * FROM TAG";

            var reader = DBManager.QueryDB(query);

            if (reader == null)
            {
                return null;
            }

            while (reader.Read())
            {
                TagModel tag = new TagModel();

                tag.ReadFromReader(reader);

                tags.Add(tag);
            }

            return tags;
        }

    >>>>>>>

        private parent of 

    ..

        private Added function 

        private to retrieve 

        private all likes 

        private on a 

        private post 

        public static List<PostModel> GetPostsByPage(PostModel startpost = null, int page = 0, int itemsPerPage = 10)
        {
            var posts = new List<PostModel>();
            OracleDataReader reader = null;

            //Get the data reader
            if (startpost == null)
            {
                var query = string.Format(
                    "SELECT * FROM post WHERE eventid = '{0}' ORDER BY ident desc",
                    Settings.ActiveEvent.Id);

                reader = DBManager.QueryDB(query);
            }
            else
            {
                var query =
                    string.Format(
                        "SELECT * FROM POST WHERE ident <= '{0}' AND WHERE eventid = '{0}' ORDER BY ident desc",
                        startpost.Id,
                        Settings.ActiveEvent.Id);

                reader = DBManager.QueryDB(query);
            }

            if (reader == null || !reader.HasRows)
            {
                return null;
            }

            //Read the datareader x amount of rows, where x = page*itemsPerPage
            for (var i = 0; i < page * itemsPerPage; i++)
            {
                reader.Read();
            }

            // Now read itemsPerPage rows
            for (var i = 0; i < itemsPerPage; i++)
            {
                if (!reader.Read())
            {
                    break;
                }

                var post = new PostModel();

                post.ReadFromReader(reader);

                posts.Add(post);
            }

            return posts;
        }
    }
}