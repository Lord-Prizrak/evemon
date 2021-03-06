﻿using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using EVEMon.Common.Enumerations;

namespace EVEMon.Common.Net
{
    static partial class HttpWebClientService
    {
        private const string XmlAccept = "text/xml,application/xml,application/xhtml+xml;q=0.8,*/*;q=0.5";

        /// <summary>
        /// Downloads an Xml document from the specified url using the specified POST data.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="method">The method.</param>
        /// <param name="acceptEncoded">if set to <c>true</c> accept encoded response.</param>
        /// <param name="postdata">The post data.</param>
        /// <param name="dataCompression">The post data compression method.</param>
        /// <returns></returns>
        public static DownloadResult<IXPathNavigable> DownloadXml(Uri url, HttpMethod method = null,
            bool acceptEncoded = false, string postdata = null, DataCompression dataCompression = DataCompression.None)
            => DownloadXmlAsync(url, method, acceptEncoded, postdata, dataCompression).Result;

        /// <summary>
        /// Asynchronously downloads an xml file from the specified url.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="method">The method.</param>
        /// <param name="acceptEncoded">if set to <c>true</c> accept encoded response.</param>
        /// <param name="postdata">The post data.</param>
        /// <param name="dataCompression">The post data compression method.</param>
        public static async Task<DownloadResult<IXPathNavigable>> DownloadXmlAsync(Uri url, HttpMethod method = null,
            bool acceptEncoded = false, string postdata = null, DataCompression dataCompression = DataCompression.None)
        {
            string urlValidationError;
            if (!IsValidURL(url, out urlValidationError))
                throw new ArgumentException(urlValidationError);

            HttpPostData postData = String.IsNullOrWhiteSpace(postdata) ? null : new HttpPostData(postdata, dataCompression);
            HttpClientServiceRequest request = new HttpClientServiceRequest();
            try
            {
                HttpResponseMessage response = await request
                    .SendAsync(url, method, postData, dataCompression, acceptEncoded, XmlAccept)
                    .ConfigureAwait(false);

                using (response)
                {
                    Stream stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
                    return GetXmlDocument(request.BaseUrl, stream);
                }
            }
            catch (HttpWebClientServiceException ex)
            {
                return new DownloadResult<IXPathNavigable>(new XmlDocument(), ex);
            }
        }

        /// <summary>
        /// Helper method to return an Xml document from the completed request.
        /// </summary>
        /// <param name="requestBaseUrl">The request base URL.</param>
        /// <param name="stream">The stream.</param>
        /// <returns></returns>
        private static DownloadResult<IXPathNavigable> GetXmlDocument(Uri requestBaseUrl, Stream stream)
        {
            XmlDocument xmlDoc = new XmlDocument();
            HttpWebClientServiceException error = null;

            if (stream == null)
            {
                error = HttpWebClientServiceException.Exception(requestBaseUrl, new ArgumentNullException(nameof(stream)));
                return new DownloadResult<IXPathNavigable>(xmlDoc, error);
            }

            try
            {
                xmlDoc.Load(Util.ZlibUncompress(stream));
            }
            catch (XmlException ex)
            {
                error = HttpWebClientServiceException.XmlException(requestBaseUrl, ex);
            }

            return new DownloadResult<IXPathNavigable>(xmlDoc, error);
        }
    }
}
