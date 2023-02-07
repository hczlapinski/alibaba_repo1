using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;


public class CSVReader
{
	public string urlPath; 

	public CSVReader(string urlPath)
	{
		this.urlPath = urlPath; 
	}

	public CSVReader()
	{
		
	}

	public void readCSV() 
	{
		var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
		{
			HasHeaderRecord = false,
			Comment = '#',
			AllowComments = true,
			Delimiter = ";",
		};

		using var streamReader = File.OpenText(urlPath);
		using var csvReader = new CsvHelper.CsvReader(streamReader, csvConfig);

		while (csvReader.Read())
		{
			var Id = csvReader.GetField(0);
			var Mag = csvReader.GetField(1);
			

			Console.WriteLine($"{Id} {Mag}");
		}
	}

   public void writeCSV(Product product)
    {

		var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
		{
			HasHeaderRecord = false,
			Comment = '#',
			AllowComments = true,
			Delimiter = ";",
			
		};

	

		using (var mem = new MemoryStream())
		using (var writer = new StreamWriter(mem))
		using (var csvWriter = new CsvWriter(writer,csvConfig))
		{
			
		

			csvWriter.WriteHeader<Product>();
			//csvWriter.WriteRecords()
			//csvWriter.WriteField(product.Name);



			writer.Flush();
			var result = Encoding.UTF8.GetString(mem.ToArray());
			Console.WriteLine(result);
		}
	}
}
