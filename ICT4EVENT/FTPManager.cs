using System;
using System.IO;
using System.Net;
using System.Text;
using ApplicationLogger;

namespace ICT4EVENT
{
    public static class FTPManager
    {
        private const string FolderLocation = "ftp://88.159.165.90/Disk/Public/Media/";
        private static string FileName = "sample.mp4";

        /// <summary>
        ///     Uploads a file to FTP
        ///     https://msdn.microsoft.com/en-us/library/ms229715%28v=vs.110%29.aspx
        /// </summary>
        /// <param name="path"></param>
        public static void UploadFile(string path)
        {
            StreamReader s;
            byte[] content = {};
            FtpWebResponse response;

            Logger.Info("Uploading file " + path);

            // Create the request 
            var request = (FtpWebRequest) WebRequest.Create(FolderLocation + FileName);
            request.Credentials = new NetworkCredential("user", "password");

            // Copy the file to a byte array
            try
            {
                s = new StreamReader(FileName);
                content = Encoding.UTF8.GetBytes(s.ReadToEnd());
                s.Close();
                request.ContentLength = content.Length;
                Logger.Debug("Successfully copied data to stream");

                // Copy contents to the request stream
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(content, 0, content.Length);
                requestStream.Close();
                Logger.Debug("Successfully copied stream to request");
                Logger.Debug("Successfully copied stream to request");
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
                Logger.Success(String.Format("Uploaded file {0}, statuscode {1}", FileName, response.StatusDescription));
            }
            else
            {
                Logger.Error(String.Format("Could not upload file {0}, Description: {1}", FileName,
                    response.StatusDescription));
            }
        }

        /// <summary>
        ///     Downloads a file from the server
        ///     https://msdn.microsoft.com/en-us/library/ms229711%28v=vs.110%29.aspx
        /// </summary>
        /// <param name="path"></param>
        public static void DownloadFile(string path)
        {
            StreamReader s;
            byte[] content = {};
            FtpWebResponse response;
            Stream responseStream;
            StreamReader reader;
            StreamWriter writer;

            Logger.Info("Downloading file " + path);

            // Create the request 
            var request = (FtpWebRequest) WebRequest.Create(FolderLocation + path);
            request.Credentials = new NetworkCredential("user", "password");

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
                responseStream = response.GetResponseStream();
                reader = new StreamReader(responseStream);

                writer = new StreamWriter(path);

                writer.Write(reader.ReadToEnd());
            }
            catch (Exception exception)
            {
                Logger.Error("Unspecified exception during file download: " + exception);
                return;
            }


            // Close streams
            reader.Close();
            writer.Close();
            responseStream.Close();
        }
    }
}