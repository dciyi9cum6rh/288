using DataModel;
using IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Utility;

namespace YunQiERP.ViewComponents
{
    [Authorize]
    public class PostOrderViewComponent : ViewComponent
    {
        private IOrderRepository IMR { get; set; }
        private IMemberRepository IMER { get; set; }
        private IConfiguration config { get; set; }

        public PostOrderViewComponent(IConfiguration configuration, IOrderRepository OrderRepository, IMemberRepository MemberRepository)
        {
            IMR = OrderRepository;
            IMR.constr = configuration.GetConnectionString("SqlConn");
            IMER = MemberRepository;
            IMER.constr = configuration.GetConnectionString("SqlConn");
            config = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync(string MemberMobile, List<CartsViewModel> Carts, ContactDataViewModel ContactData, int CartTobal)
        {
            TradeSPToken RtnModel = null;
            List<CartListViewModel> lstCLVM = null;
            string OrderId = "";
            try
            {
                //檢查商品庫存
                foreach (var o in Carts)
                {
                    int stock = await IMR.MemberCartCheck(o.productId, o.sizeId, o.colorId, o.quantity);
                    if (stock != 0)
                    {
                        return View(new PostOrderViewModel1 { ret = stock, product = o.product });
                    }
                }

                // 8.系統讀取當日最後一張訂單號。
                DateTime dt = DateTime.Now;
                OrderIdViewModel Order = await IMR.GetNewOrderId(dt);
                if (Order != null)
                {
                    // 9.系統判斷8傳回值!=null。
                    // 10.系統設定OrderId=年月日+<8讀取值最後4碼加1>。
                    OrderId = Data.GetNewId(Order.OrderId, 9, 4);
                }
                else
                {
                    // 9a.系統判斷8傳回值==null。
                    //  9a-1.系統設定OrderId=年月日+<0201>。
                    //  9a-2.回11。
                    OrderId = Data.GetStartId("B", dt);
                }
                // 6.系統在ViewComponent【Cart/PostOrder】中建立一筆綠界訂單。
                string MerchantIDTmp = config["MerchantID"];
                string TradeDesc = config["TradeDesc"];

                //測試環境轉正式環境

                //測試
                //string MerchantID = "2000132";
                //string HashKey = "5294y06JbISpM5x9";
                //string HashIV = "v77hoKGq4kWxNNIS";
                //string PostURL = "https://payment-stage.ecpay.com.tw/SP/CreateTrade";
                //正式
                string MerchantID = "3084097";
                string HashKey = "AIlPEruFqmb1fZmz";
                string HashIV = "oKf58WmB9vgevdrj";
                string PostURL = "https://payment.ecpay.com.tw/SP/CreateTrade";

                SortedDictionary<string, string> PostCollection = new SortedDictionary<string, string>();

                PostCollection.Add("MerchantID", MerchantID);
                PostCollection.Add("MerchantTradeNo", $"{OrderId}{MerchantIDTmp}");
                //PostCollection.Add("MerchantTradeNo", DateTime.Now.ToString("yyyyMMddHHmmss"));
                //PostCollection.Add("MerchantTradeNo", "sdfg1561/");
                PostCollection.Add("MerchantTradeDate", dt.ToString("yyyy/MM/dd HH:mm:ss"));
                PostCollection.Add("PaymentType", "aio");
                PostCollection.Add("TotalAmount", CartTobal.ToString());
                PostCollection.Add("TradeDesc", TradeDesc);
                string ItemName = "";
                foreach (var item in Carts)
                {
                    ItemName += $"{item.product}{item.price}元#";
                }
                ItemName = ItemName.Substring(0, ItemName.Length - 1);
                PostCollection.Add("ItemName", ItemName);
                PostCollection.Add("ReturnURL", "http://59.126.111.115/GreenApi/api/Paymeent/PostCardInfo");
                PostCollection.Add("PaymentInfoURL", "http://59.126.111.115/GreenApi/api/Paymeent/PostPaymentInfo");
                PostCollection.Add("ChoosePayment", "ALL");
                PostCollection.Add("EncryptType", "1");
                PostCollection.Add("NeedExtraPaidInfo", "N");
                PostCollection.Add("IgnorePayment", "");
                //記憶卡號
                //PostCollection.Add("BidingCard", "");
                //PostCollection.Add("MerchantMemberID", "");
                //分期付款
                //PostCollection.Add("StoreID", "");
                // PostCollection.Add("CustomField1", "");
                //PostCollection.Add("CustomField2", "");
                //PostCollection.Add("CustomField3", "");
                // PostCollection.Add("CustomField4", "");

                //定期定額
                //PostCollection.Add("PeriodAmount", "5");
                //PostCollection.Add("PeriodType", "Y");
                //PostCollection.Add("Frequency", "1");
                //PostCollection.Add("ExecTimes", "6");
                //PostCollection.Add("PeriodReturnURL", "http://127.0.0.1/01/CheckOutFeedback.php");
                //紅利折抵
                //PostCollection.Add("Redeem", "Y");
                //ATM繳費期限
                //PostCollection.Add("ExpireDate", "");
                //CVS&BARCODE繳費期限
                //PostCollection.Add("StoreExpireDate", "");
                //電子發票
                //PostCollection.Add("InvoiceMark", "N");//電子發票開立註記
                //PostCollection.Add("RelateNumber", DateTime.Now.ToString("yyyyMMddHHmmss"));  //會員自訂編號
                //PostCollection.Add("CustomerID", "");//客戶代號
                //PostCollection.Add("CustomerName", "");//客戶名稱
                //PostCollection.Add("CustomerAddr", "");//客戶地址
                //PostCollection.Add("CustomerPhone", "0912345678");//客戶手機號碼
                //PostCollection.Add("CustomerEmail", "");
                //PostCollection.Add("TaxType", "1");//課稅類別
                //PostCollection.Add("CarruerType", "");//載具類別
                //PostCollection.Add("CarruerNum", "");
                //PostCollection.Add("Donation", "2");//捐贈註記
                //PostCollection.Add("LoveCode", "");//捐贈註記
                //PostCollection.Add("Print", "0");//列印註記
                //PostCollection.Add("InvoiceItemName", "商品名稱");//商品名稱
                //PostCollection.Add("InvoiceItemCount", "1");//商品數量
                //PostCollection.Add("InvoiceItemWord", "個");//商品單位
                //PostCollection.Add("InvoiceItemPrice", "100");//商品價格
                //PostCollection.Add("InvoiceItemTaxType", "");//商品課稅別
                //PostCollection.Add("InvoiceRemark", "");//備註
                //PostCollection.Add("DelayDay", "0");//延遲天數
                //PostCollection.Add("InvType", "07");//字軌類別

                //計算檢查碼
                string str = string.Empty;
                string str_pre = string.Empty;
                foreach (var test in PostCollection)
                {
                    str += string.Format("&{0}={1}", test.Key, test.Value);
                }

                str_pre += string.Format("HashKey={0}" + str + "&HashIV={1}", HashKey, HashIV);

                string urlEncodeStrPost = HttpUtility.UrlEncode(str_pre);
                string ToLower = urlEncodeStrPost.ToLower();
                string sCheckMacValue = Data.GetSHA256(ToLower);

                PostCollection.Add("CheckMacValue", sCheckMacValue);

                string Result = "";
                string ParameterString = string.Join("&", PostCollection.Select(p => p.Key + "=" + p.Value));

                //### Server Post
                using (WebClient wc = new System.Net.WebClient())
                {
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    wc.Encoding = Encoding.UTF8;
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    Result = wc.UploadString(PostURL, ParameterString);
                }

                //### 轉Model
                RtnModel = JsonConvert.DeserializeObject<TradeSPToken>(Result);

                if (RtnModel.RtnCode != "1")
                {
                    // 7a.系統判斷6執行失敗。
                    //  7a-1.系統回傳null。
                    RtnModel = null;
                }

                // 7.系統判斷6成功執行。
                lstCLVM = new List<CartListViewModel>();
                CartListViewModel CLVM;
                if (MemberMobile != "" && MemberMobile != null)
                {
                    // 11.系統判斷MemberMobile!=""。
                    // 12.系統讀取購物車清單。
                    lstCLVM = await IMER.GetCartList(MemberMobile);
                    foreach (var item in lstCLVM)
                    {
                        item.OrderId = OrderId;
                    }
                }
                else
                {
                    // 11a.系統判斷MemberMobile==""。
                    //  11a-1.系統將carts轉換為List<CartListViewModel>。
                    foreach (CartsViewModel item in Carts)
                    {
                        CLVM = new CartListViewModel();
                        CLVM.ProductId = item.productId;
                        CLVM.Product = item.product;
                        CLVM.ProducSizeId = item.sizeId;
                        CLVM.ProductColorId = item.colorId;
                        CLVM.Quantity = item.quantity;
                        CLVM.Price = item.price;
                        CLVM.ProductSize = item.size;
                        CLVM.ProductColor = item.color;
                        CLVM.OrderId = OrderId;
                        lstCLVM.Add(CLVM);
                    }
                    //  11a-2.回13。
                }
                // 13.系統新增一筆內部訂單。
                int ret = await IMR.InsertOrder(OrderId, dt, MemberMobile, ContactData.Freight, CartTobal - ContactData.Freight, CartTobal, ContactData.MemberName, ContactData.eMail, ContactData.Phone, ContactData.ContactAddress, sCheckMacValue, lstCLVM, $"{OrderId}{MerchantIDTmp}", ContactData.MemberMobile);
                if (ret == 0)
                {
                    // 14.系統判斷13執行成功。
                    // 15.系統設定傳回值=12讀取值。
                }
                else
                {
                    // 14a.系統判斷13執行失敗。
                    //  14a-1.系統設定傳回Model=null。
                    lstCLVM = null;
                    RtnModel = null;
                    //  14a-2.回16。
                }
            }
            catch (Exception ex)
            {
                RtnModel = null;
            }
            // 16.系統回傳View【Cart/PostOrder】，並傳回new PostOrderViewModel1
            //  { OrderDetail=15設定傳回值, ContactData=contactData, CartTobal= cartTobal, OrderId=10設定OrderId, RtnModel=金流公司的TradeSPToken }。
            return View(new PostOrderViewModel1 { OrderDetail = lstCLVM, ContactData = ContactData, CartTobal = CartTobal, OrderId = OrderId, RtnModel = RtnModel });
        }
    }
}
