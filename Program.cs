using System;
using System.Net.Http.Json;
using RestSharp;
using System.Text.Json;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace RestAPI_SymfoniaERP
{
    class Program
    {

        static void Main(string[] args)
        {

            var w1 = new WebAPI();
            DataCollector d1 = new DataCollector(w1.SessionToken);

            foreach (var wa in d1.getWarehouseNamebyId(2)) 
            {
                Console.WriteLine(wa.Name); 
            }

            w1.killSession();
            


        }

       /* public static string getSessionToken() 
        {
            var baseurl = "https://alibaba-rds2.alibaba.pl:8181/api/Sessions/OpenNewSession";
            var options = new RestClientOptions(baseurl)
            {

                RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
            };
            var token = "811957b2-5861-4667-aa5f-e20ec3a528bd";
            var client = new RestClient(options);
            client.Authenticator = new RestSharp.Authenticators.OAuth2.OAuth2AuthorizationRequestHeaderAuthenticator(token, "Application");
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddParameter("deviceName", "TestC");
            var response = client.Execute(request);
            string t = response.Content.Substring(1, response.Content.Length - 2);

            return t;
        }

        public static void killSession(string session) 
        {
            var baseurl = "https://alibaba-rds2.alibaba.pl:8181/api/Sessions/CloseSession"; 
            var options = new RestClientOptions(baseurl)
            {

                RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
            };
            var token = session;
            var client = new RestClient(options);
            client.Authenticator = new RestSharp.Authenticators.OAuth2.OAuth2AuthorizationRequestHeaderAuthenticator(token, "Session");
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddParameter("deviceName", "TestC");
            var response = client.Execute(request);

            var myDeserializedClass = JsonConvert.DeserializeObject<Content>(response.Content);
            
         
      
            
        }
       */
        public static void getData(string session, string baseurl)
        {
            var options = new RestClientOptions(baseurl)
            {

                RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
            };
            var token = session;
            var client = new RestClient(options);
            client.Authenticator = new RestSharp.Authenticators.OAuth2.OAuth2AuthorizationRequestHeaderAuthenticator(token, "Session");
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddParameter("deviceName", "TestC");
            var response = client.Execute(request);


            var myDeserializedClass = JsonConvert.DeserializeObject<Product>(response.Content);
            Console.WriteLine(myDeserializedClass.UnitsOfMeasurement.DefaultUM); 



        }

       
    }

}
