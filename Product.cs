using System;
using System.Collections.Generic;


// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class BasePrice
{
    public DateTime Date { get; set; }
    public double Value { get; set; }
    public string Currency { get; set; }
}

public class CalcDuty
{
    public double Value { get; set; }
    public string Currency { get; set; }
}

public class CalcExcise
{
    public double Value { get; set; }
    public string Currency { get; set; }
}

public class CalcOther
{
    public double Value { get; set; }
    public string Currency { get; set; }
}

public class Catalog
{
    public int Id { get; set; }
    public int ParentId { get; set; }
    public string Name { get; set; }
    public string FullPath { get; set; }
}

public class Dimension
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string Value { get; set; }
    public object DictionaryValue { get; set; }
    public string Type { get; set; }
}

public class FK
{
    public string IdFK { get; set; }
    public string ParameterFK { get; set; }
}

public class Intrastat
{
    public double RatioOfWeight { get; set; }
    public double RatioOfComplementaryUM { get; set; }
    public string ComplementaryUM { get; set; }
    public bool UseComplementaryUM { get; set; }
}

public class Kind
{
    public int Id { get; set; }
    public string Code { get; set; }
    public bool Active { get; set; }
}

public class PurchasePrice
{
    public double Value { get; set; }
    public string Currency { get; set; }
}

public class PurchasePriceInCurrency
{
    public double Value { get; set; }
    public string Currency { get; set; }
}

public class Product
{
    public int Id { get; set; }
    public bool Active { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public int Type { get; set; }
    public string Barcode { get; set; }
    public string PKWiU { get; set; }
    public string CNFull { get; set; }
    public string CN { get; set; }
    public string DeliveryScheme { get; set; }
    public string FiscalName { get; set; }
    public string AgriculturalPromotionFund { get; set; }
    public bool PriceNegotiation { get; set; }
    public int PriceRounding { get; set; }
    public int PriceRecalculateType { get; set; }
    public int SettlementMethod { get; set; }
    public int PriceParameter { get; set; }
    public bool VAT50Minus { get; set; }
    public bool ReverseCharge { get; set; }
    public bool SplitPayment { get; set; }
    public int JPK_V7ProductGroup { get; set; }
    public bool StaticSet { get; set; }
    public bool PriceSetMode { get; set; }
    public bool CollationSetMode { get; set; }
    public bool SalePriceRecalculate { get; set; }
    public bool CurrencyMode { get; set; }
    public double CurrencyRateWithoutConversion { get; set; }
    public double CurrencyRate { get; set; }
    public int CurrencyConversion { get; set; }
    public DateTime CurrencyRateDate { get; set; }
    public double MinState { get; set; }
    public double MaxState { get; set; }
    public string Note { get; set; }
    public int Marker { get; set; }
    public FK FK { get; set; }
    public Intrastat Intrastat { get; set; }
    public UnitsOfMeasurement UnitsOfMeasurement { get; set; }
    public BasePrice BasePrice { get; set; }
    public PurchasePrice PurchasePrice { get; set; }
    public PurchasePriceInCurrency PurchasePriceInCurrency { get; set; }
    public List<SalePrice> SalePrices { get; set; }
    public CalcOther CalcOther { get; set; }
    public CalcExcise CalcExcise { get; set; }
    public CalcDuty CalcDuty { get; set; }
    public Kind Kind { get; set; }
    public Catalog Catalog { get; set; }
    public VatRate VatRate { get; set; }
    public object SetElements { get; set; }
    public List<Dimension> Dimensions { get; set; }
}

public class SalePrice
{
    public bool AutomaticValue { get; set; }
    public int Type { get; set; }
    public double ProfitPercent { get; set; }
    public double MarkupPercent { get; set; }
    public bool LinkedWithBasePrice { get; set; }
    public int Kind { get; set; }
    public int PriceParameter { get; set; }
    public double Value { get; set; }
    public string Currency { get; set; }
}

public class UnitsOfMeasurement
{
    public string RecordUM { get; set; }
    public string AdditionalUM1 { get; set; }
    public string AdditionalUM2 { get; set; }
    public string DefaultUM { get; set; }
    public string DisplayUM { get; set; }
    public int DefaultUMKind { get; set; }
    public double RatioOfAdditionalUM1 { get; set; }
    public double RatioOfAdditionalUM2 { get; set; }
    public double RatioOfDefaultUM { get; set; }
}

public class VatRate
{
    public int Id { get; set; }
    public string Code { get; set; }
}
