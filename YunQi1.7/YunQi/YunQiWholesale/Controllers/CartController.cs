using DataModel;
using IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YunQiWholesale.Controllers
{
    public class CartController : Controller
    {
        private IMemberRepository IMER { get; set; }

        /// <summary>
        /// the class
        /// </summary>
        private IProductRepository IPRR { get; set; }

        private IParameterRepository IPR { get; set; }
        private IOrderRepository IOR { get; set; }
        private IConfiguration config { get; set; }
        private IEmailService IES { get; set; }
        private IEmailConfiguration IEC { get; set; }

        public CartController(IConfiguration configuration, IMemberRepository MemberRepository, IProductRepository ProductRepository, IParameterRepository ParameterRepository, IOrderRepository OrderRepository, IEmailService EmailService, IEmailConfiguration EmailConfiguration)
        {
            IMER = MemberRepository;
            IMER.constr = configuration.GetConnectionString("SqlConn");
            IPRR = ProductRepository;
            IPRR.constr = configuration.GetConnectionString("SqlConn");
            IPR = ParameterRepository;
            IPR.constr = configuration.GetConnectionString("SqlConn");
            IOR = OrderRepository;
            IOR.constr = configuration.GetConnectionString("SqlConn");
            config = configuration;
            IES = EmailService;
            IEC = EmailConfiguration;
        }

        [HttpPost]
        public async Task<IActionResult> Index(string MemberMobile, List<CartsViewModel> Carts)
        {
            List<CartListViewModel> lstCLVM = new List<CartListViewModel>();
            CartListViewModel CLVM;
            MemberViewModel MVM = null;
            if (MemberMobile != "" && MemberMobile != null)
            {
                // 3-1.系統在Action【Cart/Index】判斷MemberMobile!=""。
                // 4.系統在Action【Cart/Index】讀取購物車清單。
                lstCLVM = await IMER.GetCartList(MemberMobile);
                // 4-1.系統讀取會員基本資料。
                MVM = await IMER.GetMember(MemberMobile);
            }
            else
            {
                // 3-1a.系統在Action【Cart/Index】判斷MemberMobile!=""
                //  3-1a-1.系統將carts轉換為List<CartListViewModel>。
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
                    lstCLVM.Add(CLVM);
                }
                //  3-1a-2.回4-2。
            }
            // 4-2.系統讀取運費：
            int total = 0;
            foreach (var item in lstCLVM)
            {
                total += (item.Quantity * item.Price);
            }
            OrderFreightViewModel ofvm = await IPR.GetOrderFreight(total);
            // 5.系統在Action【Cart/Index】依4讀取值(List<CartListViewModel>)中每一筆記錄之ProductId，
            //  讀取對應之List<ProductSizeViewModel>與List<ProductColorViewModel>再分別指定給List<CartListViewModel>中的lstPSVM和lstPCVM。
            for (int i = 0; i <= lstCLVM.Count - 1; i++)
            {
                // 5-1.系統讀取商品尺寸資料。
                lstCLVM[i].lstPSVM = await IPRR.GetProductSize(lstCLVM[i].ProductId);
                // 5-2.系統讀取商品顏色資料。
                lstCLVM[i].lstPCVM = await IPRR.GetProductColor(lstCLVM[i].ProductId);
            }

            List<MemberDeliveryAddressListViewModel> MDAL = await IMER.GetMemberDeliveryAddressList(MemberMobile, null, null, null, 0, 10);

            // 5-3.系統回傳View【Cart/Index】，並回傳new CartHomesViewModel { lstCLVM=4傳回值, MVM=4-1傳回值, Freight=4-2讀取值}。
            return View(new CartHomesViewModel { lstCLVM = lstCLVM, MVM = MVM, Freight = ofvm, MDAL = MDAL });
        }

        [HttpGet]
        public async Task<IActionResult> GetFreight(int CartTotals)
        {
            // 9-2.系統在Get Action【Cart/GetFreight】讀取運費：
            OrderFreightViewModel ofvm = await IPR.GetOrderFreight(CartTotals);
            // 9-3.系統回傳json( new { Freight=9-2讀取值})
            return Json(new { Freight = ofvm });
        }

        [HttpPost]
        public async Task<int> DeleteCart(string MemberMobile, CartsViewModel Cart)
        {
            int ret = 0;
            try
            {
                // 5.系統在Action【Cart/DeleteCart】刪除一筆購物項目。
                ret = await IMER.DeleteMemberCart(MemberMobile, Cart.productId, Cart.sizeId, Cart.colorId);
                // 6.系統判斷5執行成功。
                // 7.系統傳回5傳回值。
            }
            catch (Exception ex)
            {
                // 6a.系統判斷5執行時發生例外。
                //  6a-1.系統傳回1。
                ret = 1;
            }
            return ret;
        }

        [HttpPost]
        public async Task<int> DeleteCarts(string MemberMobile, List<CartsViewModel> Carts)
        {
            int ret = 0;
            try
            {
                // 5.系統在Action【Cart/DeleteCarts】刪除多筆購物項目。
                MemberCartsViewModel mcvm;
                List<MemberCartsViewModel> lstMCVM = new List<MemberCartsViewModel>();
                foreach (CartsViewModel item in Carts)
                {
                    mcvm = new MemberCartsViewModel();
                    mcvm.MemberMobile = MemberMobile;
                    mcvm.ProductId = item.productId;
                    mcvm.ProducSizeId = item.sizeId;
                    mcvm.ProductColorId = item.colorId;
                    mcvm.Quantity = item.quantity;
                    lstMCVM.Add(mcvm);
                }
                // 5.系統在Action【Cart/DeleteCarts】刪除多筆購物項目。
                ret = await IMER.DeleteMemberCarts(lstMCVM);
                // 6.系統判斷5執行成功。
                // 7.系統傳回5傳回值。
            }
            catch (Exception ex)
            {
                // 6a.系統判斷5執行時發生例外。
                //  6a-1.系統傳回1。
                ret = 1;
            }
            return ret;
        }

        [HttpPost]
        public async Task<int> UpdateCart(string MemberMobile, CartsViewModel Cart, int ProducSizeIdN, int ProductColorIdN, string ProductSize, string ProductColor, int QuantityN)
        {
            int ret = 0;
            try
            {
                // 5.系統在Action【Cart/UpdateCart】更新一筆購物項目。
                ret = await IMER.UpdateMemberCart(MemberMobile, Cart.productId, Cart.sizeId, Cart.colorId, ProducSizeIdN, ProductColorIdN, ProductSize, ProductColor, QuantityN);
                // 6.系統判斷5執行成功。
                // 7.系統傳回5傳回值。
            }
            catch (Exception ex)
            {
                // 6a.系統判斷5執行時發生例外。
                //  6a-1.系統傳回1。
                ret = 1;
            }
            return ret;
        }

        [HttpGet]
        public async Task<int> GetOutFreight(string ContactAddress)
        {
            int ret = 0;
            try
            {
                // 3-2.系統在Get Action【Cart/GetOutFreight】讀取離島地區資料：
                List<OutlyingIslandViewModel> lstOIVM = await IPR.GetOutlyingIslandList();
                bool isIs = false;
                foreach (var item in lstOIVM)
                {
                    if (ContactAddress.Contains(item.OutlyingIsland))
                    {
                        isIs = true;
                        break;
                    }
                }
                if (isIs)
                {
                    // 3-3.系統判斷3-1上傳送貨地址中包含3-2之離島地區名稱。
                    // 3-4.系統回傳1。
                    ret = 1;
                }
                else
                {
                    // 3-3.a系統判斷3-1上傳送貨地址中未包含3-2之離島地區名稱。
                    //  3-3a-1.系統回傳0。
                    ret = 0;
                }
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        //20181213 ---棋
        //使用者在前台-我的訂單-點選取消訂單
        [HttpPost]
        public async Task<int> GetCancelOrderState(string OrderId)
        {
            var ret = 0;
            ret = await IMER.UpdateOrderState(OrderId, 8);
            return ret;
        }

        [HttpPost]
        public IActionResult PostOrder(string MemberMobile, List<CartsViewModel> Carts, ContactDataViewModel ContactData, int CartTobal)
        {
            // 5.系統在Action【Cart/PostOrder】中呼叫ViewComponent【Cart/PostOrder】，並傳送4上傳之jMemberMobile、carts，contactData、cartTobal。
            return ViewComponent("PostOrder", new { MemberMobile = MemberMobile, Carts = Carts, ContactData = ContactData, CartTobal = CartTobal });
        }

        [HttpPost]
        public async Task<IActionResult> Success(ContactDataViewModel ContactData, string OrderId, string MemberMobile, byte OrderStateId = 40)
        {
            PostOrderViewModel1 povm = null;
            int ret = 0;
            try
            {
                if (OrderStateId == 1)
                {
                    // 3.系統在Action【Cart/Success】判斷2傳送OrderStateId==1。
                    // 4.系統變更訂單狀態為1。
                    ret = await IMER.UpdateOrderState(OrderId, OrderStateId);
                    if (ret != 0)
                    {
                        return View(new PostOrderViewModel1 { OrderDetail = null, ContactData = null, CartTobal = -1, OrderId = "", RtnModel = null, MemberMobile = MemberMobile, ret = ret });
                    }
                }
                if (OrderStateId == 2)
                {
                    // 3.系統在Action【Cart/Success】判斷2傳送OrderStateId==2。
                    // 4.系統變更訂單狀態為2。
                    ret = await IMER.UpdateOrderState(OrderId, OrderStateId);
                    if (ret != 0)
                    {
                        return View(new PostOrderViewModel1 { OrderDetail = null, ContactData = null, CartTobal = -1, OrderId = "", RtnModel = null, MemberMobile = MemberMobile, ret = ret });
                    }
                }

                List<OrderCheckProductStockEnoughViewModel> OCPSE = await IOR.OrderCheckProductStockEnough(OrderId);
                if (OCPSE == null)
                {
                    return View(new PostOrderViewModel1 { OrderDetail = null, ContactData = null, CartTobal = -1, OrderId = "", RtnModel = null, MemberMobile = MemberMobile, ret = ret, OCPSE = OCPSE });
                }

                // 3a.系統在Action【Cart/Success】判斷2傳送OrderStateId!=1。
                //  3a-1.回4-1。
                // 4-1.系統刪除會員之所有購物車資料。
                ret = await IMER.DeleteAllMemberCarts(MemberMobile);
                if (ret != 0)
                    return View(new PostOrderViewModel1 { OrderDetail = null, ContactData = null, CartTobal = -1, OrderId = "", RtnModel = null, MemberMobile = MemberMobile });
                // 16.系統讀取訂單明細。
                List<CartListViewModel> lstCLVM = await IOR.GetOrderDetail(OrderId);
                // 17.系統更新商品庫存。
                ret = await IOR.UpdateProductStock(lstCLVM);
                if (ret != 0)
                {
                    return View(new PostOrderViewModel1 { OrderDetail = null, ContactData = null, CartTobal = -1, OrderId = "", RtnModel = null, MemberMobile = MemberMobile });
                }
                // 5.系統在Action【Cart/Success】寄發建立訂單eMail(含平台連結)。
                //EmailMessage em = new EmailMessage();
                //EmailAddress fAdd = new EmailAddress();
                //fAdd.Name = IEC.SmtpUsername;
                //fAdd.Address = $@"{IEC.SmtpUsername}";
                ////fAdd.Address = $@"{IEC.SmtpUsername}@{IEC.SmtpServer}";
                //em.FromAddresses.Add(fAdd);
                //EmailAddress tAdd = new EmailAddress();
                //tAdd.Name = ContactData.MemberName;
                //tAdd.Address = ContactData.eMail;
                //em.ToAddresses.Add(tAdd);
                //em.Subject = "288訂購訊息";
                //em.Content = "您好，\n";
                //em.Content += $"您在288建立的訂單己完成，訂單代碼為{OrderId}，<br>";
                //em.Content += $"若為會員，請至本平台會員中心查詢訂單處理狀態，<br>";
                //em.Content += $"若非會員，本平台會寄送eMail告知訂單處理狀況，<br>";
                //em.Content += $"288網址：http://dreammaker.game.tw/YunQiWholesale，<br>";
                //em.Content += $"客服專線：04-28825252";
                //em.Content += $"288應謝您！";
                // System.Net.Mail.MailMessage Message
                //IES.Send(em);
                // 5.系統在Action【Cart/Success】寄發建立訂單eMail(含平台連結)。
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.To.Add(ContactData.eMail);
                mail.From = new System.Net.Mail.MailAddress($@"{IEC.SmtpUsername}@{IEC.SmtpServer}");
                mail.Subject = "288訂購訊息";
                mail.Body = "您好，\n";
                mail.Body += $"您在288建立的訂單己完成，訂單代碼為{OrderId}，<br>";
                mail.Body += $"若為會員，請至本平台會員中心查詢訂單處理狀態，<br>";
                mail.Body += $"若非會員，本平台會寄送eMail告知訂單處理狀況，<br>";
                mail.Body += $"288網址：http://288ibobo.com ，<br>";
                mail.Body += $"客服專線：04-24260263";
                mail.Body += $"288應謝您！";
                mail.IsBodyHtml = true;
                IES.SendMail(mail);
                // 6.系統判斷5執行成功。
                // 7.系統回傳View【Cart/Success】，並傳回new PostOrderViewModel1 { OrderDetail=null, ContactData=contactData, CartTobal= null, OrderId=4上傳orderId, RtnModel=null }。
                povm = new PostOrderViewModel1 { OrderDetail = null, ContactData = ContactData, CartTobal = -1, OrderId = OrderId, RtnModel = null, MemberMobile = MemberMobile };
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                // 6a.系統判斷5執行失敗。
                //  6a-1.系統回傳View【Cart/Success】，並傳回new PostOrderViewModel1 { OrderDetail=null, ContactData=null, CartTobal= null, OrderId="", RtnModel=null }。
                povm = new PostOrderViewModel1 { OrderDetail = null, ContactData = null, CartTobal = -1, OrderId = "", RtnModel = null, MemberMobile = MemberMobile };
            }
            return View(povm);
        }
    }
}
