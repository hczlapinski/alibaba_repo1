using System;
using System.Net.Http.Json;
using RestSharp;
using System.Text.Json;
using Newtonsoft.Json;
using System.Collections.Generic;

//testest

namespace RestAPI_SymfoniaERP
{
    class Program
    {

        static void Main(string[] args)
        {

            var w1 = new WebAPI();
            DataCollector d1 = new DataCollector(w1.SessionToken);

            //foreach (var w in d1.getInventoryState("SKielce"))
            //{
            //    if (w1.checkSessionStateAlive())
            //        Console.WriteLine(d1.getProduct(w.ProductId).Name);
            //    //else
            //        //w1 = new WebAPI();
            //        //d1 = new DataCollector(w1.SessionToken);
            //}

            var csv = new CSVReader();
            csv.writeCSV(d1.getProduct(67522)); 

            w1.killSession();

            //var csv = new CSVReader("C:\\Users\\adminali\\source\\repos\\RestAPI_SymfoniaERP\\mags.csv");
            //csv.readCSV();
            
          

        }
       

       
    }

}
