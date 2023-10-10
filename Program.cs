using System;
using System.Net.Http.Json;
using RestSharp;
using System.Text.Json;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using ClosedXML.Excel;


//testest

namespace RestAPI_SymfoniaERP
{
    class Program
    {

        static void Main(string[] args)
        {

            var csv1 = new CSVRead();

           var t = csv1.readCSV1d("C:\\Users\\adminali\\source\\repos\\RestAPI_SymfoniaERP\\mags.csv");

            foreach(var i in t)
            {
                Console.WriteLine(i);
            }

      


            //var pname = new ProductName("rossmann POa beetle V34 ru/123123 sn / 2323");
            //if (pname.nameCategoryPOSBeetle())
            //    Console.WriteLine("ok");

            //var workbook = new XLWorkbook();
            //var worksheet = workbook.Worksheets.Add("Sample Sheet");
            //worksheet.Cell("A1").Value = "Hello World!";
            //workbook.SaveAs("C:\\Users\\adminali\\source\\repos\\RestAPI_SymfoniaERP\\HelloWorld.xlsx");

            var w1 = new WebAPI();
            DataCollector d1 = new DataCollector(w1.SessionToken);

            //d1.changeProductDimensions(172237,"Kategoria sprzetu", "Skaner ladowy");
            //Console.WriteLine(w1.SessionToken); 
            //foreach (var w in d1.getInventoryState("STest"))
            //{
            //    if (w1.checkSessionStateAlive())
            //    {
            //        Console.WriteLine(d1.getProduct(w.ProductId).Name);
            //        d1.changeProductDimensions(d1.getProduct(w.ProductId).Id, "Kategoria sprzetu", "Skaner ladowy");
            //    }
                //else
                    //w1 = new WebAPI();
                    //d1 = new DataCollector(w1.SessionToken);
            //}

            //IList<Product> reports = d1.getProducts("SKielce");

            //w1.killSession();

            foreach (var w in d1.getInventoryState("SKielce"))
            {
                if (w1.checkSessionStateAlive())
                {
                   
                    Console.WriteLine(d1.getProduct(w.ProductId).Name + ", amount:" + w.AmountInStore.ToString());
                }
                else
                {
                    w1 = new WebAPI();
                    d1 = new DataCollector(w1.SessionToken);
                }
            }

           


        }
       

       
    }

}
