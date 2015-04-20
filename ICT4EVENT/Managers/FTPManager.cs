using System;
using System.IO;
using System.Net;
using System.Text;
using ApplicationLogger;

namespace ICT4EVENT
{
    public static class FTPManager
    {
        private const string username = "PTS08";
        private const string pw = "PTS08";
        private const string FolderLocation = "ftp://proftaak.me/files/";
        private static readonly string FileName = "sample.mp4";

        /// <summary>
        ///     Uploads a file to FTP
        ///     https://msdn.microsoft.com/en-us/library/ms229715%28v=vs.110%29.aspx
        /// </summary>
        /// <param name="path"></param>
        public static void UploadFile(string path)
        {
            FileStream s;
            byte[] content = {};
            FtpWebResponse response;

            Logger.Info("Uploading file " + path);

            // Create the request
            FTPCreateFolder(path);
            FtpWebRequest request = (FtpWebRequest) WebRequest.Create(FolderLocation + path);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(username, pw);
            request.UseBinary = true;

            // Copy the file to a byte array
            try
            {
                FTPCreateFolder(path);
                using (FileStream source = File.OpenRead(path))
                {
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        source.CopyTo(requestStream);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Logger.Error("File was not found: " + ex);
                return;
            }
            catch (Exception Ex)
            {
                Logger.Error("Unspecified exception while uploading file: " + Ex);
                return;
            }

            //Make the request
            try
            {
                response = (FtpWebResponse) request.GetResponse();
            }
            catch (TimeoutException exception)
            {
                Logger.Error("Request timed out: " + exception);
                return;
            }
            catch (Exception ex)
            {
                Logger.Error("Unspecified exception while uploading file: " + ex);
                return;
            }

            // We check if the status code is more then 200 and less then 300. 2xx is the success of FTP
            if ((int) response.StatusCode >= 200 && (int) response.StatusCode < 300)
            {
                Logger.Success(string.Format("Uploaded file {0}, statuscode {1}", FileName, response.StatusDescription));
            }
            else
            {
                Logger.Error(string.Format("Could not upload file {0}, Description: {1}", FileName,
                    response.StatusDescription));
            }
        }

        /// <summary>
        /// Creates a path on FTP
        /// </summary>
        /// <param name="path"></param>
        private static void FTPCreateFolder(string path)
        {
            string[] subPaths = path.Replace(Path.GetFileName(path), "").Split('/');
            string soFar = FolderLocation;

            foreach (string sub in subPaths)
            {
                FtpWebRequest request = (FtpWebRequest) WebRequest.Create(soFar + sub);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;

                request.Credentials = new NetworkCredential(username, pw);
                try
                {
                    FtpWebResponse response = (FtpWebResponse) request.GetResponse();
                    Stream requestStream = response.GetResponseStream();
                    requestStream.Close();
                    response.Close();
                }
                catch (Exception)
                {
                    //Directory already exists
                }
                soFar += string.Format("{0}/", sub);
            }
        }

        /// <summary>
        /// Creates a local path
        /// </summary>
        /// <param name="path"></param>
        private static void localCreateFolder(string path)
        {
            string[] subPaths = path.Replace(Path.GetFileName(path), "").Split('/');
            string soFar = "";

            foreach (string sub in subPaths)
            {
                Directory.CreateDirectory(soFar + sub);

                soFar += string.Format("{0}/", sub);
            }
        }

        /// <summary>
        ///     Downloads a file from the server
        ///     https://msdn.microsoft.com/en-us/library/ms229711%28v=vs.110%29.aspx
        /// </summary>
        /// <param name="path"></param>
        public static void DownloadFile(string path)
        {
            byte[] content = {};
            FtpWebResponse response;
            Stream responseStream;
            StreamReader reader;
            StreamWriter writer;

            Logger.Info("Downloading file " + path);

            // Create the request 
            FtpWebRequest request = (FtpWebRequest) WebRequest.Create(FolderLocation + path);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential(username, pw);
            request.UseBinary = true;

            // Get the response
            try
            {
                response = (FtpWebResponse) request.GetResponse();
            }
            catch (TimeoutException exception)
            {
                Logger.Error("File download timed out: " + exception);
                return;
            }
            catch (Exception exception)
            {
                Logger.Error("Unspecified exception during download" + exception);
                return;
            }

            // Convert repsonse to readable format and write it to a file
            try
            {
                localCreateFolder(path);
                responseStream = response.GetResponseStream();
                using (FileStream stream = File.Create(path))
                {
                    using (Stream requestStream = responseStream)
                    {
                        requestStream.CopyTo(stream);
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.Error("Unspecified exception during file download: " + exception);
                return;
            }


            // Close streams
            responseStream.Close();
        }
    }
}