using System;
using System.Net.Http.Json;
using RestSharp;
using System.Text.Json;
using Newtonsoft.Json;

/// <summary>
/// Summary description for Class1
/// </summary>
public class WebAPI
{
	private string sessionToken;

	public string SessionToken { get { return sessionToken;  } }

	public WebAPI()
	{
		this.sessionToken = getSessionToken();

	}

    public WebAPI(string sessionToken)
    {
        this.sessionToken = sessionToken; 

    }

    private static string getSessionToken()
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

	public  void killSession() 
	{
        var baseurl = "https://alibaba-rds2.alibaba.pl:8181/api/Sessions/CloseSession";
        var options = new RestClientOptions(baseurl)
        {

            RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
        };
        var token = this.sessionToken;
        var client = new RestClient(options);
        client.Authenticator = new RestSharp.Authenticators.OAuth2.OAuth2AuthorizationRequestHeaderAuthenticator(token, "Session");
        var request = new RestRequest();
        request.Method = Method.Get;
        request.AddParameter("deviceName", "TestC");
        var response = client.Execute(request);

        //var myDeserializedClass = JsonConvert.DeserializeObject<Content>(response.Content);

    }

    public bool checkSessionStateAlive()
    {
        var baseurl = "https://alibaba-rds2.alibaba.pl:8181/api/Warehouses";
        var options = new RestClientOptions(baseurl)
        {

            RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
        };
        var token = this.sessionToken;
        var client = new RestClient(options);
        client.Authenticator = new RestSharp.Authenticators.OAuth2.OAuth2AuthorizationRequestHeaderAuthenticator(token, "Session");
        var request = new RestRequest();
        request.Method = Method.Get;
        request.AddParameter("deviceName", "TestC");
        var response = client.Execute(request);
        var res = response.Content;

        if (res.Contains("Nieprawidłowy klucz lub sesja wygasła."))
            return false;
        else
            return true;

    }
}
