using System;
using System.Net.Http.Json;
using RestSharp;
using System.Text.Json;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using ClosedXML.Excel;
using System.Text.RegularExpressions;
using System.Text;



//testest

namespace RestAPI_SymfoniaERP
{
    class Program
    {

        static void Main(string[] args)
        {

            /*var csv1 = new CSVRead();

           var t = csv1.readCSV1d("C:\\Users\\adminali\\source\\repos\\RestAPI_SymfoniaERP\\mags.csv");

            foreach(var i in t)
            {
                Console.WriteLine(i);
            }*/


            /*AddFunctions adf1 = new AddFunctions();
            string[] tab1 = adf1.parseName("Drzwiczki małe v2 RAL7040 Swipbox KD/101-00300");*/


            //var pname = new ProductName("rossmann POa beetle V34 ru/123123 sn / 2323");
            //if (pname.nameCategoryPOSBeetle())
            //    Console.WriteLine("ok");

            //var workbook = new XLWorkbook();
            //var worksheet = workbook.Worksheets.Add("Sample Sheet");
            //worksheet.Cell("A1").Value = "Hello World!";
            //workbook.SaveAs("C:\\Users\\adminali\\source\\repos\\RestAPI_SymfoniaERP\\HelloWorld.xlsx");



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

            //

            /*  var w1 = new WebAPI();
              DataCollector d1 = new DataCollector(w1.SessionToken);
              List<List<string>> table = new List<List<string>>();



              int x = 0;
                 foreach (var w in d1.getInventoryState("SKalisz"))
                   {
                       if (w1.checkSessionStateAlive())
                       {   

                           if (w.AmountInStore > 0)
                           {

                          table.Add(new List<string>());

                          //Console.Write(d1.getProduct(w.ProductId).Name +" - ");
                          //Console.WriteLine(d1.getProduct(w.ProductId).Code);

                          table[x].Add(d1.getProduct(w.ProductId).Code);
                          table[x].Add(d1.getProduct(w.ProductId).Name);
                          table[x].Add(w.AmountInStore.ToString());

                          x++;
                          Console.SetCursorPosition(0, 0);
                          Console.Write(".");
                           }
                       }
                       else
                       {
                           w1 = new WebAPI();
                           d1 = new DataCollector(w1.SessionToken);
                       }
                   }
                   w1.killSession();
              Console.WriteLine("");
                  for (int i = 0; i < table.Count; i++)
                  {
                      for (int j = 0; j < table[i].Count; j++)
                      {
                          Console.Write(table[i][j] + " ");
                      }
                      Console.WriteLine();
                  }
  */

            var w1 = new WebAPI();
            DataCollector d1 = new DataCollector(w1.SessionToken);
            List<List<string>> table = new List<List<string>>();

            int x = 0;
            foreach (var w in d1.getInventoryState("SKielce"))
            {
                if (w1.checkSessionStateAlive())
                {

                    if (w.AmountInStore > 0)
                    {

                        table.Add(new List<string>());                    

                        table[x].Add(d1.getProduct(w.ProductId).Code);
                        table[x].Add(d1.getProduct(w.ProductId).Name);
                        table[x].Add(w.AmountInStore.ToString());
                        table[x].Add(d1.getProduct(w.ProductId).Catalog.Name);

                        x++;
                        //Console.SetCursorPosition(0, 0);
                        Console.Write(".");
                    }
                }
                else
                {
                    w1 = new WebAPI();
                    d1 = new DataCollector(w1.SessionToken);
                }
            }

            AddFunctions adf1 = new AddFunctions();
            var tab1 = System.Array.Empty<string>();
            

            String file = @"C:\Dane chronione\Output.csv";
            String separator = ",";
            StringBuilder output = new StringBuilder();
            String[] headings = { "Kod", "Name", "SN", "RU","KD","Katalog","QTY" };
            output.AppendLine(string.Join(separator, headings));

            for (int i = 0; i < table.Count; i++)
            {
                
                    tab1 = adf1.parseName(table[i][1]);
                    String[] newLine = { table[i][0], tab1[0], tab1[1], tab1[2], tab1[3], table[i][3], table[i][2] };
                    output.AppendLine(string.Join(separator, newLine));
            
            }

          
           



            try
            {
                File.Delete(file);
                File.AppendAllText(file, output.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data could not be written to the CSV file.");
                Console.WriteLine(ex.Message);
                return;
            }
            Console.WriteLine("The data has been successfully saved to the CSV file");

        }



    }

}
