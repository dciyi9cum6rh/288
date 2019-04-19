using DataModel;
using IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace YunQiWholesale.Controllers
{
    public class LostPasswordController : Controller
    {
        private IMemberRepository IMR { get; set; }
        private IEmailService IES { get; set; }
        private IEmailConfiguration IEC { get; set; }

        public LostPasswordController(IConfiguration configuration, IMemberRepository MemberRepository, IEmailService EmailService, IEmailConfiguration EmailConfiguration)
        {
            IMR = MemberRepository;
            IES = EmailService;
            IEC = EmailConfiguration;
            IMR.constr = configuration.GetConnectionString("SqlConn");
        }

        //20181207 ---棋
        //使用者點擊 信件中網址 進到變更密碼首頁
        [HttpGet]
        public async Task<IActionResult> Index(string MemberMobile, long token)
        {
            //判斷使用者網址參數是否正確
            if (MemberMobile.Length != 10 || token.ToString().Length != 19) { return RedirectToAction("Index", "Home"); }
            return View();
        }

        //20181207 ---棋
        //使用者在Login 輸入帳號 點擊 忘記密碼
        [HttpPost]
        public async Task<int> MemberForget(string MemberMobile, long token)
        {
            int ret = 0;
            //在資料表產生一筆紀錄
            ret = await IMR.MemberForget(MemberMobile, token);
            return ret;
        }

        //使用者按下忘記密碼
        [HttpPost]
        public async Task<int> InsertMemberForget(string MemberMobile)
        {
            int ret = 0;
            //產生NewGuid
            var token = Utility.Data.IntGuid();

            ret = await IMR.InsertMemberForget(MemberMobile, token);

            //取得 MemberEmail
            MemberViewModel MemberList = await IMR.GetMember(MemberMobile);
            //此帳號沒有email
            if (MemberList.eMail == null || MemberList.eMail == "") ret = -1;

            if (ret == 0)
            {
                //產生Email
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.To.Add(MemberList.eMail);
                mail.From = new System.Net.Mail.MailAddress($@"{IEC.SmtpUsername}@{IEC.SmtpServer}");
                mail.Subject = "更改密碼";
                mail.Body = "您好，\n <br>";
                mail.Body += $"最近有人要求更改您的帳戶密碼。<br>";
                mail.Body += $"如果是您提出的請求，您可以從這裡設定新密碼：<br>";
                mail.Body += $"網址: http://288ibobo.com/LostPassword?MemberMobile=" + MemberMobile + "&token=" + token + "<br>";
                mail.Body += $"若您不想變更密碼，或是您沒有提出此要求，請忽略並刪除此訊息。<br>";
                mail.Body += $"為確保您的帳戶安全無虞，請不要轉寄這封電子郵件。 請參訪說明中心，瞭解更多。<br>";
                mail.Body += $"使用愉快！<br>";
                mail.IsBodyHtml = true;
                IES.SendMail(mail);

                return ret;
            }
            return ret;
        }

        //20181207 ---棋
        //使用者從url 進來重設密碼
        [HttpPost]
        public async Task<int> UpdateMemberPassword(string MemberMobile, string MemberPassword, string DoubleCheckPassword, long token)
        {
            var ret = 0;
            if (MemberPassword != DoubleCheckPassword) ret = -1;
            ret = await IMR.UpdateMemberPassword(MemberMobile, Utility.Data.HashPassword(MemberPassword), token);
            return ret;
        }
    }
}
