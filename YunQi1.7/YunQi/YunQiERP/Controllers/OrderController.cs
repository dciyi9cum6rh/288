using DataModel;
using IRepository;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Utility;
using YunQiERP.Attributes;

namespace YunQiERP.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private IOrderRepository IAR { get; set; }
        private IProductRepository IPR { get; set; }
        private IMemberRepository IMR { get; set; }
        private IEmailService IES { get; set; }
        private IEmailConfiguration IEC { get; set; }
        private IHostingEnvironment _environment { get; set; }

        public OrderController(IConfiguration configuration, IOrderRepository OrderRepository, IProductRepository ProductRepository, IMemberRepository MemberRepository, IEmailService EmailService, IEmailConfiguration EmailConfiguration, IHostingEnvironment environment)
        {
            IAR = OrderRepository;
            IAR.constr = configuration.GetConnectionString("SqlConn");
            IPR = ProductRepository;
            IPR.constr = configuration.GetConnectionString("SqlConn");
            IMR = MemberRepository;
            IMR.constr = configuration.GetConnectionString("SqlConn");
            IES = EmailService;
            IEC = EmailConfiguration;
            _environment = environment;
        }

        // 2.系統導向至Get Action【Order/Index】。
        // 3.系統在Get Action【Order/Index】判斷登入者擁有[銷貨管理](18)之權限。
        [HavePrivilege(18)]
        public async Task<IActionResult> Index()
        {
            // 4-1.系統讀取訂單狀態基本資料。
            List<OrderStateViewModel> model = await IAR.GetOrderState();
            // 5.系統回傳View【Order/Index】。
            return View(model);
        }

        //20181213 ---棋
        //使用者在某項訂單點選取消
        [HttpPost]
        public async Task<int> GetCancelOrderState(string OrderId)
        {
            var ret = 0;
            ret = await IMR.UpdateOrderState(OrderId, 8);
            return ret;
        }

        [HttpPost]
        public IActionResult GetOrderList(DateTime? sDate, DateTime? eDate, string Product = "", string OrderId = "", string MemberMobile = "", byte OrderStateId = 0, int Page = 1, int LinkType = 0, int StartPage = 1, string AClass = "page-link")
        {
            // 9.系統在Get Action【Order/GetOrderList】呼叫ViewComponent【OrderListViewComponent】，並傳送jOrderId/jsDate/jeDate/jMemberMobile/jOrderStateId與1點按頁碼。
            return ViewComponent("OrderList", new { sDate = sDate, eDate = eDate, Product = Product, OrderId = OrderId, MemberMobile = MemberMobile, OrderStateId = OrderStateId, Page = Page, LinkType = LinkType, StartPage = StartPage, aclass = AClass });
        }

        [HttpPost]
        public IActionResult GetOrderDetailList(string OrderId, int Page = 1, int LinkType = 0, int StartPage = 1, string AClass = "inner-page-link")
        {
            // 9.系統在Controller Action【Order/GetOrderDetailList】，呼叫ViewComponent【OrderDetailList】，並傳送3傳送之jOrderId。
            return ViewComponent("OrderDetailList", new { OrderId = OrderId, Page = Page, LinkType = LinkType, StartPage = StartPage, aclass = AClass });
        }

        [HttpPost]
        public IActionResult GetOrderDetailListNoButton(string OrderId, int Page = 1, int LinkType = 0, int StartPage = 1, string AClass = "inner-page-link")
        {
            // 9.系統在Controller Action【Order/GetOrderDetailListNoButton】，呼叫ViewComponent【OrderDetailListNoButton】，並傳送3傳送之jOrderId。
            return ViewComponent("OrderDetailListNoButton", new { OrderId = OrderId, Page = Page, LinkType = LinkType, StartPage = StartPage, aclass = AClass });
        }

        [HttpPost]
        public async Task<IActionResult> GetOrderState()
        {
            // 1-2.系統在Get Action[Order/GetOrderState]讀取訂單狀態。
            List<OrderStateViewModel> lCVM = await IAR.GetOrderState();
            // 1-3.系統回傳Json(1-2讀取值)。
            return Json(lCVM);
        }

        // 7.系統在Post Action【Order/UpdateOrderState】驗証使用者有[銷貨管理](18)權限。
        [HaveRightint1(18)]
        [HttpPost]
        // 8.系統接收6上傳資料。
        public async Task<int> UpdateOrderState(string OrderId, byte OrderStateId, string MemberMobile)
        {
            int ret = 1;  // 12.系統回傳0。
            try
            {
                // 9.系統更新一筆銷貨單狀態。
                ret = await IMR.UpdateOrderState(OrderId, OrderStateId);
                if (OrderStateId == 4)
                {
                    // 9-1.系統判斷OrderStateId==4(己付款)。
                    // 9-2.系統在Action【Member/Personaldata】中讀取會員基本資料。
                    MemberViewModel mvm = await IMR.GetMember(MemberMobile);
                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                    mail.To.Add(mvm.eMail);
                    mail.From = new System.Net.Mail.MailAddress($@"{IEC.SmtpUsername}@{IEC.SmtpServer}");
                    mail.Subject = "288訂購訊息";
                    mail.Body = "您好，\n";
                    mail.Body += $"您在288建立的訂單己確認付款完成，訂單代碼為{OrderId}，<br>";
                    mail.Body += $"若為會員，請至本平台會員中心查詢訂單處理狀態，<br>";
                    mail.Body += $"若非會員，本平台會寄送eMail告知訂單處理狀況，<br>";
                    mail.Body += $"288網址：http://288ibobo.com，/<br>";
                    mail.Body += $"客服專線：04-24260263";
                    mail.Body += $"288應謝您！";
                    mail.IsBodyHtml = true;
                    IES.SendMail(mail);
                }
                // 9-1a.系統判斷OrderStateId!=4(己付款)。
                //  9-1a-1.回10。
                // 10.系統判斷9成功執行。
                // 11.系統回傳9傳回值。
            }
            catch (Exception ex)
            {
                // 10.系統判斷9執行時發生例外。
                //  10a-1.系統回傳3。
                ret = 3;
            }
            return ret;
        }

        [HttpPost]
        public async Task<IActionResult> GetOrderData(string OrderId)
        {
            // 1-2.系統在Get Action[Order/GetOrderData]讀取訂單基本資料。
            OrderListViewModel olvm = await IAR.GetOrderData(OrderId);
            // 1-3.系統在Get Action[Order/GetOrderData]讀取讀取訂單明細。
            List<CartListViewModel> lstCLVM = await IAR.GetOrderDetail(OrderId);
            // 1-4.系統回傳Json( new {Order=1-2讀取值,OrderDetail=1-3讀取值})。
            return Json(new { Order = olvm, OrderDetail = lstCLVM });
        }

        // 7.系統在Post Action【Order/PostShipment】驗証使用者有[銷貨管理](18)權限。
        [HaveRightint1(18)]
        [HttpPost]
        // 8.系統接收6上傳資料。
        public int PostShipment(string OrderId, string MemberName, string ContactAddress, string MemberMobile, string Nnuber, string Weight, string Quantity,
            string Station, string MemberId, string ProductNo, string Product, string Phone, string Postal, string PaymentType, string InsteadReceive, bool ClearOld, string Memo)
        {
            int ret = 0;  // 12.系統回傳0。
            string DirPath = "", filePaths = "", filePatht = "";
            string ShipmentId = "";
            int AddRow = 0;
            string pdfFile = "";
            DirPath = Path.Combine(_environment.WebRootPath, @"xlsx");
            DirectoryInfo DirPathPdf = new DirectoryInfo(Path.Combine(_environment.WebRootPath, @"xlsx"));
            try
            {
                // 9.系統判斷4輸入之[滙出前清除舊出貨資料]=true。
                if (ClearOld)
                {
                    // 10.系統將xlsx資料夾中的[出貨資料匯入檔_原始.xlsx]複製為[出貨資料匯入檔.xlsx]。
                    filePaths = Path.Combine(DirPath, "出貨資料匯入檔_原始.xlsx");
                    filePatht = Path.Combine(DirPath, "出貨資料匯入檔.xlsx");
                    System.IO.File.Copy(filePaths, filePatht, true);
                    List<FileInfo> fis = DirPathPdf.GetFiles().Where(m => (m.Name.Contains(".pdf"))).ToList();
                    foreach (FileInfo item in fis)
                    {
                        item.Delete();
                    }
                }
                // 11.系統讀取當日最後一筆出貨單號。
                DateTime ShipmemtTime = DateTime.Now;
                ShipmentIdViewModel svm = IAR.SyncGetNewShipmentId(ShipmemtTime);
                if (svm != null)
                {
                    // 12.系統判斷11傳回值!=null。
                    // 13.系統設定ShipmentId = 年月日 +< 8讀取值最後4碼加1 >。
                    ShipmentId = Data.GetNewId(svm.ShipmentId, 9, 4);
                }
                else
                {
                    // 12a.系統判斷11傳回值==null。
                    //  12a-1.系統設定Shipmentd=年月日+<0201>。
                    //  12a-2.回14。
                    ShipmentId = Data.GetStartId("S", ShipmemtTime);
                }

                //20190103 ---棋
                using (TransactionScope scope = new TransactionScope())
                {
                    // 14.系統新增一筆出貨單。
                    //t_Shipment
                    ret = IAR.SyncInsertShipMent(ShipmentId, MemberName, ContactAddress, MemberMobile, Nnuber, Weight, Quantity, Station, MemberId, ProductNo, Product, Phone, Postal, PaymentType, InsteadReceive, Memo, ShipmemtTime, OrderId);
                    if (ret == 6)
                    {
                        // 14-1a.系統判斷14傳回值==6。
                        //  14-1a-1.系統設定ret=2(訂單己出貨)。
                        return 6;
                        //  14-1a-2.回21。
                    }
                    else if (ret != 0)
                    {
                        // 14-1a.系統判斷14傳回值!=0。
                        //  14-1a-1.系統設定ret=2(新增出貨單失敗)。
                        return 2;
                        //  14-1a-2.回21。
                    }
                    // 14-1.系統判斷14傳回值==0。
                    // 15.系統變更訂單狀態。
                    // SELECT TOP(1) [OrderId],[OrderTime],[OrderStateId]FROM [CartCRMERP].[dbo].[t_Order]where OrderId = 'B201901030215'
                    ret = IMR.SyncUpdateOrderState(OrderId, 5);
                    if (ret != 0)
                    {
                        // 15-1a.系統判斷15傳回值!=0。
                        //15-1a-1.系統設定ret=3(更新訂單狀態失敗)。
                        return 3;
                    }
                    // 15-1.系統判斷15傳回值==0。
                    //// 16.系統讀取訂單明細。
                    //List<CartListViewModel> lstCLVM = await IAR.GetOrderDetail(OrderId);
                    //// 17.系統更新商品庫存。
                    //ret = await IAR.UpdateProductStock(lstCLVM);
                    //if(ret!=0)
                    //{
                    //    // 17-1a.系統判斷1傳回值!=0。
                    //    //  17-1a-1.系統設定ret=4(更新商品庫存失敗)。
                    //    return 4;
                    //    //  17-1a-2.回21。
                    //}
                    // 17-1.系統判斷17傳回值==0。
                    // 18.系統判斷14~17成功執行。
                    // 19.系統讀取訂單基本資料。
                    OrderListViewModel OLVM = IAR.SyncGetOrderData(OrderId);
                    // 20.系統依19讀取資料發送eMail。
                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                    mail.To.Add(OLVM.eMail);
                    mail.From = new System.Net.Mail.MailAddress($@"{IEC.SmtpUsername}@{IEC.SmtpServer}");
                    mail.Subject = "288訂購訊息";
                    mail.Body = "您好，\n";
                    mail.Body += $"您在288建立的訂單己進行出貨作業，訂單代碼為{OrderId}，<br>";
                    
                    mail.Body += $"288網址：http://288ibobo.com，<br>";
                    mail.Body += $"客服專線：04-24260263 <br>";
                    mail.Body += $"288應謝您！";
                    mail.IsBodyHtml = true;

                    // 20-1.系統將出貨資料填入出貨資料匯入檔.xlsx。
                    filePaths = Path.Combine(DirPath, "出貨資料匯入檔.xlsx");
                    filePatht = Path.Combine(DirPath, "出貨資料匯入檔_Backup.xlsx");
                    System.IO.File.Copy(filePaths, filePatht, true);
                    using (FileStream fsr = new FileStream(filePatht, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                    {
                        // 載入Excel檔案
                        //int currentRow = 0;
                        using (ExcelPackage epr = new ExcelPackage(fsr))
                        {
                            ExcelWorksheet sheet1 = epr.Workbook.Worksheets[1]; //取得Sheet1
                            int startRowNumber = sheet1.Dimension.Start.Row + 1; //起始列編號，從1算起
                            int endRowNumber = sheet1.Dimension.End.Row; //結束列編號，從1算起
                            //int startColumn = sheet1.Dimension.Start.Column; //開始欄編號，從1算起
                            //int endColumn = sheet1.Dimension.End.Column; //結束欄編號，從1算起
                            AddRow = endRowNumber + 1;
                            //for (currentRow = startRowNumber; currentRow <= endRowNumber; currentRow++)
                            //{
                            //    if (string.IsNullOrEmpty(sheet1.Cells[currentRow, 1].Text))
                            //    {
                            //        break;  // 空白列跳出，以填入新出貨資料
                            //    }
                            //}
                            // 填入新出貨資料至空白列
                            sheet1.Cells[AddRow, 1].Value = "艾寶寶網購暢貨中心";
                            sheet1.Cells[AddRow, 2].Value = MemberName;
                            sheet1.Cells[AddRow, 3].Value = ContactAddress;
                            sheet1.Cells[AddRow, 4].Value = MemberMobile;
                            sheet1.Cells[AddRow, 5].Value = Nnuber;
                            sheet1.Cells[AddRow, 6].Value = Weight;
                            sheet1.Cells[AddRow, 7].Value = Quantity;
                            sheet1.Cells[AddRow, 8].Value = Station;
                            sheet1.Cells[AddRow, 9].Value = ShipmentId;
                            sheet1.Cells[AddRow, 10].Value = MemberId;
                            sheet1.Cells[AddRow, 11].Value = ProductNo;
                            sheet1.Cells[AddRow, 12].Value = Product;
                            sheet1.Cells[AddRow, 12].Style.WrapText = true;
                            sheet1.Cells[AddRow, 13].Value = Phone;
                            sheet1.Cells[AddRow, 14].Value = Postal;
                            sheet1.Cells[AddRow, 15].Value = PaymentType;
                            sheet1.Cells[AddRow, 16].Value = InsteadReceive;
                            sheet1.Cells[AddRow, 17].Value = Memo;
                            sheet1.Cells[AddRow, 17].Style.WrapText = true;
                            using (FileStream createStream = new FileStream(filePaths, FileMode.Create, FileAccess.Write))
                            {
                                epr.SaveAs(createStream);//存檔
                            }
                        }
                    }
                    // 20-2.系統將出貨資料填入[出貨單號.pdf]。
                    Document document = new Document(PageSize.A5.Rotate(), 20, 20, 20, 20);
                    pdfFile = Path.Combine(DirPath, $@"{ShipmentId}.pdf");
                    PdfWriter PDFWriter = PdfWriter.GetInstance(document, new FileStream(pdfFile, FileMode.Create));
                    PDFWriter.ViewerPreferences = PdfWriter.PageModeUseOutlines;
                    // Our custom Header and Footer is done using Event Handler
                    //TwoColumnHeaderFooter PageEventHandler = new TwoColumnHeaderFooter();
                    //PDFWriter.PageEvent = PageEventHandler;
                    // Define the page header
                    //PageEventHandler.Title = Title;
                    //PageEventHandler.FooterFont = FontFactory.GetFont(BaseFont.COURIER_BOLD, 10, iTextSharp.text.Font.BOLD);
                    //PageEventHandler.HeaderLeft = "Group";
                    //PageEventHandler.HeaderRight = "1";
                    document.Open();
                    // 設定字型
                    string ttfFile = Path.Combine(DirPath, $@"kaiu.ttf");
                    BaseFont bf = BaseFont.CreateFont(ttfFile, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                    Font fn_big = new Font(bf, 24, Font.NORMAL, Color.BLACK);
                    Font fn_mid = new Font(bf, 16, Font.NORMAL, Color.BLACK);
                    Font fn_small = new Font(bf, 14, Font.NORMAL, Color.BLACK);
                    // 間隔
                    Chunk c_SpaseLine = new Chunk("    ");
                    Paragraph p_SpaseLine = new Paragraph();
                    p_SpaseLine.Add(c_SpaseLine);
                    // 標題
                    Chunk c_Header = new Chunk("允奇國際行銷有限公司 出貨單", fn_big);
                    Paragraph p_Header = new Paragraph();
                    p_Header.Alignment = Element.ALIGN_CENTER;
                    p_Header.Add(c_Header);
                    document.Add(p_Header);
                    document.Add(p_SpaseLine);
                    // 公司資料
                    Paragraph p_Header_Table = new Paragraph();
                    p_Header_Table.IndentationLeft = -30;
                    p_Header_Table.IndentationRight = -30;
                    PdfPTable table = new PdfPTable(new float[] { 3f, 2f });
                    table.DefaultCell.Border = PdfPCell.NO_BORDER;
                    table.DefaultCell.VerticalAlignment = Element.ALIGN_LEFT;
                    table.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    PdfPCell pc;
                    // 日期
                    pc = new PdfPCell(new Paragraph($@"日期：{ShipmemtTime.Year}年{ShipmemtTime.Month}月{ShipmemtTime.Day}日", fn_small));
                    pc.Border = PdfPCell.NO_BORDER;
                    //pc.HorizontalAlignment = Element.ALIGN_LEFT;
                    table.AddCell(pc);
                    // 電話
                    pc = new PdfPCell(new Paragraph("TEL：+884-4-24260263", fn_small));
                    pc.Border = PdfPCell.NO_BORDER;
                    //pc.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table.AddCell(pc);
                    // 地址
                    pc = new PdfPCell(new Paragraph("地址：台中市北屯區經貿五路66號6樓", fn_small));
                    pc.Border = PdfPCell.NO_BORDER;
                    //pc.HorizontalAlignment = Element.ALIGN_LEFT;
                    table.AddCell(pc);
                    // 統一編號
                    pc = new PdfPCell(new Paragraph("統一編號：63177906", fn_small));
                    pc.Border = PdfPCell.NO_BORDER;
                    //pc.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table.AddCell(pc);
                    // 網址
                    pc = new PdfPCell(new Paragraph("網址：http://288ibobo.com", fn_small));
                    pc.Border = PdfPCell.NO_BORDER;
                    //pc.HorizontalAlignment = Element.ALIGN_LEFT;
                    table.AddCell(pc);
                    // eMail
                    pc = new PdfPCell(new Paragraph("eMail：288ibobo@gmail.com", fn_small));
                    pc.Border = PdfPCell.NO_BORDER;
                    //pc.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table.AddCell(pc);
                    p_Header_Table.Add(table);
                    document.Add(p_Header_Table);
                    //////// 進貨明細表格 ////////
                    document.Add(p_SpaseLine);
                    Paragraph p_Table = new Paragraph();
                    p_Table.IndentationLeft = -30;
                    p_Table.IndentationRight = -30;
                    PdfPTable ptable = new PdfPTable(new float[] { 3f, 2f });
                    ptable.DefaultCell.VerticalAlignment = Element.ALIGN_LEFT;
                    ptable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    // 收件人
                    pc = new PdfPCell(new Paragraph($@"收件人：{MemberName}", fn_mid));
                    pc.FixedHeight = 25f;
                    ptable.AddCell(pc);
                    // 電話
                    pc = new PdfPCell(new Paragraph($@"電話號碼：{MemberMobile}", fn_mid));
                    pc.FixedHeight = 25f;
                    ptable.AddCell(pc);
                    // 地址
                    pc = new PdfPCell(new Paragraph($@"送貨地址：{ContactAddress}", fn_mid));
                    pc.FixedHeight = 25f;
                    ptable.AddCell(pc);
                    // 統一編號=>暫不顯示
                    pc = new PdfPCell(new Paragraph($@"統一編號：", fn_mid));
                    pc.FixedHeight = 25f;
                    ptable.AddCell(pc);
                    // 出貨明細
                    // 標題
                    pc = new PdfPCell(new Paragraph($@"出貨明細", fn_mid));
                    pc.Colspan = 2;
                    pc.HorizontalAlignment = Element.ALIGN_CENTER;
                    pc.FixedHeight = 25f;
                    ptable.AddCell(pc);
                    // 明細
                    StringBuilder sb = new StringBuilder();
                    int subtotal = 0;
                    List<CartListViewModel> lstCLVM = IAR.SyncGetOrderDetail(OrderId);
                    foreach (var item in lstCLVM)
                    {
                        sb.Append($@"{item.Product}/{item.ProductSize}/{item.ProductColor}X{item.Quantity}={item.SubTotal};");
                        subtotal += item.SubTotal;
                    }
                    pc = new PdfPCell(new Paragraph(sb.ToString(), fn_mid));
                    pc.Colspan = 2;
                    //pc.FixedHeight = 125f;
                    ptable.AddCell(pc);
                    // 備註
                    pc = new PdfPCell(new Paragraph(Memo, fn_mid));
                    pc.Rowspan = 2;
                    ptable.AddCell(pc);
                    // 合計
                    pc = new PdfPCell(new Paragraph($@"合計：{subtotal:#,###}", fn_mid));
                    pc.FixedHeight = 23f;
                    ptable.AddCell(pc);
                    // 總計
                    pc = new PdfPCell(new Paragraph($@"總計(含運)：{OLVM.TotalExpense:#,###}", fn_mid));
                    pc.FixedHeight = 23f;
                    ptable.AddCell(pc);
                    //////// 表尾列 ////////
                    // 存根
                    pc = new PdfPCell(new Paragraph("第一聯：存根(白)  第二聯：客戶(藍)", fn_mid));
                    pc.FixedHeight = 23f;
                    pc.Border = PdfPCell.NO_BORDER;
                    //pc.HorizontalAlignment = Element.ALIGN_LEFT;
                    ptable.AddCell(pc);
                    // 包裝
                    pc = new PdfPCell(new Paragraph("包裝：", fn_mid));
                    pc.FixedHeight = 23f;
                    pc.Border = PdfPCell.NO_BORDER;
                    pc.HorizontalAlignment = Element.ALIGN_LEFT;
                    ptable.AddCell(pc);

                    // 如果所有的操作都執行成功，則Complete()會被呼叫來提交事務
                    // 如果發生異常，則不會呼叫它並回滾事務
                    scope.Complete();

                    //20190104 ---棋

                    //新增資料進Excel檔案??
                    //刪除保留的備份檔
                    System.IO.File.Delete(filePatht);

                    //新增寫入PDF檔
                    p_Table.Add(ptable);
                    document.Add(p_Table);
                    document.Close();

                    //將訂購訊息已Mail寄出
                    IES.SendMail(mail);
                }
            }
            catch (Exception ex)
            {
                //20190104 ---棋
                //刪除Excel資料
                System.IO.File.Copy(filePaths, filePatht, true);
                using (FileStream fsr = new FileStream(filePatht, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    // 載入Excel檔案
                    using (ExcelPackage epr = new ExcelPackage(fsr))
                    {
                        ExcelWorksheet sheet = epr.Workbook.Worksheets[1]; //取得Sheet1
                        int startRowNumber = sheet.Dimension.Start.Row + 1; //起始列編號，從1算起
                        int startColumn = sheet.Dimension.Start.Column; //開始欄編號，從1算起
                        int endColumn = sheet.Dimension.End.Column; //結束欄編號，從1算起
                        string newShipmentId = sheet.Cells[AddRow, 9].Value.ToString();
                        if (newShipmentId == ShipmentId)
                        {
                            sheet.DeleteRow(AddRow);
                            using (FileStream createStream = new FileStream(filePaths, FileMode.Create, FileAccess.Write))
                            {
                                epr.SaveAs(createStream);//存檔
                            }
                        }
                    }
                }
                System.IO.File.Delete(filePatht);

                //刪除PDF檔
                System.IO.File.Delete(pdfFile);

                //https://tw.saowen.com/a/a9b2952ebcf11777eb40dc03515b84bac8223ac80d3db81c216d27da931b6f35
                string msg = ex.Message;
                // 18a.系統判斷14~17執行時發生例外。
                //  18a-1.系統設定ret=5(系統執行錯誤)。
                //  18a-2.回21。
                ret = 5;
            }

            // 21.系統回傳ret。
            return ret;
        }
    }
}