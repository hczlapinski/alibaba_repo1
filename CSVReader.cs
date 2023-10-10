using System;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using System.IO;
using System.Collections.Generic;

public class CSVRead
{
	//public string Path;

	public CSVRead()
	{
		
	}

	public List<string> readCSV1d(string path)
    {
        string t = "";
        List<string> mags = new List<string>(); 
        var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
        {
            HasHeaderRecord = false,
            Comment = '#',
            AllowComments = true,
            Delimiter = ";",
        };

        

        using var streamReader = File.OpenText(path);
        using var csvReader = new CsvReader(streamReader, csvConfig);

        

        while (csvReader.Read())
        {
           t = csvReader.GetField(0);
           mags.Add(csvReader.GetField(0)); 

            //Console.WriteLine($"{t}");
        }
        mags.Remove("Mag");
        return mags;
        
    }

    public List<string> readCSV2d(string path,int col)
    {
        
        List<string> mags = new List<string>();
        var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
        {
            HasHeaderRecord = false,
            Comment = '#',
            AllowComments = true,
            Delimiter = ";",
        };



        using var streamReader = File.OpenText(path);
        using var csvReader = new CsvReader(streamReader, csvConfig);



        while (csvReader.Read())
        {
           
            for(int i = 0; i < col; i++)
                mags.Add(csvReader.GetField(i));

          
        }
        mags.Remove("Mag");
        return mags;

    }


}
