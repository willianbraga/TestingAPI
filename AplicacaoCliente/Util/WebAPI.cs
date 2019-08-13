using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AplicacaoCliente.Util
{
    public class WebAPI
    {
        public static string URI = "http://localhost:50168/api/cliente/";
        public static string RequestGET(string metodo, string parametro)
        {
            var request = (HttpWebRequest)WebRequest.Create(URI + metodo + "/" + parametro);
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString;

        }
        public static string RequestPOST(string metodo, string jsonData)
        {
            var request = (HttpWebRequest)WebRequest.Create(URI + metodo);
            var data = Encoding.ASCII.GetBytes(jsonData);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString;
        }
        public static string RequestPUT(string metodo, string jsonData)
        {
            var request = (HttpWebRequest)WebRequest.Create(URI + metodo);
            var data = Encoding.ASCII.GetBytes(jsonData);
            request.Method = "PUT";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString;
        }
    }
}
