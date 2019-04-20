using DataModel;
using IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymeentController : ControllerBase
    {
        private IOrderRepository IOR { get; set; }
        private IConfiguration config { get; set; }
        private IEmailService IES { get; set; }
        private IEmailConfiguration IEC { get; set; }

        public PaymeentController(IConfiguration configuration, IOrderRepository OrderRepository, IEmailService EmailService, IEmailConfiguration EmailConfiguration)
        {
            IOR = OrderRepository;
            IOR.constr = configuration.GetConnectionString("SqlConn");
            config = configuration;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return $"value {id}";
        }

        // 1.綠界以http://dreammaker.game.tw/GreenApi/api/Paymeent/PostCardInfo，並傳送相關參數。
        // 2.系統呼叫Post Action【Paymeent/PostCardInfo】並傳送相關參數。
        [HttpPost]
        [Route("[action]")]
        // ReturnURL：信用卡付款結果通知
        public async Task<ActionResult<string>> PostCardInfo([FromForm] CardInfo model)
        {
            string ret = "1|OK";
            CheckMacValueModel cmvm = null;
            byte OrderStateId = 4;
            try
            {
                if (model.RtnCode == 1)
                {
                    // 3.系統在Action【Paymeent/PostCardInfo】判斷綠界傳送之RtnCode==1。
                    // 4.系統在Action【Paymeent/PostCardInfo】讀取對應訂單之CheckMacValue。
                    cmvm = await IOR.GetOrderCheckMacValue(model.MerchantTradeNo);
                    if (cmvm != null)
                    {
                        // 5.系統判斷4傳回值!=null。
                        if (cmvm.CheckMacValue != "")
                        {
                            // 6.系統判斷4傳回值之CheckMacValue!=""。
                            // 6-1.系統設定OrderStateId=4。
                            OrderStateId = 4;
                        }
                        else
                        {
                            // 6a.系統判斷4傳回值之CheckMacValue==""。
                            //  6a-1.系統設定OrderStateId=6。
                            OrderStateId = 6;
                            //  6a-2.回7。
                        }
                        // 7.系統變更訂單狀態，並新增一筆會計帳。
                        int r = await IOR.UpdateOrderGreenCard(cmvm.OrderId, OrderStateId, model.TradeDate, model.PaymentType, model.TradeAmt, model.TradeNo, DateTime.Now);
                        if (r == 0)
                        {
                            // 8-1.系統判斷7傳回值=0。
                            // 8-2.系統寄發己付款eMail。
                            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                            mail.To.Add(cmvm.eMail);
                            mail.From = new System.Net.Mail.MailAddress($@"{IEC.SmtpUsername}@{IEC.SmtpServer}");
                            mail.Subject = "288訂購訊息";
                            mail.Body = "您好，\n";
                            mail.Body += $"您在288建立的訂單己付款完成，訂單代碼為{cmvm.OrderId}，<br>";
                            mail.Body += $"若為會員，請至本平台會員中心查詢訂單處理狀態，<br>";
                            mail.Body += $"若非會員，本平台會寄送eMail告知訂單處理狀況，<br>";
                            mail.Body += $"288網址：http://288ibobo.com ，<br>";
                            mail.Body += $"客服專線：04-28825252";
                            mail.Body += $"288應謝您！";
                            mail.IsBodyHtml = true;
                            IES.SendMail(mail);
                            // 9系統回傳"1|OK"。
                            ret = "1|OK";
                        }
                        else if (r == 2)
                        {
                            // 8-1a.系統判斷7傳回值=2。
                            //  8-1a-1.系統設定傳回值=”1|特店訂單編號找不到”
                            ret = "1|特店訂單編號找不到";
                            //  8-1a-2.回10。
                        }
                        else
                        {
                            // 8-1a.系統判斷7傳回值!=0/2。
                            //  8-1a-1.系統設定傳回值=”0|特店系統內部錯誤”
                            ret = "0|特店系統內部錯誤";
                            //  8-1a-2.回10。
                        }
                    }
                    else
                    {
                        // 5a.系統判斷4傳回值==null。
                        //  5a-1.系統設定傳回值=”0|內部錯誤”。
                        ret = $@"0|特店系統內部錯誤";
                        //  5a-2.回10。
                    }
                }
                else
                {
                    // 3a.系統在Action【Paymeent/PostCardInfo】判斷綠界傳送之RtnCode!=1。
                    //  3a-1.系統設定傳回值=”0|RtnMsg”。
                    //ret = $@"0|{model.RtnMsg}";
                    ret = $@"0|{model.RtnMsg}";
                    //  3a-2.回10。
                }
            }
            catch (Exception ex)
            {
                // 8a.系統判斷7執行失敗。
                //  8a-1.系統設定傳回值=”0|特店系統內部錯誤”
                //  8a-2.回10。
                ret = $@"0|特店系統內部錯誤";
            }
            return ret;
        }

        [HttpPost]
        [Route("[action]")]
        // PaymentInfoURL：ATM、CVS的取號結果通知
        public async Task<ActionResult<string>> PostPaymentInfo([FromForm] PaymentInfo model)
        {
            string ret = "1|OK";
            bool suc = true;
            string pay = model.PaymentType.Substring(0, 3);
            switch (pay)
            {
                case "ATM":
                    if (model.RtnCode != 2)
                    {
                        // 3a.系統在Action【Paymeent/PostPaymentInfo】判斷綠界傳送之RtnCode!=2?(ATM)，或是10100073(CVS)。
                        //  3a-1.系統設定傳回值=”0|RtnMsg”。
                        ret = $@"0|{model.RtnMsg}";
                        //  3a-2.回10。
                        suc = false;
                    }
                    break;

                case "CVS":
                    if (model.RtnCode != 10100073)
                    {
                        // 3a.系統在Action【Paymeent/PostPaymentInfo】判斷綠界傳送之RtnCode!=2?(ATM)，或是10100073(CVS)。
                        //  3a-1.系統設定傳回值=”0|RtnMsg”。
                        ret = $@"0|{model.RtnMsg}";
                        //  3a-2.回10。
                        suc = false;
                    }
                    break;

                default:
                    break;
            }
            if (suc)
            {
                CheckMacValueModel cmvm = null;
                byte OrderStateId = 4;
                try
                {
                    // 3.系統在Action【Paymeent/PostPaymentInfo】判斷綠界傳送之RtnCode==2?(ATM)，或是10100073(CVS)。
                    // 4.系統在Action【Paymeent/PostCardInfo】讀取對應訂單之CheckMacValue。
                    cmvm = await IOR.GetOrderCheckMacValue(model.MerchantTradeNo);
                    if (cmvm != null)
                    {
                        // 5.系統判斷4傳回值!=null。
                        if (cmvm.CheckMacValue != "")
                        {
                            // 6.系統判斷4傳回值之CheckMacValue!=""。
                            // 6-1.系統設定OrderStateId=2。
                            OrderStateId = 2;
                        }
                        else
                        {
                            // 6a.系統判斷4傳回值之CheckMacValue==""。
                            //  6a-1.系統設定OrderStateId=6。
                            OrderStateId = 6;
                            //  6a-2.回7。
                        }
                        // 7.系統變更訂單狀態。
                        int r = await IOR.UpdateOrderGreenATMCVS(cmvm.OrderId, OrderStateId, model.TradeDate, model.PaymentType, model.TradeAmt, model.TradeNo, model.BankCode, model.vAccount, model.ExpireDate, model.PaymentNo);
                        if (r == 0)
                        {
                            // 8-1.系統判斷7傳回值=0。
                            // 8-2.系統寄發己付款eMail。
                            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                            mail.To.Add(cmvm.eMail);
                            mail.From = new System.Net.Mail.MailAddress($@"{IEC.SmtpUsername}@{IEC.SmtpServer}");
                            mail.Subject = "288訂購訊息";
                            mail.Body = "您好，\n";
                            mail.Body += $"您在288建立的訂單己付款完成({model.PaymentType})，訂單代碼為{cmvm.OrderId}，<br>";
                            if (pay == "ATM")
                            {
                                mail.Body += $"您的ATM繳款帳號為{model.vAccount}<br>";
                            }
                            else if (pay == "CVS")
                            {
                                mail.Body += $"您的超商繳款代碼為{model.PaymentNo}<br>";
                            }
                            mail.Body += $"若為會員，請至本平台會員中心查詢訂單處理狀態，<br>";
                            mail.Body += $"若非會員，本平台會寄送eMail告知訂單處理狀況，<br>";
                            mail.Body += $"288網址：http://288ibobo.com ，<br>";
                            mail.Body += $"客服專線：04-28825252";
                            mail.Body += $"288應謝您！";
                            mail.IsBodyHtml = true;
                            IES.SendMail(mail);
                            // 9系統回傳"1|OK"。
                            ret = "1|OK";
                        }
                        else if (r == 2)
                        {
                            // 8-1a.系統判斷7傳回值=2。
                            //  8-1a-1.系統設定傳回值=”1|特店訂單編號找不到”
                            ret = "1|特店訂單編號找不到";
                            //  8-1a-2.回10。
                        }
                        else
                        {
                            // 8-1a.系統判斷7傳回值!=0/2。
                            //  8-1a-1.系統設定傳回值=”0|特店系統內部錯誤”
                            ret = "0|特店系統內部錯誤";
                            //  8-1a-2.回10。
                        }
                    }
                    else
                    {
                        // 5a.系統判斷4傳回值==null。
                        //  5a-1.系統設定傳回值=”0|內部錯誤”。
                        ret = $@"0|特店系統內部錯誤";
                        //  5a-2.回10。
                    }
                }
                catch (Exception ex)
                {
                    // 8a.系統判斷7執行失敗。
                    //  8a-1.系統設定傳回值=”0|特店系統內部錯誤”
                    //  8a-2.回10。
                    ret = $@"0|特店系統內部錯誤";
                }
            }
            return ret;
        }
    }
}