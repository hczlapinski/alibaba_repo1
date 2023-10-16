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

            /*var csv1 = new CSVRead();

           var t = csv1.readCSV1d("C:\\Users\\adminali\\source\\repos\\RestAPI_SymfoniaERP\\mags.csv");

            foreach(var i in t)
            {
                Console.WriteLine(i);
            }*/




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

            var w1 = new WebAPI();
            DataCollector d1 = new DataCollector(w1.SessionToken);
            List<List<string>> table = new List<List<string>>();

            

            int x = 0;
               foreach (var w in d1.getInventoryState("SKalisz"))
                 {
                     if (w1.checkSessionStateAlive())
                     {   
                        
                         if (w.AmountInStore > 0)
                         {
                            Console.SetCursorPosition(0, 0);
                            Console.Write("");
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


                /*// create a 3x3 table of integers using a multidimensional list
                List<List<int>> table = new List<List<int>>(3);

                for (int i = 0; i < 3; i++)
                {
                    table.Add(new List<int>(5));

                    for (int j = 0; j < 5; j++)
                    {
                        table[i].Add(i);
                    }
                }
                // set some values in the table
                table[0][0] = 1;
                table[1][1] =5;
                table[2][2] = 3;
                // print the table
                for (int i = 0; i < table.Count; i++)
                {
                    for (int j = 0; j < table[i].Count; j++)
                    {
                        Console.Write(table[i][j] + " ");
                    }
                    Console.WriteLine();
                }*/

            }
       

       
    }

}
