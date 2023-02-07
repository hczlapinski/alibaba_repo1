﻿using System;
using System.Net.Http.Json;
using RestSharp;
using System.Text.Json;
using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Summary description for Class1
/// </summary>
public class DataCollector
{   
   
	public DataCollector(string sessionToken)
	{
		SessionToken = sessionToken;
	}

	public static string SessionToken;

    //Warehouse
	public List<Warehouse> getWarehouses() 
	{
        var baseUrl = "https://alibaba-rds2.alibaba.pl:8181/api/Warehouses";
        var options = new RestClientOptions(baseUrl)
        {

            RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
        };

        var wa1 = new WebAPI(SessionToken); 
        var client = new RestClient(options);
        client.Authenticator = new RestSharp.Authenticators.OAuth2.OAuth2AuthorizationRequestHeaderAuthenticator(wa1.SessionToken, "Session");
        var request = new RestRequest();
        request.Method = Method.Get;
        request.AddParameter("deviceName", "TestC");
        var response = client.Execute(request);
        List<Warehouse> myDeserializedClass = JsonConvert.DeserializeObject<List<Warehouse>>(response.Content);

        return myDeserializedClass; 
    }

    //InventoryStates
    static public List<InventoryState> getInventoryState(string magCode)
    {
        var baseUrl = "https://alibaba-rds2.alibaba.pl:8181/api/InventoryStates/ByWarehouse?code=" + magCode;
        //Console.WriteLine(baseUrl);
        var options = new RestClientOptions(baseUrl)
        {

            RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
        };

        var wa1 = new WebAPI(SessionToken);
        var client = new RestClient(options);
        client.Authenticator = new RestSharp.Authenticators.OAuth2.OAuth2AuthorizationRequestHeaderAuthenticator(wa1.SessionToken, "Session");
        var request = new RestRequest();
        request.Method = Method.Get;
        request.AddParameter("deviceName", "TestC");
        var response = client.Execute(request);
        List<InventoryState> myDeserializedClass = JsonConvert.DeserializeObject<List<InventoryState>>(response.Content);

        return myDeserializedClass;
    }

    public List<InventoryState> getInventoryState(int magId)
    {
        var baseUrl = "https://alibaba-rds2.alibaba.pl:8181/api/InventoryStates/ByWarehouse?Id=" + magId;
        
        var options = new RestClientOptions(baseUrl)
        {

            RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
        };

        var wa1 = new WebAPI(SessionToken);
        var client = new RestClient(options);
        client.Authenticator = new RestSharp.Authenticators.OAuth2.OAuth2AuthorizationRequestHeaderAuthenticator(wa1.SessionToken, "Session");
        var request = new RestRequest();
        request.Method = Method.Get;
        request.AddParameter("deviceName", "TestC");
        var response = client.Execute(request);
        List<InventoryState> myDeserializedClass = JsonConvert.DeserializeObject<List<InventoryState>>(response.Content);

        return myDeserializedClass;
    }

    public Product getProduct(int pId)
    {
        var baseUrl = "https://alibaba-rds2.alibaba.pl:8181/api/Products?id=" + pId;
        //Console.WriteLine(baseUrl); 
        var options = new RestClientOptions(baseUrl)
        {

            RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
        };

        var wa1 = new WebAPI(SessionToken);
        var client = new RestClient(options);
        client.Authenticator = new RestSharp.Authenticators.OAuth2.OAuth2AuthorizationRequestHeaderAuthenticator(wa1.SessionToken, "Session");
        var request = new RestRequest();
        request.Method = Method.Get;
        request.AddParameter("deviceName", "TestC");
        var response = client.Execute(request);
        Product myDeserializedClass = JsonConvert.DeserializeObject<Product>(response.Content);

        return myDeserializedClass;
    }

    public Product getProduct(string pCode)
    {
        var baseUrl = "https://alibaba-rds2.alibaba.pl:8181/api/Products?code=" + pCode;
        var options = new RestClientOptions(baseUrl)
        {

            RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
        };

        var wa1 = new WebAPI(SessionToken);
        var client = new RestClient(options);
        client.Authenticator = new RestSharp.Authenticators.OAuth2.OAuth2AuthorizationRequestHeaderAuthenticator(wa1.SessionToken, "Session");
        var request = new RestRequest();
        request.Method = Method.Get;
        request.AddParameter("deviceName", "TestC");
        var response = client.Execute(request);
        Product myDeserializedClass = JsonConvert.DeserializeObject<Product>(response.Content);

        return myDeserializedClass;
    }




    public IList<Product> getProducts(string magCode)
    {

        List<InventoryState> invstates = getInventoryState(magCode); 

        List<Product> products = new List<Product>(); 

        foreach(var w in invstates)
        {

            if (w.AmountInStore > 0)
            {
                products.Add(getProduct(w.ProductId));
                Console.WriteLine(w.ProductId);
            }
        }

        //Console.WriteLine(d1.getProduct(w.ProductId).Name);
        return products;
    }

}




