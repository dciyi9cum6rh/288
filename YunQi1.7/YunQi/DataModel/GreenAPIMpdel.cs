namespace DataModel
{
    public class PaymentInfo
    {
        public string MerchantID { get; set; }
        public string MerchantTradeNo { get; set; }
        public string StoreID { get; set; }
        public int RtnCode { get; set; }
        public string RtnMsg { get; set; }
        public string TradeNo { get; set; }
        public int TradeAmt { get; set; }
        public string PaymentType { get; set; }
        public string TradeDate { get; set; }
        public string CustomField1 { get; set; }
        public string CustomField2 { get; set; }
        public string CustomField3 { get; set; }
        public string CustomField4 { get; set; }
        public string CheckMacValue { get; set; }
        public string BankCode { get; set; }
        public string vAccount { get; set; }
        public string ExpireDate { get; set; }
        public string PaymentNo { get; set; }
        public string Barcode1 { get; set; }
        public string Barcode2 { get; set; }
        public string Barcode3 { get; set; }
    }

    public class CardInfo
    {
        public string MerchantID { get; set; }
        public string MerchantTradeNo { get; set; }
        public string StoreID { get; set; }
        public int RtnCode { get; set; }
        public string RtnMsg { get; set; }
        public string TradeNo { get; set; }
        public int TradeAmt { get; set; }
        public string PaymentDate { get; set; }
        public string PaymentType { get; set; }
        public int PaymentTypeChargeFee { get; set; }
        public string TradeDate { get; set; }
        public int SimulatePaid { get; set; }
        public string CustomField1 { get; set; }
        public string CustomField2 { get; set; }
        public string CustomField3 { get; set; }
        public string CustomField4 { get; set; }
        public string CheckMacValue { get; set; }
    }
}