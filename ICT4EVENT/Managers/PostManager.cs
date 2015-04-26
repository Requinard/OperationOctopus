using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

using ICT4EVENT.Models;

using Oracle.DataAccess.Client;

namespace ICT4EVENT
{
    public static class PostManager
    {
        /// <summary>
        /// Inserts a new post
        /// </summary>
        /// <param name="body">Test</param>
        /// <param name="filepath">File that is uploaded</param>
        /// <param name="parent">Parent comment</param>
        /// <returns></returns>
        public static PostModel CreateNewPost(string body, string filepath = "", PostModel parent = null)
        {
            var post = new PostModel(Settings.ActiveUser, Settings.ActiveEvent);

            if (parent != null)
            {
                post.Parent = parent;
            }
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
                File.Copy(filepath, localDirectory, true);
                FTPManager.UploadFile(localDirectory);

                post.PathToFile = localDirectory;
            }
            else
            {
                post.PathToFile = "";
            }

            post.Create();

            // Match the categories with regex
            var reg = new Regex(@"[#]\w+");

            foreach (Match match in reg.Matches(post.Content))
            {
                TagPost(post, match.ToString());
            }
            return post;
        }

        /// <summary>
        /// Tags a post with a specific tag
        /// </summary>
        /// <param name="post"></param>
        /// <param name="tag"></param>
        private static void TagPost(PostModel post, string tag)
        {
            TagModel tagModel = null;

            tag = tag.ToLower();

            // We check if the tag already exists

            var select_tagname = string.Format("SELECT * FROM TAG WHERE tagname = '{0}'", tag);

            var reader = DBManager.QueryDB(select_tagname);

            if (reader.HasRows == false)
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

        /// <summary>
        /// Gets posts that have a specific tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static List<PostModel> GetPostByTags(string tag)
        {
            var posts = new List<PostModel>();

            var query =
                string.Format("SELECT * FROM TagPost, Tag wHERE tag.tagname = '{0}' AND tag.ident = tagpost.tagid", tag);

            var reader = DBManager.QueryDB(query);

            if (reader == null)
            {
                return null;
            }

            while (reader.Read())
            {
                var post = new PostModel(int.Parse(reader["postid"].ToString()));

                posts.Add(post);
            }

            var s = from post in posts where post.EventItem.Id == Settings.ActiveEvent.Id select post;

            return s.ToList();
        }

        /// <summary>
        /// Gets the likes on a post
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public static List<LikeModel> GetPostLikes(PostModel post)
        {
            var likes = new List<LikeModel>();

            var query = string.Format("SELECT * FROM Likes WHERE postid = '{0}'", post.Id);

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

        /// <summary>
        /// Searches for a post with a text
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates a like on a post
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public static LikeModel CreateNewLike(PostModel post)
        {
            var like = new LikeModel();

            like.User = Settings.ActiveUser;
            like.Post = post;

            like.Create();

            return like;
        }

        /// <summary>
        /// Reports a post with a specific string
        /// </summary>
        /// <param name="post"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public static PostReportModel ReportPost(PostModel post, string reason)
        {
            var model = new PostReportModel(post, Settings.ActiveUser);

            model.Reason = reason;
            model.Date = DateTime.Now;
            model.Status = "Reported";

            model.Create();

            return model;
        }

        /// <summary>
        /// Gets all child comments on a post
        /// </summary>
        /// <param name="post">Post that has children</param>
        /// <returns></returns>
        public static List<PostModel> GetPostComments(PostModel post)
        {
            List<PostModel> posts = new List<PostModel>();
            string query = String.Format("SELECT * FROM POST WHERE REPLYID = '{0}'", post.Id);

            OracleDataReader reader = DBManager.QueryDB(query);

            if (reader == null || !reader.HasRows)
            {
                return null;
            }

            while (reader.Read())
            {
                PostModel ChildPost = new PostModel();

                ChildPost.ReadFromReader(reader);

                posts.Add(ChildPost);
            }
            return posts;
        }
        
        /// <summary>
        /// Gets all reports on a model
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets a list of all available tags
        /// </summary>
        /// <returns></returns>
        public static List<TagModel> GetAllTags()
        {
            var tags = new List<TagModel>();
            var query = String.Format("SELECT * FROM TAG WHERE Ident in (select tagId FROM tagpost where postid in(select ident from post where eventId = '{0}'))", Settings.ActiveEvent.Id);

            var reader = DBManager.QueryDB(query);

            if (reader == null)
            {
                return null;
            }

            while (reader.Read())
            {
                var tag = new TagModel();

                tag.ReadFromReader(reader);

                tags.Add(tag);
            }

            return tags;
        }

        /// <summary>
        /// Gets all reports in the database
        /// </summary>
        /// <returns></returns>
        public static List<PostReportModel> GetAllReports()
        {
            var query = "SELECT * FROM Report";
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

        /// <summary>
        /// Downloads a post's attached file
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public static PostModel RetrievePostFile(PostModel post)
        {
            FTPManager.DownloadFile(post.PathToFile);

            return post;
        }

        /// <summary>
        /// Gets all post by a user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="amountOfPosts"></param>
        /// <returns></returns>
        public static List<PostModel> GetUserPosts(UserModel user, int amountOfPosts = 10)
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
            int cnt = 0;
            while (reader.Read())
            {
                var post = new PostModel();

                post.ReadFromReader(reader);

                posts.Add(post);

                if (++cnt == 10)
                {
                    break;
                }
            }

            return posts;
        }

        /// <summary>
        /// Gets a page of posts
        /// </summary>
        /// <param name="startpost">First post that was retrieved</param>
        /// <param name="page">Page you're on. Starts at 0</param>
        /// <param name="itemsPerPage">How many items you want to see on a page</param>
        /// <returns></returns>
        public static List<PostModel> GetPostsByPage(PostModel startpost = null, int page = 0, int itemsPerPage = 10)
        {
            var posts = new List<PostModel>();
            OracleDataReader reader = null;

            //Get the data reader
            if (startpost == null)
            {
                var query = string.Format(
                    "SELECT * FROM post WHERE eventid = '{0}'  and replyid IS NULL ORDER BY ident desc",
                    Settings.ActiveEvent.Id);

                reader = DBManager.QueryDB(query);
            }
            else
            {
                var query =
                    string.Format(
                        "SELECT * FROM POST WHERE ident <= '{0}' AND WHERE eventid = '{0}'  and replyid IS NULL ORDER BY ident desc",
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