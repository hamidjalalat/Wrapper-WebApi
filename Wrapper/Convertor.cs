using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Wrapper
{
  public  class Convertor
    {

        public Convertor() : base()
        {

        }
        public bool CheckConnection ()
        {
            bool Connection = false;
            try
            {
                Ping Ping = new Ping();
                string MyHost = "google.com";
                PingReply PR = Ping.Send(MyHost, 1000, new byte[32], new PingOptions());
                if (PR.Status == IPStatus.Success)
                {
                    Connection = true;
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                Connection = false;
            }
            return Connection;
        }

        public Person GetPerson()
        {
            WebClient MyWebClinet = new WebClient();
            MyWebClinet.Headers[HttpRequestHeader.ContentType] = "application/json;charset=UTF-8";
            string Url = "http://localhost:33618/api/myapi/GetPerson1";
            string jsonResponse = MyWebClinet.DownloadString(Url);
            return JsonConvert.DeserializeObject<Person>(jsonResponse);
        }
        public Person GetPerson2()
        {
            //add dll RestSharp#
            var client = new RestClient();
            var uri = new Uri("http://localhost:33618/api/myapi/GetPerson1");
            client.BaseUrl = uri;
            var request = new RestRequest();
            request.Method = Method.GET;
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("ContentType", "application/json; charset=UTF-8");
            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute(request) as RestResponse;
            var json = response.Content;
            var objectResponse = JsonConvert.DeserializeObject<Person>(json);
            return objectResponse;
        }
        public T GetPersonGeneriv<T>()
        {
            WebClient MyWebClinet = new WebClient();
            MyWebClinet.Headers[HttpRequestHeader.ContentType] = "application/json;charset=UTF-8";
            string Url = "http://localhost:33618/api/myapi/GetPerson1";
            string jsonResponse = MyWebClinet.DownloadString(Url);
            var v= JsonConvert.DeserializeObject<T>(jsonResponse);
            return (T)Convert.ChangeType(v,v.GetType()) ;
        }
        public Person GetPersonHttp()
        {
            WebClient MyWebClinet = new WebClient();
            MyWebClinet.Headers[HttpRequestHeader.ContentType] = "application/json;charset=UTF-8";
            string Url = "http://localhost:33618/api/myapi/GetPerson6";
            string jsonResponse = MyWebClinet.DownloadString(Url);
            return JsonConvert.DeserializeObject<Person>(jsonResponse);
        }
        public Person GetPersonWithRouting()
        {
            WebClient MyWebClinet = new WebClient();
            MyWebClinet.Headers[HttpRequestHeader.ContentType] = "application/json;charset=UTF-8";
            string Url = "http://localhost:33618/api/googooli/Magooli";
            string jsonResponse = MyWebClinet.DownloadString(Url);
            return JsonConvert.DeserializeObject<Person>(jsonResponse);
        }
        public bool GetPersonPost()
        {
            Person P = new Person();
            P.Id = 1;
            P.Name = "Hamid";
            P.Family = "Jalalat";
            P.Address = "KhaniAbad";

            WebClient MyWebClinet = new WebClient();
            MyWebClinet.Headers[HttpRequestHeader.ContentType] = "application/json;charset=UTF-8";
            string Url = "http://localhost:33618/api/myapi/PostPerson";
            string JsonString = JsonConvert.SerializeObject(P);
            string jsonResponse = MyWebClinet.UploadString(Url, JsonString);
            if (jsonResponse=="true")
            {
                return true;
            }
            return false;
        }
    }
}
