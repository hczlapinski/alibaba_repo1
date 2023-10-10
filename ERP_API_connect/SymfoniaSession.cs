using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;


namespace ERP_API_connect
{
    class SymfoniaSession
    {
       


        public void getToken()
        {
        /*    var options = new RestClientOptions("https://alibaba-rds2.alibaba.pl:8181")
        {
            MaxTimeout = -1,
        };
        var client = new RestClient(options);
        var request = new RestRequest("/api/Sessions/OpenNewSession?deviceName=Test", Method.Get);
        request.AddHeader("Authorization", "Application 811957b2-5861-4667-aa5f-e20ec3a528bd");
        RestResponse response = await client.ExecuteAsync(request);
            //Console.WriteLine(response.Content);*/
            Console.WriteLine("test");
        }
    }
}
