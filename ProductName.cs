using System;

public class ProductName
{
	public string Pname;

    private static string[] posbeetle = { "beetle", "pos beetle", "beetle pos" };

    public ProductName(string pName)
	{
		Pname = pName; 
	}

	public void nameContainsExpr(string expr)
    {
		if (Pname.Contains(expr))
			Console.WriteLine("Zawiera"); 
    }

	public bool nameCategoryPOSBeetle()
    {
		
		foreach(var p in posbeetle)
        {
			if (Pname.ToLower().Contains(p))
				return true;
			else
				return false;


		}
		return false;
	}
}
