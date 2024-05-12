using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAvalonia.Services
{
    internal class Request
    {
        public string SendRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string jsonData = "";
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    jsonData = reader.ReadToEnd();
                }

                return jsonData;
            }
            else
            {
                throw new HttpRequestException();
            }
        }
    }
}
