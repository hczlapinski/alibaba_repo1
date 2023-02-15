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

            var pname = new ProductName("rossmann POa betle V34 ru/123123 sn / 2323");
            if (pname.nameCategoryPOSBeetle())
                Console.WriteLine("ok");

            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Sample Sheet");
            worksheet.Cell("A1").Value = "Hello World!";
            workbook.SaveAs("C:\\Users\\adminali\\source\\repos\\RestAPI_SymfoniaERP\\HelloWorld.xlsx");

            //var w1 = new WebAPI();
            //DataCollector d1 = new DataCollector(w1.SessionToken);

            //IList<Product> reports = d1.getProducts("SKielce");

            //w1.killSession();

            //foreach (var w in d1.getInventoryState("SKielce"))
            //{
            //    if (w1.checkSessionStateAlive())
            //        Console.WriteLine(d1.getProduct(w.ProductId).Name);
            //    //else
            //        //w1 = new WebAPI();
            //        //d1 = new DataCollector(w1.SessionToken);
            //}

            //using (ExcelEngine excelEngine = new ExcelEngine())
            //{
            //    IApplication application = excelEngine.Excel;
            //    application.DefaultVersion = ExcelVersion.Excel2013;
            //    IWorkbook workbook = application.Workbooks.Create(1);
            //    IWorksheet worksheet = workbook.Worksheets[0];

            //    //Import the data to worksheet
            //    IList<Product> reports = d1.getProducts("STest");
            //    worksheet.ImportData(reports, 2, 1, false);

            //    #region Save
            //    //Saving the workbook
            //    FileStream outputStream = new FileStream("C:\\Users\\adminali\\source\\repos\\RestAPI_SymfoniaERP\\ImportDataView.xlsx", FileMode.Create, FileAccess.Write);
            //    workbook.SaveAs(outputStream);
            //    #endregion

            //    //Dispose streams
            //    outputStream.Dispose();

            //    System.Diagnostics.Process process = new System.Diagnostics.Process();
            //    process.StartInfo = new System.Diagnostics.ProcessStartInfo("C:\\Users\\adminali\\source\\repos\\RestAPI_SymfoniaERP\\ImportDataView.xlsx")
            //    {
            //        UseShellExecute = true
            //    };
            //    process.Start();
            //}


        }
       

       
    }

}
