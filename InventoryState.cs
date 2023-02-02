using System;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 
// InventoryState myDeserializedClass = JsonConvert.DeserializeObject<List<InventoryState>>(myJsonResponse);
public class InventoryState
{
	public InventoryState()
	{
		//
		// TODO: Add constructor logic here
		//
	}

	public int ProductId;
	public int WarehouseId;
	public double AmountInStore;
	public double AmountToSale;
}
