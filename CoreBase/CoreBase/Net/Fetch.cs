using System;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace Nail.Core.Net
{
    /// <summary>
    /// Fetches web pages.
    /// </summary>
    public class Fetch
    {
        #region Initialiation
        /// <summary>
        /// Initializes a new instance of the <see cref="Fetch"/> class.
        /// </summary>
        public Fetch()
        {
            Headers = new WebHeaderCollection();
            Retries = 5;
            Timeout = 60000;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the headers.
        /// </summary>
        /// <value>The headers.</value>
        public WebHeaderCollection Headers { get; private set; }

        /// <summary>
        /// Gets the response.
        /// </summary>
        public HttpWebResponse Response { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public NetworkCredential Credential { get; set; }

        /// <summary>
        /// Gets the response data.
        /// </summary>
        public byte[] ResponseData { get; private set; }

        /// <summary>
        /// Gets or sets the retries.
        /// </summary>
        /// <value>The retries.</value>
        public int Retries { get; set; }

        /// <summary>
        /// Gets or sets the timeout.
        /// </summary>
        /// <value>The timeout.</value>
        public int Timeout { get; set; }

        /// <summary>
        /// Gets or sets the retry sleep in milliseconds.
        /// </summary>
        /// <value>The retry sleep.</value>
        public int RetrySleep { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Fetch"/> is success.
        /// </summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        public bool Success { get; private set; }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public void Load(string url)
        {
            for (int retry = 0; retry < Retries; retry++)
            {
                try
                {
                    string certName = @"C:\test.pfx";
                    string password = @"1%c9sC3DWm8Al$";
                    X509Certificate2 certificate = new X509Certificate2(certName, password);

                    ServicePointManager.CheckCertificateRevocationList = false;
                    ServicePointManager.ServerCertificateValidationCallback = (a, b, c, d) => true;
                    ServicePointManager.Expect100Continue = true;
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                    req.PreAuthenticate = true;
                    req.AllowAutoRedirect = true;
                    req.ClientCertificates.Add(certificate);
                    req.Method = "POST";
                    req.ContentType = "application/x-www-form-urlencoded";
                    string postData = "login-form-type=cert";
                    byte[] postBytes = Encoding.UTF8.GetBytes(postData);
                    req.ContentLength = postBytes.Length;

                    Stream postStream = req.GetRequestStream();
                    postStream.Write(postBytes, 0, postBytes.Length);
                    postStream.Flush();
                    postStream.Close();
                    WebResponse resp = req.GetResponse();

                    Stream stream = resp.GetResponseStream();
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string line = reader.ReadLine();
                        while (line != null)
                        {
                            Console.WriteLine(line);
                            line = reader.ReadLine();
                        }
                    }

                    stream.Close();
                    //var req = HttpWebRequest.Create(url) as HttpWebRequest;
                    //req.AllowAutoRedirect = true;
                    //ServicePointManager.ServerCertificateValidationCallback = (a, b, c, d) => true;
                    //if (Credential != null)
                    //    req.Credentials = Credential;
                    //req.Headers = Headers;
                    //req.Timeout = Timeout;

                    //Response = req.GetResponse() as HttpWebResponse;
                    //switch (Response.StatusCode)
                    //{
                    //    case HttpStatusCode.Found:
                    //        // This is a redirect to an error page, so ignore.
                    //        Console.WriteLine("Found (302), ignoring ");
                    //        break;

                    //    case HttpStatusCode.OK:
                    //        // This is a valid page.
                    //        using (var sr = Response.GetResponseStream())
                    //        using (var ms = new MemoryStream())
                    //        {
                    //            for (int b; (b = sr.ReadByte()) != -1;)
                    //                ms.WriteByte((byte) b);
                    //            ResponseData = ms.ToArray();
                    //        }
                    //        break;

                    //    default:
                    //        // This is unexpected.
                    //        Console.WriteLine(Response.StatusCode);
                    //        break;
                    //}
                    Success = true;
                    break;
                }
                catch (WebException ex)
                {
                    Console.WriteLine(":Exception " + ex.Message);
                    Response = ex.Response as HttpWebResponse;
                    if (ex.Status == WebExceptionStatus.Timeout)
                    {
                        Thread.Sleep(RetrySleep);
                        continue;
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public static byte[] Get(string url)
        {
            var f = new Fetch();
            f.Load(url);
            return f.ResponseData;
        }

        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <returns></returns>
        public string GetString()
        {
            var encoder = string.IsNullOrEmpty(Response.ContentEncoding) ? Encoding.UTF8 : Encoding.GetEncoding(Response.ContentEncoding);
            if (ResponseData == null)
                return string.Empty;
            return encoder.GetString(ResponseData);
        }
        #endregion
    }
}
